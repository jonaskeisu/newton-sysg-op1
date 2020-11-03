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
    border: 1px solid black;
  }
  .reveal code {
    zoom: 90%;
  }
</style>

<!-- slide -->

# Grafiska användar-gränssnitt

<!-- slide -->

## Olika typer av applikationer

- Fönsterapplikationer
  - Konsolen, webbläsare, ordbehandlare, etc. 
- Tjänster (*services*)
  - Webbserver, databasserver, remote access-server,  etc.
  - Har inget fönster, kör "i bakgrunden"
- Driftade applikationer
  - Körs av en *värdapplikation* för att utföra arbete 
  - Data skickas mellan värdapplikation och back-end-applikation över ett väldefinierat gränssnitt

<!-- slide -->


## Konsolapplikationer

- I en konsolapplikation har applikationen inget eget fönster
- Applikationen interagerar med användaren via textströmmar kopplade till konsolen som har ett fönster
- Exempel på en driftad applikation

<!-- slide -->

## Fönsterapplikation

- En applikation med grafiskt användargränssnitt (GUI) har egna fönster, med full kontroll över deras utseende och beteenden


<!-- slide -->

## Konsolapp vs. Fönsterapp

<center style="zoom: 1.5">

```plantuml
rectangle "=Operativssystem" {
    rectangle Konsol as term

    rectangle "Konsolapp" as termapp

    rectangle Fönster as termwin

    term <--> "0..1" termapp : Textström

    term "1" --> "1" termwin

    rectangle "Fönsterapp" as guiapp

    rectangle Fönster as guiwin

    guiapp "1" --> "1..*" guiwin
}
```

</center>

<!-- slide -->

## Hur fungerar fönsterappar?

- Operativsystemet har en fönsterhanterare som kontrollerar alla fönsters position och storlek samt bestämmer aktivt fönster
- En aktiv fönsterapplikation kan monitorera och reagera på vad användaren gör med t.ex. mus och tangentbord

<center style="zoom: 1.2">

```plantuml
Tangentbord -> "Aktivt fönster": Tangttryckningar
Mus -> "Aktivt fönster": Ny pekarposition
Mus -> "Aktivt fönster": Knapp tryckning
```

</center>
<!-- slide -->

### Ramverk för fönsterapplikationer

