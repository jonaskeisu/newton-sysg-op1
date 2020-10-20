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

# Funktionsobjekt och händelser

<!-- slide -->

## Funktionsobjekt

- En *delegat* är ett objekt som lagrar en referens till en funktion
- När en delegat anropas så anropas den den refererade funktionen

<!-- slide -->

## Delegattyper

- Typen för en delegat för funktioner som tar argument av typerna ``<T1>``, ``<T2>``, osv. och med returtyp ``<R>`` är:

```cs
Func<T1, T2, .., R>
```

<!-- slide -->

## Varför behövs delegater?

- Vi demonstrerar behovet med ett exempel.

<!-- slide -->

Antag att vi har en klass för kontakter:

```cs 
class Contact
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}
```

och en lista med kontater av typen ``List<Contact>``. 

<!-- slide -->

Vi kanske vill hitta alla kontakter yngre än 40: 

```cs 
static List<Contact> YoungerThan40(List<Contact> contacts) {
    List<Contact> result = new List<Contact>();
    foreach (var contact in contacts)
        if (contact.Age < 40)
            result.Add(contact);
    return result;
}
```

<!-- slide -->

Vi kanske också vill hitta alla kontakter som har en e-postadress som slutar på något speciellt, t.ex. "@gmail.com": 

```cs
static List<Contact> EmailEndsWith(List<Contact> contacts, string postfix) {
    List<Contact> result = new List<Contact>();
    foreach (var contact in contacts)
        if (contact.Email.EndsWith(postfix))
            result.Add(contact);
    return result;
}
```

Vi ser att filtreringsfunktioner har mycket gemensam logik. 

<!-- slide -->

Bättre lösning: 

```cs
static List<Contact> FilterContacts(List<Contact> contacts, 
        Func<Contact, bool> filter) {
    List<Contact> result = new List<Contact>();
    foreach (var contact in contacts)
        if (filter(contact))
            result.Add(contact);
    return result;
}
```

<!-- slide -->

## Tilldelning av delegater 

Delegater kan tilldelas från: 
- Statiska metoder
- Anrop av instansmetoder
- Lokala funktioner
- Lambda-funktioner

<!-- slide -->

## Tilldelning från statisk metod

```cs
static bool YoungerThan40(Contact contact) => contact.Age < 40;
```

```cs
public static void Main(string[] args) {
    List<Contact> contacts = // ..
    var selection = FilterContacts(contacts, YoungerThan40);
}
```

<!-- slide -->

## Tilldelning från instansmetod

```cs
class ContactFilter {
    private string postfix;
    public ContactFilter(string postfix) {
        this.postfix = postfix;
    }
    public bool EmailEndsWith(Contact contact) => 
        contacts.EndsWith(postfix);
}
public static void Main(string[] args) {
    List<Contact> contacts = // ..
    ContactFilter filter = new ContactFilter("@gmail.com");
    var selection = FilterContacts(contacts, filter.EmailEndsWith);
}
```

<!-- slide -->

## Tilldelning från lokal funktion 

```cs
public static void Main(string[] args) {
    bool youngerThan40(Contact contact) => contact.Age < 40;
    List<Contact> contacts = // ..
    var selection = FilterContacts(contacts, youngerThan40);
}
```

<!-- slide -->

## Tilldelning från lokal funktion igen

```cs
public static void Main(string[] args) {
    bool hasGmailAddress(Contact contact) => 
        contact.Email.EndsWith("@gmail.com");
    List<Contact> contacts = // ..
    var selection = FilterContacts(contacts, hasGmailAddress);
}
```

<!-- slide -->

## Lambdafunktion

En anonym funktion kan skapas med hjälp av lambdaoperator (``=>``)

Syntax: 

```cs
<argumentlista> => <uttryck | kodblock>
```

<!-- slide -->

### Exempel

```cs
Func<int, int> negate = i => -i;

Func<double, double, double> add = (a, b) => a + b;

Func<string, char, int> charCounter = (txt, c) => 
    {
        int count = 0;
        foreach (var tc in txt)
            if (c == tc)
                ++count;
        return count;            
    };
```

<!-- slide -->

## Tilldelning från lambdafunktion

```cs
public static void Main(string[] args) {
    List<Contact> contacts = // ..
    var selection = FilterContacts(contacts, c => c.Age < 40);
    var selection2 = FilterContacts(contacts, 
        c => c.Email.EndsWith("@gmail.com"));

}
```
<!-- slide -->

## FindAll

- Listor har redan en metod ``FindAll`` som tar ett argument av typen ``Predicate<T>``
- ``Predicate<T>`` är typen för en delegat som tar ett argument av typen ``T`` och returnerar ett värde av typen ``bool``.

