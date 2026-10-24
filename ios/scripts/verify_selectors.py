import re, sys, collections, json
ast_path, *cs_paths = sys.argv[1:]

# ---- parse clang AST dump
classes = collections.defaultdict(lambda: {'super': None, 'protos': set(), 'inst': set(), 'cls': set()})
protos = collections.defaultdict(lambda: {'protos': set(), 'inst': set(), 'cls': set()})
cur = None
line_re = re.compile(r'^((?:[| `] )*)[|`]-(\S+)(.*)$')
for raw in open(ast_path, errors='replace'):
    m = line_re.match(raw.rstrip('\n'))
    if not m: continue
    depth = len(m.group(1)) // 2
    kind, rest = m.group(2), m.group(3)
    if depth == 0:
        cur = None
        if kind == 'ObjCInterfaceDecl':
            name = rest.split()[-1]; cur = ('C', name); classes[name]
        elif kind == 'ObjCProtocolDecl':
            name = rest.split()[-1]; cur = ('P', name); protos[name]
        elif kind == 'ObjCCategoryDecl':
            cur = ('CAT', None)
        continue
    if cur is None or depth != 1: continue
    if cur[0] == 'CAT' and kind == 'ObjCInterface':
        cur = ('C', re.search(r"'(\w+)'", rest).group(1)); classes[cur[1]]; continue
    tgt = classes[cur[1]] if cur[0] == 'C' else protos.get(cur[1]) if cur[0]=='P' else None
    if tgt is None: continue
    if kind == 'super':
        tgt['super'] = re.search(r"'(\w+)'", rest).group(1)
    elif kind == 'ObjCProtocol':
        tgt['protos'].add(re.search(r"'(\w+)'", rest).group(1))
    elif kind == 'ObjCMethodDecl':
        mm = re.search(r' ([-+]) (\S+) \'', rest)
        if mm: tgt['inst' if mm.group(1) == '-' else 'cls'].add(mm.group(2))
    elif kind == 'ObjCPropertyDecl':
        mm = re.search(r"col:\d+ (\w+) '", rest)
        if not mm: continue
        name = mm.group(1); attrs = rest.split("'")[-1]
        isclass = ' class' in attrs
        bucket = tgt['cls' if isclass else 'inst']
        g = re.search(r'getter=?(\w+)', attrs)
        bucket.add(name)
        if 'readonly' not in attrs:
            bucket.add('set' + name[0].upper() + name[1:] + ':')

def proto_sels(p, static, seen=None):
    seen = seen or set()
    if p in seen or p not in protos: return set()
    seen.add(p); d = protos[p]
    s = set(d['cls' if static else 'inst'])
    for q in d['protos']: s |= proto_sels(q, static, seen)
    return s

def class_sels(c, static):
    s = set(); seen = set()
    while c and c in classes and c not in seen:
        seen.add(c); d = classes[c]
        s |= d['cls' if static else 'inst']
        for p in d['protos']: s |= proto_sels(p, static)
        if static:  # class methods may call NSObject instance methods on the metaclass
            pass
        c = d['super']
    return s

def demangle(n):
    m = re.match(r'^_Tt[CP](\d+)(\w+)$', n)
    if not m: return n
    rest = n[len('_TtC'):]
    parts = []
    while rest and rest[0].isdigit():
        k = re.match(r'(\d+)', rest).group(1); l = int(k)
        parts.append(rest[len(k):len(k)+l]); rest = rest[len(k)+l:]
    return parts[-1] if parts else n

# ---- parse C# ApiDefinitions
report = []
known_ifaces = {}
checked = collections.Counter()
for cs in cs_paths:
    lines = open(cs).read().split('\n')
    attrs = []; iface = None; iface_static = False; brace = 0
    pending = []
    for i, line in enumerate(lines):
        s = line.strip()
        if s.startswith('//') or not s: continue
        im = re.match(r'(?:partial\s+)?interface\s+(\w+)', s)
        if im:
            a = ' '.join(attrs)
            name = im.group(1); kind = 'C'; objc = name
            if re.search(r'\bProtocol\b', a): kind = 'P'
            nm = re.search(r'Name\s*=\s*"([^"]+)"', a)
            if nm: objc = demangle(nm.group(1))
            if re.search(r'\bCategory\b', a):
                bt = re.search(r'BaseType\s*\(\s*typeof\s*\(\s*([\w.]+)\s*\)', a)
                objc = bt.group(1).split('.')[-1]; kind = 'C'
            if kind == 'C' and not re.search(r'BaseType', a) and not re.search(r'\bProtocol\b', a):
                iface = known_ifaces.get(name)  # partial interface continuing an earlier one
            else:
                iface = (kind, objc, name); known_ifaces[name] = iface
            iface_static = bool(re.search(r'(^|[\[ ,])Static\b', a))
            attrs = []; continue
        if s.startswith('['):
            attrs.append(s); continue
        if not iface and attrs and re.search(r'Export\s*\(', ' '.join(attrs)):
            print('SKIPPED', cs.split('/')[-2], i+1, file=sys.stderr)
        if iface and attrs:
            a = ' '.join(attrs)
            em = re.search(r'Export\s*\(\s*"([^"]+)"', a)
            if em and 'Wrap' not in a:
                sel = em.group(1)
                static = iface_static or bool(re.search(r'(^|[\[ ,])Static\b', a))
                isprop = '{' in s and 'get' in s
                hasset = isprop and re.search(r'\bset\s*;', s)
                if isprop:
                    # property export may also carry its own getter name; setter
                    sels = [sel]
                    if hasset and not re.search(r'Bind\s*\(', a):
                        base = sel[:-1] if sel.endswith(':') else sel
                        if base.startswith('is') and re.search(r'\bis[A-Z]', base):
                            pass
                        sels.append('set' + base[0].upper() + base[1:] + ':')
                else:
                    sels = [sel]
                kind, objc, name = iface
                avail = (class_sels(objc, static) if kind == 'C' else proto_sels(objc, static))
                known = (objc in classes and (classes[objc]['inst'] or classes[objc]['cls'] or classes[objc]['super'])) if kind=='C' else objc in protos
                for x in sels:
                    checked[cs.split('/')[-2]] += 1
                    if not known:
                        report.append((cs, i+1, name, objc, x, static, 'TYPE-MISSING'))
                    elif x not in avail:
                        # a setter for a readonly-in-header property is its own category
                        report.append((cs, i+1, name, objc, x, static, 'SEL-MISSING'))
        attrs = []
print(dict(checked), file=sys.stderr)
print('classes', len(classes), 'protos', len(protos), file=sys.stderr)
for r in report:
    print('\t'.join(map(str, r)))
