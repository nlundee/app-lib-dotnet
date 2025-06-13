# Analyzere

Prosjektet inneholder Roslyn-analyzere som hjelper apputviklere å unngå vanlige feil. Eksempelvis rapporterer `HttpContextAccessorUsageAnalyzer` dersom `IHttpContextAccessor` brukes direkte i appkoden.

Analyserene pakkes som `Altinn.App.Analyzers` og kan refereres fra appens prosjektfil for å få statiske kodevarsler under bygging.
