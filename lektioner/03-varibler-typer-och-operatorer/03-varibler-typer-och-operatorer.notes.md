---
marp: true
theme: default
footer: © 2020 BIT ADDICT
style: | 
  section {
      @extend .markdown-body;
      display: block;
      flex-direction: column;
      font-size: 32px
  }

  @import '../css/lecture_slides.css'

---

<div class="title-page">

# Variabler, typer och operatorer
</div>

---

## Syntax

***Syntax*** är formella regler för hur man skriver giltig kod.

---

## Variabler

- En ***variabel*** är ett lagringsutrymme i minnet för att lagra data
- Variabelns ***typ*** bestämmer tolkning, storlek och struktur på data
  - Data med en bestämd tolkning, t.ex. tal eller text, kallas även ***värde***
- I kod refereras en variabel via ett unikt namn som kallas ***identifierare***

---

### Exempel

Följande kod:

```cs
string namn = "Jonas";
int ålder = 42;
bool körkort = true;
```

skapar tre variabler och lagrar värden i dem, som illustrerat i figuren nedan.

<div style="display: flex; flex-direction: column; align-items: center; margin-top: 1em;">

![variabel](fig/variable.dot.svg)

</div>

---

## Identifierare

Syntax för en identifierare:

- är en sekvens av tecken
- sekvensen består endast av bokstäver, siffror eller ``_``
- måste börja med ``_`` eller en bokstav, inte en siffra

---

### Exempel

Giltiga identifierare:

  - ``length``, ``width``, ``color``, ``myName``, ``object1``, ``_variable``

Inte giltiga identifierare: 

  - ``1object``, ``my name``, ``object:1``

---

## Heltalstyper i C#

