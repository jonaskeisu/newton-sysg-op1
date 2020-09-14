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
  table.ops th, table.ops td:not(:nth-child(4)) {
      text-align: center;
  }
</style>

<!-- slide -->

 # Enumeratorer, fallanalys och bitfält

<!-- slide -->

 ## Enumeration

 - En ***enumeration*** är en numrering av element
 - T.ex. kan elementen { ``A``, ``B``, ``C``, ``D`` }  enumeras:
  
    { ($0$, ``A``), ($1$, ``B``), ($2$, ``C``), ($3$, ``CD``) }    

    men också på 23 andra sätt, t.ex.

    { ($0$, ``D``), ($1$, ``B``), ($2$, ``A``), ($3$, ``C``) }

<!-- slide -->

## Enum

- I C# används nyckelordet ``enum`` för att skapa en ny värdetyp av namngivna och numrerade värden
- En ny ``enum``-typ kan definieras på namespace- eller klassnivå
  - .. men inte i kroppen av en funktion.

<!-- slide -->

### Exempel

```cs 
namespace Poker 
{
    class Program
    { 
        enum Suite
        {
            Hearts = 0,
            Clubs = 1,
            Diamonds = 2,
            Spades = 3
        }

        ... 
```

<!-- slide -->

## Enumvärden

- De värden för en ``enum``-typ refereras i koden via punktnotation. 
- T.ex. definierar koden nedan en variabel ``suite`` av ``enum``-typen ``Suite`` och initerar den med värdet ``Suite.Hearts``:



    ```cs 
    Suite suite = Suite.Hearts;
    ```


<!-- slide -->

## Konvertering av enum-värden

Värden av ``enum``-typ kan explicit konverteras till/från heltal.
```cs
static void Main(string[] args) {
    Suite suite = Suite.Diamonds;
    Console.WriteLine(suite); // Skriver ut "Diamonds"
    Console.WriteLine((int)suite); // Skriver "2"
    suite = (Suite)3;
    Console.WriteLine(suite); // Skriver "Spades"
}
```

<!-- slide -->

## Automatisk numrering

- Anges ingen numrering så numreras elementen från $0$
- Numreras enstaka element så numreras automatiskt mellanliggande värden 

<!-- slide -->

### Exempel

<div style="display: flex;">

<div>

Typdefinition

```cs 
enum Suite
{
    Hearts,
    Clubs,
    Diamonds,
    Spades
}


```
</div>

<div style="margin-left: 3em; width:60%">

Utskrift av numrering

```cs
Suite[] suits = {
    Suite.Hearts, Suite.Clubs, 
    Suite.Diamonds, Suite.Spades
};
for (int i = 0; i < suits.Length; ++i)
{
    // Skriver ut "0", "1", "2", "3"
    Console.WriteLine((int)suits[i]);
}                  
```
</div>

<!-- slide -->
### Exempel

<div style="display: flex;">

<div width="10%">

Typdefinition

```cs 
enum Fruit {
      Apple = -13, 
      Banan, 
      Orange = 1094,
      Mellon
}


```
</div>

<div style="margin-left: 2em; width: 100%">

Utskrift av numrering

```cs
Fruit[] fruits = { 
    fruit.Apple, fruit.Banan, 
    fruit.Orange, fruit.Mellon  
};
for (int i = 0; i < fruits.Length; ++i) {
    // Skriver ut "-13", "-12", "1094", 
    // "1095"
    Console.WriteLine((int)fruits[i]); 
}
```

</div>

</div>

<!-- slide -->
## Behövs enum-typer?
- Varför inte använda konstanter istället för enum?

    <div style="zoom: 0.9">

    ```cs
    const int Hearts   = 0; 
    const int Clubs    = 1;
    const int Diamonds = 2;
    const int Spades   = 3;
    ```
    </div>

-  .. men då kan inte färgvärdea skiljas från andra heltalsvärden:

    <div style="zoom: 0.9">

    ```cs
    int suite = 4; // Fel! .. men helt ok enligt kompilatorn. 
    ```
    </div>

