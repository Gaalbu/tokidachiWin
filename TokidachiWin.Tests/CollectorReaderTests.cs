using System.Text;
using TokidachiWin.Core;

namespace TokidachiWin.Tests;

public sealed class CollectorReaderTests
{
    [Fact]
    public void ReadsProviderIdsAndStatesFromSharedFixture()
    {
        using var stream = File.OpenRead("Fixtures/multi-provider.json");
        var document = new CollectorReader().Read(stream);

        Assert.Equal(1, document.Version);
        Assert.Equal("claude", document.Providers["claude"].Id);
        Assert.Equal("attention", document.Providers["codex"].Status);
        Assert.Equal(91, document.Providers["codex"].Windows[0].UsedPercent);
    }

    [Fact]
    public void RejectsUnsupportedContractVersion()
    {
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes("{\"version\":2,\"updatedAt\":1,\"providers\":{}}"));

        Assert.Throws<NotSupportedException>(() => new CollectorReader().Read(stream));
    }
}
