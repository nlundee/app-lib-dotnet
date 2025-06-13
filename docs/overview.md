# Arkitekturoversikt

Dette dokumentet gir et helhetlig bilde av bibliotekene i dette prosjektet og hvordan de henger sammen. Informasjonen er basert på inline-dokumentasjonen i kildekoden kombinert med en overordnet forståelse av prosjektet.

## Komponenter

- **Altinn.App.Core** – Kjernefunksjonalitet for Altinn-applikasjoner. Her finnes modeller, tjenester og grensesnitt for prosesshåndtering, datalagring, autentisering og integrasjon mot eksterne systemer.
- **Altinn.App.Api** – Web API som eksponerer funksjoner fra `Altinn.App.Core` som HTTP-endepunkter. Inneholder controllere for autentisering, applikasjonsmetadata, handlinger og mer.
- **Altinn.App.Analyzers** – Roslyn-analyzere som hjelper utviklere å skrive riktig app-kode ved å oppdage vanlige feil under kompilering.

I tillegg finnes `Altinn.App.Internal.Analyzers` som inkluderer ekstra analyser beregnet for intern bruk.
Bibliotekene brukes sammen som kjernen i Altinn App runtime. En app generert fra mal i Altinn Studio refererer disse pakkene og kjører i sitt eget ASP.NET Core-prosjekt. Apputvikler kan implementere utvidelsespunkter fra `Altinn.App.Core` for å koble inn egendefinert logikk.


## Flyt mellom lag

Applikasjonens frontend kommuniserer med API-laget i `Altinn.App.Api`. Controllerne her bruker tjenester fra `Altinn.App.Core` til å utføre nødvendig logikk. `Altinn.App.Core` tilbyr igjen klienter og abstraksjoner for å samhandle med Altinn Platform og andre eksterne systemer.
Ved oppstart injiseres tjenestene via dependency injection. For eksempel bruker `DataController` et `IDataClient` som implementeres i biblioteket og kaller Altinn Platform. På denne måten kan appen fokusere på sin egen domenelogikk.

## Utvidbarhet

Mye av funksjonaliteten beskrives gjennom grensesnitt merket med attributtet `ImplementableByApps`. Disse kan app-utviklere implementere i sin egen kode for å koble inn egendefinert logikk. Eksempler er `IUserAction` for å definere brukerhandlinger eller `IInstantiationProcessor` for å tilpasse instansiering av data.

## Testing

Prosjektet inneholder en egen `test`-mappe med enhetstester. Ved å kjøre `dotnet test` kan man verifisere funksjonaliteten i både kjerne og API-lag. (I Codex-miljøet er ikke .NET tilgjengelig, så testene kan ikke kjøres her.)

For mer informasjon om tilgjengelige grensesnitt se [Grensesnittoversikt](interfaces.md).
