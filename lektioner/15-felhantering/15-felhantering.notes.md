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

# Felhantering

<!-- slide -->

## Vad kan gå fel?

Exempel på saker som kan gå fel i koden under körning:
- Använda medlem för ``null``-referens
- Ogiltig indexiering av ett fält
- Misslyckad castning
- Division med 0
- Stackover overflow
- Slut på arbetsminne
- Användardefinierade fel

<!-- slide -->

## Vad händer när något går fel?

- Det vanliga programmetflödet avbryts
- Ett *exception* kastas

<!-- slide -->

## Exempelklass

```cs
class LinkedList {
        public int[] data;
        public LinkedList next;

        public LinkedList() {
            data = new int[1000000];
            for (int i = 0; i< data.Length; ++i)
                data[i] = i;
        }
    }
```

<!-- slide -->

## NullReferenceException

- Referens till en instansmedlem för en ``null``-referens

Exempel:

```cs
LinkedList list = null;
int x = list.data[0]; // Kastar System.NullReferenceException
```

<!-- slide -->

## IndexOutOfRangeException

- Indexieraring av ett fält med ett index som saknar element

Exempel:

```cs
int[] array = { 1, 2, 3};
System.Console.WriteLine(array[3]); // Kastar IndexOutOfRangeException
```

<!-- slide -->

## InvalidCastException

- En downcast kan misslyckas om referensen inte kan tolkas som måltypen

Exempel:

```cs
object obj = "En text";
LinkedList list = (LinkedList)obj; // Kastar System.InvalidCastException
```

<!-- slide -->

## DivideByZeroException

- Noll ryms oändligt många gånger i vilket positivt tal som helst
- Heltalstyper har ingen representation för oändliga tal 

Exempel:

```cs
int a = 1, b = 0;
int c = a / b; // Kastar System.DivideByZeroEception
```

<!-- slide -->

## StackOverflowException

- För lång kedja av funktionsanrop använder upp allt stackminne

Exempel: 

```cs
static void Main(string[] args)
{
    int a = args.Length = 0 ? 1 ; int.Parse(args[0]);
    // Raden nedan kastar till slut System.StackOverflowException
    Main(new string[] { (a + 1).ToString() });
}
```

<!-- slide -->

## OutOfMemoryException

- Ett program som systematiskt allokerar mer och mer minne som inte kan frigöras av garbage collectorn sägs ha en *minnesläcka*

Exempel:

```cs
LinkedList root = new LinkedList();
LinkedList node = root;
while (true) { // Nästa rad kastar till slut System.OutOfMemoryException
    node.next = new LinkedList();
    node = node.next;
}
```

<!-- slide -->

## Användardefinierat exception

- Fel som är definierade i kod, inte i språket.

Exempel: 

```cs
int.Parse("ett") // Kastar System.FormatException
```

<!-- slide -->

### Exempel

När går koden nedan fel?

```cs
static int CalculateAverage(int[] numbers)
{
    int sum = 0;
    foreach(var n in numbers)
        sum += n;
    return sum / numbers.Length;
}
```

<!-- slide -->

Kastar ``DivideByZeroException`` om fältet har längd ``0``

Vi fixar koden.. 

```cs
static int CalculateAverage(int[] numbers)
{
    if (numbers.Length == 0)
        return 0;
    else {
        int sum = 0;
        foreach(var n in numbers)
            sum += n;
        return sum / numbers.Length;
    }
}
```

<!-- slide -->

### Exempel

När går koden nedan fel?

```cs
static string MakeCommaSeparatedString(string[] strings) {
    var sb = new StringBuilder();
    for (int i = 0; i < strings.Length; ++i)
        sb.Append(strings[i] + (i != strings.Length - 1 ? ", " : "");
    return sb.ToString();
}
```

<!-- slide -->

Kastar ``NullReferenceException`` om ``strings`` har värdet ``null``

Vi fixar koden.. 

```cs
static string MakeCommaSeparatedString(string[] strings) {
    if (strings == null)
        return "";
    var sb = new StringBuilder();
    for (int i = 0; i < strings.Length; ++i)
        sb.Append(strings[i] + (i != strings.Length - 1 ? ", " : "");
    return sb.ToString();
}
```

<!-- slide -->

### Exempel

``Factorial(n)`` är lika med 1 × 2 × .. × (n - 1) × n. 

T.ex. är ``Factorial(6)`` lika med 1 × 2 × 3 × 4 × 5 × 6 = 720.

Vilket fel får koden nedan t.ex. för  ``number = 6``?

