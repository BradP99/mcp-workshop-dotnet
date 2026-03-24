namespace MyMonkeyApp;

/// <summary>
/// Represents a monkey species with its details.
/// </summary>
public class Monkey
{
    public string Name { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;
    public string Details { get; init; } = string.Empty;
    public string Image { get; init; } = string.Empty;
    public int Population { get; init; }

    public override string ToString() =>
        $"{Name} ({Location})";
}
