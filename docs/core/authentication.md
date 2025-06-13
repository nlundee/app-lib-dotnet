# Autentiseringsmodell

`Altinn.App.Core` benytter klassen `AuthenticationContext` for å lese innloggingsinformasjon fra `HttpContext`.
Metoden `Parse` analyserer JWT tokenet og returnerer en av typene som arver fra `Authenticated`:

- `Authenticated.User` for innloggede brukere
- `Authenticated.SystemUser` for systemtokener
- `Authenticated.Org` for organisasjoner
- `Authenticated.None` dersom forespørselen ikke er autentisert

Eksempel på bruk i en controller:

```csharp
public class ExampleController(AuthenticationContext authCtx)
{
    [HttpGet]
    public IActionResult CurrentUser()
    {
        var auth = authCtx.Authentication;
        if (auth is Authenticated.User user)
        {
            return Ok($"Logged in as {user.UserId}");
        }
        return Unauthorized();
    }
}
```
