# Eksterne API-er

`IExternalApiService` gir tilgang til data fra definerte eksterne API-er. Hver integrasjon implementerer `IExternalApiClient` som registreres via `IExternalApiFactory`.

For å hente data benyttes `GetExternalApiData`:

```csharp
var result = await externalApiService.GetExternalApiData(
    externalApiId: "myApi",
    instanceIdentifier: instanceId,
    queryParams: new Dictionary<string, string>()
);
if (result.WasExternalApiFound)
{
    // result.Data inneholder svaret fra API-et
}
```

Integrasjonene konfigureres i appens `applicationmetadata.json` hvor det defineres hvilke API-id-er som er tilgjengelige.
