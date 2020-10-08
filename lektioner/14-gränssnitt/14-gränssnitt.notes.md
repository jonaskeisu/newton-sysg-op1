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

# Gränssnitt

<!-- slide -->

## Gränssnitt

- Ett gränssnitt är ett kontrakt 
- En ``struct`` eller ``class`` som förbinder sig att uppfylla kontraktet måste definiera de medlemmar som ingår i gränssnittet
- Ett gränssnitt skapas med nyckelordet ``interface``
- En klass kan bara ärva en klass men uppfylla obegränsat många gränssnitt
- Gränssnitt frikopplar algoritmer från typer

<!-- slide -->

## Syntax

- Definition av ett gränssnitt liknar definitionen av en klass, men:
  - Använder nyckelordet ``interface`` istället för ``class``
  - Innehåller typiskt bara signaturer
  - Defaultåtkomst för medlemmarna är ``public``, inte ``private`` 


<!-- slide -->

### Exempel

Standardbiblioteket innehåller ett gränssnitt enligt nedan:

```cs
public interface IComparable {
    // Returnerar ett heltal som är:
    // - mindre än 0 om det här objektet är mindre än det andra
    // - exakt 0 om objekten är likvärdiga
    // - större än 0 om det här objektet är större än det andra
    int CompareTo(object other); 
}
```

<!-- slide -->

Generell sorting av ett fält jämförbara objekt:

```cs
static public void Sort(IComparable[] objs)
{
    for (int i = objs.Length - 1; i >= 0; i--) {
        for (int j = 0; j < i; j++) {
            if (objs[j].CompareTo(objs[j + 1]) > 0) {
                IComparable tmp = objs[j];
                objs[j] = objs[j + 1];
                objs[j + 1] = tmp; 
            }
        }
    }
}
```

<!-- slide -->

Kan sortera fält av t.ex. personer efter namn:

```cs
class Person : IComparable {
    public string Name { get; set; }
    public int Age { get; set; }
    public int CompareTo(object other) {
        if (other is Person otherPerson) {
            return Name.CompareTo(otherPerson.Name);
        }
        return -1; 
    }
}
```

<!-- slide -->
.. och bilar efter hästkrafter:

```cs
class Car : IComparable {
    public int HorsePower { get; private set; }
    public string Model { get; private set; }
    public int CompareTo(object other) {
        if (other is Car otherCar) {
            return HorsePower - otherCar.HorsePower;
        }
        return -1;
    }
}
```
trots att de två typerna är helt oberoende av varandra!

<!-- slide -->

## Klassdiagram

<center style="margin-top: 1em; zoom: 1.5">

```plantuml
interface IComparable
{
    int CompareTo(object)
}

class Person
{
    + string Name
    + int Age
    + int CompareTo(object)
}

Person ..|> IComparable

class Car
{
    + string Model
    + int HorsePower
    + int CompareTo(object)
}

Car ..|> IComparable
```

</center>

<!-- slide -->

## Enumerator

- Ett annat viktigt gränssnitt i standardbiblioteket är ``IEnumerator``
- En *enumerator* är ett objekt som löper genom alla elementen i en samling och uppfyller följande gränssnitt:

```cs
interface IEnumerator {
    bool MoveNext(); // Gå till nästa element, returnera false om slut
    object Current { get; } // Hämta aktuellt element
    void Reset(); // Börja om från början
}
```

<!-- slide -->

## Enumerable

- Ett samlingsobjekt uppfyller gränssnittet ``IEnumerable``
- Uppfylls bl.a. av alla fälttyper

```cs
interface IEnumerable 
{
    IEnumerator GetEnumerator(); // Skapa en ny enumerator
}
```


<!-- slide -->

## Iterera över elementen

En generell algoritm för att iterera över en samling ``collection`` som uppfyller ``IEnumerable``: 

```cs
{
    IEnumertor enumerator = collection.GetEnumerator();
    while(enumerator.MoveNext()) {
        <typ> element = (<typ>)enumerator.Current;
        // .. gör något med aktuell element
    }
}    
```

<!-- slide -->

## Iteration med ``foreach``

- Iteration på tidigare nämnda vis över en samling som uppfyller ``IEnumerable`` kan skrivas kortare med nyckelorden ``foreach`` och ``in``, men betydelsen är densamma: 

```cs 
foreach (<typ> element in collection) {
    // .. gör något med aktuellt ellement
}
```

<!-- slide -->

### Exempel - Iteration över fält

```cs
class Person {
    public string Name { get; set; } 
    public int Age { get; set; }
}
// ..
static public void Main(string[] args) {
    var people = new Person[] { 
        new Person() { Name = "Jonas", Age = 42},
        // .. 
    }
    foreach (Person person in people) {
        Console.WriteLine($"{person.Name} är {person.Age} år gammal.");
    }
}
```

<!-- slide -->

### Exempel - Iteration över primtal

<center style="top-margin: 1em; zoom: 1.5">

```plantuml
left to right direction
interface IEnumerable
{
    IEnumerator GetEnumerator()
}

interface IEnumerator
{
    object Current
    bool MoveNext()
    void Reset()
}

class PrimesCollection
{
    + int Start
    + int End
    + PrimesCollection(int, int)
    + IEnumerator GetEnumerator()
}

PrimesCollection ..|> IEnumerable

class Enumerator
{
    - PrimesCollection Collection
    object Current
    + Enumerator(PrimesCollection)
    + bool MoveNext()
    + void Reset()
}

Enumerator ..|> IEnumerator

PrimesCollection "1" --* "0..*" Enumerator
Enumerator "1" ..> "1" PrimesCollection
```

</center>

<!-- slide -->

Vi tittar på koden.