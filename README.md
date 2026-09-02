# Tokidachi Windows

Native Windows host for Tokidachi. Tokidachi is three coordinated components:
the shared collector and Linux/GNOME host in
[`tokidachi`](https://github.com/Gaalbu/tokidachi), the native macOS host in
[`tokidachiMac`](https://github.com/Gaalbu/tokidachiMac), and this native
Windows host. This repository owns only the WinUI 3 presentation layer; the
collector and versioned JSON contract remain in `tokidachi`.

### Tokidachi components

| Component | Scope | Repository / downloads |
| --- | --- | --- |
| Collector + Linux host | Java collector and GNOME Shell widget | [tokidachi](https://github.com/Gaalbu/tokidachi) · [Linux releases](https://github.com/Gaalbu/tokidachi/releases) |
| macOS host | Swift/AppKit/SwiftUI menu bar app | [tokidachiMac](https://github.com/Gaalbu/tokidachiMac) · _macOS releases: TBD_ |
| Windows host | WinUI 3/.NET tray app | [tokidachiWin](https://github.com/Gaalbu/tokidachiWin) · _Windows releases: TBD_ |

The current vertical slice targets Windows 10 1809+ with .NET 8 and the
Windows App SDK 1.8 maintenance release. It includes a packaged WinUI 3
window, MSIX manifest, contract reader, provider cards, and offline tests.
Collector process launching, tray integration, periodic refresh, settings,
and signed distribution are next slices.

```powershell
dotnet test TokidachiWin.Tests/TokidachiWin.Tests.csproj
dotnet build TokidachiWin/TokidachiWin.csproj --configuration Release --arch x64
```

The fixture mirrors `tokidachi/fixtures/collector/multi-provider.json` and is
used only for offline contract tests.

## CI smoke test

The Windows workflow creates a temporary self-signed certificate, signs and
installs the generated MSIX, starts `TokidachiWin`, verifies the process, then
stops and uninstalls it. This covers basic package installation, launch, and
cleanup; it does not cover UI appearance, real credentials, or production
code-signing certificates.
