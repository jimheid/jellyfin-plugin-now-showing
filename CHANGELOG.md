# Changelog

## 1.0.0 — Initial public release

- Generates a single self-contained `index.html` catalog from selected Jellyfin libraries.
- Detects the libraries that exist on the installed Jellyfin server.
- Per-library include controls and public-facing aliases.
- All-library and individual-library browsing.
- Title search and genre filtering.
- Sort by title, genre, newest year, or oldest year.
- Cards and responsive, sortable Columnar display styles.
- Serif and Sans Serif text styles.
- Default, Dark, Retro, and Custom appearance modes.
- Color pickers with editable web-color values.
- Built-in unbranded banner, custom-banner upload, and no-banner modes.
- Blank site name and tagline by default.
- Optional release year and genre display.
- Optional catalog-updated timestamp and footer text.
- Public or password-protected site generation.
- AES-256-GCM encryption with PBKDF2-HMAC-SHA256 for password-protected catalogs.
- Optional noindex/nofollow/noarchive metadata.
- Live preview that reflects selected libraries, public names, appearance choices, and display style.
- Password-protected preview for testing before export.
- Password show/hide controls.
- Responsive dashboard and generated-site layouts.
- Movie libraries list movies; TV libraries list series rather than individual episodes.
- Paginated Jellyfin metadata retrieval for large libraries.
- No telemetry or third-party service dependencies.
- No FTP/SFTP publishing in 1.0; generated files are uploaded or shared manually.
