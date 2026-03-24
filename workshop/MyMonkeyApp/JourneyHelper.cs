using System.Text.Json;

namespace MyMonkeyApp;

/// <summary>
/// Maps monkey MCP JSON payloads to strongly typed journey models.
/// </summary>
public static class JourneyHelper
{
  private static readonly JsonSerializerOptions SerializerOptions = new()
  {
    PropertyNameCaseInsensitive = true
  };

  /// <summary>
  /// Parses one or many journeys from an MCP JSON payload.
  /// Supports array payloads, a single journey object, or an object containing a "journeys" array.
  /// </summary>
  public static IReadOnlyList<MonkeyJourney> ParseJourneys(string json)
  {
    if (string.IsNullOrWhiteSpace(json))
    {
      return [];
    }

    using var document = JsonDocument.Parse(json);
    var root = document.RootElement;

    if (root.ValueKind == JsonValueKind.Array)
    {
      return JsonSerializer.Deserialize<List<MonkeyJourney>>(root.GetRawText(), SerializerOptions) ?? [];
    }

    if (root.ValueKind == JsonValueKind.Object)
    {
      if (root.TryGetProperty("journeys", out var journeysElement) && journeysElement.ValueKind == JsonValueKind.Array)
      {
        return JsonSerializer.Deserialize<List<MonkeyJourney>>(journeysElement.GetRawText(), SerializerOptions) ?? [];
      }

      var singleJourney = JsonSerializer.Deserialize<MonkeyJourney>(root.GetRawText(), SerializerOptions);
      return singleJourney is null ? [] : [singleJourney];
    }

    return [];
  }

  /// <summary>
  /// Finds a journey by monkey name, using case-insensitive matching.
  /// </summary>
  public static MonkeyJourney? GetJourneyByMonkeyName(IEnumerable<MonkeyJourney> journeys, string monkeyName)
  {
    if (string.IsNullOrWhiteSpace(monkeyName))
    {
      return null;
    }

    return journeys.FirstOrDefault(j =>
        j.MonkeyName.Equals(monkeyName.Trim(), StringComparison.OrdinalIgnoreCase));
  }

  /// <summary>
  /// Returns distinct monkey names from the provided journeys.
  /// </summary>
  public static IReadOnlyList<string> GetAvailableMonkeyNames(IEnumerable<MonkeyJourney> journeys)
  {
    return journeys
        .Select(j => j.MonkeyName)
        .Where(name => !string.IsNullOrWhiteSpace(name))
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .OrderBy(name => name)
        .ToList();
  }
}
