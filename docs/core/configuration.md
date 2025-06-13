# Konfigurasjon

`GeneralSettings` klassen samler sentrale konfigurasjonsverdier for apper. Flere av egenskapene er forklart i kildekoden med XML-kommentarer.

```csharp
public class GeneralSettings
{
    /// <summary>
    /// Prefiks som benyttes i mykere valideringsmeldinger.
    /// </summary>
    public string SoftValidationPrefix { get; set; } = "*WARNING*";

    /// <summary>
    /// Navnet på cookien som lagrer valgt party.
    /// </summary>
    public string AltinnPartyCookieName { get; set; } = "AltinnPartyId";
    /// <summary>
    /// Adressen applikasjonen tilgjengeliggjøres på.
    /// </summary>
    public string HostName { get; set; } = "local.altinn.cloud";

    /// <summary>
    /// Base-URL som bygges opp med øvrige innstillinger.
    /// </summary>
    public string ExternalAppBaseUrl { get; set; } = "http://{hostName}/{org}/{app}/";
}
```
`GeneralSettingsExtensions.FormattedExternalAppBaseUrlWithTrailingPound` kan
brukes for å generere URL med trailing `/#` slik frontend forventer.

`GeneralSettings` kan injiseres via `IOptions<GeneralSettings>` og benyttes i kontroller eller tjenester.

Miljøinformasjon håndteres av `AltinnEnvironments`, som kartlegger ulike miljønavn til et `HostingEnvironment`-oppsett.
