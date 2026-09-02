# Tokidachi Windows

Native Windows host for the Tokidachi collector. This repository owns the
WinUI 3 presentation layer; the collector and JSON contract remain in
[`Gaalbu/tokidachi`](https://github.com/Gaalbu/tokidachi). macOS is covered by
[`Gaalbu/tokidachiMac`](https://github.com/Gaalbu/tokidachiMac).

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
