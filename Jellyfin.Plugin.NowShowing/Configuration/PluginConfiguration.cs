using System.Collections.Generic;
using MediaBrowser.Model.Plugins;

namespace Jellyfin.Plugin.NowShowing.Configuration;

/// <summary>
/// Stores persistent Now Showing settings. Publication passwords are deliberately excluded.
/// </summary>
public sealed class PluginConfiguration : BasePluginConfiguration
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PluginConfiguration"/> class with safe defaults.
    /// </summary>
    public PluginConfiguration()
    {
        SiteName = string.Empty;
        Tagline = string.Empty;
        BannerMode = "default";
        CustomBannerDataUrl = string.Empty;
        ThemePreset = "default";
        TextStyle = "sans";
        PageBackground = "#F3F0E8";
        PanelBackground = "#FFFFFF";
        PrimaryText = "#262626";
        SecondaryText = "#666666";
        AccentColor = "#355C7D";
        ButtonBackground = "#355C7D";
        ButtonText = "#FFFFFF";
        StartingLibraryId = "__all__";
        DefaultSort = "title";
        DisplayStyle = "cards";
        ShowReleaseYear = true;
        ShowGenre = true;
        EnableSearch = true;
        EnableGenreFilter = true;
        AccessMode = "protected";
        DiscourageIndexing = true;
        ShowUpdatedTimestamp = true;
        FooterText = string.Empty;
        Libraries = new List<LibraryPublicationSetting>();
    }

    /// <summary>Gets or sets the optional public site name.</summary>
    public string SiteName { get; set; }

    /// <summary>Gets or sets the optional public tagline.</summary>
    public string Tagline { get; set; }

    /// <summary>Gets or sets the banner mode: default, custom, or none.</summary>
    public string BannerMode { get; set; }

    /// <summary>Gets or sets the resized custom banner as a data URL.</summary>
    public string CustomBannerDataUrl { get; set; }

    /// <summary>Gets or sets the theme preset: default, dark, retro, or custom.</summary>
    public string ThemePreset { get; set; }

    /// <summary>Gets or sets the catalog text style: serif or sans.</summary>
    public string TextStyle { get; set; }

    /// <summary>Gets or sets the page background color.</summary>
    public string PageBackground { get; set; }

    /// <summary>Gets or sets the panel background color.</summary>
    public string PanelBackground { get; set; }

    /// <summary>Gets or sets the primary text color.</summary>
    public string PrimaryText { get; set; }

    /// <summary>Gets or sets the secondary text color.</summary>
    public string SecondaryText { get; set; }

    /// <summary>Gets or sets the accent color.</summary>
    public string AccentColor { get; set; }

    /// <summary>Gets or sets the button background color.</summary>
    public string ButtonBackground { get; set; }

    /// <summary>Gets or sets the button text color.</summary>
    public string ButtonText { get; set; }

    /// <summary>Gets or sets the Jellyfin library ID used as the starting view, or __all__.</summary>
    public string StartingLibraryId { get; set; }

    /// <summary>Gets or sets the default sort: title, genre, yearAsc, or yearDesc.</summary>
    public string DefaultSort { get; set; }

    /// <summary>Gets or sets the catalog display style: cards or columnar.</summary>
    public string DisplayStyle { get; set; }

    /// <summary>Gets or sets a value indicating whether release years are displayed.</summary>
    public bool ShowReleaseYear { get; set; }

    /// <summary>Gets or sets a value indicating whether genres are displayed.</summary>
    public bool ShowGenre { get; set; }

    /// <summary>Gets or sets a value indicating whether title search is enabled.</summary>
    public bool EnableSearch { get; set; }

    /// <summary>Gets or sets a value indicating whether genre filtering is enabled.</summary>
    public bool EnableGenreFilter { get; set; }

    /// <summary>Gets or sets the site access mode: public or protected.</summary>
    public string AccessMode { get; set; }

    /// <summary>Gets or sets a value indicating whether search-engine indexing should be discouraged.</summary>
    public bool DiscourageIndexing { get; set; }

    /// <summary>Gets or sets a value indicating whether the catalog update date is shown.</summary>
    public bool ShowUpdatedTimestamp { get; set; }

    /// <summary>Gets or sets optional footer text for the generated site.</summary>
    public string FooterText { get; set; }

    /// <summary>Gets or sets publication settings for the Jellyfin libraries discovered on this server.</summary>
    public List<LibraryPublicationSetting> Libraries { get; set; }
}

/// <summary>
/// Stores the publication choice and public-facing alias for one Jellyfin library.
/// </summary>
public sealed class LibraryPublicationSetting
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LibraryPublicationSetting"/> class.
    /// </summary>
    public LibraryPublicationSetting()
    {
        Id = string.Empty;
        PublicName = string.Empty;
    }

    /// <summary>Gets or sets the Jellyfin library ID.</summary>
    public string Id { get; set; }

    /// <summary>Gets or sets the public-facing library name.</summary>
    public string PublicName { get; set; }

    /// <summary>Gets or sets a value indicating whether this library is included in the published catalog.</summary>
    public bool Included { get; set; }
}
