using System.Text.Json;

namespace TokidachiWin.Core;

public sealed class CollectorReader
{
    private readonly JsonSerializerOptions _options = new(JsonSerializerDefaults.Web);

    public CollectorDocument Read(Stream json)
    {
        var document = JsonSerializer.Deserialize<CollectorDocument>(json, _options)
            ?? throw new JsonException("Collector returned an empty document.");

        if (document.Version != 1)
            throw new NotSupportedException($"Unsupported collector contract version: {document.Version}");

        foreach (var (id, provider) in document.Providers)
            document.Providers[id] = provider with { Id = id };

        return document;
    }

    public CollectorDocument Read(string path)
    {
        using var stream = File.OpenRead(path);
        return Read(stream);
    }
}
