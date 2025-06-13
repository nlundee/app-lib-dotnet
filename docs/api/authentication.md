# Autentisering

`AuthenticationController` håndterer tokenfornying og sletting av runtime-cookie.

Kall mot endepunktet returnerer HTTP 200 dersom token ble fornyet, ellers HTTP 400 hvis det feiler.

```csharp
[Authorize]
[HttpGet("{org}/{app}/api/[controller]/keepAlive")]
public async Task<IActionResult> KeepAlive()
```

`InvalidateCookie` fjerner `AltinnStudioRuntime`-cookien.