- Enum-typer gör koden tydligare och mer säkrare. 

<!-- slide -->

### Exempel

Standardbiblioteket innehåller t.ex. följande  ``enum``-typ för att ange hur en fil skall öppnas.

```cs
enum FileMode
{
        CreateNew    = 1,
        Create       = 2,
        Open         = 3,
        OpenOrCreate = 4,
        Truncate     = 5,
        Append       = 6
}
```

<!-- slide -->

## Bitfält  

- Ett ***bitfält*** är ett heltalsvärde betraktat som ett fält av bitar. 
- T.ex. är värde av typen: 
  - ``byte`` ett fält av 8 bitar.
  - ``int`` ett fält av 16 bitar.
  - ``short`` ett fält av 32 bitar.
  - ``long`` ett fält av 64 bitar.

<!-- slide -->

## Bitvisa operatorer

- ***Bitvisa operatorer*** utför operationer på individuella bitar av heltalsvärden betraktade bitfält. 

<!-- slide -->
## Bitvisa operatorer i C#

<div style="display: flex; flex-direction: column; align-items: center; zoom: 0.65">


I tabellen nedan betecknas bitarna i $n$-bitars heltalasvärdet ``x`` som: $x_{n-1}x_{n-2}$ ... $x_1x_0$
</div>

</div>

<table class="ops" style="zoom: 0.65; text-align: center; width: 100%">
  <tr>
    <th>Operatornamn</th>
    <th>Symbol</th>
    <th>Exempel</th>
    <th>Betydelse</th>
  </tr>
  <tr>
    <td> <i>Bitvis och</i> </td>
    <td><code>&</code></td>
    <td><code style="white-space: nowrap">x = a & b</code> </td> 
    <td> 
    
$x_i$ är lika med 1 om $a_i$</sub> <i>och</i> $b_i$ är lika med $1$, annars $0$.</td>
  </tr>
  <tr>
    <td><i>Bitvis eller</i></td>
    <td><code>|</code></td>
    <td><code>x = a | b</code></td>
    <td>

$x_i$ är lika $1$ om $a_i$ <i>eller</i> $b_i$ är lika med $1$, annars $0$.</td>
  </tr>
  <tr>
    <td><i>Bitvis exklusivt-eller</i></td>
    <td><code>ˆ</code></td>
    <td><code>x = a ˆ b</code></td>
    <td>
    
$x_i$ är lika med $1$ om <i>enbart</i> $a_i$ eller <i>enbart</i> $b_i$ är lika med $1$, annars $0$.</td>
  </tr>
  <tr>
    <td><i>Bitvis komplement</i></td>
    <td><code>~</code></td>
    <td><code>x = ~a</code></td>
    <td>
    
$x_i$ är lika med $1$ om $a_i$ är lika med $0$,annars $0$.</td>
  </tr>
</table>

<!-- slide -->
## Exempel

```cs 
byte a = 0b_1111_0000;

byte b = 0b_1010_1010;

byte c = a & b; // c = 0b_1010_0000

byte d = a | c; // d = 0b_1111_1010

byte e = a ^ b; // e = 0b_0101_1010

byte f = ~a;    // f = 0b_0000_1111

byte g = ~b;    // g = 0b_0101_0101
```
<!-- slide -->
## Skiftoperatorer

- *Skiftoperatorer* förskjuter bitarna i ett bitfält
- Operatorn ``<<`` kallas *vänsterskift* och förskjuter bitfält åt vänster. 
- Operatorn ``>>`` kallas *högerskift* förskjuter bitfält åt vänster. 
- Skiftning påverkar inte bitfältets längd:
  - Nya bitar som "skiftas in" har värdet 0. 
  - Bitar som "skiftas över kanten" försvinner.  

<!-- slide -->
## Exempel

```cs
byte a = 0b_1111_0000;

byte b = 0b_1010_1010;

byte c = a << 1; // c = 0b_1110_000

byte d = a >> 1; // d = 0b_0111_100

byte d = b << 3; // d = 0b_0101_000
```

