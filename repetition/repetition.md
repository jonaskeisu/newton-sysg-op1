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
    <sats1>;
    <sats2>;
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

## Klasser

Vad är en klass? 

- Ett namngivet scope - en behållare för deklarationer av identifierare
- En mall för hur man skapar objekt (instanser) tillhörande klassen

En stats som deklararerar en klass använder nyckelordet ``class``. 

Exempel: 

```cs
namspace Program
{
    class Person // Person är en identifierare av typen klass deklarerad i scopet Program
    {
        // variabeldeklaration i scopet Person
        public string name; 
        public int age; 
        public string email; 
    }
}
```

Identifierare deklararerade i en klass kallas för *medlemmar*. 

## Klass som mall för att skapa objekt i minnet

Funktioner deklarerade i en klass (medlemsfunktion) kalls för *metoder*. 

Ett objekt skapat från klassen som mall består i datorns minne som en ny kopia av de variabler som är deklarerade i klassen. 

Ett nytt objekt tillhörande en klass skapas med syntaxen: 

```cs
new <klass>(<parameterlista för konstruktor>)
```

som är ett uttryck av typen ``<klass>`` som beräknas till en referens till ett nytt objekt i datorns minne.

Om ingen konstruktor är deklarerad i klassen skapas automatiskt en *defaultkonstruktor* som inte har några parametrar och som initierar alla objektets variabler till defaultvärde efter typ. 

Exempel:

```cs
namespace Program
{
    class Person
    {
        // som ovan
        // ...
    }

    public static void Main(string[] args)
    {
        Person jonas = new Person();
        Person karl = new Person(); 
        // Brytpunkt 1 
        jonas.name = "Jonas";
        jonas.age = 42;
        jonas.email = "jonas.keisu@bitaddict.se";
        karl.name = "Karl";
        karl.age = 27;
        karl.email = "karl.svensson@bitaddict.se";
        // Brytpunkt 2
        // .. mer kod        
    }
}
```

Efter brytpunkt 1 så ligger följande objekt lagrade i datorns minne:

```plantuml
object jonas {
    name = null
    age = 0
    email = null
}

object karl {
    name = null
    age = 0
    email = null
}
```

Efter brytpunkt 2 så innehåller objekten i minnet följande värden:

```plantuml
object jonas {
    name = "Jonas"
    age = 42
    email = "jonas.keisu@bitaddict.se"
}

object karl {
    name = "Karl"
    age = 27
    email = "karl.svensson@bitaddict.se"
}
```

Aktuellt värde på ett objekts variabler kallas för objektets *tillstånd*. 

Två objekt kan ha samma tillstånd vilket betyder att de är likvärdiga men det behöver inte vara samma objekt. 

```cs
Person jonas = new Person();
Person karl = new Person(); 
jonas.name = "Jonas";
jonas.age = 42;
jonas.email = "jonas.keisu@bitaddict.se";
karl.name = "Jonas";
karl.age = 42;
karl.email = "jonas.keisu@bitaddict.se";
// De två objekten ovan har samma tillstånd nu
```

Ett objekt som är skapat med en klass som mall kallas för en *instans* (eng. *instance*) av klassen. T.ex. innehåller variablerna i exemplet ovan referenser till instanser av klassen ``Person``. 

## Metoder

En funktion som är en medlem i en klass kallas för *metod*.

Motivation till metoder: 

Om vi har en klass som samlar variabler som beskriver t.ex. en person: 

```cs
class Person
{
    public string name; 
    public int age; 
    public string email; 
}
```

så vill vi säker ha funktioner som gör olika saker med objekt tillhörande klassen, t.ex. 

```cs
// Skriver ut personinformation
void PersonPrintInfo(Person person)
{
    Console.WriteLine($"Name: {person.name} Age: {person.age}, Email: {person.email}");
}

// Ökar personens ålder med 1
void PersonBirthday(Person person)
{
    person.age += 1; 
}

void PersonSayHelloTo(Person person, Person otherPerson)
{
    Console.WriteLine($"{person.name} says 'Hello' to {otherPerson.name});
}

// .. 
Person jonas = new Person();
Person karl = new Person(); 
jonas.name = "Jonas";
jonas.age = 42;
jonas.email = "jonas.keisu@bitaddict.se";
karl.name = "Karl";
karl.age = 27;
karl.email = "karl.svensson@bitaddict.se";

PersonPrintInfo(jonas);
PersonBirthday(jonas);
PersonSayHelloTo(jonas, karl);
```

