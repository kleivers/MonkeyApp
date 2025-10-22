using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMonkeyApp;

/// <summary>
/// Static helper class for managing monkey data operations with access tracking.
/// </summary>
public static class MonkeyHelper
{
    private static readonly Random _random = new();
    private static readonly Dictionary<string, int> _accessCounts = new();
    private static int _totalAccesses = 0;
    
    /// <summary>
    /// Gets all available monkeys from the data source.
    /// </summary>
    /// <returns>A list of all monkey species.</returns>
    public static List<Monkey> GetMonkeys()
    {
        IncrementTotalAccess();
        
        return new List<Monkey>
        {
            new Monkey
            {
                Name = "Baboon",
                Location = "Africa & Asia",
                Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg",
                Population = 10000,
                Latitude = -8.783195,
                Longitude = 34.508523
            },
            new Monkey
            {
                Name = "Capuchin Monkey",
                Location = "Central & South America",
                Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg",
                Population = 23000,
                Latitude = 12.769013,
                Longitude = -85.602364
            },
            new Monkey
            {
                Name = "Blue Monkey",
                Location = "Central and East Africa",
                Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg",
                Population = 12000,
                Latitude = 1.957709,
                Longitude = 37.297204
            },
            new Monkey
            {
                Name = "Squirrel Monkey",
                Location = "Central & South America",
                Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/saimiri.jpg",
                Population = 11000,
                Latitude = -8.783195,
                Longitude = -55.491477
            },
            new Monkey
            {
                Name = "Golden Lion Tamarin",
                Location = "Brazil",
                Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/tamarin.jpg",
                Population = 19000,
                Latitude = -14.235004,
                Longitude = -51.92528
            },
            new Monkey
            {
                Name = "Howler Monkey",
                Location = "South America",
                Details = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/alouatta.jpg",
                Population = 8000,
                Latitude = -8.783195,
                Longitude = -55.491477
            },
            new Monkey
            {
                Name = "Japanese Macaque",
                Location = "Japan",
                Details = "The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macasa.jpg",
                Population = 1000,
                Latitude = 36.204824,
                Longitude = 138.252924
            },
            new Monkey
            {
                Name = "Mandrill",
                Location = "Southern Cameroon, Gabon, and Congo",
                Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg",
                Population = 17000,
                Latitude = 7.369722,
                Longitude = 12.354722
            },
            new Monkey
            {
                Name = "Proboscis Monkey",
                Location = "Borneo",
                Details = "The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/borneo.jpg",
                Population = 15000,
                Latitude = 0.961883,
                Longitude = 114.55485
            },
            new Monkey
            {
                Name = "Sebastian",
                Location = "Seattle",
                Details = "This little trouble maker lives in Seattle with James and loves traveling on adventures with James and tweeting @MotzMonkeys. He by far is an Android fanboy and is getting ready for the new Google Pixel 9!",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/sebastian.jpg",
                Population = 1,
                Latitude = 47.606209,
                Longitude = -122.332071
            },
            new Monkey
            {
                Name = "Henry",
                Location = "Phoenix",
                Details = "An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. His favorite platform is iOS by far and is excited for the new iPhone Xs!",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/henry.jpg",
                Population = 1,
                Latitude = 33.448377,
                Longitude = -112.074037
            },
            new Monkey
            {
                Name = "Red-shanked douc",
                Location = "Vietnam",
                Details = "The red-shanked douc is a species of Old World monkey, among the most colourful of all primates. The douc is an arboreal and diurnal monkey that eats and sleeps in the trees of the forest.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg",
                Population = 1300,
                Latitude = 16.111648,
                Longitude = 108.262122
            },
            new Monkey
            {
                Name = "Mooch",
                Location = "Seattle",
                Details = "An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. Her favorite platform is iOS by far and is excited for the new iPhone 16!",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/Mooch.PNG",
                Population = 1,
                Latitude = 47.608013,
                Longitude = -122.335167
            }
        };
    }

