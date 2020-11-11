# Repetition 

## Variabel

Vad är en variabel?

Ett lagringsutrymme i datorn där man kan lagra värden av specifik typ. 

En variabel har:
- Ett namn
- En typ
- Ett lagrat värde

Exempel:

Bilden nedan illustrerar en variabel med namnet ``age``, typen ``int`` och som lagrar värdet ``42``: 

```plantuml
node " " as var {
    label "42"
}
note left of var 
    int age
endnote
```

### Identifierare

Namn vars betydelse anges av programmeraren kallas inom programmering för *identifierare* (*identifier*).

### Deklaration

*Deklaration* (*declaration*) är en beskrivning i koden av betydelsen av en identifierare. Ibland säger man *definition* istället för deklaration.

Exempel: 

Variabeldeklaration

```cs
int age;
```

### Syntax

*Syntax* är regler för hur giltig kod kan skrivas. 

### Tilldelning 

*Tilldelning* (*assignment*) är sats (kodrad) som när den körs lagrar ett värde i ett lagringsutrymme. Tilldelning gör med tilldelningsoperatorn: ``=``

Syntax: 

```cs
<lagringsutrymme> = <uttryck>;
```

där uttrycket måste ha sammma typ som lagringsutrymmet. 

Exempel: 

Variabeltilldelning

```cs
age = 42;
```

### Initiering

*Initiering* (*initialization*) är tilldelning av en identifierare i samband med deklaration. M.a.o. på samma kodrad som vi deklarerar identifieraren tilldelar vi också identifieraren ett värde. 

Syntaxen: 

```cs
<variabeldeklaration> = <initierare>;
```

Exempel:

Variabelinitiering

```cs
int age = 42;
```

## Uttryck

Ett *uttryck* (*expression*) är ett segment kod som kan beräknas till ett värde av en specifik typ. Ett *kodsegment* är en sammanhängande följd kod. 

Ett uttryck är ensamt (isolerat) ingen giltig kod!

Exempel:

```cs
123 // litteral - värdet som uttrycket skall beräknas till står bokstavligen utskrivet i koden

age // variabelreferens - beräknas till värdet senast tilldelat variabeln, har samma typ som variabeln

Count(arr) // funktionsanrop -  beräknas genom att köra kroppen i deklarationen av funktionen, har typen som är funktionens returtyp i deklarationen

1 + 2 // operatoruttryck - beräknas till ett värde enligt operatorns beräkningsregel och beroende på beräknat värde på operatorns operander
```

### Litteral

En *litteral* (*literal*) är ett uttryck vars värde beskrivs bokstavligen i koden.

Exempel: 

```cs
123 // litteral av typen int
123.0 // litteral av typen double
123.0f // litteral av typen float
false // litteral av typen bool
true // litteral av typen bool
"hej" // litteral av typen string
'x' // litteral av typen char
```

### Sats

En *sats* (*statement*) är det minsta segementet kod som kan köras ensamt (isolerat).

Exempel på enkla satser: 

```cs
int age; 

age = 42;

count = Count(arr); 
```

### Kodblock

Ett kodblock sammanfogar en sekvens satser till en sats. Att köra den resulterande satsen betyder att köra koden i kodblocket. 

Syntax: 

```cs
{
    <sats 1>;
    <sats 2>;
    ...
}
```

### Styrning av programflödet

Satser som bestämmer vilka kodrader som skall köras och i vilken ordning kallas för satser som styr programflödet (*flow control*).

Exempel:

En if-sats är en sammansatt sats me följande syntax:

```cs 
if (<villkor>)
    <sats>
```


där ``<villkor>`` är ett uttryck av typen ``bool``. Vid körning har satsen betydelsen: om och endast om det beräknade värdet av ``<villkor>`` är ``true``, kör då ``<sats>``.

I exemplet ovan så är: 

```cs
if (<villkor>)
```

huvudet för den sammansatta satsen och:

```cs
<sats>
```

är kroppen för den sammansatta satsen. 

Ett till exempel: 

En if-else-sats är en sammansatt sats med syntax:

```cs
if (<villkor>)
    <sats1>
else 
    <sats2>
```

där ``<villkor>`` är ett uttryck av typen ``bool``. Vid körning har satsen betydelsen: om ``<villkor>`` beräknas till ``true``, kör ``<sats1>``, annars kör ``<sats2>``.

### Villkor

Ett *villkor* (*condition*) är ett uttryck av typen *bool*.

### Funktion

En *funktion* (*function*) är ett namngivet kodblock. 

Man använder funktioner t.ex. för att kunna återanvända kod. Kodeblocket för en funktion kan köras från olika ställen i koden hur många gånger som helst genom att referera namnet på funktionen, vilket kallas att man *anropar* (*call*) funktionen. 