<center>
<table style="font-size: 80%; display: inline">
    <tr><th>Keyword</th><th>Möjliga värden</th><th>Data</th><th>.NET-typ</th></tr>
    <tr>
        <td><code>sbyte</code></td>
        <td>[-128, 127]</td>
        <td>8 bitar</td>
        <td><code>System.SByte</code></td>
    </tr>
    <tr>
        <td><code>byte</code></td>
        <td>[0, 255]</td>
        <td>8 bitar</td>
        <td><code>System.Byte</code></td>
    </tr>
    <tr>
        <td><code>short</code></td>
        <td>[-32 768, 32 767]</td>
        <td>16 bitar</td>
        <td><code>System.Int16</code></td>
    </tr>
    <tr>
        <td><code>ushort</code></td>
        <td>[0, 65'535]</td>
        <td>16 bitar</td>
        <td><code>System.UInt16</code></td>
    </tr>
    <tr>
        <td><code>int</code></td>
        <td>[-2 147 483 648, 2 147 483 647]</td>
        <td>32 bitar</td>
        <td><code>System.Int32</code></td>
    </tr>
    <tr>
        <td><code>uint</code></td>
        <td>[0, 4 294 967 295]</td>
        <td>32 bitar</td>
        <td><code>System.UInt32</code></td>
    </tr>
    <tr>
        <td><code>long</code></td>
        <td>[-9 223 372 036 854 775 808,<br/> 9 223 372 036 854 775 807] </td>
        <td>64 bitar</td>
        <td><code>System.Int64</code></td>
    </tr>
    <tr>
        <td><code>ulong</code></td>
        <td>[0, 18 446 744 073 709 551 615]</td>
        <td>64 bitar</td>
        <td><code>System.UInt64</code></td>
    </tr>
</table>
</center>

---

## Flyttalstyper i C#

<center>
<table style="font-size: 80%; display: inline">
    <tr><th>Keyword</th><th>Möjliga värden</th><th>Data</th><th>.NET-typ</th></tr>
    <tr>
        <td><code>float</code></td>
        <td>±1.5 x 10<sup>−45</sup> to ±3.4 x 10<sup>38</sup></td>
        <td>32 bitar</td>
        <td><code>System.Single</code></td>
    </tr>
    <tr>
        <td><code>double</code></td>
        <td>±5.0 × 10<sup>−324</sup> to ±1.7 × 10<sup>308</sup></td>
        <td>64 bitar</td>
        <td><code>System.Double</code></td>
    </tr>
    <tr>
        <td><code>decimal</code></td>
        <td>±1.0 x 10<sup>-28</sup> to ±7.9228 x 10<sup>28</sup></td>
        <td>128 bitar</td>
        <td><code>System.Decimal</code></td>
    </tr>
</table>
</center>

---

## Keyword

- Ett ***keyword*** är ett ord med speciell betydelse i programmeringspsråket.
- Keywords är inte giltiga identifierare. 

---

## Variabeldefinition

- Innan en variabel kan användas i koden så måste den *definieras*.
- Syntax för definition av en variabel:
    ``<typ> <identifierare>;``
- Identifieraren får inte redan vara definierad i samma block av kod.

---

### Exempel

```cs
byte shoeSize; // 1 byte allokerad
uint pixels; // 4 bytes allokerad
long credit; // 8 bytes allokerad
sbyte shoeSize; // FEL! redan definierad i kodblocket
int ulong; // FEL! ulong är ett keyword
int @ulong; // 4 bytes allokerade
```

*``//`` och efterföljande text på samma kodrad en kommentar i dokumenterande syfte och och påverkar inte programmets beteende*.

---

# Tilldelning

- Efter definition av en variabel är det möjligt att skriva till dess minne
- Att skriva till en variabels minne kallas att ***tilldela*** variabeln
- Syntaxen för tilldeling av en variabel är: 
    ``<variabel> = <uttryck>;``
- Uttrycket till höger i en tilldelning måste ha samma typ som variabeln

---

### Exempel

```cs 
int a;
int b; 
a = 1 + 2;
b = a * 3; 
```

---

## Variabelinitialisering

- En variabel kan tilldelas samtidigt som den definieras.
- Detta kallas ***initialisering*** av variabeln.
- En ej initialiserad variabel har standardvärdet för typen till den tilldelas.

---

### Exempel

```cs 
int a = 1 + 2;
int b = a * 3; 
```
---

## Implicit typning

- Om en variabel initialiseras kan typen ersättas med ``var``
- Variabeln får då automatiskt samma typ som initaliseringsuttrycket.
- Detta kallas att variabeln har ***implicit*** typ.

---

### Exempel

```cs 
var a = 1 + 2; // a har typen int
var b = 1.0 + 2.0; // b har typen double 
```

---

## Uttryck

- Ett ***utryck*** är kod som beräknas till ett värde 
- Exempel på enkla uttryck är:
  - Bokstavliga värden, så kallade ***litteraler***
    - T.ex. ``15``, ``123.456``, ``-189``
  - Variabler
    - T.ex. ``length``, ``x``, ``shoeSize``

---

## Heltalslitteraler

```cs
var a = 123; // int

var b = 123L; // long

var c = 123UL; // unsigned long

var d = 0x1AC3; // int på hexdecimal form

var e = 0b10101010; // int på binär form

var f = 0b_1010_1010; // samma betydelse som föregående rad

```

---

## Flyttalslitteraler

Flyttalslitteraler utmärker sig genom att de alltid innehåller en punkt.

```cs
var a = 123.0; // litteral av typen double

var b = 123.0f; // litteral av typen float

var c = 1.23e2; // litteral av typen double, scientific notation

var d = 1.23e2f; // litteral av typen float, scientific notation
```

---

## Operatorer

- ***Operatorer*** skapar nya uttryck från andra uttryck
- Syntaxen för operatoruttryck använder sig av symboler, t.ex. ``+``, ``-`` och ``*``
- Uttrycken en operator beror på kallas för ***operander***

--- 

### Exempel 

I koden nedan:

```cs
int a = 17 + 3
```

används additionsoperatorn för att skapa ett uttryck, illustrerat av figuren nedan.


<div style="display: flex; flex-direction: column; align-items: center; margin-top: 1em;">

![variabel](fig/uttryck.dot.svg)

</div>

---

### Exempel 

I koden nedan:

```cs
int a = 10
int b = 17 + 3 + a
```

använder additionsoperatorn två gånger för att skapa två uttryck, varav ett är operand till det andra, som illustrerat av figuren nedan.


<div style="display: flex; flex-direction: column; align-items: center; margin-top: 0em;">

![variabel](fig/sammansatt-uttryck.dot.svg)

</div>

---

## Aritematiska operatorer

Följande operatorer finns för alla heltals- och flyttalstyper.

<center>
<table style="font-size: 75%; display: inline">
  <tr><th>Operator</th><th>Syntax</th><th>Resultat</th></tr>
  <tr><td>Addition</td><td><code>a + b</code></td><td>Summan av <code>a</code> och <code>b</code></td></tr>
  <tr><td>Subtraktion</td><td><code>a - b</code></td><td>Differenansen mellan <code>a</code> och <code>b</code></td></tr>
  <tr><td>Multiplikation</td><td><code>a * b</code></td><td>Produkten av <code>a</code> och <code>b</code></td></tr>
  <tr><td>Division</td><td><code>a / b</code></td><td>Kvoten av <code>a</code> och <code>b</code><br/></td></tr>
  <tr><td>Negative</td><td><code>-a</code></td><td>Minus <code>a</code></td></tr>
</table>
</center>
<br/>

OBS: ``a`` och ``b`` måste ha samma typ för att beräkningen skall kunna utföras och resultatet har samma typ som operanderna.

--- 

### Exempel

```cs
int a = 3;
int b = 2; 
double c = 3.0;
double d = 2.0;
var e = a + b; // int med värdet 5
var f = c + d; // double med värdet 5.0
var g = a / b; // int med värde 1 (heltalsdivision)
var h = c / d; // double med värdet 1.5
var i = -c; // double med värdet -3.0
```

---

## Heltalsoperatorer

Följande operatorer finns endast för  heltalstyper.

<table style="font-size: 75%">
  <tr><th>Namn</th><th>Syntax</th><th>Resultat och sidoeffekt</th></tr>
  <tr><td>Prefix inkrement</td><td><code>++a</code></td><td>Öka värdet på <code>a</code> med 1 och ge sedan värdet på <code>a</code> som resultat</td></tr>
  <tr><td>Postfix inkrement</td><td><code>a++ </code></td><td>Ge värdet på <code>a</code>  som resultat och öka sedan värdet på <code>a</code> med 1</td></tr>
  <tr><td>Prefix dekrement</td><td><code>--a</code></td><td>Minska värdet på <code>a</code> med 1 och ge sedan värdet på <code>a</code> som resultat</td></tr>
  <tr><td>Postfix dekrement</td><td><code>a--</code></td><td>Ge värdet på <code>a</code>  som resultat och minska sedan värdet på <code>a</code> med 1</td></tr>
</table>

---

## Kedjor av operatorer

Har uttrycket tilldelat ``x`` i koden nedan:

```cs
int x = 1 + 2 * 3;
```

strukturen enligt bilden till höger eller vänster nedan?


<div style="display: flex; flex-direction: column; align-items: center">
<div style="display: flex;">
<div style="display: flex; flex-direction: column; align-items: center; margin-top: 0em;">

![variabel](fig/operatorföreträde-1.dot.svg)

</div>

<div style="display: flex; flex-direction: column; align-items: center; margin-left: 3em;">

![variabel](fig/operatorföreträde-2.dot.svg)

</div>
</div>
</div>

---

## Operatorföreträde

- Svaret på frågan framgår av figuren nedan. 
- Anledningen är att det finns en [företrädesordning](https://docs.microsoft.com/en-us/cpp/c-language/precedence-and-order-of-evaluation?view=vs-2019) för operatorer.
- Multiplikation ligger högre i ordningen än addition och binder därför sina operander först. 

<div style="display: flex; flex-direction: column; align-items: center; margin-left: 3em;">

![variabel](fig/operatorföreträde-2.dot.svg)

</div>

---

## Gruppering med parenteser

- Företrädesordningen kan kringgås genom gruppering med parentser. 
- Operatorer inom parenteser binder sina operander innan operatorerna utanför parenteserna.

---

### Exempel

Med parenterser har uttrycket tilldelat ``x`` i koden nedan: 

```cs
int x = (1 + 2) * 3;
```

nu strukturen enligt figuren nedan.

<div style="display: flex; flex-direction: column; align-items: center; margin-top: 0em;">

![variabel](fig/operatorföreträde-1.dot.svg)

</div>

---

## Aritet

- En operators *aritet* är lika med dess antal operander
- En operator med aritet 1 kallas ***unär***
- En operator med aritet 2 kallas ***binär***
- En operator med aritet 3 kallas ***trinär***

---

# Konvertering

- En typ av tal kan konvertersa till en annan typ
  - Dock med risken att information går förlorad!
- Konverteringsoperatorn har följande syntax:

  ``(<typ>) <uttryck>``

  där ``<typ>`` är typen som uttrycket skall konverteras till.

--- 

### Exempel

```cs
int a = 123;
byte b = (byte)a; // konvertering till byte

double c = 123.456;
float d = (float)d; // konvertering till float
```

---

## Implicit konvertering

- Vid behov kan tal implicit konverteras till "rymligare" taltyper 

