using System.Text.Json.Serialization;

namespace TokidachiWin.Core;

public sealed record CollectorDocument(
    int Version,
    long UpdatedAt,
    Dictionary<string, ProviderCard> Providers);

public sealed record ProviderCard(
    [property: JsonPropertyName("displayName")] string DisplayName,
    string Color,
    string Pet,
    string Status,
    bool Configured,
    List<UsageWindow> Windows,
    List<string> Notices,
    string? Message)
{
    [JsonIgnore]
    public string Id { get; init; } = "";
}

public sealed record UsageWindow(
    string Label,
    double UsedPercent,
    string? ResetLabel);
