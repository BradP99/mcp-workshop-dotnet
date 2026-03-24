using MyMonkeyApp;

DisplayBanner();

var running = true;
while (running)
{
    DisplayMenu();
    var input = Console.ReadLine()?.Trim();

    switch (input)
    {
        case "1":
            ListAllMonkeys();
            break;
        case "2":
            GetMonkeyByName();
            break;
        case "3":
            GetRandomMonkey();
            break;
        case "q":
        case "Q":
            running = false;
            Console.WriteLine("\n🐒 Goodbye! Thanks for visiting the Monkey App! 🐒\n");
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n❌ Invalid option. Please enter 1, 2, 3, or q.\n");
            Console.ResetColor();
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
    Console.WriteLine("╔══════════════════════════════════╗");
    Console.WriteLine("║       🐒 MONKEY MENU 🐒         ║");
    Console.WriteLine("╠══════════════════════════════════╣");
    Console.WriteLine("║  1. List all monkeys             ║");
    Console.WriteLine("║  2. Get monkey by name           ║");
    Console.WriteLine("║  3. Pick a random monkey         ║");
    Console.WriteLine("║  q. Quit                         ║");
    Console.WriteLine("╚══════════════════════════════════╝");
    Console.ResetColor();
    Console.Write("\nSelect an option: ");
}

static void ListAllMonkeys()
{
    var monkeys = MonkeyHelper.GetMonkeys();
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{"Name",-25} {"Location",-30} {"Population",10}");
    Console.WriteLine(new string('─', 67));
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

    DisplayMonkeyDetails(monkey);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"  (Random picks so far: {MonkeyHelper.GetRandomAccessCount()})\n");
    Console.ResetColor();
}

static void DisplayMonkeyDetails(Monkey monkey)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("  ╭─────────────────────────────────────────╮");
    Console.WriteLine($"  │  {monkey.Image} {monkey.Name,-38} │");
    Console.WriteLine("  ├─────────────────────────────────────────┤");
    Console.ResetColor();
    Console.WriteLine($"  │  Location:   {monkey.Location,-27} │");
    Console.WriteLine($"  │  Population: {monkey.Population,-27:N0} │");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("  ╰─────────────────────────────────────────╯");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine($"\n  {monkey.Details}\n");
    Console.ResetColor();
}
