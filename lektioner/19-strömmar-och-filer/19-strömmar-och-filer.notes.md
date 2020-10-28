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

# Strömmar och filer

<!-- slide -->

## Strömmar

- Strömmar är en abstraktion för att läsa data från och skriva data till ett medium, utan att behöva veta vad detta medium är
- Ett medium kan vara t.ex.:
  - En fil i det lokala filssysteet
  - Isolerad lagringsplats för applikationen 
  - En applikation på en annan dator på ett nätverk
  - En minnesarea på datorn
- Data som skickas över en ström är en sekvens av bytes
- Applikationen bestämmer tolkningen av datat

<!-- slide -->

## Random access-strömmar

- Visa typer av strömmar har en aktuell storlek och tillåter läsning/skrivning med start på godtycklig position
  - Dessa kallas för random access-strömer
- En fil på datorn är typiskt random access
- Kommunikation med en annan applikation över nätverk är typiskt inte random access

<!-- slide -->

## Abstrakt basklass för stream

<center style="margin-top: 1em; zoom: 2">

```plantuml
abstract Stream
{
    bool CanRead
    bool CanWrite
    bool CanSeek // Är strömmen random access?
    int Position // Bara för random access
    long Length // Bara för random access
    int Read(byte[], int, int)
    int Write(byte[], int, int)
    Int64 Seek(Int64, SeekOrigin)
    void Close()
}

enum SeekOrigin
{
    Begin
    Current
    End
}

Stream -right-> SeekOrigin
```

</center>

<!-- slide -->

## Skrivning till ström

```cs
var data = new byte[] { 0b00001101, 0b01001111, 01001111, ... };
stream.Write(data, 0, data.Length)
```

<center style="margin-top: 1em; zoom: 1.2">

```plantuml
autoactivate on
Applikation -> Ström: .. 01001111 01001111 00001101 
Ström -> Medium: ... 10001001 01001111 00001101
return 
return 
```

</center>

<!-- slide -->

## Läsning från ström

```cs
var data = new byte[1000]; // buffer size = 1000
stream.Read(data, 0, data.Length)
```

<center style="margin-top: 1em; zoom: 1.2">

```plantuml
autoactivate on
Applikation -> Ström: <i>Läs bytes</i>
Ström -> Medium
return 00101100 10010011 01100011 ..
return 00101100 10010011 01100011 ..
```

</center>

<!-- slide -->

## Automatisk positionering 

- Anrop till ``Read``/``Write`` uppdaterar automatiskt aktuell position i strömmen.

<!-- slide -->

### Exempel

```cs
Stream stream = File.Open("data.bin", FileMode.Open);
var data = new byte[] { 0b00101100, 0b10010011, 0b00101100 };
// Aktuellt värde på stream.Position är 0

// Skriv över byte på position 0, 1, 2
stream.Write(data, 0, data.Length);
// Aktuellt värde på stream.Position är 3

// Läs byte på position 3, 4
stream.Read(data, 0, 2);
// Aktuellt värde på stream.Position är 5
```

<!-- slide -->

## Seek

- Seek-metoden sätter manuellt aktuell position i strömmen.

<!-- slide -->

### Exempel

```cs
// 4 byte före slutet på strömmen
stream.Seek(-4, SeekOrigin.End); 
```

```cs
// 100 byte efter början på strömmen
stream.Seek(100, SeekOrigin.Begin); 
```

```cs
// 8 byte efter aktuell position i strömmen
stream.Seek(8, SeekOrigin.Current); 
```

<!-- slide -->

## File och FileStream

Den statiska klassen ``File`` innehåller bl.a. metoder för att skapa strömmar till i det lokala filsystemet.

<center style="margin-top: 1em; zoom: 1.5">

```plantuml
class File
{
    {static} FileStream Open(string, FileMode)    
}

abstract Stream
{
}

class FileStream
{
}

Stream <|-left- FileStream

enum FileMode 
{
    CreateNew
    Create
    Open
    OpenOrCreate
    Truncate
    Append
}

FileMode <.left. File
FileStream <.right. File
```