<!-- slide --> 
## Bitflaggor

- En *bitflagga* är en bit i ett bitfält motsvarar ett booleskt värde. 
  - ``0`` betyder *falskt*.
  - ``1`` betyder *sant*.
- Bitflaggor är används ofta inom maskinnära programmering:
  - Datakommunikation, operativsystemet och inbyggda system.
<!-- slide -->

### Exempel
- Önskade rättigheter för en fil öppnad i C# anges med bitflaggor.
- De två bitflaggorna motsvarar:
  - Läsrättighet
  - Skrivrättighet

<!-- slide -->

## Operationer på bitfält

- Vanliga operationer på bitfält är t.ex.: 
  - *Testa* (eng. *test*) om en specifik bitar har värdet  ``1``
  - *Sätta* (eng. *set*) specifika bitar till ``1``
  - *Återställa* (eng. *reset*) specifika bitar till ``0``
- Dessa operationer på bitfält implementeras med hjälp av bitvisa operationer och bitmasker
  
<!-- slide -->

## Mask
- En *mask* är ett binärt fält som "maskerar" element som inte skall ingå i en fältoperation med värdet ``0`` och släpper igenom övriga element med värdet ``1``.

<!-- slide -->

### Exempel

Nedan definieras tre bitmasker.

```cs
// alla bitar utom den med index 4 maskerade
byte mask1 = 0b_0001_0000; 

// samma som betydelse som mask1 
byte mask2 = 1 << 4;

// enbart biten med index 4 maskerad  
byte mask3 = ~mask1; 
```

*Notera att vänsterskiftoperatorn gör det det enkelt att uttrycka en bitmask med endast en ``1``:a på en specifik position.*

<!-- slide -->
## Testa bitar

```cs
bool test = (bitfält & mask) == mask;
```

### Exempel

```cs
byte a = 0b_0101_0101;
byte b = 0b_1010_1010;
byte mask = 1 << 5; // mask = 0b_0010_0000, testa bit 5
bool atest = (a & mask) == mask; // atest = false
bool btest = (b & mask) == mask; // btest = true
```

<!-- slide -->

## Sätta bitar


```cs
bitfält |= mask; 
```

### Exempel

<div style="zoom: 0.9">

```cs
byte a = 0b_0101_0101;
byte b = 0b_1010_1010;
byte mask = 1 << 5; // mask = 0b_0010_0000, sätt bit 5
a |= mask; // a är nu 0b_0111_0101
b |= mask; // b är fortfarande 0b_1010_1010
```
</div>

<!-- slide -->

## Återställa bitar

```cs
bitfält &= ~mask; 
```

### Exempel

<div style="zoom: 0.9">

```cs
byte a = 0b_0101_0101;
byte b = 0b_1010_1010;
byte mask = 1 << 5; // mask = 0b_0010_000, så ~mask == 0b_1101_1111
a &= ~mask; // a är fortfarande 0b_0101_0101
b &= ~mask; // b är nu 0b_1000_1010
```
</div>

<!-- slide -->

## Enum som flaggor

- Enum-typer används för att lagra namngivna bitmasker.
- Genom att lägga till attributet ``[Flags]`` i definitionen av en enum-typ tillåts att värdena ingår i bitvisa operationer. 

<!-- slide -->

## Exemple

<div style="zoom: 1">

```cs
[Flags]
enum FileAccess {
    Read       = 0b01,
    Write      = 0b10,
    ReadWrite  = 0b11 
}
```

```cs
FileStream file = new FileStream(
    @"C:\test.txt", FileMode.Open, FileAccess.Read | FileAccess.Write)
{
    // kod som skriver/läser till filen
}
```
</div>

<!-- slide -->

## Switch

- Ett alternativ till ``if-else``-satser för fallanalys är  ``switch``-satsen.

```cs
switch(color) {
  case Color.Yellow:
    Console.WriteLine("In swedish flag!");
    break;
  case Color.Blue: 
    Console.WriteLine("In swedish flag!");
    break;
  default:
    Console.WriteLine("NOT swedish flag!");
}
```

