# Overrides

This file documents the places where the generated bindings still need help.

If a binding folder is not listed here, it should ideally contain no hand-written override files at all.

## Version-Level Overrides

### `src/android/com.mapbox.base/common`

- `0.12.0.fixed.json`
  Pins `Xamarin.Kotlin.StdLib.Jdk7`.
- `0.12.0.missing.json`
  Forces the missing Kotlin stdlib dependency into the surfaced graph.
- `binding/Additions/Additions.cs`
  Adds a `Function1Action<T>` bridge used by the generated APIs.
- `src/libs/Binderator.Gradle/Model/ArtifactModel.cs`
  Adds the matching manual package reference.

### `src/android/com.mapbox.mapboxsdk/mapbox-sdk-geojson`

- `7.10.0.fixed.json`
  Keeps the external package graph on a buildable version set.

## Binding Hotspots

### `src/android/com.mapbox.common/common-ndk27`

- `24.19.0.fixed.json`
  Uses the official `Square.OkIO` package and lifts `Xamarin.Kotlin.StdLib.Common`
  to satisfy OkIO's Kotlin dependency floor.
- `Transforms/Metadata.xml`
  Renames `Location` and opens `GooglePlayServicesHelper`.
- `Additions/Additions.cs`
  Fixes AndroidX Startup initializer interfaces and a stream-return contract.

### `src/android/com.mapbox.extension/maps-style-ndk27`

- `Transforms/Metadata.xml`
  Large property-name, setter-name, and collection-shape cleanup for generated style APIs.
- `Additions/Additions.cs`
  Adds DSL helpers, projection/light extension methods, and expression-builder conveniences.

This is the largest override surface in the repo.

### `src/android/com.mapbox.mapboxsdk/mapbox-sdk-geojson`

- `Transforms/Metadata.xml`
  Renames generated methods and removes incorrect interface implementations.
- `Additions/Additions.cs`
  Reintroduces the intended interface shapes with explicit implementations and Gson adapter fixes.

### `src/android/com.mapbox.maps/base-ndk27`

- `Transforms/Metadata.xml`
  Disambiguates generated typed-featureset methods.
- `Additions/Additions.cs`
  Adds listener adapters, convenience extension methods, and Parcelable creator fixes.
  Each `Standard*` typed-featureset class (Buildings, Poi, PlaceLabels, LandmarkIcons,
  IndoorLabels as of 11.33) needs an override forwarding the abstract
  `GetFeatureState`/`GetFeaturesetFeature` to the `...X` renamed covariant methods.

### `src/android/com.mapbox.maps/android-core-ndk27`

- `Additions/Additions.cs`
  Fixes the AndroidX Startup initializer bridge.

### `src/android/com.mapbox.maps/android-ndk27`

- `Additions/Additions.cs`
  Adds `Action<Style>` and error-callback convenience overloads for style loading.

### `src/android/com.mapbox.plugin/maps-annotation-ndk27`

- `Transforms/Metadata.xml`
  Renames generated methods and adds typed click-listener interfaces.
- `Additions/Additions.cs`
  Re-exposes the intended `Build` and offset-geometry members.

### `src/android/com.mapbox.plugin/maps-attribution-ndk27`

- `Transforms/Metadata.xml`
  Opens an internal delegate getter.
- `Additions/Additions.cs`
  Restores the `SetContentDescription(ICharSequence)` overload.

### `src/android/com.mapbox.plugin/maps-gestures-ndk27`

- `Transforms/Metadata.xml`
  Makes the gestures manager getter visible.
- `Additions/Additions.cs`
  Adds extension helpers for plugin-provider access.

### `src/android/com.mapbox.plugin/maps-locationcomponent-ndk27`

- `Additions/Additions.cs`
  Adds a plugin-provider extension helper.

### `src/android/com.mapbox.plugin/maps-viewport-ndk27`

- `Transforms/Metadata.xml`
  Renames a generated field to avoid a bad managed name.
- `Additions/Additions.cs`
  Adds completion-listener and async transition helpers.

### `src/android/com.mapbox.plugin/maps-animation-ndk27`

- `Transforms/Metadata.xml`
  Renames a generated field to a stable managed name.

## Rule Of Thumb

Prefer the smallest fix that works:

1. `Metadata.xml` before `Additions.cs`
2. `<version>.fixed.json` before hard-coded package references
3. shared props before per-group or per-artifact `maven.props`

When an override is added, add a short rationale here.
