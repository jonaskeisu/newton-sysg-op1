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

# Generisk programmering

<!-- slide -->

## Ett bättre alternativ till array

- Det är jobbigt att ändra storlek på fält
- Därför vill vi skapa en typ för dynamiska fält av heltal

<center style="zoom: 1.7">

```plantuml
left to right direction 
interface IEnumerable
{
    {abstract} + IEnumerator GetEnumerator()
}

class IntList
{
    + int Length
    + int this[int]
    + IntList()
    + IntList(IEnumerable)
    + Add(int)
    + Append(IEnumerable)
    + IEnumerator GetEnumerator()
    + string ToString()
    {static} + IntList operator +(ListOfInts, ListOfInts)
    {static} + implicit operator IntList(int[])
}
IEnumerable <|.. IntList
```
</center>

<!-- slide -->
 ### Exempel

Koden nedan: 

```cs
IntList list = new int[] { 1, 2, 3};
IntList list2 = new int[] { 4, 5, 6};
Console.WriteLine(list + list2);
```

skall t.ex. ge utskriften:

```text
1, 2, 3, 4, 5, 6
```

<!-- slide -->

### Privata medlemsvariabler och egenskaper

```cs
class IntList : IEnumerable {
    private int length; 
    private int[] elements;

    private int Capacity => elements.Length;
    private int Length => length;
    // ...
```

<!-- slide -->

### Konstruktorer

```cs
class IntList : IEnumerable {
    // ...
    public IntList() 
    {
        length = 0;
        elements = new int[1];
    }
    public IntList(IEnumerable elements) :
        this() 
    {
        Append(elements);
    }
    // ...
```

<!-- slide -->

### Append och Add

```cs
class IntList : IEnumerable {
    // ...
    public IntList Append(IEnumerable elements) {
        foreach (int element in elements)
            Add(element);
        return this;
    }
    public void Add(int value) {
        if (Length == Capacity)
            DoubleCapacity();
        elements[length++] = value;
    }
    // ...
```

<!-- slide -->

### DoubleCapacity

```cs
class IntList : IEnumerable {
    // ...
    private void DoubleCapacity() {
        Array.Resize(ref elements, Capacity * 2);
    }
    // ...
```

<!-- slide -->

### Indexierare

```cs
class IntList : IEnumerable {
    // ...
    public int this[int index] {
        get => elements[CheckedIndex(index)];
        set => elements[CheckedIndex(index)] = value;
    }
    private int CheckedIndex(int index) {
        if (index < 0 || index >= length)
            throw new IndexOutOfRangeException();
        return index;
    }
    // ...
```

<!-- slide -->

### Operatorer

```cs
class IntList : IEnumerable {
    // ...
    static public IntList operator +(IntList a, IntList b) =>
        new IntList(a).Append(b);

    static public implicit operator IntList(int[] array) =>
        new IntList(array);
    // ...
```

<!-- slide -->

### ToString

```cs
class IntList : IEnumerable {
    // ...
    override public string ToString() =>
            String.Join(", ", elements.Take(length));
    // ...
```

<!-- slide -->

### IEnumerable

```cs
class IntList : IEnumerable {
    // ...
    public IEnumerator GetEnumerator() => new Enumerator(this);
    // ...
```

<!-- slide -->

### IEnumerator

```cs
class IntList : IEnumerable {
    // ...
    private class Enumerator : IEnumerator {
        int currentIndex; 
        private IntList list; 
        public Enumerator(IntList list) {
            currentIndex = -1;
            this.list = list;
        }
        public object Current => list[currentIndex];
        public bool MoveNext() => ++currentIndex < list.Length;
        public void Reset() => currentIndex = -1;
    }
}
```

<!-- slide -->

## The curse of success

- En toppenklass, alla älskar den!
- .. så mycket att nu vill de också ha: 
  - ``ListByte``, ``ListShort``, ``ListFloat``, ``ListDouble``, osv
- Identisk kod för varje klass, bara elementtypen skiljer
- Mardröm att underhålla all redundant kod

<!-- slide -->

## Generisk programmering

- Generisk programmering tillåter oss att skriva en *mall* för typer och metoder med andra typer som parametrar
- Vi gör ett nytt försök att skriva vår List-klass

<!-- slide -->

### Privata medlemsvariabler och egenskaper

```cs
class List<T> : IEnumerable {
    private int length; 
    private T[] elements;

    private int Capacity => elements.Length;
    private int Length => length;
    // ...
```

<!-- slide -->

### Konstruktorer

```cs
class List<T> : IEnumerable {
    // ...
    public List()
    {
        length = 0;
        elements = new T[1];
    }

    public List(IEnumerable elements) :
        this()
    {
        Append(elements);
    }
   // ...
```

<!-- slide -->

### Append och Add

```cs
class List<T> : IEnumerable {
    // ...
    public List<T> Append(IEnumerable elements) {
        foreach (T element in elements)
            Add(element);
        return this;
    }
    public void Add(T value) {
        if (Length == Capacity)
            DoubleCapacity();
        elements[length++] = value;
    }
    // ...
```

<!-- slide -->

### DoubleCapacity

```cs
class IntList : IEnumerable {
    // ...
    private void DoubleCapacity() {
        Array.Resize(ref elements, Capacity * 2);
    }
    // ...
```