Vi ser ett mönster! Alla funktioner ovan tar som första parameter en referens till en *aktuell* person. Det är väldigt vanligt förekommande att ha funktioner som arbetar på ett aktuell objekt. Så vanligt att det finns ett speciellt sätt att skapa sådana funktioner i C#, genom att göra funktionerna till metoder för objektets klass. 

Som metoder i klassen ``Person`` blir ovanstående kod: 

```cs 
class Person
{
    public string name; 
    public int age; 
    public string email; 

    void PrintInfo()
    {
        Console.WriteLine($"Name: {this.name} Age: {this.age}, Email: {this.email}");
    }

    // Ökar personens ålder med 1
    void Birthday()
    {
        this.age += 1; 
    }

    void SayHelloTo(Person otherPerson)
    {
        Console.WriteLine($"{this.name} says 'Hello' to {otherPerson.name});
    }
}
```

där nyckelordet ``this`` ersätter parametern motsvarande det aktuella objektet. Anrop till metoder görs med hjälp av punktoperatorn med följande syntax:

```cs
<aktuellt objekt> . <metod>(<argumentlista>)
```

där vid anropet ``<objekt>`` tilldelas ``this`` och argumentens värden tilldelas metodens parameterar innan metodens kropp körs. 

```cs
Person jonas = new Person();
Person karl = new Person(); 
jonas.name = "Jonas";
jonas.age = 42;
jonas.email = "jonas.keisu@bitaddict.se";
karl.name = "Karl";
karl.age = 27;
karl.email = "karl.svensson@bitaddict.se";

// PersonPrintInfo(jonas) blir som metodanrop: 
jonas.PrintInfo();
// PersonBirthday(jonas) blir som metodanrop: 
jonas.Birthday();
// PersonSayHelloTo(jonas, karl) blir som metodanrop:
jonas.SayHelloTo(karl);
```

## Implicit referens till this

Alla medlemmar till klassen är synliga i scopet för en metods kropp. Om vi använder namnet av en medlem för objekt av klassen i kroppen för en metod *utan* aktuellt objekt och punktoperator, så är det underförstått (implicit) att att det aktuella objektet är ``this.``. 

Vi kan alltså skriva koden ovan på följande sätt: 

```cs 
class Person
{
    public string name; 
    public int age; 
    public string email; 

    void PrintInfo()
    {
        Console.WriteLine($"Name: {name} Age: {age}, Email: {email}");
    }

    // Ökar personens ålder med 1
    void Birthday()
    {
        age += 1; 
    }

    void SayHelloTo(Person otherPerson)
    {
        Console.WriteLine($"{name} says 'Hello' to {otherPerson.name});
    }
}
```

Notera att koden ser likadan ut, förutom att vi tagit bort ``this.`` framför namnen på det aktuella objektets medlemmar i metodernas kroppar.

## Ibland är det inte korrekt att ta bort this.

Ta inte bort ``this.`` i kroppen till en metod om det finns en parameter till metoden som har samma identifierare som en variabel eller egenskap för aktuellt objekt. 

T.ex. skulle nedanstående metod ``AddAge`` inte längre göra rätt sak om vi tar bort ``this.`` framför ``age`` i vänsterledet av tilldelningen. 

```cs 
class Person
{
    public string name;
    public int age; 
    // .. samma som ovan
    void AddAge(int age)
    {
        this.age = age;
    }
}
```

### Egenskaper 

En *egenskap* (eng. *property*) för ett objekt är något som objektet har, t.ex. namn, färg, storlek och antal. De operationer som är tillåtna för en egenskap är att hämta egenskapens värde och sätta  egenskapens värde. Detta skulle vi kunna göra med två metoder per egenskap. 

```cs
class Person
{
    // Sätt/hämta egenskapen Name
    public void SetName(string value)
    {
        // .. 
    }

    public string GetName()
    {
        // .. 
    }

    // Sätt/hämta egenskapen Age
    public void SetAge(int value)
    {
        // .. 
    }

    public int GetAge()
    {
        // .. 
    }

    // Sätt/hämta egenskapen Email
    public void SetEmail(string value)
    {
        // .. 
    }

    public string GetEmail()
    {
        // .. 
    }
}
```

