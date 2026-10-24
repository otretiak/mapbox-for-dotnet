# Runbook

## Prerequisites

- `.NET 10`
- Java `21`
- Android workload: `dotnet workload install android`
- A usable Android SDK
- A Mapbox downloads token in `~/.gradle/gradle.properties`

```properties
MAPBOX_DOWNLOADS_TOKEN=your_token_here
```

## Update Flow

### 1. Pick the root artifact

Current checked-in root:

```text
com.mapbox.maps:android-ndk27:11.33.0
```

This is the repository's current Android binding root. Check the upstream
Mapbox Android docs before choosing the next target version.

NuGet package versions should use the native artifact version plus one package
revision component. For example, the `11.23.0` Android SDK packages are
published as `11.23.0.1`, and binding-only maintenance updates can increment
only the final component.

Fork note (unifly/11.33): the per-version `<version>.json` files for the 11.33 artifacts carry
`"nugetVersion": "<native>.1-unifly"`, so the packages are prereleases and cannot collide with a
future upstream release. `bind.sh` uses `grep -E` instead of `rg`. The final `NugetTask` of `bind.sh`
fails with "Inadequate permissions"; run restore, build and pack manually afterwards.

Update `.github/workflows/mapbox.yml` first so the workflow input matches the version you are preparing.

### 2. Regenerate the graph

Run from the `android` folder:

```bash
sh bind.sh --artifact com.mapbox.maps:android-ndk27:<version>
```

You can run a non-default task through the same entrypoint:

```bash
sh bind.sh --artifact com.mapbox.maps:android-ndk27:<version> --target=deps
```

### 3. Review the generated delta

Look for:

- newly discovered artifact folders under `src/android`
- changed `<version>.json` files
- regenerated `binding/*.csproj` and `.targets`
- dependency shifts in `bindings.g.sln`

### 4. Fix regressions

Use the narrowest override point that works:

- `binding/Transforms/Metadata.xml`
  Naming, visibility, signature, and node-removal fixes.
- `binding/Additions/Additions.cs`
  Wrapper types, explicit interface implementations, and convenience APIs.
- `<version>.fixed.json`
  Wrong package version chosen by the graph.
- `<version>.missing.json`
  Missing dependency that must be surfaced anyway.
- `src/libs/Binderator.Gradle/Model/ArtifactModel.cs`
  True one-off package metadata or manual package-reference hacks.

The current hotspots are cataloged in [Overrides](overrides.md).

### 5. Validate

Build:

```bash
dotnet build bindings.g.sln -c Release -v minimal
```

Pack:

```bash
dotnet pack bindings.g.sln -c Release -o ./nugets
```

Useful signals:

- build errors are blockers
- `NU1605` and `NU1608` usually mean graph normalization is still wrong
- nullability and XML-doc warnings matter only if they hide a real binding problem

## Cleanup

Do not commit local build output:

```bash
find src -type d \( -name bin -o -name obj \) -prune -exec rm -rf {} +
rm -rf nugets
```
