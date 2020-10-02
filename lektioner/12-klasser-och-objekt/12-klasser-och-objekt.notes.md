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

# Klasser och objekt 

<!-- slide -->

## Klasser utökar strukturer

- Både klasser och strukturer är komposittyper
- All syntax för en struktur är giltig för en klass, men.. 
- Strukturer är *värdetyper* och klasser är *referenstyper*

<!-- slide -->

### Exempel

Antag typerna:

```cs
struct A {
    public int x;
}

class B { 
    public int x;
} 
```

<!-- slide -->

Koden nedan: 

```cs
A a1 = new A { x = 1 };
B b1 = new B { x = 1 };
A a2 = a1;
B b2 = b1;
a2.x = 2;
b2.x = 2;
Console.WriteLine($"{a1.x}, {b1.x}, {a1.Equals(a2)}, {b1.Equals(b2)}");
```

ger utskriften: 

```text
1, 2, False, True
```

<!-- slide -->

Skälet framgår ur hur minne allokerats och tilldelats värde av koden, vilket illustreras av figuren nedan:

```plantuml
@startuml

rectangle "Call stack" {
    node b2 {
        label "  " as r2
    }

    node b1 {
        label " " as r1
    }

    node a2 {
        node x as x2 {
            label "2"
        }
    }

    node a1 {
        node x as x1 {
            label "1"
        }
    }
}

cloud Heap {
    node " " as obj {
        node "**x**" as x3 {
            label "2" as objl 
        }
    }
}

b2 -> obj
b1 -> obj

@enduml
```

<!-- slide -->

## Ny möjligheter med klasser

- Konstruerare utan argument. 
- Initialiserare för instansmedlemsvariabler.
- Arv mellan klasser. 

<!-- slide -->

### Exempel

```cs
class A {
    int x = 1; // Ej tillåtet för struktur
    int y;  
    public A() { // Ej tillåtet för struktur
        y = 2;
    }
}
```

<!-- slide -->

## Klasser vs. objekt

- En klass är en typ
- Instanser av en klass kallas *objekt*
- En konstruktor:
  - Anropas efter nyckelordet ``new``
  - Initialiserar ett nytt objekt på heapen

<!-- slide -->

### Exempel

I följande kod:
```cs
class A {
    int x; 
    public A(int x) {
        this.x = x;
    }
}
... 
A a = new A(10);
```
 gäller att ``A`` är en typ och ``a`` är en referens till ett objekt av typen ``A``.

<!-- slide -->

## Vad är objektorienterad programmering?

- Inom procedurell programming beskrivs program genom funktioner och variabler
- Inom objektorienterad programmering beskrivs program genom *relationer mellan klasser av objekt*

<!-- slide -->

## Objekt

- Ett objekt representeras av:
  - Egenskaper - attribut för objektet
    - Färg, form, kodning, namn, rank, etc.
    - Tilldelas/avläses genom accesssormetoder (``get``/``set``)
  - Metoder - saker som objektet kan göra
    - Skicka, ta emot, rita, koda, avkoda, .. 

<!-- slide -->

## Klass

- En klass beskriver objekt med gemensamma egenskaper och metoder

<!-- slide -->

### Exempel

En *Kortlek* kan definieras som en klass av objekt med: 
  - Egenskapen *Antal kort* som är ett heltal.
  - En *konstruktor* som initerar en ny kortlek med alla 52 kort. 
  - Metoden *Blanda* som slumpar ordningen på korten i leken.
  - En metoden *Ta kort* som ger det översta kortet i leken.
  - En metod *Lägg tillbaka kort* för att föra tillbaka kort till leken.
  

<!-- slide -->

## Objektorienterad design

- Objektorienterad design består av att i en  systembeskrivning identifiera klasser av objekt och deras relationer

<!-- slide -->

## Typer av objektrelationer

<div style="display: flex; align-items: center">

<div>

- Har koppling till (*association*)
- Ärver (*inheritance*)
- Implementerar (*implements*)
- Beror på (*dependency*)
- Samlar på (*aggregation*)
- Består av (*composition*)

</div>

<div style="margin-left: 1em; zoom: 1.8">