</center>

<!-- slide -->

## FileMode

- ``FileMode.CreateNew`` - Skapa ny fil, får inte existera
- ``FileMode.Create`` - Skapa fil, truncate om finns
- ``FileMode.Open`` - Öppna existerande fil
- ``FileMode.OpenOrCreate`` - Öppna existerande fil om existerar, annars skapa den
- ``FileMode.Truncate`` - Skriv över existerande fil
- ``FileMode.Append`` - Skriv till slutet på existerande fil

<!-- slide -->

### Komplett program - lagra primtal som byte

```cs
static void Main(string[] args)
{
    const string fileName = "primes.bin";
    if (args.Length == 0)
    {
        GeneratePrimesFile(fileName);
    }
    else
    {
        byte prime = LookupPrimeInFile(fileName, int.Parse(args[0]));
        System.Console.WriteLine(prime);
    }
}
```

<!-- slide -->

```cs
static void GeneratePrimesFile(string fileName)
{
    // Skapa bytefält av primtal LINQ
    byte[] primes = 
        Enumerable.Range(2, 254).
        Where(n => !Enumerable.Range(2, n - 2).Any(d => n % d == 0)).
        Select(n => (byte)n).ToArray();

    // Spara bytefältet till fil
    Stream stream = File.Open(fileName, FileMode.Create);
    stream.Write(primes, 0, primes.Length);
    stream.Close();
}
```

<!-- slide -->

```cs
static byte LookupPrimeInFile(string fileName, int position)
{
    int index = position - 1;
    Stream stream = File.Open(fileName, FileMode.Open);
    stream.Seek(index, SeekOrigin.Begin);
    byte[] prime = new byte[1];
    stream.Read(prime, 0, 1);
    stream.Close();
    return prime[0];
}  
```

<!-- slide -->

## BinaryReader och BinaryWriter

Standardbiblioteket har klasserna ``BinaryReader`` och ``BinaryWriter`` som förenklar läsning/skrivning av binära filer.

<center style="margin-top: 1em; zoom: 1.4">

```plantuml
abstract Stream
{
}

class BinaryReader
{
    BinaryReader(Stream)
    byte ReadByte()
    sbyte ReadSByte()
    ushort ReadUInt16()
    short ReadInt16()
    uint ReadUInt32()
    int ReadInt32()
    double ReadDouble()
    double ReadSingle()
    bool ReadBool();
    char ReadChar();
}

BinaryReader .right.> Stream

class BinaryWriter
{
    BinaryWriter(Stream)
    void Write(byte)
    void Write(sbyte)
    void Write(ushort)
    void Write(short)
    void Write(uint)
    void Write(int)
    void Write(double)
    void Write(double)
    void Write(bool)
    void Write(char)
}

BinaryWriter .left.> Stream
```

</center>

<!-- slide -->

### Komplett program - lagra primtal som int

```cs
static void Main(string[] args)
{
    const string fileName = "primes.bin";
    if (args.Length == 0)
    {
        GeneratePrimesFile(fileName);
    }
    else
    {
        int prime = LookupPrimeInFile(fileName, int.Parse(args[0]));
        System.Console.WriteLine(prime);
    }
}
```

<!-- slide -->

```cs
static void GeneratePrimesFile(string fileName)
{
    // Skapa sammling av primtal av typen int med LINQ
    IEnumerable<int> primes = 
        Enumerable.Range(2, 1000).
        Where(n => !Enumerable.Range(2, n - 2).Any(d => n % d == 0));
    // Spara talen till fil
    FileStream stream = File.Open(fileName, FileMode.Create);
    BinaryWriter writer = new BinaryWriter(stream);
    foreach (int prime in primes)
    {
        writer.Write(prime);
    }
    stream.Close();
}
```

