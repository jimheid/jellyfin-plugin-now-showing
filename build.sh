#!/usr/bin/env bash
set -euo pipefail
ROOT="$(cd "$(dirname "$0")" && pwd)"
PROJECT="$ROOT/Jellyfin.Plugin.NowShowing/Jellyfin.Plugin.NowShowing.csproj"
OUT="$ROOT/publish"
rm -rf "$OUT"
dotnet restore "$PROJECT"
dotnet publish "$PROJECT" -c Release --no-self-contained -o "$OUT"
echo
echo "Built: $OUT/Jellyfin.Plugin.NowShowing.dll"
