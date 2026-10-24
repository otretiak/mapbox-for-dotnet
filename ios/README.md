# Mapbox .NET iOS Bindings

.NET iOS bindings for the native Mapbox iOS SDK.[^tuyen] These packages target
`net10.0-ios` and iOS 15 or later.

## Install

For an app that renders Mapbox maps, install the Maps package and the Objective-C
bridge package:

```bash
dotnet add package Bindings.Mapbox.iOS --version 11.33.0.1-unifly
dotnet add package Bindings.Mapbox.iOS.MapsObjC --version 11.33.0.1-unifly
```

`Bindings.Mapbox.iOS` brings in the Common, CoreMaps, and Turf binding packages.
Install those directly only when you need those APIs without a map view.

## Tokens

Set `MAPBOX_DOWNLOADS_TOKEN` to a secret Mapbox downloads token before building.
The package targets use it to download the native Mapbox frameworks:

```bash
export MAPBOX_DOWNLOADS_TOKEN=sk...
```

Set a public Mapbox access token for runtime tile access. The usual options are
an `MBXAccessToken` entry in `Info.plist`:

```xml
<key>MBXAccessToken</key>
<string>$(MapboxAccessToken)</string>
```

or setting it in code before creating the map:

```csharp
MapboxCommon.MBXMapboxOptions.SetAccessTokenForToken("pk...");
```

## Minimal Map

```csharp
using CoreGraphics;
using CoreLocation;
using MapboxCoreMaps;
using MapboxMaps;
using MapboxMapsObjC;
using UIKit;

var camera = new TMBCameraOptions(
    new CLLocationCoordinate2D(40.7128, -74.0060),
    UIEdgeInsets.Zero,
    CGPoint.Empty,
    10,
    0,
    0);

var options = MapInitOptionsFactory.CreateWithMapOptions(
    null,
    camera,
    BuiltInStyles.Streets,
    null,
    (nint)1);

var mapView = MapViewFactory.CreateWithFrame(View.Bounds, options);
mapView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
View.AddSubview(mapView);
```

## Links

- Source: [mapbox-for-dotnet](https://github.com/matthewrdev/mapbox-for-dotnet)
- Mapbox iOS docs: [docs.mapbox.com/ios/maps](https://docs.mapbox.com/ios/maps/)

[^tuyen]: The iOS binding and Objective-C bridge strategy build on [Tuyen Vu Duc](https://github.com/tuyen-vuduc)'s [`mapbox-ios-binding`](https://github.com/tuyen-vuduc/mapbox-ios-binding) and [`mapbox-ios-objective-c`](https://github.com/tuyen-vuduc/mapbox-ios-objective-c). Native Mapbox SDK components and Mapbox artifacts are copyright Mapbox, Inc. Please consider [sponsoring Tuyen](https://github.com/sponsors/tuyen-vuduc).
