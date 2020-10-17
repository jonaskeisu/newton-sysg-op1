# Fusklapp C# .NET

## Binär kodning och grundäggande typer

### Arbetsminnet

Program lagrar information i datorn *arbetsminnet* som sekvenser av *bitar*. 

Ett annat ord för information är *data*. 

Arbetsminnet kallas ofta enbart för *minnet*.  

En *bit* är ett värde som bara kan vara ``0`` eller ``1``. 

En *byte* är ett fält med 8 bitar, t.ex. ``11010001``. 

Arbetsminnet består av fält av *bytes*. 

Längden av fältet anges av storleken på arbetsminnet. 

### Talbaser
 
Ett tal har basen $B$ om representationen av talet kan innehålla $B$ olika unika symboler tilldelade värden $0$, $1$, .., $B-2$, $B-1$. 

Decimala har basen $B = 10$ och kan innehålla symbolerna: 


#### Decimala tal

| Tecken | ``0`` | ``1``  | ``2`` | ``3`` | ``4`` | ``5`` | ``6`` | ``7``  | ``8`` | ``9``  |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |--- |
| Värde| $0$ | $1$ |$2$ | $3$ | $4$ | $5$ | $6$ | $7$ | $8$ | $9$ |

#### Binära tal

Binära tal har basen $B = 2$ och kan innehålla symbolerna: 

| Tecken | ``0`` | ``1``  | 
| --- | --- | --- | 
| Värde| $0$ | $1$ |

#### Hexadecimala tal

Hexadecimala tal har basen $B = 16$ och kan innehålla symbolerna: 

| Tecken | ``0`` | ``1``  | ``2`` | ``3`` | ``4`` | ``5`` | ``6`` | ``7``  | ``8`` | ``9``  | ``A`` | ``B`` | ``c``  | ``D`` | ``E``  | ``F``  |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Värde| $0$ | $1$ |$2$ | $3$ | $4$ | $5$ | $6$ | $7$ | $8$ | $9$ | $10$ | $11$ | $12$ | $13$ | $14$ | $15$ |

### Notation för tal i olika baser

Ett tal $x$ i talbasen skrivs $(x)_B$. T.ex. gäller att:

> $(FF)_{16} = (11111111)_{2} = (255)_{10}$

Skrivs ingen talbas ut för ett tal så är den normalt  $10$.

### Konvertering till talbas 10

Ett tal $(S_{N-1}S_{N-2}..S_1S_0)_B$ kan konverteras till basen 10 genom formeln:

> $S_{N-1} × B^2 + S_{N-1} × B^2 + .. + S_1 × B^1 + S_1 × B^0$

T.ex. kan värdet $(A0F6)_{16}$ konverteras till basen 10 på följande sätt:

> $(A)_{16} × 16^3 + (0)_{16} × 16^2 + (F)_{16} × 16^1 + (6)_{16} × 16^0 =$ <br/>
> $10 × 16^3 + 0 × 16^2 + 15 × 16^1 + 6 × 16^0 =$ <br/>
> $10 × 4096 + 0 × 255 + 15 × 16 + 6 × 1 =$ <br/>
> $41 206$

### Antal koder

Antalet unika koder som kan lagras i ett fält av längden $N$ där elementen väljs bland $B$ unika symboler är $B^N$. T.ex. med två unika symboler ``0`` och ``1`` så kan ett fält med längden $16$ representera $2^{16} = 65536$ binära koder.

### Grundläggande typer

Heltal som bara kan vara 0 eller positiva kallas *naturliga tal*. 