<!-- slide -->

```cs
static int LookupPrimeInFile(string fileName, int position)
{
    int index = position - 1;
    FileStream stream = File.Open(fileName, FileMode.Open);
    BinaryReader reader = new BinaryReader(stream);
    stream.Seek(index * sizeof(int), SeekOrigin.Begin);
    int prime = reader.ReadInt32();
    stream.Close();
    return prime;
}
```

<!-- slide -->

## TextReader och TextWriter

Standardbiblioteket har abstrakta klasser ``TextReader`` och ``TextWriter`` som förenklar läsning/skrivning av textfiler.

<center style="margin-top: 1em; zoom: 1.35">

```plantuml
abstract Stream
{
}

abstract TextReader
{
    string ReadToEnd()
    string ReadLine()
}

TextReader .right.> Stream

class StreamReader
{
    StreamReader(Stream)
}

class StringReader
{
    StringReader(string)
}


TextReader <|-- StreamReader
TextReader <|-- StringReader

abstract TextWriter
{
    Write(string)
    WriteLine(string)
}

TextWriter .left.> Stream

class StreamWriter
{
    StreamWriter(Stream)
}

class StringWriter
{
    WriterReader()
    string ToString()
}

TextWriter <|-- StreamWriter
TextWriter <|-- StringWriter

```

</center>

<!-- slide -->

## StringReader/StringWriter

- Praktiskt ibland att kunna behandla strängar som textströmmar
- Vi kommer titta mer på dessa klasser t.ex. i testkursen

<!-- slide -->

### Komplett exempel - personregister

```cs
class Employee {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }

    public override string ToString() {
        return $"{Name} <{Email}> {Birthday.ToString("yyyy-MM-dd")}";
    }
}
```

<!-- slide -->

```cs
static void Main(string[] args) {
    const string fileName = "employees.txt";
    LoadTextFile(fileName);
    if (args.Length > 1)
        switch (args[0]) {
            case "add":
                AddEmployee(args[1..]);
                SaveTextFile(fileName);
                break;
            case "find":
                System.Console.WriteLine(employees.
                    Find(e => e.Id == int.Parse(args[1])));
                break;
    // .. 
```

<!-- slide -->

```cs
static List<Employee> employees = new List<Employee>();

static void LoadTextFile(string fileName)
{
    var stream = File.Open(fileName, FileMode.OpenOrCreate);
    TextReader reader = new StreamReader(stream);
    string line; 
    while((line = reader.ReadLine()) != null)
    {
        employees.Add(Deserialize(line));
    }
    reader.Close();
}
```

<!-- slide -->

```cs
static Employee Deserialize(string line)
{
    // Tolka rad på formatet: <id> "<namn>" <email> <birthday>"
    Regex re = new Regex(@"(\d+) ""([^""]+)"" (\S+) (\S+)"); 
    CultureInfo cultureInfo = new CultureInfo("se-SE");
    Match match = re.Match(line);
    return new Employee()
    {
        Id = int.Parse(match.Groups[1].Value),
        Name = match.Groups[2].Value,
        Email = match.Groups[3].Value,
        Birthday = DateTime.Parse(match.Groups[4].Value, cultureInfo)
    };
}
```

<!-- slide -->

```cs
static void SaveTextFile(string fileName)
{
    var stream = File.Open(fileName, FileMode.Create);
    TextWriter writer = new StreamWriter(stream);
    foreach (Employee employee in employees)
    {
        writer.WriteLine(Serialize(employee));
    }
    writer.Close();
}
```

<!-- slide -->

```cs
static string Serialize(Employee employee)
{
    // Skapa rad på formatet: <id> "<namn>" <email> <birthday>"
    return 
        $"{employee.Id} \"{employee.Name}\" {employee.Email} " 
        + $"{employee.Birthday:yyyy-MM-dd}";
}
```

<!-- slide -->

## Serialsering