- För att göra det enklare att designa en fönsterapplikation används ofta ett *ramverksbibliotek*
  - T.ex. [WinForms](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/overview/?view=netdesktop-5.0), [WPF](https://docs.microsoft.com/en-us/visualstudio/designers/getting-started-with-wpf?view=vs-2019) , [UWP](https://docs.microsoft.com/en-us/windows/uwp/), [Xamarin](https://dotnet.microsoft.com/apps/xamarin), [Unity](https://unity.com/), [Avalonia](https://avaloniaui.net/)
- I denna lektion tittar vi på exempel med Avalonia som är ett plattformsoberende ramverk
  - .. men principen är densamma i WPF, UWP och Xamarin. 

<!-- slide -->

## Utseende och logik

- Det är god form att separa utseende från logik i en grafisk applikation
- Inom webb beskrivs t.ex. utseende på webbsidor med HTML-data och logiken i webbsidan med JavaScript-kod
- På motsvarande sätt inom .NET beskrivs utseende för en fönsterapplikation typiskt med XAML-data och logiken med t.ex. C#-kod

<!-- slide -->

## XAML

- XAML står för *eXtensible Application Markup Language*
- XAML används bl.a. i WPF, UWP, Xamarin och Avalonia
- Syntaxen bygger på [XML](https://www.w3schools.com/xml/) och har vissa likheter med HTML
- Används för att beskriva en hierarki (trädstruktur) av grafiska komponenter
- I hierarkin motsvaras varje komponent av ett XML-*element* och egenskaper för en komponent sätts med hjälp av *attribut* för elementen

<!-- slide -->

### Exempel



<div style="display: flex">

<div style="width: 80%">
XAML

<div style="zoom: 0.6">

```xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d" d:DesignWidth="800" d:DesignHeight="450"
        x:Class="Example.MainWindow"
        Width="100" Height="100"
        Title="Example">    
    <StackPanel>
        <Button Name="Red button" Margin="5" Background="Red">Röd knapp</Button>
        <Button Name="Green button" Margin="5" Background="Green"> Grön knapp </Button>
        <Button Name="Blue button" Margin="5" Background="Blue"> Blå knapp </Button>
    </StackPanel>
</Window>
```
</div>
</div>

<div>
Resultat

<image style="border: none; zoom: 1" src="fig/red%20green%20blue%20buttons.png"/>
</div>
</div>

<!-- slide -->

## Fönster, paneler och kontroller

- Ramverk delar ofta upp ett fönsters skärmyta i delareor
- Varje area tillhör en *grafisk komponent*
- Grafiska komponenterna kan delas upp i två kategorier
  - Paneler
  - Kontroller

<!-- slide -->

<center>

<image style="border: none; zoom: 0.5" src="fig/window%20panel%20control.png"/>

</center>

<!-- slide -->

## Händelser för grafiska komponenter

- Ramverken översätter aktivitet med mus och tangentbord för aktivt fönster till lättolkade händelser för fönstrets komponenter
- T.ex. knappen är *klickad*, textet i fältet är *ändrad*, fönstret har *ändrat storlek*
- Applikationens logik skapas genom att C#-kod koppas som lyssnare till dessa händelser

<!-- slide -->

## "Koden bakom"

- Attributet ``x:Class`` säger i vilken klass "koden bakom" för en XAML-komponent ligger. 
- I konstruktorn för klassen finns ett anrop till ``InitializeComponent()``-metod som körs när komponenten är initialiserad vid uppstart av Avalonia-applikationen
- Efter denna rad kan vi t.ex. hitta och spara undan referens till  komponenter i ett fönster fönstret samt koppla lyssnare till deras händelser händelser

<!-- slide -->

### Exempel

Innehållet i ``MainWindow.xaml.cs``: 
```cs
namespace Example {
    public class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            // Kod som hitta och lagrar referenser komponenter samt 
            // registrerar lyssnare för deras händelser kan skriva här
        }
        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
```

<!-- slide -->

## Event-handlers

- En event-handler i ett ramverk för fönsterapplikationer tar som regel två argument: 
  - Ett objekt som skickade eventet (*sender*)
  - Ett objekt som innehåller information om händelsen (*e*)

<!-- slide -->

### Exempel

```cs
public class MainWindow : Window {
    Button[] buttons;
    public MainWindow() {
            buttons = new[] { "Red", "Green", "Blue" }
                .Select(s => this.FindControl<Button>(s + " button"))
                .ToArray(); // Spara referenser till alla tre knappar
            foreach (Button b in buttons) {
                var bg = b.Background;
                b.Click += (sender, e) => { // Registera lyssnare ..
                    foreach (Button b in buttons) 
                        b.Background = bg; // .. som sätter knappens 
                };               // originalfärg på samtliga knappar.
            }
    // ...
```

<!-- slide -->

## Kontroller

- En kontroll visar data och/eller tillåter användaren interagera med applikationen
  
<!-- slide -->

## Exempel på kontroller

- Exempel på kontroller är:
  - Etiketter / textfält
  - Knappar
    - Vanliga knappar, radioknappar, checkboxar
  - Reglage / spinners
  - Listor, trädstrukturer, rutnät
  - Bilder
  - Progress bar
  - Kalender

<!-- slide -->

### Exempel

```xml
<Image Width="200" Source="/Assets/cat.png"/>
...
<TextBlock>Etikett</TextBlock>
<TextBox Width="100">Textfält</TextBox>
...
<Button>Knapp</Button>
<RadioButton IsChecked="true"> Radioknapp 1</RadioButton>
<RadioButton>Radioknapp 2</RadioButton>
<CheckBox IsChecked="true">Checkbox</CheckBox> 
...
<Slider Width="100"/>
...
<Calendar/>
```

<!-- slide -->

<center style="margin-top: 2em">

<image style="border: none; zoom: 1.7" src="fig/avalonia%20controls.png"/>

</center>

<!-- slide -->

## Paneler

- En panel används för att arrangera (*layout*) en grupp sammanhörande grafiska komponenter

<!-- slide -->

## Exempel på paneltyper

- Vanliga exempel på paneler är:
  - Stack
  - Dock
  - Wrap
  - Grid 

<!-- slide -->

### StackPanel

```xml
<StackPanel>
    <TextBlock Background="#FF0000">Text 1</TextBlock>
    <TextBlock Background="#0080FF">Text 2</TextBlock>
    <TextBlock Background="#0000FF">Text 3</TextBlock>
    <TextBlock Background="#8000FF">Text 4</TextBlock>
    <TextBlock Background="#FF00FF">Text 5</TextBlock>
    <TextBlock Background="#FF0080">Text 6</TextBlock>
    <TextBlock Background="#FF0000">Text 7</TextBlock>
    <TextBlock Background="#FF8000">Text 8</TextBlock>
    <TextBlock Background="#FFFF00">Text 9</TextBlock>
    <TextBlock Background="#80FF00">Text 10</TextBlock>
    <TextBlock Background="#00FF00">Text 11</TextBlock>
    <TextBlock Background="#00FF80">Text 12</TextBlock>
</StackPanel>
```

<!-- slide -->

<center>

<image style="border: none; zoom: 0.7" src="fig/stack%20layout.png"/>

</center>

<!-- slide -->

### WrapPanel

```xml
<WrapPanel>
    <TextBlock Background="#FF0000">Text 1</TextBlock>
    <TextBlock Background="#0080FF">Text 2</TextBlock>
    <TextBlock Background="#0000FF">Text 3</TextBlock>
    <TextBlock Background="#8000FF">Text 4</TextBlock>
    <TextBlock Background="#FF00FF">Text 5</TextBlock>
    <TextBlock Background="#FF0080">Text 6</TextBlock>
    <TextBlock Background="#FF0000">Text 7</TextBlock>
    <TextBlock Background="#FF8000">Text 8</TextBlock>
    <TextBlock Background="#FFFF00">Text 9</TextBlock>
    <TextBlock Background="#80FF00">Text 10</TextBlock>
    <TextBlock Background="#00FF00">Text 11</TextBlock>
    <TextBlock Background="#00FF80">Text 12</TextBlock>
</WrapPanel>
```

<!-- slide -->

<center>

<image style="border: none; zoom: 1.9" src="fig/wrap%20layout.png"/>

</center>

<!-- slide -->

### DockPanel

```xml
<DockPanel>
    <TextBlock DockPanel.Dock="Left" Background="#FF0000">Text 1</TextBlock>
    <TextBlock DockPanel.Dock="Right" Background="#0080FF">Text 2</TextBlock>
    <TextBlock DockPanel.Dock="Top" Background="#0000FF">Text 3</TextBlock>
    <TextBlock DockPanel.Dock="Bottom" Background="#8000FF">Text 4</TextBlock>
    <TextBlock Background="#FF00FF">Text 5</TextBlock>
</DockPanel>
```

<!-- slide -->

<center>

<image style="border: none;" src="fig/dock%20layout.png"/>

</center>

<!-- slide -->

### Grid

<div style="zoom: 1">

```xml
<Grid ColumnDefinitions="1*, 1*, 1*" RowDefinitions="1*, 1*, 1*, 1*">
    <TextBlock Grid.Row="0" Grid.Column="0" Background="#FF0000">Text 1</TextBlock>
    <TextBlock Grid.Row="0" Grid.Column="1" Background="#0080FF">Text 2</TextBlock>
    <TextBlock Grid.Row="0" Grid.Column="2"  Background="#0000FF">Text 3</TextBlock>
    <TextBlock Grid.Row="1" Grid.Column="0" Grid.RowSpan="2" 
               Grid.ColumnSpan="2" Background="#8000FF">Text 4</TextBlock>
    <TextBlock Grid.Row="1" Grid.Column="2" Grid.RowSpan="2" 
               Background="#FF00FF">Text 5</TextBlock>
    <TextBlock Grid.Row="3" Grid.Column="0" Grid.ColumnSpan="4" 
               Background="#FF0080">Text 6</TextBlock>
</Grid>
```

</div>

<!-- slide -->

<center>

<image style="border: none;" src="fig/grid%20layout.png"/>

</center>

<!-- slide -->

## Komplett exempel - Miniräknare

<!-- slide -->

## Databindingar och MVVM

- Mer avancerade applikationer dynamiska kopplingar mellan data i applikationen och XAML (*data binding*) och MVVM
  - *Databinding* att kontrollers utseende, innehåll i och interaktion automatiskt synkroniserat med data i applikationen.
  - *MVVM* (*Model-View-Viewmodel*) och är ett designmönster för att separera data/logik (*Model*) för applikationen från det grafiska användargränssnittet (*View*) genom ett mellanliggande lager som kallas  *Viewmodel*. 