Typiskt lagras aktuellt värde för var och en av ett objekts egenskaper i variabler för objektet. 

```cs
class Person
{
    private string name;
    private int age; 
    private string email; 

    // De två metoderna för egenskapen Name
    public void SetName(string value)
    {
        this.name = value; 
    }

    public string GetName()
    {
        return this.name; 
    }

    // De två metoderna för egenskapen Age
    public void SetAge(int value)
    {
        this.age = value; 
    }

    public int GetAge()
    {
        return age;
    }

    // De två metoderna för egenskapen Email
    public void SetEmail(string value)
    {
        this.email = value; 
    }

    public string GetEmail()
    {
        return email; 
    }
}
```

Egenskaper används för att *kapsla in* tillståndet för ett objekt. De kan användas för att kontrollera hur kod utanför objektets klass kan uppdatera ett objekts tillstånd. 

```cs
class Person
{
    // .. som ovan
    public void SetAge(int value)
    {
        if (age < 0 || age > 150)
        {
            throw new ValueException("Not valid age");
        }
        this.age = value; 
    }

    public void SetEmail(string value)
    {
        if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new ValueException("Not a valid email string");
        }
        this.email = value;  
    }
}
```

Kod som använder egenskaperna ovan kan se ut t.ex. såhär: 

```cs
public void Main(string[] args)
{
    Person jonas = new Person();
    jonas.SetName("Jonas");
    jonas.SetAge(42);
    jonas.SetEmail("jonas.keisubitaddict.se"); // Kastar exception!!
}
```

Det är allmänt ansett att variabler för klassobjekt ALLTID skall kapslas, dvs endast tillåta läsning och skrivning för variablerna via egenskaper. 

## Egenskaper som är read/write only

En egenskap kan vara *read only* och saknar då ``Set..``-metod. 

En egenskap kan också vara *write only* och saknar då ``Get..``-metod.


## Syntax för egenskaper i C#

Syntaxen i C# för t.ex. egenskapen: 

```cs
class Person
{
    // .. 

    public void SetName(string value)
    {
        this.name = value; 
    }

    public string GetName()
    {
        return this.name; 
    }

    public int GetAge()
    {
        return this.age;
    }

    public void SetAge(int value)
    {
        if (age < 0 || age > 150)
        {
            throw new ValueException("Not valid age");
        }
        this.age = value; 
    }

    public string GetEmail()
    {
        return this.email;
    }

    public void SetEmail(string value)
    {
        if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new ValueException("Not a valid email string");
        }
        this.email = value;  
    }

    // .. 
}
```

är: 

```cs
class Person
{
    // ..

    public string Name 
    {
        set 
        {
            this.name = value;
        }

        get
        {
            return this.name;
        }
    }

    public int Age
    {
        set
        {
            if (age < 0 || age > 150)
            {
                throw new ValueException("Not valid age");
            }
            this.age = value; 
        }

        get
        {
            return this.age;
        }
    }

    public string Email
    {
        set
        {
            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new ValueException("Not a valid email string");
            }
            this.email = value;  
        }

        get
        {
            return this.email;
        }
    }

    // ..
}
```

Koden som sätter egenskapernas värde blir i C#: 

```cs
public void Main(string[] args)
{
    Person jonas = new Person();
    jonas.Name = "Jonas";
    jonas.Age = 42;
    jonas.Email = "jonas.keisubitaddict.se"; // Kastar exception!!

    Console.WriteLine(jonas.Name);
}
```

## Automatiskt implementerade egenskaper

I C# kan man istället för att skriva t.ex. 

```cs
class Person
{
    private string name;

    public string Name
    {
        get 
        {
            return this.name;
        }

        set
        {
            this.name = value;
        }
    }
}
```

istället skriva:

```cs
class Person
{
    public string Name 
    { 
        get; 
        set; 
    }
}
```

För denna kod skapar kompilatorn automatiskt en anonym medlemsvariabel som används för att spara undan värdet på egenskapen ``Name``. För programmeraren är nu ``Name`` både en egenskap och en medlemsvariabel och skall ses som en del av objektens tillstånd. 