| Antal bytes | Beskrivning | Kodning | .NET-typ | Alias | Range | 
| --- | --- | --- | --- | --- | --- | 
| 1 | Naturliga tal | bas 2 | ``System.Byte`` | ``byte`` | $[0, 255]$ | 
| 1 | Heltal | två-komplement | ``System.SByte`` | ``sbyte`` | $[-128, 127]$ | 
| 2 | Naturliga tal | bas 2 | ``System.UInt16`` | ``ushort`` |  $[0,  65536]$ | 
| 2 | Heltal | två-komplement | ``System.Int16`` | ``short`` | $[-32768, 32767]$ | 
| 4 | Naturliga tal | bas 2 | ``System.UInt32`` | ``uint`` | $[0, 4294967296]$ | 
| 4 | Heltal | två-komplement | ``System.Int32`` | ``int`` | $[-2147483648,  2147483647]$
| 8 | Naturliga tal | bas 2 | ``System.UInt64`` | ``ulong`` | $[0, 1.8 × 10^{19}]$ (ca.) |  
| 8 | Heltal | två-komplement | ``System.Int64`` | ``long`` | $[-9.2 × 10^{18}, 9.2 × 10^{18}]$ (ca.) |
| 2 | Tecken | UTF-16 | ``System.Char`` | ``char`` | $[0,  65536]$ |
|  | Sanningsvärde |  | ``System.Boolean`` | ``bool`` | $false$, $true$ |


Den binära representationen av ``bool``-värden är inte definierad av .NET-standarden och kan därför variera.

### Unicode 

Standard med målsättning att omfatta alla tecken i hela världen, inklusive alla alfabeten, symboler, emoijis, etc. Består av totalt 17 plan med upp till 65536 tecken i varje plan. T.ex. finns alla bokstäver och andra vanligt förekommande tecken i text i plan 0, emoijis ligger i plan 1, etc.  

### Textkodning

| Kodning | Egenskaper | 
| --- | --- | 
| ASCII | 1 byte per tecken, 128 tecken, inkluderar engelska alfabetet. |
| ISO-8859-1 | 1 byte per tecken, 255 tecken, utökning av ASCII med tecken för språk med rötterna i det Latinska alfabetet, t.ex. svenska. 
| UTF-8 | 1-4 byte per tecken, kodning av alla Unicode-tecken, bakåtkompatibel med ASCII-standarden. | 
| UTF-16 | 2 byte per tecken, kodning av alla Unicode-tecken i plan 0. Kan även koda vilket tecken som helst utanför plan 0 med hjälp av ett surrogatpar av tecken. |
| UTF-32 | 4 byte per tecken, kodning av alla Unicode-tecken. | 


### Char

