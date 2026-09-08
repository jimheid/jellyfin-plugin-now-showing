using System;
using System.Collections.Generic;
using Jellyfin.Plugin.NowShowing.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.NowShowing;

/// <summary>
/// Now Showing plugin entry point.
/// </summary>
public sealed class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
{
    private static readonly Guid PluginId = Guid.Parse("1481bd52-3078-4e98-ad1c-69ce06a436bb");

    /// <summary>
    /// Initializes a new instance of the <see cref="Plugin"/> class.
    /// </summary>
    public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
        : base(applicationPaths, xmlSerializer)
    {
        Instance = this;
    }

    /// <summary>
    /// Gets the active plugin instance.
    /// </summary>
    public static Plugin? Instance { get; private set; }

    /// <inheritdoc />
    public override string Name => "Now Showing";

    /// <inheritdoc />
    public override string Description => "Creates customizable, optionally password-protected static catalog websites from Jellyfin libraries.";

    /// <inheritdoc />
    public override Guid Id => PluginId;

    /// <inheritdoc />
    public IEnumerable<PluginPageInfo> GetPages()
    {
        yield return new PluginPageInfo
        {
            Name = "NowShowing",
            DisplayName = "Now Showing",
            EmbeddedResourcePath = $"{GetType().Namespace}.Configuration.config.html",
            EnableInMainMenu = true,
            MenuSection = "server"
        };
    }
}