## Konstruerare 

Konstruerare är metoder med det speciella syftet att initiera tillståndet för ett nytt objekt skapat i minnet med nyckelordet ``new``. 

En konstruerare har alltid samma namn som klassen den är deklarerad i och får inte ha en resultattyp (int ens ``void``).

Exempel: 

```cs
class Person
{
    private string name;
    private int age; 
    private string email; 

    public Person(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age; 
        this.Email = email; 
    }

    // ..
}

// ..

public void Main(string[] args)
{
    // Person jonas = new Person(); // INTE längre tillåtet
    Person jonas = new Person("Jonas", 42, "jonas.keisu@bitaddict.se");
}
```

## Tillgång

För att kod skall kunna använda en identifierare så måste:
- Identifieraren vara synlig i kodens scope. 
- Vara tillgänglig (eng. *accessable*) för koden.

Tillgängligheten för identifierare bestäms av *modifierare* (eng. *modifiers*) som föregår deklarationen av identifieraren. De viktigaste modifierarna för tillgänglighet är: 

- ``public`` - Tillgänglig i all kod 
- ``private`` - Tillgänglig endast för kod i samma klass
- ``internal`` - Tillgänglig i all kod i samma assembly 
- ``protected`` - Tillgänglig endast för kod i samma klass eller i ärvande klass

Standardtillgänglighet (om ingen modifierare för detta anges) för typdeklarationer är ``internal`` och för klassmedlemmar ``private``.

## Strukturer

En struktur är, precis som klasser, en programmerardeklarerad typ. Strukturer fungerar väldigt likt klasser men med några viktiga skillnader: 

- Strukturer deklareras med nyckelordet ``struct`` istället för ``class``
- Strukturer är värdetyper, men klasser är referenstyper
- Strukturer kan inte ärva 
- Strukturer kan inte överlagra defaultkonstruktorn
- Strukturer kan inte initilisera medlemsvariabler vid deklaration 

## Värdetyper vs. referenstyper

För en värdetyp lagras objektet i en variabel av typen. 

För en referenstyp så lagras en *referens* (ibland kallat *pekare*) till objektet i en variabel av typen. 

```cs 
namespace Program
{
    class Person1
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    struct Person2
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    public void Main(string[] args)
    {
        Person1 karl = new Person1("karl", 27);
        Person2 jonas = new Person2("jonas", 42);
        Person1 karl2 = karl;
        Person2 jonas2 = jonas;
        // Brytpunkt
        // ..
    }
}

```

Vid brytpunkten kommer följande vara lagrat i datorns minne:


```plantuml

object karl {
    (referens)
}

object karl2 {
    (referens)
}


object " " as obj {
    name = Karl
    age = 27
}

karl --> obj
karl2 --> obj

object jonas {
    name = "Jonas"
    age = 42
}

object jonas2 {
    name = "Jonas"
    age = 42
}
```

Antag att vi efter brytpunkten hade följande kod:

```cs
// ..
    public void Main(string[] args)
    {
        // ..
        // Brytpunkt
        jonas2.Age = 43;
        karl2.Age = 28;
        // Brytpunkt 2
        Console.WriteLine($"The Karls: {karl.age} {karl2.age}");
        Console.WriteLine($"The Jonas: {jonas.age} {jonas2.age}");
    }
```

Vid brytpunkt 2 har vi då följande värden lagrade i minnet:

```plantuml

object karl {
    (referens)
}

object karl2 {
    (referens)
}


object " " as obj {
    name = Karl
    age = 28
}

karl --> obj
karl2 --> obj

object jonas {
    name = "Jonas"
    age = 42
}

object jonas2 {
    name = "Jonas"
    age = 43
}
```

och sedan får vi följande utskrift:

```console
The Karls: 28 28
The Jonas: 42 43
```

Alla de grundläggande enkla typerna, t.ex.: ``int``, ``byte``, ``float``, ``double``, ``boolean`` och ``char`` är värdetyper. 

Alla fälttyper är referenstyper.

Ett till exempel:

```cs
namespace Program
{
    public void Main(string[] args)
    {
        int[] a = { 1, 2, 3};
        double b = 15.0;
        int[] a2 = a;
        double b2 = b;
    }
}
```
```plantuml

object a {
    (referens)
}

object a2 {
    (referens)
}


object " " as obj {
    {1, 2, 3}
}

a --> obj
a2 --> obj

object b {
    15.0
}

object b2 {
    15.0
}
```

