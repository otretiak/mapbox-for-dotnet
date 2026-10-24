#!/usr/bin/env bash

set -euo pipefail

args=("$@")
artifact=""

while (($#)); do
    case "$1" in
        --artifact)
            artifact="${2:-}"
            shift 2
            ;;
        --artifact=*)
            artifact="${1#*=}"
            shift
            ;;
        *)
            shift
            ;;
    esac
done

if [[ -z "$artifact" ]]; then
    echo "bind.sh requires --artifact group:artifact:version" >&2
    exit 1
fi

group_id="${artifact%%:*}"
artifact_rest="${artifact#*:}"
artifact_id="${artifact_rest%%:*}"

export BindingArtifact="$artifact"
export BindingSharedPropsPath=""
export BindingGroupPropsPath=""
export BindingArtifactPropsPath=""

if [[ "$group_id" == com.mapbox* ]]; then
    export BindingSharedPropsPath="$PWD/src/Mapbox.Shared.props"
fi

group_props_path="$PWD/src/android/$group_id/maven.props"
artifact_props_path="$PWD/src/android/$group_id/$artifact_id/maven.props"

if [[ -f "$group_props_path" ]]; then
    export BindingGroupPropsPath="$group_props_path"
fi

if [[ -f "$artifact_props_path" ]]; then
    export BindingArtifactPropsPath="$artifact_props_path"
fi

if ! dotnet workload list | grep -Eq '^android\s'; then
    echo "Installing Android workload"
    dotnet workload install android
fi

dotnet run --project ./src/libs/BindingHost/BindingHost.csproj \
    --verbosity minimal \
    -- --base-path="$PWD" "${args[@]}"
