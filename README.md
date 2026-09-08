# Now Showing for Jellyfin

**Now Showing** is a Jellyfin server plugin that turns selected libraries into a customizable, shareable static catalog website.

Choose the libraries you want to publish, give them guest-friendly names, customize the appearance, and generate a single self-contained `index.html` file. The finished catalog can be uploaded to almost any web host. Public catalogs can also be shared directly as a file—no web server is required.

Now Showing does **not** stream media or provide access to your Jellyfin server. The generated catalog is a read-only listing of the metadata you choose to publish.

## Highlights

- Generates one self-contained `index.html` file.
- Select any combination of the libraries that actually exist on your Jellyfin server.
- Give each library a separate public-facing name without renaming it in Jellyfin.
- Browse all published libraries or jump directly to an individual library.
- Search titles and filter by genre.
- Sort by title, genre, newest year, or oldest year.
- Choose **Cards** or a responsive, sortable **Columnar** layout.
- Choose **Serif** or **Sans Serif** text.
- Start with Default, Dark, Retro, or Custom color presets, then customize colors individually.
- Use the built-in generic banner, upload your own JPG/PNG/WebP banner, or use no banner.
- Add an optional site name, tagline, footer, and “Catalog updated” timestamp.
- Generate a public catalog or an optionally password-protected one.
- Preview changes from inside the Jellyfin dashboard before generating the site.
- Movie libraries list movies; TV libraries list series rather than every episode.
- Large libraries are retrieved in pages rather than assuming a fixed maximum size.

## How it works

1. Install Now Showing on your Jellyfin server.
2. Open **Dashboard > Now Showing**.
3. Select the libraries you want to publish and optionally give them public names.
4. Customize the banner, colors, typography, display style, search/filter options, and access settings.
5. Preview the site.
6. Click **Generate Website**.
7. Upload the resulting `index.html` to your web host—or share a public catalog directly as a file.

The generated site is static. After it has been generated, it does not connect back to Jellyfin and contains no Jellyfin server URL, API token, username, or Jellyfin password.

## Sharing without a web server

A public catalog is just an HTML file, so you can also send it to someone directly. The recipient can save `index.html` and open it in a modern browser. Some email services block raw HTML attachments; putting the file in a ZIP usually avoids that problem.

Password-protected catalogs are intended to be served over **HTTPS**, because their browser-side decryption uses the Web Crypto API.

## Appearance

### Branding

- Site name and tagline are blank by default.
- Built-in unbranded media banner.
- Optional custom JPG, PNG, or WebP banner.
- **1600 × 400 pixels (4:1)** is recommended for custom banners.
- Optional no-banner mode.
- Custom banners are embedded into the generated HTML, so the finished website remains a single file.

### Themes and typography

Now Showing includes Default, Dark, Retro, and Custom theme modes. You can independently adjust:

- Page background
- Panel background
- Primary text
- Secondary text
- Accent color
- Button background
- Button text

Text can use **Serif** or **Sans Serif** styling. Catalog content can use the **Cards** layout or a responsive **Columnar** layout.

## Password protection

A generated catalog can be either:

- **Public** — no password required.
- **Password protected** — catalog metadata is encrypted before export.

Password-protected catalogs use AES-256-GCM authenticated encryption with a PBKDF2-HMAC-SHA256 password-derived key. The publication password is used while generating the site and is **not saved** in Now Showing settings.

Because the encrypted HTML file can be downloaded, an attacker can attempt offline password guessing. Use a reasonably strong password. If the catalog contains genuinely sensitive information, protect it at the web-server/hosting layer as well.

## Privacy and network behavior

Now Showing does not include telemetry, advertising, analytics, or calls to third-party services. The plugin reads metadata from the Jellyfin server on which it is installed and generates a static catalog from that metadata.

The generated site does not contact Jellyfin or any external service after publication.

## Compatibility

The first public release targets:

- Jellyfin **10.11.11**
- .NET **9.0**

Jellyfin plugin package references generally need to match the Jellyfin server version. If you are building for another Jellyfin release, update both `Jellyfin.Controller` and `Jellyfin.Model` in:

`Jellyfin.Plugin.NowShowing/Jellyfin.Plugin.NowShowing.csproj`

## Installation

### Through Jellyfin's plugin catalog

In Jellyfin, open **Dashboard > Plugins > Repositories**, add a repository named **Now Showing**, and use this manifest URL:

`https://raw.githubusercontent.com/jimheid/jellyfin-plugin-now-showing/main/manifest.json`

After saving the repository, return to the plugin catalog, find **Now Showing**, and install it there. Installing through the repository lets Jellyfin display the plugin owner/repository metadata and makes future updates easier to discover.

### From a GitHub Release

1. Download the latest Now Showing release ZIP from the **Releases** section of this repository.
2. Stop Jellyfin.
3. Create a folder named `Now Showing` inside Jellyfin's plugins directory.
4. Extract `Jellyfin.Plugin.NowShowing.dll` into that folder.
5. Start Jellyfin.
6. Open **Dashboard > Now Showing**.

Common plugin locations include:

- macOS: `~/Library/Application Support/Jellyfin/plugins/`
- Linux packages: `/var/lib/jellyfin/plugins/`
- Windows direct install: `%LOCALAPPDATA%\\jellyfin\\plugins\\`
- Windows tray install: `%PROGRAMDATA%\\Jellyfin\\Server\\plugins\\`

Your installation may use a different data directory.

## Building from source

Install the .NET 9 SDK, then from the repository folder run:

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

## Release builds

A GitHub Actions workflow is included. Pushing a version tag such as `v1.0.0` builds the plugin and creates a GitHub Release containing a ready-to-install ZIP plus SHA-256 and MD5 checksum files.

The root-level `manifest.json` is the Jellyfin plugin-repository manifest. When publishing a new release, add its version, release ZIP URL, MD5 checksum, target Jellyfin ABI, and timestamp to the top of the manifest's `versions` list.

## Development note

Now Showing was developed with extensive AI assistance. Feature design, requirements, iterative testing, and acceptance decisions were performed by the project maintainer against a working Jellyfin installation. AI was used to generate and revise substantial portions of the code and documentation.

The source is public so users can inspect it, build it themselves, report problems, and contribute improvements. Bug reports and code review are welcome.

## Reporting bugs

Please use the repository's **Issues** tab. When possible, include:

- Jellyfin server version
- Now Showing version
- Browser and operating system
- Steps to reproduce the problem
- Relevant Jellyfin log messages or browser-console errors

Please do not post passwords, API keys, server credentials, or other secrets in an issue.

## Project scope

Version 1.0 intentionally does **not** upload the generated site for you. FTP/SFTP publishing and other automated deployment methods may be considered later, but the 1.0 workflow is deliberately simple: **configure, preview, generate, upload/share**.

Now Showing is an independent community plugin and is not affiliated with or endorsed by the Jellyfin project.

## License

MIT. See [LICENSE](LICENSE).
