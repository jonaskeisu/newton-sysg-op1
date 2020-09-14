---
presentation:
  width: 1200
  height: 600
  theme: 'black.css'
  center: false
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
     border: 1px solid white;
  }
  .reveal code {
    zoom: 90%;
  }
</style>


<!-- slide -->

# Funktioner

<!-- slide -->

## Funktion

- I C# är en *funktion* ett namngivet kodblock
- Koden i blocket körs genom att funktionen *anropas* i koden
- Kodblocket kallas funktionens *kropp*

<!-- slide -->

## Användningsområden

- Funktioner används t.ex. för att:
  - Återanvändning av logik
  - Strukturera långa kodblock (*spaghettikod*)
  - Callbacks - anropa egen kod från tredjepartsfunktion
  - Skapa metoder

<!-- slide -->

## Parametrar

- Varje funktionen har en lista av parametrar 
- En *parameter*:
  - är en lokal variabel för funktionens kropp
  - måste tilldelas ett värde vid varje anrop till funktionen
- Värden tilldelade parametrar vid anrop kallas *argument*

<!-- slide -->

## Returvärde 

- Ett funktionsanrop kan *returnera* ett värde
- Ett funktions som returnerar ett värde är ett uttryck


<!-- slide -->

## Definition av funktion

- Syntaxen för att definiera en funktion är:

    ```cs
    <typ> <identifierare> (<param1>, <param2>, ..) 
    {
        // Kod som körs vid anrop av funktionen.
        // Kallas funktionens kropp.
    }
    ``` 

    där ``<typ>`` är typen på värdet som funktionen returnerar. 
- Hela raden före funktionens kropp kallas fuktionens *huvud*

<!-- slide -->

## Definition av parameter

En parameter definieras med samma syntax som en variabel: 

```cs
<typ> <identifierare>
```

<!-- slide -->

## Return

- Varje flöde genom kroppen på en funktion med returvärde måste alltid sluta i satsen: 

  ```cs
  return <uttryck>;
  ```

  där ``return`` är ett nyckelord följt av ett uttryck av typ matchande definitionen av funktionen. 


<!-- slide -->

### Exempel

```cs
  // Definition av funktion `Bmi`
  double Bmi(double lengthCm, double weightKg)
  {
      var lengthMeters = lengthCm / 100;
      return weightKg / (lengthMeters * lengthMeters);
  }

  // Ett anrop till funktionen 'Bmi' 
  // med argumenten '178' och '78.5'
  var bmi = Bmi(178, 78.5); // x = 24.77.. 
```

<!-- slide -->

## Parameter via position

- Parametrar tilldelas argumenten parametrar via position. 

  ```cs
  var bmi = Bmi(178, 78.5);
  ```

- Lätt göra ett misstag. 

  ```cs
  // OOPS! Fel i båda raderna, 
  // men ingen varning från kompilatorn
  var bmi = Bmi(78.5, 178); 
  var bmi2 = Bmi(1.78, 78.5); 
  ```


<!-- slide -->

## Parameter via namn

- Parametrar kan också tilldelas argument via namn. 

  ```cs
  var bmi = Bmi(lengthCm: 178, weightKg: 78.5);
  ```

- Kan göra koden mer robus och lättare att förstå.

  ```cs
  // Fortfarande korrekt
  var bmi = Bmi(weightKg: 78.5, lengthCm: 178);
  ```


<!-- slide -->

## Kortform för enkla funktioner

- Alternativ syntax för funktioner med kropp bestående av en sats:

  ```cs
  <typ> <identifierare> (<param1>, <param2>, .. ) => <uttryck>
  ```

<!-- slide -->

### Exampel

- Alternativ implementation av BMI-funktionen.

  ```cs
  double Bmi(double lengthCm, double weightKg) => 
          weightKg / Math.Pow(lengthCm / 100, 2);
  ```

<!-- slide -->

## Procedur

- En funktion måste inte returnera ett värde
- Resultattypen är då nyckelordet ``void``
- En funktion utan resultatvärde kallas *procedur*
- Flödet återvänder från funktionens kropp:
  - Vid körning av satsen  ``return; ``, eller
  - När kodblocket tar slut. 

<!-- slide -->

### Exempel 

<div style="zoom: 0.75">

Procedur som skriver ut text med ram. 

```cs 
void WriteInFrame(string text, int width, char border)
{
    width = Math.Max(width, text.Length + 4);

    var line = new String(border, width);
    var spacer = border + new String(' ', width - 2) + border;

    var paddingNeeded = width - 2 - text.Length;
    var padLeft = new String(' ', paddingNeeded / 2);
    var padRight = new String(' ', paddingNeeded - padLeft.Length);

    Console.WriteLine(
        line + '\n' + spacer + '\n' + 
        border + padLeft + text + padRight + border + '\n' + 
        spacer + '\n' + line
    );
}               
```

</div>

<!-- slide -->

### Exempel fort.

<div style="display: flex">

<div style="text-align: center; width: 60%; margin-left: 0.75em">
  Kod
  
  ```cs
  WriteInFrame("Daniel", 0, '#');
  Console.WriteLine();
  WriteInFrame("Bo", 0, '#');
  ```
</div>
<div style="margin-left: 5%; text-align: center; width: 25%">
Urskrift

```text
##########
#        #
# Daniel #
#        #
##########

######
#    #
# Bo #
#    #
######
```
</div>

<!-- slide -->

## Defaultvärde för PARAMETER

- Parametrar kan ha defaultvärde. 
- Parametrar med defaultvärden måste komma sist i definitionen av funktionen.

<!-- slide -->

## Exempel

<div style="zoom: 0.75">

Procedur som skriver ut text med ram. 

```cs 
void WriteInFrame(string text, int width = 0, char border = '*')
{
    width = Math.Max(width, text.Length + 4);

    var line = new String(border, width);
    var spacer = border + new String(' ', width - 2) + border;

    ...             
```

</div>

<!-- slide -->

<div style="display: flex">

<div style="text-align: center; width: 65%; margin-left: 0.75em">
  Kod
  
  ```cs
WriteInFrame("Anna");
Console.WriteLine();
WriteInFrame("Mattias", border: '$');
  ```
</div>
  <div style="margin-left: 5%; text-align: center; width: 23%">
  Urskrift
  
  ```text
********
*      *
* Anna *
*      *
********

$$$$$$$$$$$
$         $
$ Mattias $
$         $
$$$$$$$$$$$
  ```
  </div>

<!-- slide -->

## Strukturering och återanvänding av kod

- I slutet av lektionen skall vi titta på exempel där funktioner avnänds för att förtydliga struktur och återanvända kod. 

<!-- slide -->



