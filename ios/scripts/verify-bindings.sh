#!/bin/zsh
# Verifies every [Export] selector and every enum value in the iOS ApiDefinitions/StructsAndEnums
# against the real native headers (stale selectors only fail at runtime as "unrecognized selector").
#
# usage: ios/scripts/verify-bindings.sh <official-sdk>/artifacts <MapboxMapObjC.xcframework>
set -euo pipefail
SDK=${1:?official SDK artifacts dir}; BRIDGE=${2:?MapboxMapObjC.xcframework}
HERE=${0:A:h}; LIBS=$HERE/../libs; WORK=$(mktemp -d)
cat > $WORK/all.m <<'M'
#import <UIKit/UIKit.h>
#import <MapboxCommon/MapboxCommon.h>
#import <MapboxCommon/MapboxCommon-Swift.h>
#import <MapboxCoreMaps/MapboxCoreMaps.h>
#import <MapboxMaps/MapboxMaps.h>
@interface MapView : UIView
@end
@interface MapInitOptions : NSObject
@end
#import <MapboxMapObjC/MapboxMapObjC-Swift.h>
M
xcrun clang -x objective-c -target arm64-apple-ios15.0 -isysroot $(xcrun --sdk iphoneos --show-sdk-path) \
  -fsyntax-only -fno-modules -fobjc-arc \
  -F $SDK/MapboxCommon.xcframework/ios-arm64 -F $SDK/MapboxCoreMaps.xcframework/ios-arm64 \
  -F $SDK/MapboxMaps.xcframework/ios-arm64 -F $SDK/Turf.xcframework/ios-arm64 -F $BRIDGE/ios-arm64 \
  -Xclang -ast-dump $WORK/all.m > $WORK/ast.txt
echo "== selectors (empty = all exports exist natively)"
python3 -I $HERE/verify_selectors.py $WORK/ast.txt $LIBS/MapboxCommon.iOS/ApiDefinitions.cs $LIBS/MapboxCoreMaps.iOS/ApiDefinitions.cs $LIBS/MapboxMapsObjC.iOS/ApiDefinitions.cs
echo "== enums"
python3 -I $HERE/verify_enums.py $WORK/ast.txt $LIBS/MapboxCommon.iOS/StructsAndEnums.cs $LIBS/MapboxCoreMaps.iOS/StructsAndEnums.cs $LIBS/MapboxMapsObjC.iOS/StructsAndEnums.cs
rm -rf $WORK
