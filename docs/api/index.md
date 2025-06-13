# API-biblioteket

`Altinn.App.Api` tilbyr kontroller og endepunkter som eksponerer funksjonalitet i en Altinn-app.

Eksempelvis har `AuthenticationController` metoder for å forlenge token og invalidere cookie.

Tilgjengelige kontroller inkluderer blant annet:
- `AccountController` for innlogging
- `ApplicationMetadataController` som eksponerer app-informasjon
- `ActionsController` for brukerhandlinger
- `AuthenticationController` for tokenbehandling


```csharp
[Authorize]
[HttpGet("{org}/{app}/api/[controller]/keepAlive")]
public async Task<IActionResult> KeepAlive()
```

Se også [Autentisering](authentication.md) for en nærmere beskrivelse.
