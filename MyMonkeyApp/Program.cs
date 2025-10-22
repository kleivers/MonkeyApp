using System;

namespace MyMonkeyApp;

/// <summary>
/// Main program class for the Monkey Console Application.
/// </summary>
class Program
{
    /// <summary>
    /// Main entry point of the application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    static void Main(string[] args)
    {
        DisplayWelcomeBanner();
        
        bool exitRequested = false;
        
        while (!exitRequested)
        {
            DisplayMenu();
            var choice = GetUserChoice();
            
            switch (choice)
            {
                case 1:
                    ListAllMonkeys();
                    break;
                case 2:
                    GetMonkeyByName();
                    break;
                case 3:
                    GetRandomMonkey();
                    break;
                case 4:
                    exitRequested = true;
                    DisplayExitMessage();
                    break;
                default:
                    Console.WriteLine("❌ Invalid choice. Please select 1-4.");
                    break;
            }
            
            if (!exitRequested)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    /// <summary>
    /// Displays the welcome banner with ASCII art.
    /// </summary>
    static void DisplayWelcomeBanner()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
    ╔══════════════════════════════════════╗
    ║          🐵 MONKEY EXPLORER 🐵         ║
    ╚══════════════════════════════════════╝
        
           /\_/\  
          ( o.o ) 
           > ^ <  
          
    Welcome to the Interactive Monkey Database!
    Discover amazing monkey species from around the world.
        ");
        Console.ResetColor();
    }

    /// <summary>
    /// Displays the main menu options.
    /// </summary>
    static void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n" + new string('═', 50));
        Console.WriteLine("                 MAIN MENU");
        Console.WriteLine(new string('═', 50));
        Console.ResetColor();
        
        Console.WriteLine("1. 📋 List all monkeys");
        Console.WriteLine("2. 🔍 Get monkey details by name");
        Console.WriteLine("3. 🎲 Get a random monkey");
        Console.WriteLine("4. 🚪 Exit");
        
        Console.Write("\nEnter your choice (1-4): ");
    }

