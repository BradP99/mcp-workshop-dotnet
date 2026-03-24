namespace MyMonkeyApp;

/// <summary>
/// Represents a monkey species with its details.
/// </summary>
public class Monkey
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int Population { get; set; }

    public override string ToString() =>
        $"{Name} ({Location})";
}
