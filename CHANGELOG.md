# Changelog

## 1.0.8

- Stacked the four main configuration steps vertically in numeric order: Identity, Content, Appearance, Access. This gives Live Preview a substantially larger column and makes the configuration area more reliable at narrower desktop widths.
- Increased the fixed-header clearance used by Live Preview so its heading no longer scrolls underneath Jellyfin’s narrow top bar.
- Rephrased the Appearance guidance to “Start with a preset, then customize as desired.”
- Added Text style choices: Serif and San Serif. The live preview, generated catalog, and password gate all reflect the selected text style.

## 1.0.7

- Replaced CSS `position: sticky` for Live Preview with Jellyfin-aware scroll tracking. Jellyfin dashboard pages can scroll inside transformed/overflow containers that prevent normal sticky positioning from behaving consistently.
- Live Preview now stays in its own grid column and is translated as the Jellyfin page scrolls, so it remains visible on desktop-sized layouts without covering the configuration controls.
- Added resize/preview-size tracking so the floating position stays correct when the browser is resized or the preview changes height.
- Mobile/tablet stacked layouts continue to use normal document flow.

## 1.0.6

- Live Preview now stays pinned beside the configuration controls while the Jellyfin settings page scrolls on desktop-sized layouts. The preview gets its own viewport-height scroll area when needed, so it remains usable even when the preview is taller than the browser window.
- Lowered the side-by-side-to-stacked breakpoint so Live Preview remains sticky on more desktop and laptop window sizes.
- Moved the “Catalog updated” timestamp and Footer text controls out of the separate Additional options panel and into Appearance, where they affect the generated site's presentation.
- Removed the separate panel 5; Appearance remains panel 3, preserving the numbering established in v1.0.4.

## 1.0.5

- Moved the Appearance panel ahead of Content in the dashboard layout while retaining panel numbers 3 and 2, placing appearance controls closer to Live Preview.
- Removed the unwanted solid band from the built-in 1600 × 400 default banner.
- Password-protected login pages now inherit the selected page, panel, text, accent, button, and button-text colors before the catalog is unlocked. Retro theme login headings also use the retro heading font.
- Added accent styling to the password card and focus state so the login screen visibly matches the selected theme.
- Retained Custom banner behavior: Choose File remains disabled until Custom banner is selected.

## 1.0.4

- Added Cards and Columnar website display styles.
- Columnar view is responsive and supports sorting by Title, Genre, and Release Year.
- Live Preview now reflects the selected display style.
- Reordered/renumbered Content as panel 2 and Appearance as panel 3.
- Renamed the custom-banner option and disabled the file picker unless Custom banner is selected.
- Replaced the default banner with a text-free film-reel / filmstrip design.

## 1.0.3

Generated-site template fix.

- Removed all `${...}` interpolation markers from the embedded Jellyfin dashboard page. Jellyfin's dashboard-page processing could rewrite those markers before the generator ran, which produced literal `lockMarkup` text, missing password markup, and nearly blank generated/preview pages.
- Generated-site HTML now uses neutral `@@TOKEN@@` placeholders that are replaced only by Now Showing at generation time.
- Public output is verified to contain no password form; protected Preview is verified to contain the password gate and remain hidden until the correct preview password is entered.
- Added generation-time integrity checks so unresolved template tokens or mismatched public/protected markup are reported instead of downloading a broken page.

## 1.0.2

Second test-fix update focused on publication-state accuracy.

- Fixed public Preview incorrectly inheriting password-protected state.
- Fixed public generated HTML failing during startup and appearing nearly blank.
- Preview and Generate now capture one immutable snapshot of the on-screen settings before asynchronous Jellyfin calls.
- Generated catalogs now use that captured library selection and public-name mapping instead of re-reading the live dashboard DOM.
- Live Preview uses the same selected-library/public-name snapshot logic and makes each selected library visually distinct.
- Added robust support for both PascalCase and camelCase Jellyfin configuration/API JSON.
- Password-protected Preview now has a local preview-only password gate, so it can be tested even when the Jellyfin dashboard itself is using HTTP. Generated protected sites remain AES-GCM encrypted and require HTTPS for browser decryption.
- Made plugin-page initialization idempotent to avoid duplicate event handlers on repeated dashboard page initialization.

## 1.0.1

First test-fix update.

- Live preview now reflects the libraries currently selected for publication and their public-facing names.
- Live preview respects the selected starting view instead of always showing the first sample library.
- Added a 1600 × 400 pixel (4:1) banner recommendation.
- Preview and Generate now require a password and confirmation when Password protected is selected.
- Password-protected Preview now includes the actual password gate so it can be tested before export.
- Public exports no longer contain the password dialog markup.
- Hardened browser-side AES-GCM decryption and error handling.
- Added show/hide password eyeball buttons to both dashboard password fields and the generated protected page.
- Added XML documentation to public configuration/API members to clean up CS1591 warnings before GitHub publication.

## 1.0.0

Initial release candidate.

- Generates a single self-contained `index.html` catalog from selected Jellyfin libraries.
- Separate plugin identity from Simple Catalog, so both can be installed together.
- Blank site name and tagline by default.
- Built-in generic, unbranded banner plus custom-banner upload and no-banner modes.
- Default, Dark, Retro, and Custom appearance modes.
- Color pickers with editable hex values.
- Per-library include controls and public-facing aliases.
- All-library and individual-library browsing.
- Title search, genre filtering, and title/genre/year sorting.
- Optional display of release year and genre.
- Public or password-protected site generation.
- AES-256-GCM encryption with PBKDF2-HMAC-SHA256 for password-protected catalogs.
- Optional noindex/nofollow/noarchive metadata.
- Optional catalog-updated timestamp and custom footer text.
- Live sample preview and full-page preview.
- No FTP/SFTP publishing in 1.0; generated files are uploaded manually.
