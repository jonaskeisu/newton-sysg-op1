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

# Samlingar

<!-- slide -->

## Samlingar

- En *samling* (eng. *collection*) är en dynamiska behållare av element
  - *Dynamiskt* betyder kan växa/krympa efter behov 
  - Motsatsen till dynamisk är *statisk*, d.v.s. fast storlek

<!-- slide -->

## Olika typer av samlingar

- Standardbiblioteket  innehåller olika typer av samlingar, t.ex: 
  - Listor
  - Dictionaries
  - Köer
  - Stackar

<!-- slide -->

## IEnumerable

- Alla samligar implementerar gränssnittet ``IEnumerable``
- Gränssnittet ``IEnumerable`` ger ett gemensamt sätt löpa igenom elementen i en samling
- Namespacet ``System.Linq`` innehåller många generellt användbara extrametoder som fungerar på alla samlingar som implementerar ``IEnumerable``. 

<!-- slide -->

## Listor

- En lista lagrar en sekvens av element
- Varje element kan effektivt hämtas/skrivas via sitt index
- Listor är den vanligaste samlingstypen
- Genom att använda ``using System.Linq`` får listor många användbara extrametoder.

<!-- slide -->

### Exempel

```cs
int[] array = {1, 2, 3};
// En lista kan konstrueras från vilken samling som helst.
List<int> list = new List<int>(array);
// Lägg till ett element till slutet av listan
list.Add(4); 
// Lägg till en sekvens av element till slutet av listan
list.AddRange(new int[] { 5, 6, 7});
// Ta bort först förekomsten av ett elementvärde
list.Remove(6);
// Lägg in ett element på specifik posoition mellan två element 
list.Insert(5, 6);
```

<!-- slide -->

## Dictionaries

- En *dictionary* lagrar varje element under en unik nycklel
- Nyckeltypen är oberoende av elementtypen
- Typen för en dictionary med nycklar av typen ``K`` som lagrar element av typen ``V`` är ``Dictionary<K, V>``
- Dictionaries är den vanligaste samlingen efter listor

<!-- slide -->

### Exempel

```cs
// Dictionaries har en egen initializer-syntax
var colorNames = new Dictionary<Color, string> {
    { Color.Red, "Rött" },
    { Color.Green,  "Grönt"}, 
    { Color.Blue, "Blått"}
};
// Ett dictionary kan indexieras med sin nyckeltyp, kan kasta exception.
Console.WriteLine(colorNames[Color.Red]); // Skriver ut "Rött"
// Använd metoden 'GetValueOrDefault' för att inte riskera exception.
colorNames.GetValueOrDefault(Color.Purple, "Okänd");
if (!colorNames.ContainsKey(Color.Purple))
    // Lägg in element under nya/gamla nycklar med indexieraren
    colorNames[Color.Purple] = "Lila";
```

<!-- slide -->

## LINQ

- LINQ står för *Language Integrated Query* och innehåller:
  - Många användbara extra metoder för samlingar.
  - Ett SQL-liknande minispråk integrerat i C# för konstruera frågor (eng. *queries*) som skapar data från samlingar, med nyckelord som ``from``, ``in``, ``select``, ``where``, ``group``, m.fl.
- Allt man kan göra med query-språket kan man göra med metoderana också. 

<!-- slide -->

## LINQ-metoder

- LINQ-metoder är definierade för objekt som implementerar ``IEnumerable<T>``. 
- När resultatet av en LINQ-metod är en ny datasamling är returtypen också av typen ``IEnumerable<T>``, inte(!) samma typ som ursprungssamlingen
- Objekt av typen ``IEnumerable<T>`` kan konverteras till t.ex. fält med metoden  ``ToArray()`` eller listor med metoden ``ToList()`` vid behov. 

<!-- slide -->

## Extensionmetoder

- LINQ-metoderna är s.k. *extension methods*
- Kan anropas som instansmetoder, men får instansen som första argument. 

<!-- slide -->

### Exempel

I följande exmpel använder vi klassen:

```cs 
class Contact {
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}
```

och förutsätter att vi har ett objet ``contacts`` av typen ``List<Contact>`` som innehåller en lång lista kontakter.

<!-- slide -->

### Select

- Metoden ``Select`` projicerar (avbildar) samlingen. 

Signatur: 

```cs
IEnumerable<R> Select<V,R>(this IEnumerable<V> soruce, Func<V,R> func)
```

Exempel:
  
```cs
var names = contacts.Select(c => c.Name);
var ages = contacts.Select(c => c.Age);
var descriptions = contacts.Select(c => $"{c.Name} ({c.Age } år)");
```

<!-- slide -->

### Where

- Metoden ``Where`` filtrerar samlingen. 

Signatur: 

```cs
IEnumerable<V> Where<V>(this IEnumerable<V> source, Func<V,bool> func)
```

Exempel:
  
```cs
var young = contacts.Where(c => c.Age < 25);
var bitaddicts = contacts.Where(c => c.Email.EndsWith("@bitaddict.se"));
```

<!-- slide -->

### Sum

Summera talen i samlingen.

Signatur (definierad för övriga taltyper med):

```cs
int Sum (this System.Collections.Generic.IEnumerable<int> source)
```

Exempel:

