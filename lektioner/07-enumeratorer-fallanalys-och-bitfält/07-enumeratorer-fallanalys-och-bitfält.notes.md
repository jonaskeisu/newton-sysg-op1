---
presentation:
  width: 1200
  height: 600
  theme: 'simple.css'
  center: false
---
<style type="text/css">
  .reveal h1 {
    text-align: center;
    display: flex;
    flex-direction: column;
    align-items: center;
  }
  .reveal h2, .reveal h3 {
    margin-left: 1em;
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
    zoom: 100%;
  }
  div.slides{
     # border: 1px solid white;
  }
  .reveal code {
    zoom: 100%;
  }
  table.ops th, table.ops td {
      text-align: center;
  }
</style>

<!-- slide -->

 # Enumeratorer, fallanalys och bitfält

<!-- slide -->

 ## Enumeration

 - En ***enumeration*** är en numrering av element
 - T.ex. kan elementen { ``A``, ``B``, ``C``, ``D`` }  enumreras:
  
    { ($0$, ``A``), ($1$, ``B``), ($2$, ``C``), ($3$, ``CD``) }    

    men också på 23 andra sätt, t.ex.

    { ($0$, ``D``), ($1$, ``B``), ($2$, ``A``), ($3$, ``C``) }

<!-- slide -->

## Enum

- I C# används nyckelordet ``enum`` för att skapa en ny typ av namngivna heltalsvärden
- En ``enum``-typ kan definieras på namespace- eller klassnivå
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

- Värden av en ``enum``-typ refereras i koden via punktnotation. 
- T.ex. definierar koden nedan en variabel ``suite`` av typen ``Suite`` och initerar den med värdet ``Suite.Hearts``:



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

</div>

<!-- slide -->
### Exempel

<div style="display: flex;">

<div>

Typdefinition

```cs 
enum Fruit 
{
    Apple = -13, 
    Banan, 
    Orange = 1094,
    Mellon
}



```
</div>

<div style="margin-left: 2em; width: 60%">

Utskrift av numrering

```cs
Fruit[] fruits = { 
    fruit.Apple, fruit.Banan, 
    fruit.Orange, fruit.Mellon  
};
for (int i = 0; i < fruits.Length; ++i) 
{
    // Skriver ut "-13", "-12", 
    // "1094", "1095"
    Console.WriteLine((int)fruits[i]); 
}
```

</div>

</div>

<!-- slide -->
## Behövs enum-typer?
Varför inte använda konstanter istället för ``enum``?

<div style="zoom: 0.9">

```cs
const int Hearts   = 0; 
const int Clubs    = 1;
const int Diamonds = 2;
const int Spades   = 3;
```
</div>

.. men då kan inte kortfärger skiljas från andra heltalsvärden:

<div style="zoom: 0.9">

```cs
int suite = 4; // Fel! .. men helt ok enligt kompilatorn. 
```
</div>

Med ``enum``-typer blir koden tydligare och säkrare. 

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

- Ett ***bitfält*** är en heltalsvärde betraktat som ett fält av bitar. 
- T.ex. är värde av typen: 
  - ``byte`` ett fält av 8 bitar.
  - ``int`` ett fält av 16 bitar.
  - ``short`` ett fält av 32 bitar.
  - ``long`` ett fält av 64 bitar.

<!-- slide -->

## Bitvisa operatorer

- *Bitvisa operatorer* utför operationer på individuella bitar av heltalsvärden betraktade som bitfält. 
- I beskrivningarna av de bitvisa operatorerna betecknas bitarna i ett $n$-bitars heltalasvärdet ``x`` som: $x_{n-1}x_{n-2}$ ... $x_1x_0$

<!-- slide -->

### Bitvis och-operatorn

