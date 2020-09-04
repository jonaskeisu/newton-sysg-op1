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

# Villkor och val
</div>

---

## Satser

- En ***stats*** är ett stycke kod som kan exekveras fristående

---

## Kodrad 

- En kodrad är en är en sats. 
- Slutet på en sats markeras med ett *semikolon* (``;``)

```text
<kod> ;
```

---

## Skillnaden på satser och uttryck

- En *sats* till skillnaden till ett *uttryck* behöver inte resulterar i ett värde
- Syftet med en sats är att definiera en identifierare eller skapa en *sidoeffekt*.
- En ***sidoeffekt*** är en bestående effekt av att en sats exekverats, t.ex. förändrad data i minnet eller I/O:
    - ``a = 1; // förändrad data i minnet``
    - ``Console.WriteLine("Hello!"); // I/O``

---

## Kodblock

- Sammansatta satser kan skapas ***kodblock***
- Exkevering av kodblocket innebär att exekvera dess satser *sekventiellt*
- Ett kodblock formas genom att placera en sekvens av satser mellan klammerparenterser (``{}``)

    ```text
    {
        <sats 1>
        <sats 2>
        ..
    }
    ```

--- 

### Nästade kodblock

Kodblock kan vara nästade.

```text
{
    <sats 1>
    <sats 2>
    ..
    {
        <sats k>
        <sats k + 1>
        ..
    }
    ...
}
```


---

## Scope

- En variabel är bara synlig i kodblocket där den definieras
- En synlig variabel sägs vara i ***scope***
- En ej synlig variabel sägs vara ur scope

---

### Exempel

```cs
int a = 1; 
{
    int b = 2;
    int c = a + b; // c = 1 + 2
    {
        int d = 3; 
        int e = a + b + c; // e = 1 + 2 + 3
    }
    int f = a + b; // d = 1 + 2
    int g = a + b + c + d; // FEL! d är ur scope
}
int g = a; // g = 1
int h = a + b + d; // FEL! både b och d är ur scope
```

---

## Flödeskontroll

- Vid det här laget vet vi hur man utför satser i en sekvens
- .. men inom programmering vill man ofta bestämma vilka satser som skall exekveras eller upprepa exekveringen av ett kodblock
- Nyckelord som kontrollera vilka satser som exekveras eller i vilken ordning satserna skall exekveras för ***flödeskontroll***

---

## If-sats

- Nyckelordet ***if*** används för att skapa en if-sats
- En if-sats utför en sats endast om och endast om ett *villkor* är uppfyllt

    ```cs
    if ( <villkor> )
        <sats> // Körs bara om villkoret är uppfyllt
    ```

---

## Datatypen för villkor

- Typen för villkor kallas ***boolean***
- Ett villkor kan endast vara ***sant*** eller ***falskt***
- Nyckelordet för typen boolean är ``bool``
- Följande är litteraler av typen ``bool``:
  - ``true`` (med betydelsen *sant*)
  - ``false`` ( med betydelsen *falskt*)

---

## Jämförelser

- C# har binära operatorer som skapar uttryck genom att jämförelse
- Uttrycket har typen ``bool``

---

# Jämförelseoperatorer

<center>

<table style="display: inline">
    <tr><th>Syntax</th><th>Betydelse</th><th>Fungerar på</th></tr>
    <tr><td><code><</code></td><td>mindre än</td><td>Tal</td></tr>
    <tr><td><code><=</code></td><td>mindre än eller lika med</td><td>Tal</td></tr>
    <tr><td><code>></code></td><td>större än</td><td>Tal</td></tr>
    <tr><td><code>>=</code></td><td>större än eller lika med</td><td>Tal</td></tr>
    <tr><td><code>==</code></td><td>lika med</td><td>Alla värden</td></tr>
    <tr><td><code>!=</code></td><td>inte lika med</td><td>Alla värden</td></tr>
</table>

</center>

---

### Exempel

```cs 
double x = 10.0; 
double y = 10.00000001;
bool a = 10.0 < x; // false
bool b = 10.0 <= x; // true
bool c = 10.0 > x; // false
bool d = 10.0 >= x; // true
bool e = x == y; // false
bool f = x != y; // true
```

---

### Exempel 

Nu kan börja skapa villkor för meningsfulla ``if``-satser.

