import re, sys
ast, *cs_files = sys.argv[1:]
line_re = re.compile(r'^((?:[| `] )*)[|`]-(\S+)(.*)$')
enums = {}; cur=None; last=None; pending=None
for raw in open(ast, errors='replace'):
    m = line_re.match(raw.rstrip('\n'))
    if not m: continue
    depth = len(m.group(1))//2; kind, rest = m.group(2), m.group(3)
    if depth == 0:
        cur=None
        if kind == 'EnumDecl':
            nm = re.search(r" (\w+) '", rest) or re.search(r" (\w+)$", rest.strip())
            name = nm.group(1) if nm else None
            if name: cur = enums.setdefault(name, {}); last=-1
        elif kind == 'TypedefDecl' and pending is not None:
            pass
        continue
    if cur is None: continue
    if depth == 1 and kind == 'EnumConstantDecl':
        name = re.search(r" (?:referenced )?(\w+) '", rest).group(1)
        last = last + 1; cur[name] = last; curconst = name; gotval = False
    elif depth >= 2 and cur is not None and kind == 'value:' and rest.startswith(' Int'):
        v = int(rest.split()[1])
        # first value child after constant decl
        if not gotval:
            cur[curconst] = v; last = v; gotval = True
issues = 0
for cs in cs_files:
    src = open(cs).read()
    src = re.sub(r'/\*.*?\*/', '', src, flags=re.S)
    src = re.sub(r'//[^\n]*', '', src)
    for em in re.finditer(r'enum\s+(\w+)\s*(?::\s*\w+)?\s*\{(.*?)\}', src, re.S):
        name, body = em.group(1), em.group(2)
        native = enums.get(name)
        if native is None:
            print(f'{cs.split("/")[-2]}: enum {name}: NO NATIVE ENUM'); issues+=1; continue
        val = -1
        members = [x.strip() for x in body.split(',') if x.strip()]
        for mem in members:
            mem = re.sub(r'\[[^\]]*\]', '', mem).strip()
            mm = re.match(r'(\w+)\s*(?:=\s*(.+))?$', mem)
            if not mm: continue
            mname, mval = mm.group(1), mm.group(2)
            if mval is not None:
                try: val = int(eval(mval.replace('L','').replace('u','').replace('U','')))
                except Exception: print('cannot eval', name, mem); continue
            else: val += 1
            cands = [k for k in native if k == name + mname] or [k for k in native if k.endswith(mname) and k.startswith(name)]
            if not cands:
                cands = [k for k in native if k.lower().endswith(mname.lower())]
            if not cands:
                print(f'{cs.split("/")[-2]}: {name}.{mname}={val}: MISSING natively'); issues+=1
            elif native[cands[0]] != val:
                print(f'{cs.split("/")[-2]}: {name}.{mname}: C#={val} native={native[cands[0]]} ({cands[0]})'); issues+=1
        # native members not in C#
        cs_names = {re.match(r'(\w+)', re.sub(r'\[[^\]]*\]','',x).strip()).group(1) for x in members if re.match(r'(\w+)', re.sub(r'\[[^\]]*\]','',x).strip())}
        for k,v in native.items():
            short = k[len(name):] if k.startswith(name) else k
            if short not in cs_names and not any(k.lower().endswith(c.lower()) for c in cs_names):
                print(f'{cs.split("/")[-2]}: {name}: native {k}={v} not bound')
print('issues', issues, 'native enums', len(enums), file=sys.stderr)