```cs
static int Factorial(int number)
{
    return Factorial(number - 1) * number;    
}
```

<!-- slide -->

Funktionen slutar inte anropa sig själv för ``Factorial(1)``. 

Till slut blir det ``StackOverflowException``. 

En bättre lösning är: 

```cs
static int Factorial(int number)
{
    if (number == 1)
        return 1;
    else 
        return Factorial(number - 1) * number;    
}
```

<!-- slide -->


### Exempel

Vilket fel får koden nedan?

```cs
string[] errorLog = new string[];
while (true) {
    Request request = WaitForServerRequest(); 
    string errorMessage;
    if (!TryProcessRequest(request, out errorMessage)) {
        Array.Resize(ref errorLog, errorLog.Length + 1);
        errorLog[errorLog.Length - 1] = errorMessage;
    }
}
```

<!-- slide -->

Får servern tillräckligt många felaktiga requests så tar arbetsminnet slut. En bättre lösning använder en cirkulär buffer för felmeddelanden.

```cs
string[] errorLog = new string[10000];
int errorMessageIndex = 0;
while (true) {
    Request request = WaitForServerRequest(); 
    string errorMessage;
    if (!TryProcessRequest(request, out errorMessage)) {
        errorLog[errorMessageIndex] = errorMessage;
        errorMessageIndex = (errorMessageIndex + 1) % errorLog.Length;
    }
}
```
<!-- slide -->

## Hantering av fel

- För att hantera ett fel används en ``try .. catch``-sats

Syntax:

```cs
try {
    <kod som kan kasta exception>
    // .. 
}
catch (<typ av exception som skall hanteras>)
{

}
```

<!-- slide -->

## Exempel

```cs
try {
    Console.Write("Skriv in ett tal: ");
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine($"Faktorialen av talet är {Factorial(number)}");
}
catch (System.FormatException e)
{
    Console.WriteLine("Texten du skrev in kan inte tolkas som ett tal.")
}
```

<!-- slide -->

## Hantering av olika fel

- Kedjor av ``catch``-satser kan användas för att hantera flera olika typer av fel

<!-- slide -->

## Exempel

```cs
int[] primes = { 2, 3, 5, 7, 11, 13, 17 };
try {
    Console.Write("Skriv in ett tal: ");
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine($"Primaltal nummer {number} är {primes[number]}");
}
catch (System.FormatException e) {
    Console.WriteLine("Texten du skrev in kan inte tolkas som ett tal.")
}
catch (System.IndexOutOfRangeException e) {
    Console.WriteLine("Talet du skrev in var för högt.");
}
```

<!-- slide -->

## Egenddefinierade exceptions

- Egna exceptions kan definieras genom att ärva klassen ``System.Exception``
- Exception kastas med nyckelordet ``throw``

<!-- slide -->
## Arv från exception

```cs
public class MyOwnException : System.Exception {
    public EmployeeListNotFoundException()
    {
    }
    public EmployeeListNotFoundException(string message)
        : base(message)
    {
    }
    public EmployeeListNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
```

<!-- slide -->

## Egenskaper för Exceptions

- ``Message`` - Meddelande som gavs som argument till konstruktorn 
- ``InnerException`` - Om ett exception hanteras genom att kasta en annan typ av exception är det rekommenderat att ge det ursprungliga exceptionet som argument till konstruktorn

<!-- slide -->

### Exempel

Ett shackspel kan ha följande exception: 

```cs
public class IllegalMoveException : System.Exception {
    public IllegalMoveException(string message)
        : base(message)
    {
    }
    public IllegalMoveException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
```

<!-- slide -->

```cs
class Board {
    Piece[,] squares; 
    // ..
    void MovePiece(int fromRow, int fromCol, int toRow, int toCol) {
        try {
            var piece = squares[fromRow, fromCol];
            if (piece.Color != activePlayer)
                throw new IllegalMove("Fel färg på pjäsen");
            piece.MoveTo(toRow, toCol);
        }
        catch (IndexOutOfRangeException e)
            throw new IllegalMoveException("Ogiltig position", e);
        catch (NullReferenceException e) 
            throw new IllegalMoveException("Ingen pjäs på positionen", e);
    }
}
```

<!-- slide -->

## Propagering av exceptions

- Ett fel i en metod som inte hanteras av den anropande metoden kastas vidare till metoden som anropade den anropande metoden, o.s.v.
- Om entry point-metoden kastar ett exception så hanterar CLR felet genom att avbryta körningen och skriva ut information om felet som uppstått
  - Detta kallas att programmet "kraschat"


