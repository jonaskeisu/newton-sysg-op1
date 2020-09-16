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
  - Callbacks - anropa egen kod från tredjepartskod
  - Skapa metoder

<!-- slide -->

## Parametrar

- Varje funktionen har en lista av *parametrar* 
- En parameter:
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

### Exempel
```cs
double EmployeeTax(int employeeAge, double salary)
{
  if (employeeAge >= 65) {
    return 0.1021 * salary; 
  }
  else if (employeeAge < 18 && salary <= 25000) {
    return 0.1021 * salary; 
  }
  else {
    return 0.3142 * salary;
  }
}
```

<!-- slide -->

## Parameter via position

Parametrar kan tilldelas argumenten via position. 

  ```cs
  var bmi = Bmi(178, 78.5);
  ```

Lätt göra ett misstag.. 

  ```cs
  // OOPS! Fel i båda anropen, men ingen varning från kompilatorn
  var bmi1 = Bmi(78.5, 178); 
  var bmi2 = Bmi(1.78, 78.5); 
  ```


<!-- slide -->

## Parameter via namn

- Parametrar kan också tilldelas argument via namn. 

  ```cs
  var bmi = Bmi(lengthCm: 178, weightKg: 78.5);
  ```

- Kan ibland göra koden mer robust och lättare att förstå.

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

  ```cs
  double Bmi(double lengthCm, double weightKg) => 
          weightKg / Math.Pow(lengthCm / 100, 2);
  ```

<!-- slide -->

## Exempel

```cs
double EmployeeTax(int employeeAge, double salary) =>
  salary * ((employeeAge, salary) switch {
    var (age, sal) when age >= 65                 => 0.1021,
    var (age, sal) when age  < 18 && sal <= 25000 => 0.1021,
    _                                             => 0.3142,
  });
```

<!-- slide -->

## Procedur

- En funktion utan resultatvärde kallas *procedur*
- Resultattypen för en procedur är ``void``
- Exerkveringsflödet återvänder från funktionens kropp:
  - Vid exekvering av satsen ``return; ``, eller
  - När flödet når kroppens slut

<!-- slide -->

### Exempel 


```cs 
void Frame(string text, int width, char border) {
    int w = Math.Max(width, text.Length + 4); // outer width
    int iw = w - 2; // inner width
    char b = border;
    string Repeat(char c, int times) => new string(c, times);
    WriteLine(Repeat(b, w) + '\n' + b + Repeat(' ', iw) + b);
    string padl = Repeat(' ', (iw - text.Length) / 2);
    string padr = Repeat(' ', padl.Length + (iw - text.Length) % 2);
    WriteLine(b + padl + text + padr + b);
    WriteLine(b + Repeat(' ', iw) + b + '\n' + Repeat(b, w));
}      
```

</div>

<!-- slide -->

### Exempel fort.

<div style="display: flex">

<div style="width: 60%; margin-left: 0.75em">
  Kod
  
  ```cs
  Frame("Daniel", width: 0, border: '#');
  Console.WriteLine();
  Frame("Bo", width: 0, border: '#');
  ```
</div>
<div style="margin-left: 5%; width: 25%">
Utskrift

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

## Defaultvärde för parameter

- Parametrar kan ha defaultvärde. 
- Måste då komma sist i parameterlistan. 

<!-- slide -->

### Exempel

<div style="zoom: 0.75">


```cs 
void Frame(string text, int width = 0, char border = '#')
{
    int w = Math.Max(width, text.Length + 4); // outer width
    int iw = w - 2; // inner width
    char b = border;
    ...             
```

</div>

<!-- slide -->

### Exempel

<div style="display: flex">

<div style="width: 65%; margin-left: 0.75em">
  Kod
  
  ```cs
Frame("Anna");
Console.WriteLine();
Frame("Mattias", border: '$');
  ```
</div>
  <div style="margin-left: 5%; width: 23%">
  Utskrift
  
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

