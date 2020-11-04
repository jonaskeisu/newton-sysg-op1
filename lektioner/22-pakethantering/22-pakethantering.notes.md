---
presentation:
  width: 1200
  height: 600
  theme: 'serif.css'
  center: false
  slideNumber: true
---
<style type="text/css">
  .reveal h1 {
    display: inline;
    text-align: center;
    display: flex;
    flex-direction: column;
    align-items: center;
  }
  .reveal p {
    text-align: left;
  }
  .reveal ul {
    display: block;
  }
  .reveal ol {
    display: block;
  }
  .reveal section {
    resize: false;
    width: 100%;
    height: 100;
    text-align: left;
   
  }
  .reveal pre {
    zoom: 110%;
  }
  div.slides{
    # border: 1px solid black;
  }
  .reveal code {
    zoom: 90%;
  }
</style>

<!-- slide -->

# Pakhethantering

<!-- slide -->

## NuGet 

- Pakethanteraren för .NET heter NuGet
- NuGet hanterar paket med avseende på:
  - Version
  - Targets
  - Beroenden
- Publika mjukvarupaket i NuGet kan sökas på [nuget.org](https://www.nuget.org/)
- Möjliggör återanvänding av andras kod

<!-- slide -->

## Lägga till ett NuGet-packetberoende 

- Gå till aktuell katalog för projektet i konsolen
- Ge kommandot: ``dotnet add package <paketnamn>``

Exempel: 

```console
dotnet add package Newtonsoft.Json
```

<!-- slide -->

## Publicera NuGet-paket 

- Nogranna instruktioner för hur assemblies paketeras och publiceras med NuGet finns [här](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli). 