![relationer](object-relationships.svg)

</div>
</div>

<!-- slide -->

### Exempel

*Sten, sax, påse* är ett spel med två spelare. Reglerna är att varje spelare i hemlighet väljer *sten*, *sax* och *påse*. Spelarna visar samtidigt sitt föremål åt varandra. Om båda spelarna valt samma föremål så blir det lika och spelet börjar om. Om spelarna valt olika föremål, så vinner en av spelarna enligt logiken:
- Sten krossar sax.
- Sax klipper sönder påse.
- Påse fångar sten.

<!-- slide -->

### Objektorienterad design

<center>

```plantuml
@startuml

class Player
{
    + string Name
    + Item SecretItem
    + Player(string)
    + void SelectSecretItem()
}

Player "0..2" --* "1" Item

class Game
{
    - Player[] Players
    + Game(Player, Player)
    + Player Play()
}

Game "1" --* "2" Player

enum Item
{
    Rock
    Scissors,
    Paper
}

@enduml
```

</center>

<!-- slide -->

### Vanliga implementationer av egenskaper

- Inkapsling av privata variabler
- Automatisk implementation
- Härledda egenskaper
- Kortsyntax för ``get``/``set``
- Ännu kortare syntax för egenskaper som bara har ``get``

<!-- slide -->

### Inkapsling av privata variabler

```cs
class Person {
    private int age;

    public int Age {
        get { return age; }

        private set {
            if (value >= 0 <= 150) { 
                age = value;
            }
        }
    }
}
```

<!-- slide -->

Ibland blir inkapslingen mekanisk och meningslös:

```cs
class Person {
    private bool driversLicense;

    public bool DriversLicense {
        get { return driversLicense; }

        set { driversLicense = value; }
    }
}
```

<!-- slide -->

### Automatisk implementation

```cs
class Person {
    public bool DriversLicense {
        get;
        set;
    }
}
```

<!-- slide -->

## Härledda egenskaper

```cs
class Array2D {
    private int elements = new int[0];
    private int columns = 0;
    public int Columns {
        get { return columns; }
        set { columns = value; elements = new int[Columns * Rows]; }
    }
    public int Rows {
        get { return elements.Length / Columns; }
        set { elements = new int[value * Columns]; }
    }
}
```

<!-- slide -->

### Kortformssyntax


```cs
class Person {
    private int age;

    public int Age {
        get => age;

        private set {
            if (value >= 0 <= 150) { 
                age = value;
            }
        }
    }
}
```

<!-- slide -->

### Ännu kortare syntax

```cs
class Person {
    private int age;

    public int Age => age; 
}
```


<!-- slide -->

### Array-klassen och comparabels

- Vi tittar närmare på:
  - ``Array``-klassens medlemmar
  - ``IComparable``-kontraktet
  - ``IComparer``-kontraktet

<!-- slide -->

### Exempel 

Poker är ett spel där en *dealer* har en *kortlek* med 52 *spelkort*. Varje kort i leken har en unik kombination av *rank* (*två*, *tre*, .., *nio*, *tio*, *knekt*, *dam*, *kung* eller *ess*) samt *färg* (*klöver*, *ruter*, *hjärter* eller *spader*).

Varje spelrunda går till på följande vis:
- Dealern *blandar* kortleken. 
- Dealern *delar* ut kort i taget laget runt från toppen av leken till *spelarna* till alla spelare fem kort på *handen*. 
<!-- slide -->
- Spelare erbjuds en i taget att *kasta* valfritt antal kort från sin hand i en *slaskhög* och *ersätts* då med lika många kort av dealern från toppen av kortleken.
- Samtliga spelare *visar* sina händer. 
- Dealern *utser vinnaren* som den spelaren som har den högsta handen.
- Spelarna *ger tillbaka* sin hand till delearn som för tillbaka korten i kortleken. 
- Dealern *tar slaskhögen* av kort och *för tillbaka* dem i kortleken. 


<!-- slide -->

