namespace MyMonkeyApp;

/// <summary>
/// Provides methods to manage and retrieve monkey data.
/// </summary>
public static class MonkeyHelper
{
    private static int _randomAccessCount;
    private static readonly List<Monkey> _monkeys = new()
    {
        new Monkey
        {
            Name = "Capuchin",
            Location = "Central and South America",
            Details = "Capuchins are intelligent and social primates known for their tool use and problem-solving abilities.",
            Image = "🐒",
            Population = 54000
        },
        new Monkey
        {
            Name = "Japanese Macaque",
            Location = "Japan",
            Details = "Also known as snow monkeys, Japanese macaques are famous for bathing in hot springs during winter.",
            Image = "🐵",
            Population = 114000
        },
        new Monkey
        {
            Name = "Mandrill",
            Location = "Central Africa",
            Details = "Mandrills are the world's largest monkeys, recognizable by their colorful blue and red faces.",
            Image = "🐒",
            Population = 25000
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Location = "Central and South America",
            Details = "Howler monkeys are among the loudest animals on Earth; their calls can be heard up to 3 miles away.",
            Image = "🐵",
            Population = 100000
        },
        new Monkey
        {
            Name = "Spider Monkey",
            Location = "Central and South America",
            Details = "Spider monkeys are known for their long limbs and prehensile tails, which they use like a fifth hand.",
            Image = "🐒",
            Population = 42000
        },
        new Monkey
        {
            Name = "Golden Lion Tamarin",
            Location = "Brazil",
            Details = "Golden lion tamarins are small, brightly colored primates named for their impressive orange manes.",
            Image = "🐵",
            Population = 3200
        },
        new Monkey
        {
            Name = "Proboscis Monkey",
            Location = "Borneo",
            Details = "Proboscis monkeys are easily identified by their large, fleshy noses which can exceed 10 cm in length.",
            Image = "🐒",
            Population = 7000
        },
        new Monkey
        {
            Name = "Pygmy Marmoset",
            Location = "South America",
            Details = "Pygmy marmosets are the smallest monkeys in the world, weighing around 100 grams as adults.",
            Image = "🐵",
            Population = 50000
        },
        new Monkey
        {
            Name = "Baboon",
            Location = "Africa and Arabia",
            Details = "Baboons are highly adaptable primates that live in complex social groups called troops.",
            Image = "🐒",
            Population = 200000
        },
        new Monkey
        {
            Name = "Squirrel Monkey",
            Location = "Central and South America",
            Details = "Squirrel monkeys live in large groups and have the largest brain-to-body ratio of all primates.",
            Image = "🐵",
            Population = 85000
        }
    };

    /// <summary>
    /// Returns all available monkeys.
    /// </summary>
    public static List<Monkey> GetMonkeys() => _monkeys;

    /// <summary>
    /// Returns a random monkey from the collection.
    /// </summary>
    public static Monkey? GetRandomMonkey()
    {
        if (_monkeys.Count == 0)
            return null;

        _randomAccessCount++;
        var index = Random.Shared.Next(_monkeys.Count);
        return _monkeys[index];
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive, trimmed).
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m =>
            m.Name.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Returns the number of times a random monkey has been picked.
    /// </summary>
    public static int GetRandomAccessCount() => _randomAccessCount;
}