<!-- slide -->

### Indexierare

```cs
class List<T> : IEnumerable {
    // ...
    public T this[int index] {
        get => elements[CheckedIndex(index)];
        set => elements[CheckedIndex(index)] = value;
    }
    private int CheckedIndex(int index) {
        if (index < 0 || index >= length)
            throw new IndexOutOfRangeException();
        return index;
    }
    // ...
```

<!-- slide -->

### Operatorer

```cs
class List<T> : IEnumerable {
    // ...
    static public List<T> operator +(List<T> a, List<T> b) =>
        new List<T>(a).Append(b);

    static public implicit operator List<T>(T[] array) =>
        new List<T>(array);
    // ...
```

<!-- slide -->

### ToString

```cs
class List<T> : IEnumerable {
    // ...
    override public string ToString() =>
            String.Join(", ", elements.Take(length));
    // ...
```

<!-- slide -->

### IEnumerable

```cs
class List<T> : IEnumerable {
    // ...
    public IEnumerator GetEnumerator() => new Enumerator(this);
    // ...
```

<!-- slide -->

### IEnumerator

```cs
class List<T> : IEnumerable {
    // ...
    private class Enumerator : IEnumerator {
        int currentIndex; 
        private List<T> list; 
        public Enumerator(List<T> list) {
            currentIndex = -1;
            this.list = list;
        }
        public object Current => list[currentIndex];
        public bool MoveNext() => ++currentIndex < list.Length;
        public void Reset() => currentIndex -1;
    }
}
```

<!-- slide -->

Koden nedan:

```cs
List<int> list = new int[] { 1, 2, 3 };
List<int> list2 = new int[] { 4, 5, 6 };
System.Console.WriteLine(list + list2 );

List<double> list3 = new double[] { 1.1, 1.2, 1.3 };
List<double> list4 = new double[] { 1.4, 1.5, 1.6 };
System.Console.WriteLine(list3 + list4);
```

ger nu utskriften:
```console
1, 2, 3, 4, 5, 6
1.1, 1.2, 1.3, 1.4, 1.5, 1.6
```

<!-- slide -->

## Generiska metoder

- Det går även att göra mallar till metoder

<!-- slide -->

## Exempel

Ibland har man nytta av en metod som byter värde på två variabler. Vi kan skriva en generisk swapmetod på följande vis: 

```cs
static public void Swap(ref object a, ref object b) {
    T temp = a;
    a = b;
    b = temp;
}
```

<!-- slide -->

Kräver att argument är castade till ``object``. 

Finns ingen garanti att argumenten har samma typ:

```cs
object a = "hej";
object b = new int[] {1, 2};
Algorithms.Swap(ref a, ref b)
```

<!-- slide -->

En generisk metod fungerarar för alla typer, kräver ingen castning och garanterar att argumenten har samma typ:

```cs
static public void Swap<T>(ref T a, ref T b) {
    T temp = a;
    a = b;
    b = temp;
}
```

<!-- slide -->

Typen ``T`` är implicit från anropets argument:

```cs 
int a = 1, b = 2;

string x = "hej", y = "då";

Swap(ref a, ref b); // T är implicit för detta anrop int 

Swap(ref x, ref y); // T är implicit för detta anrop string

Swap(ref a, ref x); // FEL! Denna rad kompilerar inte.
```

<!-- slide -->

### Så nu kan vi en generisk sorteringsmetod?

```cs
static public void Sort<T>(T[] objs) {
    for (int i = objs.Length - 1; i >= 0; i--)
        for (int j = 0; j < i; j++) {
            if (objs[j].CompareTo(objs[j + 1]) > 0) 
                Swap(ref objs[j], ref objs[j + 1]);
}
```
- Nej, koden ovan kompilerar inte!
- Ingen garanti att objekt av typen ``T`` har metoden:

```cs
int CompareTo(T)
```

<!-- slide -->

## Typbegränsningar

- För att sorteringen skall fungera måste vi begränsa vilka typer ``T`` som är acceptabla:
```cs
static public void Sort<T>(T[] objs) where T : IComparable<T> {
    for (int i = objs.Length - 1; i >= 0; i--)
        for (int j = 0; j < i; j++)
            if (objs[j].CompareTo(objs[j + 1]) > 0)
                Swap(ref objs[j], ref objs[j + 1]);
}
```

<!-- slide -->

Nu ger koden:

```cs
int[] numbers = { 8, 3, 6, 2, 1, 9, 0, 5, 4, 7 };
Sort(numbers); // T för detta anrop har implicit typen int
WriteLine(String.Join(", ", numbers));
string[] names = 
    { "Jonas", "Marcus", "Niclas", "Daniel", "Henrik", "Anna" };
Sort(names); // T för detta anrop har implicit typen string
WriteLine(String.Join(", ", names));
```

utskriftern:

```console
0, 1, 2, 3, 4, 5, 6, 7, 8, 9
Anna, Daniel, Henrik, Jonas, Marcus, Niclas
```

<!-- slide -->

## Olika typbegräsningar 

- En lista över alla möjliga typbegränsingar finns [här](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters).

<!-- slide -->

## Titta på exempel

- Vi tittar på exempel med generisk kod med flera typparametrar.