<!-- slide --> 

## Switch-satsens syntax

En ``switch``-sats har syntax: 

<div style="zoom: 0.9">

```cs
switch ( <uttryck> ) {
  case <mönster1> :
    ... // Kod för att hantera fallet
    break;
  case <mönster2> : 
    ... // Kod för att hantera fallet
    break;
  ...
  default: 
    // Kod för att hantera alla andra fall
}
```
</div>

där ``switch``, ``case``, ``break`` och  ``default`` är nyckelord.

<!-- slide -->

## Switch-satsens betydelse

  - Utvärdera ``<uttryck>``
  - Om uttryckets värde matchar mönstret för något ``case``:
    - Hoppa till kodraden efter detta ``case``
  - Annars: 
    - Hoppa till kodraden efter ``default``
  - Fortsätt exekveringen koden fram till ``break``.
  - Gå till satsen direkt efter ``switch``-satsen

<!-- slide --> 

## Gruppering av fall

- Om flera fall skall hanteras lika i en ``switch``-sats så kan dessa grupperas:

```cs
switch(color) {
  case Color.Yellow:
  case Color.Blue:
    Console.WriteLine("In swedish flag!");
    break;
  default:
    Console.WriteLine("NOT in swedish flag!");
}
``` 

<!-- slide -->

## Bivillkor

- Ett mönster behöver inte vara en litteral. 
- Kan också vara att värdet skall ha en viss typ tillsammans med bivillkor på värdet.

<!-- slide -->

### Exempel

<div style="zoom: 0.9">

```cs
switch (score)
{
    case int x when x < 10:
        Console.WriteLine("IG");
        break;
    case int x when x >= 10 && x < 20:
        Console.WriteLine("G");
        break;
    case int x when x >= 10 && x < 20:
        Console.WriteLine("VG");
        break;
    default:
        Console.WriteLine("Ogiltig poäng");
        break;
}
```

</div>

<!-- slide -->

### Exempel

<div style="zoom: 0.9">

```cs
object obj = "Det här är en lång text.";
switch (obj) {
    case string s when s.Length < 10:
        Console.WriteLine("En kort text");
        break;
    case string s when s.Length >= 10:
        Console.WriteLine("En lång text");
        break;
    case bool b: 
        Console.WriteLine($"Boolean with value: {b}");
        break;
    default:
        Console.WriteLine("Känner inte igen värdet.");
        break;
}
```

</div>

<!-- slide -->

## Mönstermatchning av tuples

- Det går att mönstermatcha flera värden samtidigt genom *tuples*
- En tuple är fält men typen för värdet kan vara unikt för varje index 
- Hela tupeln kan matchas som en enhet 
- Också möjligt matcha de uppackade värdena i tupeln

<!-- slide -->

### Exempel

<div style="zoom: 1">

```cs
switch (age, name)
{
    case var x when x.Item2.Equals("Bo"):
        Console.WriteLine($"Bo är {x.Item1} år");
        break;
    case (42, "Jonas"):
        Console.WriteLine("Du verkar bekant!");
        break;
    case var (x, _) when x >= 18:
        Console.WriteLine("Du är myndig.");
        break;
    default:
        break;
}
```

</div>

<!-- slide -->

## Switch-uttryck

- Det går också att skapa uttryck med nyckelordet ``switch``, med följande syntax. 

    ```cs
    <uttryck> switch {
    <mönster1> => <uttryck1>,
    <mönster2> => <uttryck2>,
    ...
    }
    ```

    där ``<uttryck1>``, ``<uttryck2>``, o.s.v. har samma typ. 
- I ``switch``-uttryck är ``_`` ett mönster som matchar allt, likt default.

<!-- slide -->

### Exempel

```cs
Console.WriteLine(score switch {
    int x when x >=  0 && x  < 10 => "IG",
    int x when x >= 10 && x  < 20 => "G",
    int x when x >= 20 && x <= 30 => "VG",
    _ => "Ogiltig poäng",
});
```