## Nästade funktionsanrop
Funktioner kan anropa andra funktioner.

```cs
void Main(string[] args) {
  int x = Twice(3);
  
  int Twice(int x) {
    int sum = Add(x, x);
    return sum;
  }

  int Add(int x, int y) => x + y;
}
```

<!-- slide -->

## Call stacken
- Minnesaeran för lokala variabler i *ett* funktionsanrop kallas *frame*
- Ett anrop till en funktion lägger en frame överst på *call stacken* 
- Return kasserar den översta framen på call stacken

<div style="margin-top: 2em; display: flex; align-items: flex-end; zoom: 0.55">

<div>
<table>
  <tr><td style="border: 0; vertical-align: middle; " rowspan="2">Main()</td><td style="border: 0; border-top: 1px solid black"><code>x = 0</code></td></tr>  
  <tr><td style="border: 0; border-bottom: 1px solid black"><code>args = ..</code></td></tr>  
</table>
</div>

<div style="margin-left: 1em">
<table>
  <tr><td style="border: 0; vertical-align: middle; " rowspan="2">Twice()</td><td style="border: 0; border-top: 1px solid black"><code>x = 3</code></td></tr>
  <tr><td style="border: 0"><code>sum = 0</code></td></tr>
  <tr><td style="border: 0; vertical-align: middle; " rowspan="2">Main()</td><td style="border: 0; border-top: 1px solid black"><code>x = 0</code></td></tr>  
  <tr><td style="border: 0; border-bottom: 1px solid black"><code>args = ..</code></td></tr>
</table>
</div>

<div style="margin-left: 1em">
<table>  
  <tr><td style="border: 0; vertical-align: middle; " rowspan="2">Add()</td><td style="border: 0; border-top: 1px solid black"><code>x = 3</code></td></tr>
  <tr><td style="border: 0"><code>y = 3</code></td></tr>
  <tr><td style="border: 0; vertical-align: middle; " rowspan="2">Twice()</td><td style="border: 0; border-top: 1px solid black"><code>x = 3</code></td></tr>
  <tr><td style="border: 0"><code>sum = 0</code></td></tr>
  <tr><td style="border: 0; vertical-align: middle; " rowspan="2">Main()</td><td style="border: 0; border-top: 1px solid black"><code>x = 0</code></td></tr>  
  <tr><td style="border: 0; border-bottom: 1px solid black"><code>args = ..</code></td></tr>
</table>
</div>

<div style="margin-left: 1em">
<table>
  <tr><td style="border: 0; vertical-align: middle; " rowspan="2">Twice()</td><td style="border: 0; border-top: 1px solid black"><code>x = 3</code></td></tr>
  <tr><td style="border: 0"><code>sum = 6</code></td></tr>
  <tr><td style="border: 0; vertical-align: middle; " rowspan="2">Main()</td><td style="border: 0; border-top: 1px solid black"><code>x = 0</code></td></tr>  
  <tr><td style="border: 0; border-bottom: 1px solid black"><code>args = ..</code></td></tr>
</table>
</div>

<div style="margin-left: 1em">
<table>
  <tr><td style="border: 0; vertical-align: middle; " rowspan="2">Main()</td><td style="border: 0; border-top: 1px solid black"><code>x = 6</code></td></tr>  
  <tr><td style="border: 0; border-bottom: 1px solid black"><code>args = ..</code></td></tr>  
</table>
</div>

</div>

<!-- slide -->

## Rekursion

<!-- slide -->

## Stack overflow

<!-- slide -->

## Pass by reference

<!-- slide -->

## Returnera flera värden

<!-- slide -->

## Variadiska funktioner

<!-- slide -->

## Refaktorering

- *Refakorering* är omstrukturering av kod som inte ändrar funktion
- Vi skall nu refaktorera en applikation med hjälp av funktioner

<!-- slide -->