```cs
int[] ints = {1, 2, 3, 4, 5};
int intSum = ints.Sum();
double[] doubles = {6.0, 7.0, 8.0};
int doubleSum = ints.Sum();
```

### Average

Medelvärdet av talen i samlingen. 

Signatur (definierad för övriga taltyper med):

```cs
double Average (this IEnumerable<int> source);
```

Exempel:

```cs
int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
int avg = ints.Average(); // avg = 5
```

<!-- slide -->

### Average

Medelvärdet av talen i samlingen. 

Signatur (definierad för övriga taltyper med):

```cs
double Average (this IEnumerable<int> source);
```

Exempel:

```cs
int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
int avg = ints.Average(); // avg = 5
```

<!-- slide -->

### OrderBy

Sortera samlingen efter nyckelvärde.

Signatur:

```cs
IEnumerable<V> OrderBy<V,K>(this IEnumerable<V> source, Func<V,K> getKey)
```

Exempel:

```cs
var byAge = contacts.OrderBy(c => c.Age);
var byName = contacts.OrderBy(c => c.Name);
```

<!-- slide -->

### Take

Ta ett visst antal element från början på samlingen.

Signatur:

```cs
IEnumerable<V> Take<TSource>(this IEnumerable<V> source, int count)
```

Exempel:

```cs
var byName = contacts.OrderBy(c => c.Name);
var withTenFirstNames = byName.Take(10);
```

<!-- slide -->

### Skip

Ta alla utom ett visst antal element från början på samlingen.

Signatur:

```cs
IEnumerable<V> Skip<TSource>(this IEnumerable<V> source, int count)
```

Exempel:

```cs
var byName = contacts.OrderBy(c => c.Name);
var allButTenFirstNames = byName.Skip(10);
```

<!-- slide -->

### TakeWhile

Ta element från början så länge ett villkor är uppfyllt.

Signatur:

```cs
IEnumerable<V> TakeWhile<TSource>(this IEnumerable<V> source, Func<V,bool>)
```

Exempel:

```cs
var byName = contacts.OrderBy(c => c.Name);
var namesOnA = byName.TakeWhile(c => c.Name.CompareTo("b") < 0);
```

<!-- slide -->

### SkipWhile

Hoppa över element från början så länge ett villkor är uppfyllt.

Signatur:

```cs
IEnumerable<V> TakeWhile<TSource>(this IEnumerable<V> source, Func<V,bool>)
```

Exempel:

```cs
var byName = contacts.OrderBy(c => c.Name);
var namesAfterA = byName.SkipWhile(c => c.Name.CompareTo("b") < 0);
```

<!-- slide -->

### Any

Sant om en funktion returnerar sant för något element i listan är sant. 

Signatur:

```cs
bool Any(IEnumerable<V> source, Func<V, bool>)
```

Exempel:

```cs 
var someoneHasGmail = 
    contacts.Any(c => c.Email.EndsWith("@gmail.com"));
var someoneIsReallyOld = 
    contacts.Any(c => c.Age >= 90);
```
<!-- slide -->

### All

Sant om en funktion retturnerar sant för alla element i listan är sanna. 

Signatur:

```cs
bool All(IEnumerable<bool> source, Func<V, bool>)
```

Exempel:

```cs 
var everyoneIsFromBitaddict = 
    contacts.All(c => c.Email.EndsWith("@bitaddict.se");
var everyoneIsMiddleAged = 
    contacts.All(c => c.Age >= 35 && c.Age < 50);
```

<!-- slide -->

### Reverse

Elementen i baklänges ordning.

Signatur:

```cs
IEnumerable<V> Reverse<TSource>(this IEnumerable<V> source)
```

Exempel:

```cs
var byName = contacts.OrderBy(c => c.Name);
var namesFromZtoA = byNames.Reverse();
```

<!-- slide -->

### First

Första elementet i samlingen (kan kasta exception).

Signatur:

```cs
V First<V>(IEnumerable<V>)
```

Exempel: 

```cs
var byAge = contacts.OrderBy(c => c.Age);
var byName = contacts.OrderBy(c => c.Name);
var firstByName = byName.First();
var firstByAge = byAge.First();
```

<!-- slide -->

### Last

Sista elementet i samlingen (kan kasta exception).

Signatur:

```cs
V Last<V>(IEnumerable<V>)
```

Exempel: 

```cs
var byAge = contacts.OrderBy(c => c.Age);
var byName = contacts.OrderBy(c => c.Name);
var lastByName = byName.Last();
var lastByAge = byAge.Last();
```
<!-- slide -->

## Kedjor av metodanrop

- LINQ-metoder kan kedjas ihop för att skapa sammansatta operationer på samlingar

<!-- slide -->

### Exempel

```cs
var emailsToYoungPeople = 
    contacts.
    Where(c => c.Age < 25).
    Select(c => c.Email);

var averageAgeOfGmailUsers = 
    contacts.
    Where(c => c.Email.EndsWith("@gmail.com")).
    Select(c => c.Age).
    Average();
```

<!-- slide -->

### LINQ-språket

Koden: 
```cs
var emailsToYoungPeople = 
    contacts.
    Where(c => c.Age < 25).
    Select(c => c.Email);
```
kan med LINQ query-syntax även skrivas:

```cs
var emailsToYoungPeople = 
    from c in contacts where c.Age < 25 select c.Email;
```