```cs 
Console.WriteLine("Hur lång är du?")

double length = Double.Parse(Console.ReadLine());

if ( length >= 190.0 ) 
{
    Console.WriteLine("Oj, vad lång du är!");
}
```
---

## If-else-sats

- Nyckelordet ``if`` kan kombineras med nyckelordet ***``else``*** med syntax:

    ```text
    if ( <villkor> )
        <sats a>
    else
        <sats b>
    ```
- Om villkoret är uppfyllt exekverar ``<sats a>``, annars ``<sats b>`` 

--- 

### Exempel

```cs 
Console.WriteLine("Hur lång är du?")

double length = Double.Parse(Console.ReadLine());

if ( length >= 190.0 ) 
{
    Console.WriteLine("Oj, vad lång du är!");
}
else 
{
    Console.WriteLine("Du är inte ovanligt lång.");
}
```

---

## Kedjor av if-else

- Det är vanligt att koppla samman kedjor av *if-else* för att skapa fallanalys som täcker mer än två fall

---

### Exempel

```cs 
Console.WriteLine("Hur många poäng fick du på provet?");

int testScore = Int32.Parse(Console.ReadLine());

if (testScore < 10) {
  Console.WriteLine("Underkänd");
} 
else if (testScore < 20) {
  Console.WriteLine("Godkänd");
}
else if (testScore < 30) {
  Console.WriteLine("Väl godkänd");
}
else {
    // testScore >= 30
    Console.WriteLine("Mycket väl godkänd");
}
```

---

## Jämförelse av strängar

- Text kan av orsaker vi kommer diskutera senare inte jämföras med ``==``
- För att testa om sträng ``a`` och sträng ``b`` har samma text används uttrycket:

    ``a.Equals(b)``

    som beräknas till ``true`` om texten är samma, annars ``false``.

---

### Exempel

```cs
Console.WriteLine("Vad är ditt namn?");
string name = Console.ReadLine();

if (name.Equals("Jonas"))
{
    Console.WriteLine("Tjusigt namn!");
}
```

---

# Logiska operatorer

- ***Logiska operatorer*** skapar sammansatta villkor

<center>

<table style="display: inline; font-size: 90%">
    <tr><th>Operator</th><th>Syntax</th><th>Betydelse</th></tr>
    <tr><td><i>och</i></td><td><code>a && b</code></td><td><code>true</code> om både <code>a</code> <i>och</i> <code>b</code> är <code>true</code>, annars <code>false</code></td></tr>
    <tr><td><i>eller</i></td><td><code>a || b</code></td><td><code>true</code> om minst en av <code>a</code> <i>och</i> <code>b</code> är <code>true</code>, annars <code>false</code></td></tr>
    <tr><td><i>inte</i></td><td><code>! a</code></td><td><code>true</code> om <code>a</code> är <code>false</code>, annars <code>false</code>
</table>

</center>

--- 

### Exempel

```cs 
Console.WriteLine("Hur många års erfarenhet har du?");

double experience = Double.Parse(Console.ReadLine());

if (experience >= 2 && experience <= 5) 
{
    Console.WriteLine("Du har rätt mängd erfarenhet för jobbet!");
} 
```

---

### Exempel


```cs 
Console.WriteLine("Hur många poäng fick du på provet?");

int testScore = Int32.Parse(Console.ReadLine());

if (!(testScore >= 0 && testScore <= 50)) {
  Console.WriteLine("Ogiltig inmatning.");
} 
..
```

---

### Exempel

```cs 
Console.WriteLine("Skriv ett heltal mellan 1 och 10.");

int num = Int32.Parse(Console.ReadLine());

if (num == 2 || num == 3 || num == 5 || num == 7) 
{
    Console.WriteLine($"Talet {num} är ett primtal!"); 
} 
```

---

# Kortslutning av logiska operatorer

- I uttrycket ``a && b`` beräknas bara ``b`` om ``a`` är ``true``
- I uttrycket ``a || b`` beräknas bara ``b`` om ``a`` är ``false``

</div>

---

### Exempel

```cs 
int x = 0; 
bool a, b; 

a = true;

b = a || (++x == 1); // b = true, x = 0

a = false;

b = a || (++x == 1); // b = true, x = 1

b = a && (++x == 2); // b = false, x = 1

a = true;

b = a && (++x == 2); // b = true, x = 2
```