## Static 

Lägger man till modifieraren ``static`` på en medlem i en klass eller struktur så ingår inte längre medlemmen i mallen för hur objekt av typen skapas eller vilka medlemmar som objekten har. Istället så tillhör medlemmen själva klassen. Det är precis som att deklarera t.ex. en lokal variabel eller funktion men i klassens scope. 

```cs 
namespace TicTacToe
{
    class TicTacToeBoard
    {
        private char[,] symbols = new char[3, 3];

        static public bool CheckValid(int row, int column)
        {
            return row >= 0 && row < 3 && column >= 0 && columns < 3;
        }

        public char GetSymbol(int row, int column)
        {
            if (!CheckValid(row, column))
            {
                throw new ArgumentException("Not valid position on board");
            }
            return this.symbols[row, column];
        }
    }

    public static int AskUserForRowIndex()
    {
        // ..
    }

    public static int AskUserForColumnIndex()
    {
        // ..
    }

    public static void Main(string[] args)
    {
        TicTacToeBoard board = new TicTacToeBoard();
        // .. 
        int column = AskUserForColumnIndex();
        int row = AskUserForRowIndex(); 
        if (TicTacToeBoard.CheckValid(row, column))
        {
            Console.WriteLine(board.GetSymbol(row, column));
        }
    }
}
```

# Exempel på objektorienterad design

Ett konsultföretag har anställda. Anställda är antingen konsulter, säljare eller säljchefer. En konsult är antingen junior eller senior, vilket påverkar lönen för konsulten men också timtaxan när konsulten är på uppdrag. Det är säljarnas ansvar att hitta uppdrag ute hos kunder åt konsulterna. Ett uppdrag har en utsträckning i tiden. Säljaren som hittat ett uppdrag åt en konsult får varje månad en procentuell bonus av intäkterna från uppdraget medan uppdraget pågår. En säljchef får varje månad en procentuell bonus av hela företagets intäkter. Alla anställda anställda har samma fasta kostnader utöver lön varje månad som täcker t.ex. kontor, it och telefoni. Säljare och säljchefer har dessutom olika tjänstebil som kostar företaget ytterligare varje månad. Systemet skall räkna ut resultatet för företaget (intäkter minus kostnader) för en specifik månad.

### Klassdiagram

<div style="zoom: 1">

```plantuml 
class Employee {
    Company Employer
    {static} double FixedCost;
    virtual double CalcCost(DateTime)
    virtual double CalcRevenue(DateTime)
}

enum ExperienceLevel {
    Junior
    Senior
}

class Consultant {
    ExperienceLevel Experience
    override double CalcCost(DateTime)
    override double CalcRevenue(DateTime)
}

class EmployeeWithCar
{
    double CarCost
    override double CalcCost(DateTime)
}

class SalesRep {
    double BonusPercentage
    override double CalcCost(DateTime)
}

class SalesMgr {
    double BonusPercentage
    override double CalcCost(DateTime)
}

class Company {
    List<Employee> Empoloyees
    List<Assignment> Assigments
    double CalcResult(DateTime)
}

class Assignment
{
    SalesRep Seller
    Consultant Resource
    DateTime Start
    DateTime End
    bool IsActive(DateTime)
}

Employee <|-- Consultant: "Är en"
Employee <|-- EmployeeWithCar: "Är en"
EmployeeWithCar <|-- SalesRep: "Är en"
EmployeeWithCar <|-- SalesMgr: "Är en"

Company "1" --o "0 .. *" Employee: "Sammlar"
Company --o "0 .. *" Assignment: "Sammlar"

Consultant --* ExperienceLevel: "Består av"
```
</div>

### Kod

