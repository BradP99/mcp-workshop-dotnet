using MyMonkeyApp;

DisplayBanner();
DisplayRandomMonkeyArt();

var running = true;
while (running)
{
    DisplayMenu();
    var input = Console.ReadLine()?.Trim();

    switch (input)
    {
        case "1":
            ListAllMonkeys();
            PauseForContinue();
            break;
        case "2":
            GetMonkeyByName();
            PauseForContinue();
            break;
        case "3":
            GetRandomMonkey();
            PauseForContinue();
            break;
        case "4":
            running = false;
            Console.WriteLine("\n🐒 Goodbye! Thanks for visiting the Monkey App! 🐒\n");
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n❌ Invalid option. Please enter 1, 2, 3, or 4.\n");
            Console.ResetColor();
            PauseForContinue();
            break;
    }
}

static void DisplayBanner()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("""

      __  __             _              
     |  \/  | ___  _ __ | | _____ _   _ 
     | |\/| |/ _ \| '_ \| |/ / _ \ | | |
     | |  | | (_) | | | |   <  __/ |_| |
     |_|  |_|\___/|_| |_|_|\_\___|\__, |
         Console App              |___/ 
    
    """);
    Console.ResetColor();
    Console.WriteLine("Welcome to the Monkey Console App! 🐵");
    Console.WriteLine("Explore monkey species from around the world.\n");
}

static void DisplayMenu()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("+----------------------------------+");
    Console.WriteLine("|           MONKEY MENU            |");
    Console.WriteLine("+----------------------------------+");
    Console.WriteLine("| 1. List all monkeys              |");
    Console.WriteLine("| 2. Get details by name           |");
    Console.WriteLine("| 3. Get a random monkey           |");
    Console.WriteLine("| 4. Exit app                      |");
    Console.WriteLine("+----------------------------------+");
    Console.ResetColor();
    Console.Write("\nSelect an option: ");
}

static void ListAllMonkeys()
{
    var monkeys = MonkeyHelper.GetMonkeys();
    Console.WriteLine();
    DisplayRandomMonkeyArt();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{"Name",-25} {"Location",-30} {"Population",10}");
    Console.WriteLine(new string('-', 67));
    Console.ResetColor();

    foreach (var monkey in monkeys)
    {
        Console.WriteLine($" {monkey.Image} {monkey.Name,-22} {monkey.Location,-30} {monkey.Population,10:N0}");
    }

    Console.WriteLine();
}

static void GetMonkeyByName()
{
    Console.Write("\nEnter monkey name: ");
    var name = Console.ReadLine();

    var monkey = MonkeyHelper.GetMonkeyByName(name ?? string.Empty);

    if (monkey is null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n❌ No monkey found with the name '{name?.Trim()}'.");
        Console.WriteLine("Tip: Use option 1 to see all available monkey names.\n");
        Console.ResetColor();
        return;
    }

    DisplayRandomMonkeyArt();
    DisplayMonkeyDetails(monkey);
}

static void GetRandomMonkey()
{
    var monkey = MonkeyHelper.GetRandomMonkey();

    if (monkey is null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n❌ No monkeys available.\n");
        Console.ResetColor();
        return;
    }

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("\n🎲 Random monkey selected!");
    Console.ResetColor();

    DisplayRandomMonkeyArt();
    DisplayMonkeyDetails(monkey);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"  (Random picks so far: {MonkeyHelper.GetRandomAccessCount()})\n");
    Console.ResetColor();
}

static void DisplayMonkeyDetails(Monkey monkey)
{
    Console.WriteLine();
    const int innerWidth = 45;
    var title = $"{monkey.Image} {monkey.Name}";
    var location = $"Location: {monkey.Location}";
    var population = $"Population: {monkey.Population:N0}";

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"+{new string('-', innerWidth)}+");
    Console.WriteLine($"| {TruncateAndPad(title, innerWidth - 2)} |");
    Console.WriteLine($"+{new string('-', innerWidth)}+");
    Console.ResetColor();
    Console.WriteLine($"| {TruncateAndPad(location, innerWidth - 2)} |");
    Console.WriteLine($"| {TruncateAndPad(population, innerWidth - 2)} |");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"+{new string('-', innerWidth)}+");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine($"\n  {monkey.Details}\n");
    Console.ResetColor();
}

static string TruncateAndPad(string value, int width)
{
    if (string.IsNullOrEmpty(value))
    {
        return new string(' ', width);
    }

    if (value.Length > width)
    {
        if (width <= 3)
        {
            return value[..width];
        }

        return value[..(width - 3)] + "...";
    }

    return value.PadRight(width);
}

static void DisplayRandomMonkeyArt()
{
    string[] monkeyArts =
    [
                @"  .-""""-.
 / .===. \
 \/ 6 6 \/
 ( \___/ )
___ooo__V__ooo___",
                @" .=""""=.
/ _  _ \
|  d  b  |
\   /\   /
 '.\__/.''
 _/    \_",
                @".-""-.   .-""-.
/    |___|    \
;  O  /   \  O  ;
|    |  .  |    |
;  O  \___/  O  ;
 \    /   \    /
    '-./_____\.-'"
    ];

    var art = monkeyArts[Random.Shared.Next(monkeyArts.Length)];
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine();
    Console.WriteLine(art);
    Console.ResetColor();
}

static void PauseForContinue()
{
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("Press Enter to continue...");
    Console.ResetColor();
    Console.ReadLine();
    Console.WriteLine();
}
