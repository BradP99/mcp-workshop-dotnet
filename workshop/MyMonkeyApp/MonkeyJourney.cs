namespace MyMonkeyApp;

/// <summary>
/// Represents a monkey's tracked journey over a time window.
/// </summary>
public class MonkeyJourney
{
  public string MonkeyName { get; init; } = string.Empty;
  public GeoCoordinate StartLocation { get; init; } = new();
  public DateTime StartTime { get; init; }
  public DateTime EndTime { get; init; }

  public List<JourneyPoint> PathPoints { get; init; } = new();
  public List<MonkeyActivity> Activities { get; init; } = new();

  public MonkeyHealthStats HealthStats { get; init; } = new();

  public TimeSpan TotalDuration { get; init; }
  public double TotalDistanceKm { get; init; }
}

/// <summary>
/// Represents a latitude/longitude coordinate.
/// </summary>
public class GeoCoordinate
{
  public double Latitude { get; init; }
  public double Longitude { get; init; }
}

/// <summary>
/// Represents a point in the monkey's journey path.
/// </summary>
public class JourneyPoint
{
  public GeoCoordinate Location { get; init; } = new();
  public DateTime Timestamp { get; init; }
}

/// <summary>
/// Represents an observed activity event for the monkey.
/// </summary>
public class MonkeyActivity
{
  public string Type { get; init; } = string.Empty;
  public string Description { get; init; } = string.Empty;
  public GeoCoordinate Location { get; init; } = new();
  public DateTime Timestamp { get; init; }
  public TimeSpan Duration { get; init; }
  public int EnergyChange { get; init; }
}

/// <summary>
/// Represents the monkey's aggregate health-related stats.
/// </summary>
public class MonkeyHealthStats
{
  public int Energy { get; init; }
  public int Happiness { get; init; }
  public int Hunger { get; init; }
  public int Social { get; init; }
  public int Stress { get; init; }
  public int Health { get; init; }
}