<table class="ops" style="margin-top: 2em">
  <tr>
    <th>Symbol</th>
    <th>Syntax</th>
    <th>Betydelse</th>
  </tr>
  <tr>
    <td><code>&</code></td>
    <td><code style="white-space: nowrap">a & b</code> </td> 
    <td><code>(a & b)</code><sub>i</sub> är lika med 1 om <code>a</code><sub>i</sub> <i>och</i> <code>b</code><sub>i</sub><br/> är lika med 1, annars 0.</td>
  </tr>
</table>

<!-- slide -->

### Bitvis eller-operatorn

<table class="ops" style="margin-top: 2em">
  <tr>
    <th>Symbol</th>
    <th>Syntax</th>
    <th>Betydelse</th>
  </tr>
  <tr>
    <td><code>|</code></td>
    <td><code style="white-space: nowrap">a | b</code> </td> 
    <td><code>(a | b)</code><sub>i</sub> är lika med 1 om <code>a</code><sub>i</sub> <i>eller</i> <code>b</code><sub>i</sub><br/> är lika med 1, annars 0.</td>
  </tr>
</table>

<!-- slide -->

### Bitvis exklusivt eller-operatorn

<table class="ops" style="margin-top: 2em">
  <tr>
    <th>Symbol</th>
    <th>Syntax</th>
    <th>Betydelse</th>
  </tr>
  <tr>
    <td><code>ˆ</code></td>
    <td><code style="white-space: nowrap">a ˆ b</code> </td> 
    <td><code>(a ˆ b)</code><sub>i</sub> är lika med 1 om endast <i>en</i> av <code>a</code><sub>i</sub> och <code>b</code><sub>i</sub> är lika med 1 och den andra är lika med 0, annars 0. </td>
  </tr>
</table>

<!-- slide -->

### Bitvis komplement-operatorn

<table class="ops" style="margin-top: 2em">
  <tr>
    <th>Symbol</th>
    <th>Syntax</th>
    <th>Betydelse</th>
  </tr>
  <tr>
    <td><code>˜</code></td>
    <td><code style="white-space: nowrap">~a</code> </td> 
    <td><code>(~a)</code><sub>i</sub> är lika med 1 om <code>a</code><sub>i</sub> är lika med 0, annars 0. </td>
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
  - Bitar som "skiftas ut" går förlorade.  

<!-- slide -->
## Exempel

```cs
byte a = 0b_1111_0000;

byte b = 0b_1010_1010;

byte c = a << 1; // c = 0b_1110_0000

byte d = a >> 1; // d = 0b_0111_1000

byte d = b << 3; // d = 0b_0101_0000

byte e = b >> 3; // e = 0b_0001_0101
```

<!-- slide --> 
## Bitflaggor

- En *bitflagga* är en bit i ett bitfält som används som en boolean. 
  - Värdet ``0`` för biten betyder *falskt*.
  - Värdet ``1`` för biten betyder *sant*.
- Bitflaggor används ofta inom maskinnära programmering:
  - Datakommunikation, operativsystemet, nbyggda system.

<!-- slide -->

### Exempel
- Önskade rättigheter för en öppnad fil anges med bitflaggor.
  - Första biten i bitfältet motsvar läsrättighet.
  - Andra biten i bitfältet motsvarar skrivrättigheter.

<!-- slide -->

## Operationer på bitfält

- Vanliga operationer på bitfält är t.ex.: 
  - *Testa* (eng. *test*) om specifika bitar har värdet  ``1``
  - *Sätta* (eng. *set*) specifika bitar till ``1``
  - *Återställa* (eng. *reset*) specifika bitar till ``0``
- Dessa operationer på bitfält implementeras med hjälp av bitvisa operatorer och bitmasker
  
<!-- slide -->

## Mask
- En *mask* är ett binärt fält som "maskerar" element som inte skall ingå i en fältoperation med värdet ``0`` och släpper igenom övriga element med värdet ``1``.
- Samma koncept som en stencil/schablon.

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

```cs
byte a = 0b_0101_0101;
byte b = 0b_1010_1010;
byte mask = 1 << 5; // mask = 0b_0010_0000, sätt bit 5
a |= mask; // a är nu 0b_0111_0101
b |= mask; // b är fortfarande 0b_1010_1010
```