    /// <summary>
    /// Gets and validates user menu choice.
    /// </summary>
    /// <returns>The user's menu choice as an integer.</returns>
    static int GetUserChoice()
    {
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice;
        }
        return 0; // Invalid choice
    }

    /// <summary>
    /// Lists all available monkeys with their access counts.
    /// </summary>
    static void ListAllMonkeys()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n🐵 ALL MONKEY SPECIES:");
        Console.WriteLine(new string('-', 60));
        Console.ResetColor();

        var monkeys = MonkeyHelper.GetMonkeys();
        var accessStats = MonkeyHelper.GetAccessStatistics();

        for (int i = 0; i < monkeys.Count; i++)
        {
            var monkey = monkeys[i];
            var accessCount = MonkeyHelper.GetAccessCount(monkey.Name);
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{i + 1:D2}. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{monkey.Name}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($" - {monkey.Location}");
            
            if (accessCount > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($" (Viewed {accessCount} time{(accessCount == 1 ? "" : "s")})");
            }
            
            Console.WriteLine();
        }

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nTotal Monkeys: {MonkeyHelper.GetMonkeyCount()}");
        Console.WriteLine($"Total Views: {MonkeyHelper.GetTotalAccessCount()}");
        
        var mostPopular = MonkeyHelper.GetMostPopularMonkey();
        if (mostPopular != null)
        {
            Console.WriteLine($"Most Popular: {mostPopular}");
        }
        Console.ResetColor();
    }

    /// <summary>
    /// Gets monkey details by name from user input.
    /// </summary>
    static void GetMonkeyByName()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n🔍 FIND MONKEY BY NAME:");
        Console.WriteLine(new string('-', 30));
        Console.ResetColor();

        Console.Write("Enter monkey name: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Please enter a valid monkey name.");
            Console.ResetColor();
            return;
        }

        var monkey = MonkeyHelper.GetMonkeyByName(name);

        if (monkey == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ Monkey '{name}' not found.");
            Console.WriteLine("\n💡 Tip: Try one of these names:");
            
            var allMonkeys = MonkeyHelper.GetMonkeys();
            var suggestions = allMonkeys.Take(5).Select(m => m.Name);
            Console.WriteLine($"   {string.Join(", ", suggestions)}...");
            Console.ResetColor();
        }
        else
        {
            DisplayMonkeyDetails(monkey);
        }
    }

    /// <summary>
    /// Gets and displays a random monkey.
    /// </summary>
    static void GetRandomMonkey()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n🎲 RANDOM MONKEY SELECTION:");
        Console.WriteLine(new string('-', 35));
        Console.ResetColor();

        var randomMonkey = MonkeyHelper.GetRandomMonkey();
        DisplayMonkeyDetails(randomMonkey);
    }

    /// <summary>
    /// Displays detailed information about a monkey with ASCII art.
    /// </summary>
    /// <param name="monkey">The monkey to display details for.</param>
    static void DisplayMonkeyDetails(Monkey monkey)
    {
        Console.Clear();
        
        // Display monkey ASCII art
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
        🐵 MONKEY DETAILS 🐵
        
           .-""-.
          /     \
         | () () |
          \  ^  /
           |||||| 
           ||||||
        ");
        Console.ResetColor();

        // Display monkey information
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', 60));
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"NAME: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"  {monkey.Name}");
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"\nLOCATION: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  {monkey.Location}");

        if (monkey.Population.HasValue)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nPOPULATION: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"  {monkey.Population:N0}");
        }

        if (monkey.Latitude.HasValue && monkey.Longitude.HasValue)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nCOORDINATES: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"  {monkey.Latitude:F6}, {monkey.Longitude:F6}");
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"\nDETAILS: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"  {WrapText(monkey.Details, 55)}");

        // Display access count
        var accessCount = MonkeyHelper.GetAccessCount(monkey.Name);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nVIEWS: {accessCount} time{(accessCount == 1 ? "" : "s")}");
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', 60));
        Console.ResetColor();
    }

    /// <summary>
    /// Wraps text to a specified width for better display formatting.
    /// </summary>
    /// <param name="text">The text to wrap.</param>
    /// <param name="width">The maximum width per line.</param>
    /// <returns>The wrapped text.</returns>
    static string WrapText(string text, int width)
    {
        if (string.IsNullOrEmpty(text) || text.Length <= width)
            return text;

        var words = text.Split(' ');
        var lines = new List<string>();
        var currentLine = "";

        foreach (var word in words)
        {
            if ((currentLine + " " + word).Length <= width)
            {
                currentLine += (currentLine.Length == 0 ? "" : " ") + word;
            }
            else
            {
                if (currentLine.Length > 0)
                    lines.Add("  " + currentLine);
                currentLine = word;
            }
        }

        if (currentLine.Length > 0)
            lines.Add("  " + currentLine);

        return string.Join("\n", lines);
    }

    /// <summary>
    /// Displays the exit message with statistics.
    /// </summary>
    static void DisplayExitMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
    Thanks for exploring the Monkey Database! 🐵
    
           .-""-.
          /     \
         | ^   ^ |
          \  -  /
           |||||| 
           ||||||
           
    ");
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("📊 SESSION STATISTICS:");
        Console.WriteLine(new string('-', 25));
        Console.WriteLine($"Total monkey views: {MonkeyHelper.GetTotalAccessCount()}");
        
        var mostPopular = MonkeyHelper.GetMostPopularMonkey();
        if (mostPopular != null)
        {
            var popularCount = MonkeyHelper.GetAccessCount(mostPopular);
            Console.WriteLine($"Most viewed monkey: {mostPopular} ({popularCount} views)");
        }
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nGoodbye! Come back soon! 🌟");
        Console.ResetColor();
    }
}