Värden av typen ``char`` lagras i minnet som 16-bitars heltal i intervallet 0 - 65&nbsp;536. Alla värden som inte binärt börjar med ``11011`` representerar ett tecken i [Unicode-plan 0](https://en.wikipedia.org/wiki/Plane_(Unicode)). 

### String

En sträng är ett fält av element av typen ``char``. 

### Surrogatpar

Det finns inga teckenkoder i Unicode plan 0 som på binär form börjar med sekvensen ``11011``, men i en UTF-16-sträng bildar ett tecken på  binär form: 

> $110110x_9x_8x_7x_6x_5x_4x_3x_2x_1x_0$

följt av ett tecken på binär form:

> $110110y_9y_8y_7y_6y_5y_4y_3y_2y_1y_0$

ett *surrogatpar* som kodar tecknet:

> $(x_5x_4x_3x_2x_1x_0y_9y_8y_7y_6y_5y_4y_3y_2y_1y_0)_2$

i Unicode-plan nummer:

> $(x_9x_8x_7x_6)_2 + 1$ 

## Identifierare

Ett namn som definieras av kod kallas för en *identifierare*.

T.ex. kan en identifierare namnge: 
- En lokal variabel
- En medlem
- En typ (``enum``, ``struct`` eller ``class``)
- Ett namespace 
- En funktion 
- En parameter

## Scope

Ett scope är en behållare av identifierare och varje identifierare är definierad i ett scope. 

Olika typer av scope beskrivs av tabellen nedan.

| Scope | Kan innehålla | 
| --- | --- | 
| Typ | <ul><li>Variabler</li><li>Metoder</li><li>Egenskaper</li><li>Nästade typer</li><li>Event</li><li>Operatorer</li><li>Konstanter</li><li>Indexierare</ul> | 
| Namespace | <ul><li>Typdefinitioner</li><li>Nästade namespace</li></ul> | 
| Kodblock | <ul><li>Lokala variabler</li><li>Lokala funktioner</li><li>Nästade kodblock</li><li>Parametrar</ul> |


## Synlighet

En identifierare är *synlig* i:
- Scopet där den definieras. 
- Alla nästade scope till scopet där den är definierad.  

Omvänt, i ett scope är en identifierare synliga om den är:
- Definierade i det aktuella scopet. 
- Definierad i ett ovanliggande scope. 


## Uttryck

Ett uttryck är ett komplett segment kod som kan beräknas till ett värde. Ett uttryck är inte fristående kod utan måste ingå i en sats.


### Litteraler

Litteraler är konkreta värden som beskrivs boktstavligen i koden, t.ex. ``0``, ``1``, ``3.14``, ``7e-10``, ``true``, ``false``, ``"abc"`` och ``'a'``. 

### Variabler

En synlig och åtkomlig variabel är ett uttryck som beräknas till värdet lagrat i variabeln minne. En variabel får endast användas efter att den blivit tilldelad. Tilldening av en variabel i samma sats som definierar variabeln kallas för *initalisering*. 

### Metodanrop

Ett anrop till en synlig och åtkomlig metod är ett uttryck som beräknas genom att anropets argument beräknas och tilldelas metodens parametrar varefter metodens kropp körs. Resultatet blir värdet av uttrycket som metoden returnerar. 

### Operatoruttryck

Operatorer beräknar värden från värdet av andra uttryck som kallas operatorns operander. Exempel på operatorer är: 

| Kategori | Exempel |
| --- | --- |
| Tilldelning | ``=``, ``+=``, ``-=``, ``*=``, ``/=``
| Aritmetisk | ``+``, ``-``, ``*``, ``/``, ``%``, ``++``, ``--`` |
| Jämförelse | ``<``, ``>``, ``<=``, ``>=``, ``==``, ``!=`` |
| Logiska | ``&&``, <code>&#124;&#124;</code>, ``!`` |
| Bitvisa | <code>&#124;</code>, ``&``, ``^``, ``~`` |
| Shift | ``<<``, ``>>`` | 


### Switch-uttryck

Beräkning av ett värde genom mönstermatchning mot ett argumentvärde. 

```cs
(<argument>) switch {
    <mönster> => <resultat>,
    <mönster> => <resultat>,
    ..
    _ => <resultat>
}
```

## Satser

Kod är en sekvens av *satser*. En sats är den minsta enheten av kod som kan köras självständigt. 

### Variabeldefinition

Deklarerar en ny variabel i aktuellt scope. 

```cs
<typ> <identifierare> = <initaliserare>;
``` 

### Blocksats

```cs
{
    <sats1>
    <sats2>
    ...
}
```

### If-else-sats

```cs
if (<villkor>) 
    <sats>  
else 
    <sats>
```

### Switch-sats

```cs
switch (<argument>) {
    case <mönster>: 
        <kod>
        break;
    case <mönster>
        <kod>
        break;
    ..
    default:
        <kod>;
        break;
}
```

### For-sats

```cs
for (<initalisering>; <villkor>; <stegning>)
    <sats>
```

### Foreach-sats

```cs
foreach (<variabel> in <IEnumerable>)
    <sats>
```

### While-sats

```cs 
while (<villkor>)
    <sats>
```

### Do-while-sats

```cs
do
    <sats>
while (<villkor>);
```

### Break

Hoppa ut kroopen på en loop- eller switch-sats.

```cs
break;
```

### Continue

Hoppa direkt till slutet på kroppen för en loop-sats.

```cs
continue;
```

### Return 

Avsluta ett anrop till en metod. Om returtypen för metoden inte är ``void`` skall nyckelordet ``return`` följas av ett uttryck ger som beräknas till metodens resultat.

```cs
return <resultat>;
```

### Uttryck som sats

Ett uttryck vars beräkning har sidoeffekt är följt av ett semikolon en giltig sats. 

```cs
<uttryck>;
```

## Uttrycksföreträde

Företrädesnivåer för operatorer från högsta till lägsta.

| Operator |
| --- | 
| ``f(x)``, ``x.y``, ``a[i]``, ``x++``, ``x--``, ``new`` |
| ``-x``, ``++x``, ``--x``, ``!x``, ``^x``, ``~x`` |
| ``switch`` | 
| ``x * y``, ``x / y``, ``x % y`` | 
| ``x + y``, ``x - y`` | 
| ``x << y``, ``x >> y`` |
| ``x <= y``, ``x < y``, ``x => y``, ``x > y``, ``as``, ``is`` |
| ``x == y``, ``x != y`` |
| ``x & y`` | 
| ``x ^ y`` | 
| <code>x &#124; y</code> |
| ``x && y`` | 
| <code>x &#124;&#124; y</code> |
| ``c ? t : f`` | 
| ``=``, ``+=``, ``-=``, ``*=``, ``/=``, ``x %= y``, ``x &= y``,<code>x &#124;= y</code>, ``x <<= y``, ``x >>= y`` |

## Variabel

Variabler är namngivet lagringsuttrymme i minnet för att lagra värden av en viss typ.

### Värdetyper

 För värdetyper är värdet som lagras i variabelns minne ett *objekt*. Ett objekt lagras i minnet som de aktuella värdena på objektets alla *medlemsvariabler*. 

```plantuml
node " "Jonas", 42" as person
note left
    Värdetyp
end note
```

Exempel på värdetyper:
- Alla taltyper (``byte``, ``int``, ``float``, ``double``, ``enum``, ``char``, m.fl.)
- Booleans (``bool``)
- Användardefinierade strukturer (``struct``)
 
### Referenstyper 

 För referenstyper är värdet som lagras i variabelns minne en *referens* till ett objekt som skapats med nyckelordet ``new`` och som ligger lagrat på *heapen*.  

```plantuml
node "<referens>" as ref
note left 
    Referenstyp
end note

cloud Heap {
    node " "Tesla", "ABC123" " as car
}

ref --> car
```

Exempel på referenstyper:
- Strängar (```string```)
- Fält (``<typ>[]``)
- Användardefinierade klasser (``class``)

### Null

Nyckelordet ``null`` är värdet på en referens som inte refererar till något värde.


### Kopiering av värden

När ett värde av referenstyp kopieras skapas en ny kopia av en referens. När ett värde av värdetyp kopieras tilldelas varje medlemsvariabel för kopian aktuella värdet för motsvarande medlemsvariabel hos originalet.

```plantuml
node " "Jonas", 42" as person1
note left 
    Original
end note

node " "Jonas", 42" as person2
note left 
    Kopia
end note

person1 ..> person2: Kopiering

node "<referens>" as ref1
note left 
    Original
end note
node "<referens>" as ref2
note right 
    Kopia
end note

ref1 ..> ref2: Kopiering

cloud Heap {
    node " "Tesla", "ABC123" " as car
}

ref1 --> car
ref2 --> car
```


Värden kopieras t.ex. när ett värde:
- Tilldelas av en variabel, egenskap eller indexierare.
- Returnerneras från en metod.
- Används som argument till en metod.
- Används som operand till en operator.

## Defaultvärden

Ett oiniterat värden har defaultvärde enligt typ. 

| Typ | Defaultvärde
| --- | --- | 
| Alla taltyper | $0$ | 
| ``enum`` | $0$ | 
| ``char`` | ``'\0'`` | 
| ``bool`` | ``false`` | 
| Fält | ``null`` | 
| ``class`` | ``null`` | 
| ``struct`` | Medlemsvariabler har defaultvärde. |

## Fält

Exempel på definition och initierare av fält:
```cs 
int[] numbers = { 1, 2, 3 }; // Endimensionellt fält
string[,] texts = { // Tvådimensionellt fält
    { "anna", "karl" }, 
    { "jimmy", "daniel" }, 
    { "fredrik", "veronica" }
};
```

För fälten ovan är nedanstående villkor uppfyllda: 

```cs
numbers[0] == 1
numbers[2] == 3
texts[2, 1] == "veronica"
numbers.Rank == 1
numbers.Length == 3
texts.Rank == 2
texts.GetLength(0) == 3
texts.GetLength(1) == 2
```

Skapa nya fält:

```cs 
new string[10]; // nytt fält av 10 strängreferenser
new bool[5, 2]; // nytt fält med 5 rader och 2 kolumner av boolvärden
```

Element för nya fält utan initiering har defaultvärde.

## Konvertering

Ett värde av typ ``B`` kan konverteras till ett värde av annan typ ``A`` endast om det finns en implicit eller explicit konverteringsgoperator från ``B`` till ``A``. 


```cs
// Kodraden nedan kräver ett automatiskt anrop till en 
// implicit konverteringsoperator till typen A överlagrad
// för en operand av typen B.  
A a1 = <uttryck av typen B>; 

// Kodraden nedan innehåller ett anrop till den explicit 
// konverteringsoperator (A) till typen A överlagrad för 
// en operand av typen B. 
A a2 = (A)<uttryck av typen B>; 
```

### Användardefinierade konverteringsoperatorer

```cs 
struct B {
    // ..
    public static implicit operator B(A a) {
        /* kod som returnerar ett motsvarande värde av typen A */
    }

    public static explicit operator C(A a) {
        /* kod som returnerar ett motsvarande värde av typen C */
    }
    // ..
```

### Inbyggda konverteringsoperatorer

X = Implicit konvertersopertor är inbyggd i språket.
Blankt = Explicit konverteringsoperator är inbyggd i språket.

| Från/Till | ``byte`` | ``sbyte`` | ``ushort`` | ``short`` | ``uint`` | ``int`` | ``ulong`` | ``long`` | ``enum`` | ``char`` | ``float`` | ``double`` |
| --- | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | 
| **``byte``**    |   |   |   | X |   | X |   | X |   |   | X | X |
| **``ubyte``**   |   |   | X | X | X | X | X | X |   |   | X | X |    
| **``ushort``**  |   |   |   |   | X | X | X | X |   |   | X | X |    
| **``short``**   |   |   |   |   |   | X |   | X |   |   | X | X |
| **``uint``**    |   |   |   |   |   |   | X | X |   |   | X | X |
| **``int``**     |   |   |   |   |   |   |   | X |   |   | X | X |
| **``ulong``**   |   |   |   |   |   |   |   |   |   |   | X | X |
| **``long``**    |   |   |   |   |   |   |   |   |   |   | X | X |
| **``enum``**    |   |   |   |   |   |   |   |   |   |   |   |   |
| **``char``**    |   |   | X |   | X | X | X | X |   |   | X | X |
| **``float``**   |   |   |   |   |   |   |   |   |   |   |   | X |
| **``double``**  |   |   |   |   |   |   |   |   |   |   |   |   |

## Funktioner

En funktion består av en *signatur* och en kropp. 

### Signatur

Funktionens signatur innehåller:
- En identifierare för funktionen. 
- En lista av parametrar med typ och identifierare.
- Typen på returvärdet (``void`` om inget värde returneras).

Syntax: 

```cs
<returtyp> <identifierare>(<parameterlista>)
```

#### Exempel

```cs
bool IsPalindrome(string text)

string Substring(string text, int starPosition, int length)

void Sort(object[] objects)

int Max(int[] numbers, int default)
```

### Kropp

Kroppen för en funktion är ett kodblock som följer efter funktionens signatur. Funktionens parametrar kan användas som lokala variabler i funktionens kropp. För en funktion som inte har returtyp ``void`` måste varje programflöde genom funktionen sluta med satsen:

``return <uttryck>;``

#### Exempel

```cs 
bool IsPalindrome(string text)  { 
    for (int i = 0; i < text.Length / 2; ++i) 
        if (text[i] != text[text.Length - 1 - i])
            return false;
    return true;
}

int Max(int[] numbers, int default) {
    if (numbers.Length == 0)
        return default;
    else 
    {
        int max = numbers[0];
        for (int i = 1; i < numbers.Length; ++i)
            if (numbers[i] > max)
                max = numbers[i];
        return max;
    }
}
```

### Anrop

Ett funktionsanrop är ett uttryck som består av funktionens identifierare följt av en lista av uttryck som kallas argumentlista. Typen för och antalet argument måste matcha funktionens parameterlista. 

Värdet av ett funktionsanrop beräknas genom att:
- Argumentens värden beräknas och tilldelas funktionens parametrar. 
- Koden i funktionens kropp körs till programflödet når en ``return``-sats.
- Uttrycket i returnsatsen beräknas som funktionsanropets resultat. 

#### Exempel

```cs 
Substring("Jonas Keisu", 6, 5) // Anropet beräknas till "Keisu"

IsPlandrom("tappat") // Anropet beräknas till true

Max(new in[] { 1, 2, 3, 2, 1}, 0) // Anropet beräknas till 3
```

## Objekt

Ett objekt är en behållare av medlemmar.

### Medlemmar

Objekt kan ha följande sorters medlemmar: 
- Variabler
- Metoder
- Egenskaper
- Konstruerare
- Operatorer
- Indexierare
- Nästade typer
- Event

samt *konstanter* och *dekonstruerare* som vi inte går in på djupare i kursen.

### Tillstånd

Ett objekts tillstånd är informationen som lagras i datorns arbetsminne för att repsentera det specifika objektet. Ett objekts tillstånd består av  aktuella värdena på objektets medlemsvariabler. Två objekt med samma tillstånd är likvärdiga, men inte nödvändigtvis samma objekt. 


## Klass

En klass beskriver objekt med gemensamma medlemmar men är också själv ett objekt med egna medlemmar. En ny klass definieras med följande syntax:

```cs
<modifierare> class <identifierare>
{
    <modifierare> <medlem1>
    <modifierare> <medlem2>
    ..
}
```


### Instanser

Objekt tillhörande en klass kallas *instanser* av klassen och deras medlemmar kallas *instansmedlemmar*. 

#### New

En ny instans av klassen skapas på heapen med nyckelordet ``new`` följt av ett anrop till en konstruktor för att initialisera instansen tillstånd. 

#### Referens till instansmedlemmar

En instansmedlem kan endast refereras via en instans, t.ex. med hjälp av punktoperatorn med en instans som första operand. I kroppen av en instansmedlem kan instansmedlemmar av samma klass refereras direkt utan punktoperatorn med betydelsen att refererens gäller samma instans som kroppen anropats för.

#### This

I kroppen till en instansmetod är nyckelordet ``this`` ett uttryck för den instans som metoden har anropats för. Nyckelordet ``this`` används t.ex. för att särskilja på instansmedlemmar och metodparametrar med samma namn. 

#### Exempel

```cs 
class Program {
    class Car {
        // Värdena på medlemmsvariablerna 'model' och 'horsePower' för  instansen
        // utgör tillståndet på en instans av Car.
        private string model;
        private int horsePowers;

        // Konstruktor
        public Car(string model, int horsePowers) {
            // Identifieraren 'model' refererar till konstruktorn parameter 'model',
            // men 'this.model' refererar till medlemsvariabeln 'model' för instansen.
            this.model = model;
            this.horsePowers = horsePowers;
        }

        // Instansmetod
        public void Drive() {
            // För anropet 'car.Drive()' nedan refererar kommer 'horsePower' på 
            // nästa kodrad referera till 'car.horsePower'.
            if (horsePower < 400)
                System.Console.WriteLine("Wrooom");
            else 
                System.Console.WriteLine("WROOOM");
        }
    }

    public static void Main(string[] args) {
        // Ny instans av klassen Car skapas på heapen och en referens till instansen
        // tilldelas variabeln 'car'.
        Car car = new Car("Tesla", 600); 
        // Medlemmen 'Drive()' anropas för instansen 'car'
        car.Drive();
    }
}
```

### Static

En medlem med modifieraren ``static`` tillhör klassen istället för klassens instanser. För statiska medlemmar fungerar klassen som ett namespace. I klassens scope och nästade scope till klassen är statiska medlemmar synliga. Från andra scope kan en statisk medlem refereras med punktoperatorn via klassens namn.

#### Exempel

```cs 
class Program {
    class Car {
        // ..
        // Medlemsvariabel för klassen
        private static int carCount; 

        // Egenskap för klassen
        public static int CarCount {
            get => carCount; 
            private set => carCount = value;
        }

        // Konstruktor
        public Car(string model, int horsePowers) {
            this.model = mode;
            this.horsePowers = horsePowers;
            // Nästat scope till klassen 'Car' där egenskapen 'CarCount' är synlig.
            ++CarCount;         
        }
        // ..
    }

    public static void Main(string[] args)
    {
        var volvo = new Car("Volvo", 407);
        var tesla = new Car("Tesla", 600);
        // Klassen 'Car' är synlig i detta scope men inte egenskapen 'CarCount', 
        // så  'CarCount' måste refereras via klassnamnet 'Car' med punktnotation.
        var carCount = Car.CarCount; 
    }
```

### Åtkomst

En identifierare kan endast användas i kod där den är *synlig* och *åtkomlig*. Åtkomst för typer och medlemmar bestäms genom modifierarna i tabellen nedan. 

| Modifierare | Åtkomlig för | Tillämpbar för |
| --- | --- | --- |  
| ``public`` | All kod | Typer och medlemmar | 
| ``internal`` | Kod i samma assembly | Typer och medlemmar | 
| ``protected`` | Kod i samma klass eller ärvande klasser | Medlemmar | 
| ``private`` | Kod i samma klass/struktur | Medlemmar

Defaultåtkomst är för typer ``internal`` och för medlemmar ``private``. 


### Metoder

En metod är en funktion som är definierad som en medlem i en klass eller struktur.  

## Arv 

En klass kan ärva en annan klass. Objekt av den ärvande klassen har alla medlemmar som objekt av den ärvda klassens objekt har plus medlemmarna definierade i den ärvande klassen. 

En klass kan bara ärva en en annan klass, men många klasser kan ärva samma klass. Därför formar arv en trädstruktur (*hierarki*) av klasser. 

En klass som inte explicit ärver en annan klass ärver automatiskt klassen ``System.Object``. Därför ligger ``System.Object`` alltid högst upp i hierarkin.

```plantuml
class Object 
class Fordon
class Moped
class Bil
class Taxi 
class Ambulans
Object <|-- Fordon
Fordon <|-- Moped
Fordon <|-- Bil
Bil <|-- Taxi
Bil <|-- Ambulans

```

#### Abstract

En klass som har signaturer för medlemmar som saknar kropp är är abstrakt och måste ha modifieraren ``abstract``.  


## Casting

Casting konverterar typen på en referens. 

### Up-cast

Om klassen ``B`` ärver från typen ``A`` så kan en referens av typen ``B`` implicit castas till typen ``A``. 

```cs 
A a = <uttryck av typen B>; // Implicit up-cast
```

### Down-cast

Om klassen ``B`` ärver från typen ``A`` så kan en referens av typen ``A`` explicit castas till typen ``B``. Om refensen inte refererar till objekt av typen ``B`` eller som ärver från typen ``B`` så genereras ett ``InvalidCastException``. 

```cs
B b = (B)<uttryck av typen A>; // Explicit down-cast
```

### Is

Operatorn ``is`` tar en referens och en typ som operander och returnerar ett värde av typen ``bool``. Resultatet är ``true`` om referenens kan castas till operandtypen, annars ``false``.  

#### Exempel

```cs
class A {}
class B : A {}
// ..
A a = new A();
B b = new B();
bool x = a is B; // x = false
bool y = b is A; // y = true
```

### As

Operatorn ``as`` tar en referens och en typ som operander och returnerar en referens av operandtypen. Om referensen kan kastas till operandtypen så är resultatet den castade referensen, annars ``null``. 
