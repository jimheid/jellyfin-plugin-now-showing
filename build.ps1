$ErrorActionPreference = "Stop"
$Root = Split-Path -Parent $MyInvocation.MyCommand.Path
$Project = Join-Path $Root "Jellyfin.Plugin.NowShowing/Jellyfin.Plugin.NowShowing.csproj"
$Out = Join-Path $Root "publish"
if (Test-Path $Out) { Remove-Item $Out -Recurse -Force }
dotnet restore $Project
dotnet publish $Project -c Release --no-self-contained -o $Out
Write-Host ""
Write-Host "Built: $Out/Jellyfin.Plugin.NowShowing.dll"