<!-- slide -->

## Återställa bitar

```cs
bitfält &= ~mask; 
```

### Exempel


```cs
byte a = 0b_0101_0101;
byte b = 0b_1010_1010;
byte mask = 1 << 5; // mask = 0b_0010_000, så ~mask == 0b_1101_1111
a &= ~mask; // a är fortfarande 0b_0101_0101
b &= ~mask; // b är nu 0b_1000_1010
```

<!-- slide -->

## Enum som flaggor

- Enum-typer används för att lagra namngivna bitmasker.
- Genom att lägga till attributet ``[Flags]`` i definitionen av en ``enum``-typ tillåts dess värden som operander till bitvisa operationer. 

<!-- slide -->

## Exemple

<div style="display: flex;">

<div>

Typdefinition

```cs
[Flags]
enum FileAccess 
{
    Read       = 0b01,
    Write      = 0b10,
    ReadWrite  = 0b11 
}
```

</div>

<div style="width: 60%; margin-left: 2em;">

Tillämpning

```cs
FileStream file = new FileStream(
    @"C:\test.txt", FileMode.Open, 
    FileAccess.Read | FileAccess.Write);
// kod som skriver/läser till filen



```

</div>

</div>

<!-- slide -->

## Switch

Ett alternativ till ``if-else``-satser för fallanalys är  ``switch``-satsen.

<div style="zoom: 0.95">

```cs
switch(suite) {
    case Suite.Hearts:
        Console.WriteLine("Rött!");
        break;
    case Suite.Clubs: 
        Console.WriteLine("Svart!");
        break;
    case Suite.Diamonds:
        Console.WriteLine("Rött!");
        break;
    case Suite.Spades: 
        Console.WriteLine("Svart!");
        break;
}
```

</div>

<!-- slide --> 

## Switch-satsens syntax

En ``switch``-sats har syntax: 

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

<!-- slide -->

## Switch-satsens betydelse

  - Utvärdera ``<uttryck>``.
  - Om uttryckets värde matchar något mönstret:
    - Hoppa till kodraden efter motsvarande ``case``-rad.
  - Annars: 
    - Hoppa till kodraden efter ``default:``.
  - Fortsätt körningen till ``break;``.
  - Hoppa till satsen efter ``switch``-satsen.

<!-- slide --> 

## Gruppering av fall

Flera fall som hanteras lika i en ``switch``-sats kan grupperas:


```cs
switch(suite) {
  case Suite.Hearts:
  case Suite.Diamonds:
    Console.WriteLine("Rött!");
    break;
  case Suite.Clubs: 
  case Suite.Spades: 
    Console.WriteLine("Svart!");
    break;
}
```

<!-- slide -->

## Typmatching och bivillkor

- Ett mönster i en ``switch``-sats behöver inte vara en litteral. 
- Kan också vara att värdet skall ha en viss typ och eventuellt uppfylla ett bivillkor.

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
    case int x when x >= 20 && x <= 30:
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
        Console.WriteLine($"Boolean med värde: {b}");
        break;
    default:
        Console.WriteLine("Känner inte igen värdet.");
        break;
}
```

<!-- slide -->

## Mönstermatchning av tuples

- Det går att mönstermatcha flera värden samtidigt genom *tuples*
- En tuple är en packetering av element med individuell typ
- Syntaxen för en tupel är en kommaseprerat lista av element inom parenteser
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

- Det går också att skapa uttryck med nyckelordet ``switch``, genom följande syntax: 

    ```cs
    <uttryck> switch {
        <mönster1> => <uttryck1>,
        <mönster2> => <uttryck2>,
        ...
    }
    ```

    där ``<uttryck1>``, ``<uttryck2>``, o.s.v. har samma typ. 
- I ``switch``-uttryck är ``_`` ett mönster som matchar allt.

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