- Processen att göra om ett objekt till en bytesekvens kallas *serialisering*
- Processen att göra om en bytesekvens till ett objekt kallas *deserialisering*

<!-- slide -->

## Automatisk serialisering

- Klasser som har attributet ``[Serializable]`` kan automatiskt serialiseras/deserialiseras

<!-- slide -->

## IFormatter

<center style="zoom:2">

```plantuml
interface IFormatter
{
    void Serialize(Stream, object)
    object Deserialize(Stream)
}

class BinaryFormatter

IFormatter <|.. BinaryFormatter
```

</center>

<!-- slide -->

### Komplett exempel - personregister igen

```cs
[Serializable]
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }

    public override string ToString() {
        return $"{Name} <{Email}> {Birthday.ToString("yyyy-MM-dd")}";
    }
}
```

<!-- slide -->

```cs
static void Main(string[] args) {
    const string fileName = "employees.bin";
    LoadBinaryFile(fileName);
    if (args.Length > 1)
        switch (args[0])
        {
            case "add":
                AddEmployee(args[1..]);
                SaveBinaryFile(fileName);
                break;
            case "find":
                System.Console.WriteLine(employeeDb.Find(
                        e => e.Id == int.Parse(args[1])));
                break;
    // ..
```

<!-- slide -->

```cs
static List<Employee> employees = new List<Employee>();

static void LoadBinaryFile(string fileName)
{
    var stream = File.Open(fileName, FileMode.OpenOrCreate);
    IFormatter formatter = new BinaryFormatter();
    while (stream.Position < stream.Length)
    {
        employees.Add((Employee)formatter.Deserialize(stream));
    }
    stream.Close();
}
```

<!-- slide -->

```cs
static void SaveBinaryFile(string fileName)
{
    var stream = File.Open(fileName, FileMode.Create);
    IFormatter formatter = new BinaryFormatter();
    foreach (Employee employee in employees)
    {
        formatter.Serialize(stream, employee);
    }
    stream.Close();
}
```

<!-- slide -->

## Varför måste ``Close()`` anropas?

Man måste anropa metoden ``Close()`` för en ström för att: 
- Alla skrivningar skall verkställas. 
- Låsningar av filen skall släppas. 
- Resursen skall frigöras från applikationen.

<!-- slide -->

## Vanligt problem

- Exception kastas så filen stängs aldrig

<!-- slide -->

### Exempel

```cs
static void LoadTextFile(string fileName)
{
    var stream = File.Open(fileName, FileMode.OpenOrCreate);
    TextReader reader = new StreamReader(stream);
    string line; 
    while((line = reader.ReadLine()) != null)
    {
        // OOPS! Raden nedan kan kasta exception!
        employees.Add(Deserialize(line));
    }
    // .. och isf anropas aldrig reader.Close()
    reader.Close();
}
```

<!-- slide -->

## Using

- Ett ``using``-block säkerställer att metoden ``Dispose()`` anropas automatiskt för ett objekt innan programflödet lämnar blocket

```cs
using (<typ> obj1 = ... )
using (<typ> obj2 = ... )
...
{
    // Kod som använder obj1 och obj2 ..
    // Innan blocket lämnas anropas alltid automatiskt först 
    // obj2.Dispose(), sedan obj1.Dispose()
}
```

<!-- slide -->

## Strömmar och ``Dispose()`` 

- För en ström anropar metoden ``Dispose()`` i sin tur ``Close()``

<!-- slide -->

### Exempel

```cs
static void LoadTextFile(string fileName)
{
    using(var stream = File.Open(fileName, FileMode.OpenOrCreate)) 
    using(var reader = new StreamReader(stream))
    {
        string line; 
        while((line = reader.ReadLine()) != null)
            employees.Add(Deserialize(line));
        // Innan blocket lämnas anropas alltid automatiskt först 
        // reader.Close() och sedan stream.Close()
    }
}
```