<table style="zoom: 0.8">
    <tr><th>Handtyper </th><th>Kommentar</th></tr>
    <tr><td>Färgstege</td><td>Färg och stege</td></tr>
    <tr><td>Fyrtal</td><td>Fyra kort med samma rank</td></tr>
    <tr><td>Kåk</td><td>Triss och par</td></tr>
    <tr><td>Färg</td><td>Alla kort har samma färg</td></tr>
    <tr><td>Stege</td><td>Kortens ranker ligger i följd</td></tr>
    <tr><td>Triss</td><td>Tre kort med samma rank</td></tr>
    <tr><td>Två par</td><td>Två par</td></tr>
    <tr><td>Par</td><td>Två kort med samma rank</td></tr>
    <tr><td>Högsta kort</td><td>Inget av ovanstående</td></tr>
</table>

<!-- slide -->

Om två spelare har samma typ av hand avgör ranken på korten på hand vinnaren i första hand och färgen i andra hand (*spader* är högst, följt av *hjärter*, *ruter* och sist *klöver*).

<!-- slide -->

Avgörande kort för olika typer av händer:

- Färgstege, stege, färg - högsta kortet avgör
- Fyrtal - högsta rank av fyrtal avgör
- Triss - högsta rank av triss avgör
- Två par - högsta rank av något par avgör, annars ranken av det andra paret, eller i sista hand det återstående kortet.
- Par - högsta rank på paret avgör, annars rankerna av återstående kort, eller i sista hand färgerna av återstående kort
- Högsta kort - rankerna på korten, eller i sista hand färgerna på korten


<!-- slide -->

### Objektorienterad design

<center style="zoom:0.7">

```plantuml
@startuml
left to right direction 

class Card
{
    + Rank Rank
    + Suite Suite
    + Card(Rank, Suite)
    + int CompareTo(Card)
}

interface "IComparable<Card>"
{
}

Card ..|> "IComparable<Card>"

enum Suite
{
    Clubs,
    Diamonds,
    Hearts,
    Spader
}

enum Rank
{
    Two, 
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
}

Card "4" --* "1" Rank
Card "13" --* "1" Suite

class Hand 
{
    + Card[] Cards
    + HandType Type
    - Card[] ArbitrationCards
    + Hand()
    + void Recieve(Card)
    + void ThrowAway(Card[], Pile)
    + int CompareTo(Hand)
}

interface "IComparable<Hand>"
{
}

Hand ..|> "IComparable<Hand>"

enum HandType
{
    Incomplete,
    HighCard,
    Pair,
    TwoPairs,
    ThreeOfAKind,
    Straight,
    Flush,
    FullHouse,
    FourOfAKind
    StraightFlush
}

Hand "*" ..* "1" HandType
Hand "0..1" --o "0..5" Card

class Deck 
{
    - Card[] Cards
    + Deck()
    + void Shuffle()
    + Card TakeCardFromTop()
    + void ReturnCards(Card[])
}

Deck "0..1" --o "0..52" Card

class Dealer
{
    - Deck Deck
    + Dealer()
    + void ShuffleDeck()
    + void Deal(Player[])
    + void ReplaceCards(Player[])
    + void PresentWinner(Player[])
    + void RecieveHand(Hand)
    + void TakePile(Pile)
}

Dealer "1" ..* "1" Deck
Dealer "1" ..> "1" PlayerComparer

interface "IComparer<Player>"
{

}

class PlayerComparer
{
    int Compare(Player, Player)
}

PlayerComparer ..|> "IComparer<Player>"

class Player 
{
    + Hand Hand
    + string Name
    + Player(string)
    + void RecieveDealtCard(Card)
    + void ThrowCards(Pile)
    + void RecieveReplacements(Card[])
    + void ShowHand()
    + void GiveBackHand(Dealer)
}

Player "*" ..* "1" Hand

class Pile
{
    - Card[] Cards
    + Pile()
    + void Receive(Card[])
    + void ReturnToDeck(Deck)
}

Pile "0..1" --o "0..52" Card

class Game 
{
    - Dealer Dealer
    - Player[] Players
    + Game(Players[])
    + Play()
}

Game "1" ..* "1" Dealer
Game "1" ..o "*" Player

@enduml
```

</center>

