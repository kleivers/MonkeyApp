// Monkey model representing monkey data from MonkeyMCP
using System;

namespace MyMonkeyApp;

/// <summary>
/// Represents a monkey species with details and location information.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey species.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the location or habitat of the monkey.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets interesting details about the monkey.
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the URL to an image or ASCII art representation of the monkey.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the estimated population of the monkey species.
    /// </summary>
    public int? Population { get; set; }

    /// <summary>
    /// Gets or sets the latitude of the monkey's habitat.
    /// </summary>
    public double? Latitude { get; set; }

    /// <summary>
    /// Gets or sets the longitude of the monkey's habitat.
    /// </summary>
    public double? Longitude { get; set; }
}