```cs 
using System;
using System.Collections.Generic;

namespace ProfitCalculator
{
    class Company
    {
        public List<Employee> Employees { get; set; }
        public List<Assignment> Assignments { get; set; }

        public Company()
        {
            Employees = new List<Employee>();
            Assignments = new List<Assignment>();
        }

        public double CalcResult(DateTime month)
        {
            double revenue = 0;
            double cost = 0;
            foreach (Employee employee in this.Employees)
            {
                revenue += employee.CalcRevenue(month);
                cost += employee.CalcCost(month);
            }
            return revenue - cost;
        }
    }

    class Assignment
    {
        public SalesRep Seller { get; set; }
        public Consultant Resource { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsActive(DateTime month)
        {
            return Start <= month && End >= month;
        }
    }

    class Employee
    {
        public bool HasInsurance { get; set; }

        public static double FixedCost
        {
            get
            {
                return 10000;
            }
        }

        public Company Employer { get; set; }

        public virtual double CalcCost(DateTime month)
        {
            return FixedCost + (HasInsurance ? 5000 : 0);
        }

        public virtual double CalcRevenue(DateTime month)
        {
            return 0;
        }
    }

    enum ExperienceLevel
    {
        Junior,
        Senior
    }

    class Consultant : Employee
    {
        public ExperienceLevel Experience { get; set; }

        public override double CalcCost(DateTime month)
        {
            return base.CalcCost(month) + (this.Experience) switch
            {
                ExperienceLevel.Junior => 30000,
                _ => 45000,
            };
        }

        public override double CalcRevenue(DateTime month)
        {
            bool isOnAssignment = false;

            foreach (Assignment assignment in this.Employer.Assignments)
            {
                if (assignment.Resource == this && assignment.IsActive(month))
                {
                    isOnAssignment = true;
                    break;
                }
            }

            double revenue = base.CalcRevenue(month);

            if (isOnAssignment)
            {
                revenue += 168 * (this.Experience) switch
                {
                    ExperienceLevel.Junior => 500,
                    _ => 800,
                };
            }

            return revenue;
        }
    }

    class EmployeeWithCar : Employee
    {
        public double CarCost { get; set; }

        public override double CalcCost(DateTime month)
        {
            return base.CalcCost(month) + this.CarCost;
        }
    }

    class SalesRep : EmployeeWithCar
    {
        public double BonusPercentage { get; set; }

        public override double CalcCost(DateTime month)
        {
            double revenue = 0;
            foreach (Assignment assignment in Employer.Assignments)
            {
                if (assignment.Seller == this && assignment.IsActive(month))
                {
                    revenue += assignment.Resource.CalcRevenue(month);
                }
            }

            return base.CalcCost(month) + 25000 + BonusPercentage * revenue;
        }
    }

    class SalesMgr : EmployeeWithCar
    {
        public double BonusPercentage { get; set; }

        public override double CalcCost(DateTime month)
        {
            double revenue = 0;
            foreach (Assignment assignment in Employer.Assignments)
            {
                if (assignment.IsActive(month))
                {
                    revenue += assignment.Resource.CalcRevenue(month);
                }
            }

            return base.CalcCost(month) + 60000 + BonusPercentage * revenue;
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            Company company = new Company();
            Consultant karl = new Consultant()
            {
                Employer = company,
                Experience = ExperienceLevel.Junior
            };
            SalesRep niclas = new SalesRep()
            {
                Employer = company,
                CarCost = 8000,
                BonusPercentage = 0.05
            };
            company.Employees.Add(karl);
            company.Employees.Add(niclas);
            company.Employees.Add(
                new SalesMgr()
                {
                    Employer = company,
                    CarCost = 15000,
                    BonusPercentage = 0.02
                }
            );
            company.Assignments.Add(
                new Assignment()
                {
                    Seller = niclas,
                    Resource = karl,
                    Start = new DateTime(2020, 1, 1),
                    End = new DateTime(2020, 12, 31)
                }
            );

            Console.WriteLine($"Result in december 2020: {company.CalcResult(new DateTime(2020, 12, 1))}");
        }
    }
}
```

## Arv 

Arv används inom objektorienterad programmering för att implementera en "är en"-relation. 

En klass som ärver en annan klass har alla medlemmar som klassen den ärver har plus de medlemmmar som klassen lägger till. 

Varje klass kan bara ärva en annan klass, men många klasser kan ärva från samma klass. 

I en arvsrelation mellan två klasser kallas den ärvda klassen *basklass* (eng. *base class*), *super class* eller *förälderklass* (eng. *parent class*). Den ärvande klassen kallas *barnklass* (eng. *child class*) eller underklass (eng. *sub class*). 

Exempel: 






















