```cs
public static void Main(string[] args) {
    List<Contact> contacts = // ..
    var selection = contacts.FindAll(c => c.Age < 40);
    var selection2 = contacts.FindAll(c => 
        c.Email.EndsWith("@gmail.com"));
}
```

<!-- slide -->

## Action

``Action<T1, T2, ..>`` är typen för delegater som tar argument av typerna ``T1``, ``T2``, osv. och inte returnerar något värde.

<!-- slide -->

### Exempel

Koden:

```cs
Action<int> printNumber = i => Console.WriteLine(i);
int[] numbers = {1, 2, 3};
foreach (int num in numbers) 
    printNumber(num);
```

ger utskriften:

```text
1
2
3
```

<!-- slide -->

## Vad skriver programmet ut?

```cs
List<Action> actions = new List<Action>();
for (int i = 0; i < 5; ++i) 
    actions.Add(() => Console.WriteLine(i));

foreach (Action action in actions) 
    action();
```

<!-- slide -->

Programmet skriver ut: 

```text
0
1
2
3
4
```

<!-- slide -->

## Closures

- Varje gång en funktion tilldelas en delegat fångar funktionen aktuella värden på använda variabler i yttre scope i något som kallas ett *closure*
- När funktionen anropas hämtas värden på variabler i yttre scope från den specifika funktionensreferensen closure

<!-- slide -->

### Delegate

- Användre kan definiera egna delegattyper med nyckelordet ``delegate``:

```cs
delegate <signatur>;
```

- Namnet på delegattypen är identifieren för funktionen i signaturen.

<!-- slide -->

### Exempel

```cs
namespace MyApp {
    delegate double BinaryDoubleOperator(double a, doubl b);
    delegate void IntegerProessor(int a);
    class Program {
        public static void Main(string[] args) {
            BinaryDoubleOperator op = (a, b) => a * b;
            double c = op(a, b);
            IntegerProcess proc = a => Console.WriteLine(a);
            int[] numbers = {1, 2, 3, 4, 5};
            foreach (int num in numbers)
                proc(num);
        }
    }
}
```

<!-- slide -->

## Händelser

- En *händelse* (eng. *event*) är något specifikt som kan hända med ett objekt under programmets körning
- Användare av objektet kan registrera delegater som *lyssnare* till händelser
- Varje gång händelsen inträffar så anropas händelsens alla lyssnare

<!-- slide -->

### Exempel

```cs
delegate void OnProcessNumber(int number);

class Counter {
    private int count;

    public event OnProcessNumber Tick; // Definition av event

    public void Increment() {
        ++count;
        if (Tick != null) // Null-kontroll innan anrop!
            Tick(count);
    }
}
```

<!-- slide -->

```cs
int tickCounter = 0;

Counter counter = new Counter();

counter.Tick += i => Console.WriteLine($"Got tick: {i}");
counter.Tick += i => ++tickCounter;

Console.WriteLine($"Tick counter: {tickCounter}");

for (int i = 0; i < 5; ++i)
    counter.Increment();

Console.WriteLine($"Tick counter: {tickCounter}");
```

<!-- slide -->

Programmet ger utskriften:

```text
Tick counter: 0
Got tick: 1
Got tick: 2
Got tick: 3
Got tick: 4
Got tick: 5
Tick counter: 5
```

<!-- slide -->

## Händelser och ramverk

- Händerser används ofta för att koppla applikationer till ramverkskod

<!-- slide -->

### Exempel - GameLib

<center>

```plantuml
class Sprite
{
    + int Width
    + int Height
    + Sprite(string[] rows)
}

class Position
{
    + int Row
    + int Column
}

abstract Object
{
    + string Tag
    + Position Position
    + <<event>> Tick()
    + Object(Position, string)
}

class SpriteObj
{
    + Sprite Sprite
    + <<event>> Collision(SpriteObj)
    + SpriteObject(Position, Sprite, string)
}

Object --* Position
Object <|-- SpriteObj

SpriteObj --* Sprite

class Text
{
    + string String
    + Text(Position, string, string)
}

Object <|-- Text

interface IEnumerable
{
    + IEnumerator GetEnumerator()
}

class Scene 
{
    Add(Object)
    Remove(Object)
    + <<event>> Key(ConsoleKey)
    + IEnumerator GetEnumerator()
}

Object o-- Scene

IEnumerable <|.. Scene

class Game
{
    + Game(Scene)
    + void Run()
    + void TransitionTo(Scene)
    + void Quit()
}

Game --o Scene

```

</center>





