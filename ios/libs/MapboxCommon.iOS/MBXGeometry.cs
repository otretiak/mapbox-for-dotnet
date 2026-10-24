using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace MapboxCommon
{
    public partial class MBXGeometry
    {
        const string LibObjC = "/usr/lib/libobjc.dylib";

        [LibraryImport(LibObjC, EntryPoint = "objc_msgSend")]
        private static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector);

        [LibraryImport(LibObjC, EntryPoint = "objc_msgSend")]
        private static partial IntPtr IntPtr_objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);

        static MBXGeometry Create(string initSelector, NSObject argument)
        {
            ArgumentNullException.ThrowIfNull(argument);
            var allocated = IntPtr_objc_msgSend(Class.GetHandle("MBXGeometry"), Selector.GetHandle("alloc"));
            var handle = IntPtr_objc_msgSend_IntPtr(allocated, Selector.GetHandle(initSelector), argument.Handle);
            GC.KeepAlive(argument);
            return Runtime.GetNSObject<MBXGeometry>(handle, true)!;
        }

        // -(instancetype _Nonnull)initWithPolygon:(NSArray<NSArray<NSValue *> *> * _Nonnull)locations;
        public static MBXGeometry FromPolygon(NSArray locations) => Create("initWithPolygon:", locations);

        // -(instancetype _Nonnull)initWithMultiPoint:(NSArray<NSValue *> * _Nonnull)locations;
        public static MBXGeometry FromMultiPoint(NSValue[] locations) => Create("initWithMultiPoint:", NSArray.FromNSObjects(locations));

        // -(instancetype _Nonnull)initWithMultiLine:(NSArray<NSArray<NSValue *> *> * _Nonnull)locations;
        public static MBXGeometry FromMultiLine(NSArray locations) => Create("initWithMultiLine:", locations);

        // -(instancetype _Nonnull)initWithMultiPolygon:(NSArray<NSArray<NSArray<NSValue *> *> *> * _Nonnull)locations;
        public static MBXGeometry FromMultiPolygon(NSArray locations) => Create("initWithMultiPolygon:", locations);

        // -(instancetype _Nonnull)initWithGeometryCollection:(NSArray<MBXGeometry *> * _Nonnull)geometries;
        public static MBXGeometry FromGeometryCollection(MBXGeometry[] geometries) => Create("initWithGeometryCollection:", NSArray.FromNSObjects(geometries));
    }
}