    /// <summary>
    /// Gets a monkey by its name (case-insensitive search) and tracks access count.
    /// </summary>
    /// <param name="name">The name of the monkey to find.</param>
    /// <returns>The monkey if found, otherwise null.</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        var monkeys = GetMonkeys();
        var monkey = monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));

        if (monkey != null)
        {
            IncrementAccessCount(monkey.Name);
        }

        return monkey;
    }

    /// <summary>
    /// Gets a random monkey from the available collection and tracks access count.
    /// </summary>
    /// <returns>A randomly selected monkey.</returns>
    public static Monkey GetRandomMonkey()
    {
        var monkeys = GetMonkeys();
        var randomIndex = _random.Next(monkeys.Count);
        var monkey = monkeys[randomIndex];
        
        IncrementAccessCount(monkey.Name);
        return monkey;
    }

    /// <summary>
    /// Gets the total count of available monkeys.
    /// </summary>
    /// <returns>The number of monkey species available.</returns>
    public static int GetMonkeyCount()
    {
        return GetMonkeys().Count;
    }

    /// <summary>
    /// Gets monkeys filtered by location (case-insensitive search).
    /// </summary>
    /// <param name="location">The location to search for.</param>
    /// <returns>A list of monkeys found in the specified location.</returns>
    public static List<Monkey> GetMonkeysByLocation(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
            return new List<Monkey>();

        var monkeys = GetMonkeys();
        return monkeys.Where(m => 
            m.Location.Contains(location, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    /// <summary>
    /// Gets the access count for a specific monkey by name.
    /// </summary>
    /// <param name="monkeyName">The name of the monkey.</param>
    /// <returns>The number of times this monkey has been accessed.</returns>
    public static int GetAccessCount(string monkeyName)
    {
        if (string.IsNullOrWhiteSpace(monkeyName))
            return 0;

        return _accessCounts.TryGetValue(monkeyName, out var count) ? count : 0;
    }

    /// <summary>
    /// Gets the total number of monkey accesses across all species.
    /// </summary>
    /// <returns>The total access count.</returns>
    public static int GetTotalAccessCount()
    {
        return _totalAccesses;
    }

    /// <summary>
    /// Gets access statistics for all monkeys that have been accessed.
    /// </summary>
    /// <returns>A dictionary with monkey names and their access counts.</returns>
    public static Dictionary<string, int> GetAccessStatistics()
    {
        return new Dictionary<string, int>(_accessCounts);
    }

    /// <summary>
    /// Gets the most popular monkey based on access count.
    /// </summary>
    /// <returns>The name of the most accessed monkey, or null if no accesses recorded.</returns>
    public static string? GetMostPopularMonkey()
    {
        if (_accessCounts.Count == 0)
            return null;

        return _accessCounts.OrderByDescending(kvp => kvp.Value).First().Key;
    }

    /// <summary>
    /// Resets all access counts to zero.
    /// </summary>
    public static void ResetAccessCounts()
    {
        _accessCounts.Clear();
        _totalAccesses = 0;
    }

    /// <summary>
    /// Gets all unique locations where monkeys are found.
    /// </summary>
    /// <returns>A list of unique monkey locations.</returns>
    public static List<string> GetAllLocations()
    {
        var monkeys = GetMonkeys();
        return monkeys.Select(m => m.Location)
                     .Where(location => !string.IsNullOrWhiteSpace(location))
                     .Distinct()
                     .OrderBy(location => location)
                     .ToList();
    }

    /// <summary>
    /// Increments the access count for a specific monkey.
    /// </summary>
    /// <param name="monkeyName">The name of the monkey to increment.</param>
    private static void IncrementAccessCount(string monkeyName)
    {
        if (string.IsNullOrWhiteSpace(monkeyName))
            return;

        if (_accessCounts.ContainsKey(monkeyName))
        {
            _accessCounts[monkeyName]++;
        }
        else
        {
            _accessCounts[monkeyName] = 1;
        }
    }

    /// <summary>
    /// Increments the total access count.
    /// </summary>
    private static void IncrementTotalAccess()
    {
        _totalAccesses++;
    }
}