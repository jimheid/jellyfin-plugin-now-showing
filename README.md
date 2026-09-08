# Now Showing for Jellyfin

**Now Showing** turns selected Jellyfin libraries into a customizable static catalog website that you can upload to any ordinary web host. This source tree is currently at **v1.0.8**.

The generated site is a single self-contained `index.html` file. It never connects back to Jellyfin after publication and contains no Jellyfin server URL, API token, username, or password.

## 1.0 features

### Branding

- Blank site name by default.
- Blank tagline by default.
- Generic built-in media banner with no branding or text.
- Upload a custom JPG, PNG, or WebP banner. **1600 × 400 pixels (4:1) is recommended.**
- Or generate the site with no banner.
- Custom banners are resized in the dashboard before being stored in plugin configuration and embedded into the generated page.

### Appearance

- Default, Dark, Retro, and Custom theme modes.
- Color picker + editable hex value for:
  - page background
  - panel background
  - primary text
  - secondary text
  - accent color
  - button background
  - button text
- Reset Colors button.
- Serif or San Serif text styles, reflected in Live Preview and the generated site.
- Cards or responsive, sortable Columnar display styles.
- Optional “Catalog updated” timestamp and custom footer text are configured in Appearance.
- The four configuration steps are stacked vertically in order, leaving more room for a larger Live Preview beside them.
- Live Preview stays visible beside the controls while scrolling on desktop-sized layouts, with clearance for Jellyfin’s fixed top bar.
- Responsive desktop, tablet, and phone layouts.

### Content

- Select which Jellyfin libraries to publish.
- Give every library its own public-facing name without renaming it in Jellyfin.
- Choose the initial view: All libraries or one selected library.
- Default sort by title, genre, newest year, or oldest year.
- Optional release year and genre display.
- Optional title search and genre filter.
- Movie libraries list movies; TV libraries list series rather than episodes.
- Large libraries are fetched in pages rather than assuming a fixed maximum size.

### Access

The generated catalog can be either:

- **Public** — no password required.
- **Password protected** — catalog metadata is encrypted before export.

Password-protected catalogs use AES-256-GCM authenticated encryption with a PBKDF2-HMAC-SHA256 password-derived key. The publication password is used only while generating the site and is **never saved** in Now Showing settings.

A password-protected static file can still be downloaded and subjected to offline password guessing, so use a reasonably strong password. For highly sensitive material, use authentication at the web-server or hosting layer as well.

Password-protected catalogs should be hosted over **HTTPS**, because browser Web Crypto is generally available only in secure contexts.

### Publication

Version 1.0 intentionally does **not** include FTP/SFTP publishing.

Workflow:

1. Configure the site in Jellyfin.
2. Click **Preview Website** if desired. The preview uses the currently selected libraries and public names. If password protection is selected, the preview reproduces the password gate and validates the password you entered without requiring HTTPS. The downloaded protected site uses the real encrypted payload.
3. Click **Generate Website**. Password-protected previews and exports require an 8+ character password and matching confirmation. The downloaded protected site should be hosted over HTTPS.
4. Upload the resulting `index.html` file to your web host.

## Coexists with Simple Catalog

Now Showing has its own:

- plugin name
- assembly/DLL name
- plugin GUID
- configuration file
- dashboard page

It can therefore be installed alongside **Simple Catalog** without replacing or changing Simple Catalog.

## Jellyfin compatibility

This source targets:

- Jellyfin **10.11.11**
- .NET **9.0**

Jellyfin plugin package references should match the server version. If you target another Jellyfin release, change both `Jellyfin.Controller` and `Jellyfin.Model` versions in:

`Jellyfin.Plugin.NowShowing/Jellyfin.Plugin.NowShowing.csproj`

## Build

Install the .NET 9 SDK, then run:

```bash
chmod +x build.sh
./build.sh
```

The primary output is:

`publish/Jellyfin.Plugin.NowShowing.dll`

Equivalent manual commands:

```bash
dotnet restore Jellyfin.Plugin.NowShowing/Jellyfin.Plugin.NowShowing.csproj
dotnet publish Jellyfin.Plugin.NowShowing/Jellyfin.Plugin.NowShowing.csproj -c Release --no-self-contained -o publish
```

## Manual installation

1. Stop Jellyfin.
2. Create a plugin folder named `Now Showing` in Jellyfin's plugins directory.
3. Copy `Jellyfin.Plugin.NowShowing.dll` into that folder.
4. Start Jellyfin.
5. Open Dashboard > **Now Showing**.

Typical plugin locations include:

- Linux packages: `/var/lib/jellyfin/plugins/`
- Windows direct install: `%LOCALAPPDATA%\\jellyfin\\plugins\\`
- Windows tray install: `%PROGRAMDATA%\\Jellyfin\\Server\\plugins\\`

## Default banner

The source artwork is in:

`Jellyfin.Plugin.NowShowing/Assets/default-banner.png`

The dashboard embeds the banner into the generated HTML so the finished website remains a single file.

## GitHub releases

A GitHub Actions workflow is included. Pushing a tag such as `v1.0.8` builds the plugin and attaches a ready-to-install ZIP to a GitHub Release.

## License

MIT. See `LICENSE`.