En funktion har utöver ett kodblock en lista av parametrar. En *parameter* är en variabel tillhörande funktionens kodblocket som måste tilldelas ett värde vid varje anrop till funktionen innan  kodblock körs. En parameterlista är en kommaseparerad sekvens parametrar inom parenteser. 

Ett anrop till en funktion är ett uttryck. Anropet beräknas till ett värde av funktionens *resultattyp*. Värdet beräknas genom att funktionens kodblock körs. Därför måste varje möjligt programflöde genom funktionens kodblock sluta med en sats som innehåller nyckelordet ``return`` följt av ett uttryck av samma typ som funktionens resultattyp. När vid anrop programflödet i funktionens kodblocket når en ``return``-sats så är beräkningen av anropets värde färdigt och lika med det beräknade värdet av uttrycket efter nyckelordet ``return``. 

Syntax för deklaration av funktion: 

```cs
<resultattyp> <identifierare> (<parameter 1>, <parameter 2>, ...)
    <kodblock>
```

Syntaxen för anrop av funktion:

En funktion anropas med följande syntax:

```cs
<identifierare> (<argument 1>, <argument 2>, ..)
```

där ``<argument k>`` är ett uttryck av samma typ som ``<parameter k>``. Anropet är ett uttryck av samma typ som funktionens resultat. För att beräkna uttryckets värde så beräknas först värdet av alla argumentuttryck och tilldelas motsvarande parameterar. Sedan körs kodblocket till dess att programflödet når en ``return``-sats. Uttrycket som följer nyckelordet ``return`` beräknas som funktionsanropets värde. 

Exempel:

Följande är en deklaration av en funktion:

```cs
int Add(int term1, int term2)
{
    return term1 + term2;
}
```

där ``<resultattyp>`` är ``int``, ``<identifierare>`` är ``Add``, parameterlista är ``(int term1, int term2)`` och ``<kodblock>`` är: 

```cs
{
    return term1 + term2;
}
```

Om vi antar att det finns en deklarerad variabel ``x`` av typen kan vi anropa den deklarerade funktionen:

```cs 
Add(23, x)
```

Anropet är ett uttryck av typen ``int``. Vid körning av uttrycket räknas först värdet anropets första argument (``23``) ut och tilldelas parametern ``term1``. Sedan beräknas värdet av anropets andra argument ut och tilldelas parametern ``term2``. Sedan körs funktionens kodblock fram till en ``return``-sats, vilken i det här fallet returnerar värdet på uttryck ``term1 + term2``. På så sätt beräknas värdet av uttrycket ``Add(23, x)`` till det senaste värdet tilldelat variabeln ``x`` plus ``23``. 

## Funktionens signatur och kropp

Huvudet på en deklaration av en funktion kallas för funktionens *signatur* (*signature*). Kodblocket för en funktion kallas för funktionens kropp (*body*). 

Exempel:

I funktionsdeklarationen ovan så är signaturen: 

```cs
int Add(int term1, int term2)
```

och kroppen: 

```cs
{
    return term1 + term2;
}
```

## Funktioner utan parametrar

En parameterlista kan vara tom: 

```cs
<resultattyp> <identifierare> ()
    <kodblock>
```

och då har funktionsanropet följande syntax:

```cs
<identifierare> ()
```

## Funktioner utan resultatvärde

En funktion kan ha resultattyp ``void`` vilket betyder att funktionen inte resulterar i ett värde:

```cs
void <identifierare> (<parameter 1>, <parameter 2>, ...)
    <kodblock>
```

Ett anrop till en funktion som har resultattyp ``void`` kan inte som ett uttryck tilldelas ett lagringsutrymme. 

En funktion som har resultattyp ``void`` har inget uttryck efter nyckelordet ``return`` i sitt kodblock. Ett giltigt avslut på anropet av en ``void``-funktion är också att programflödet når kodblockets slut.

## Operatorer

En *operator* är en eller flera reserverade symboler i programmeringsspråket som kombinerar värden till uttryck. Värdena som ingår i ett operatoruttryck kallas för *operander*. 

Exempel: 

Additionsoperatorn för heltal kan anropas med följande syntax: 

```cs
<operand1> + <operand2>
```

där både ``<operand1>`` och ``<operand2>`` är ett uttryck av typen ``int``. Anropet är ett uttryck av typen ``int``. 

### Aritmetiska operatorer

En *aritmetisk* operator beräknar talvärden och har tal som operander.

Exempel:

```cs
x + y
x - y
x * y
x / y
x % y
++x
x++
--x
++x
-x
```

### Jämförelseoperatorer

En jämförelseoperator skapar ett villkor genom att jämför två värden av samma typ. 

