# Brukerhandlinger

Biblioteket støtter tilpassede brukerhandlinger via grensesnittet `IUserAction`. Dette markeres med attributtet `ImplementableByApps` slik at handlingene kan implementeres i appen.

```csharp
public interface IUserAction
{
    /// <summary>
    /// Id til handlingen
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Metode som utfører selve handlingen
    /// </summary>
    Task<UserActionResult> HandleAction(UserActionContext context);
}
```

`UserActionService` hjelper med å hente riktig implementasjon basert på `Id`.
Innebygde handlinger som "sign" og "pay" kan brukes direkte i prosessdefinisjonen.
Egne handlinger implementeres i app-koden og registreres via avhengighetsinjeksjon.