Exempel:

```cs 
x < y
x <= y
x == y
x >= y
x > y
x != y
```

### Logiska operatorer

En logisk operator skapar ett villkor från andra villkor som operander.

```cs
x && y
x || y
!x
```

där ``x`` och ``y`` är uttryck av typen ``bool``.

## Valoperatorn

*Valoperatorn* (*conditional operator*) består av två symboler (``?`` och ``:``) tillsammans med tre operander:

```cs
<villkor> ? <operand2> : <operand3>
```

där ``<villkor>`` är ett uttryck av typen ``bool`` och uttrycken ``<operand2>`` och ``<operand3>`` kan ha vilken typ som helt men de måste ha *samma* typ. Uttrycket har samma typ som ``<operand2>`` och ``<operand3>`` och beräknas som: om ``<villkor>`` beräknas till ``true``, så är värdet på uttrycket det beräknade värdet av ``<operand2>``, annars det beräknade värdet av ``<operand3>``. 

Exempel:

Följande är ett uttryck:

```cs 
(age > 40) ? "gammal" : "ung"
```

av typen ``string`` som beräknas genom att villkoret ``(age > 40)`` först beräknas och om värdet är ``true`` så blir hela resultatet ``"gammal"``, annars ``"ung"``. 

## Scope

Ett *scope* är en behållare för deklarationer av identifierare. Varje deklaration av en identifierare sker i ett scope. 

Exempel på scope (behållare av deklarationer):
- Funktionskropp
- Nästat kodblock
- Klasser / stukturer
- Namespace 


```cs
int Sum(int[] arr)
{ // Funktionskroppen är ett scope som innehåller identifierarna arr och s
    int s = 0;
    foreach (int elem in arr)
    { // Det nästade kodblocket är ett scope som innehåller identifierarna elem
        s += elem;
    }
    return s;
}

class Employee
{ // Klassen är ett scope som innehåller identifierarna age, name och ToString
    int age;
    string name;

    public string ToString()
    { // Funktionskroppen är ett scope som innehåller identifieraren description
        string description = age.ToString() + name;
        return description;  
    }
}

namespace Program 
{ // Namespace är ett scope som innehåller identifieraren Car
    struct Car 
    { // Strukturen är ett scope som innehåller identifierarna horsePowers och productionYear
        int horsePowers; 
        string productionYear;
    }
}
```

## Synlighet

En identifierare är *synlig* (*in scope*) i det scopet där den är deklarerad och i det scopets innre scope (nästade scope). En identifierare kan bara refereras direkt via sitt namn i de scope där den är synlig. Grundregeln är att varje identifierare får bara ha en deklaration i varje scope. 

Exempel:

```cs
// Scope 0 (även kallat root eller global scope)

namespace Program 
{ // Scope 1
    class MyApp
    { // Scope 2
        static void Main(string[] args)
        { // Scope 3
            int sum = 0;  
            for (int i = 0; i < 10; ++i)
            { // Scope 4 
                 
                sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}
```

Identifieraren ``Program`` är synlig i scope 0, 1, 2, 3 och 4. 

Identifieraren ``MyApp`` är synlig i scope 1, 2, 3 och 4.

Identifieraren ``Main`` är synlig i scope 2, 3 och 4.

Identifieraren ``args`` och ``sum`` är synlig i scope 3 och 4. 

Identifieraren ``i`` är synlig i scope 4.

## Överlagring

Flera funktioner kan deklareras med samma identifierare om de olika funktionsdeklarationerna har olika typer på eller antal av parametrar. 

Exempel: 

```cs
class Math
{
    int Add(int term1, int term2)
    {
        return term1 + term2;
    }

    int Add(float term1, float term2) // OK, överlagring
    {
        return (int)(term1 + term2);
    }

    float Add(int x, int y) // INTE OK, samma antal parametrar och samma typer på parametrarna på varje position som i första deklarationen ovan
    {
        return x + y;
    }
}
```

## Konvertering

Ett värde av en typ kan automatiskt *konverteras* (*convert*) till ett värde av en annan "rymligare" typ. T.ex. kan värden av typen ``sbyte`` automatiskt konverteras till ``int``, ``short`` och ``long``. Som ett annat exempel kan värden av typen ``float`` automatiskt konverteras till ``double``. Konvertering som kan ske automatiskt kallas för *implicit* konvertering. 


Exempel:

Koden nedan är bara giltig eftersom värden av typen ``int`` är automatiskt konverterbara till värden av typen ``double``.

```cs 
double x = 3.14 + 10;  
```

Vi kan tvinga ett värde att konverteras till en "mindre rymlig" typ genom explicit konvertering. 

```cs
int x = (int)3.14;
string tal = (string)999;
```















