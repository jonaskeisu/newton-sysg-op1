## Tentamen Newton - OP1

## Uppgift 1 (2p)

a) Vad är det decimala värdet av unsigned bytevärdet ``1000001``? (1p)
b) Vad är det decimala värdet av signed bytevärdet ``1000001``? (1p)

## Uppgift 2 (11p)

Förklara följande begrepp: 

a) Variabeldeklaration (1p)
b) Variabelinitiering (1p)
c) Uttryck (1p)
d) Sats (1p)
e) Operator (2p)
f) Funktion (2p)
g) Funktionsanrop (2p)
h) Konvertering (1p)

## Uppgift 3 (4p)

a) Skriv en statisk metod som kontrollerar om ett fält av integers är symmetriskt, dvs samma framlänges och baklänges, med hjälp av en ``for``-loop. (2p)
b) Skriv om metoden så att den är generisk med elementtypen i fältet som typparameter.  (2p)

## Uppgift 4 (3p)

a) Vad skriver följande program ut? Varför? (2p)

```cs 
namespace App
{
    struct Employee
    {
        public string Name;
        public int Age;
    }

    class Program
    {
        static void Birthday(Employee employee) 
        {
            ++employee.Age; 
        }

        public static void Main(string[] args)
        {
            Employee employee = new Employee() { Name = "Jonas", Age = 42 };
            Birthday(employee);
            Console.WriteLine($"Age after birthday: {employee.Age}");
        }
    }
}
```

b) Modifera parametern till metoden ``Birthday`` så att koden fungerar som tänkt. Behöver koden några ytterligare ändringar? (1p)

## Uppgift 4 (3p)

Rätta felet i koderna nedan:

a)

```cs
int sum = 0; 
for (int i = 0; i <= array.Length; ++i)
{
    sum += array[i];
}
```

(1p)

b)

```cs 
double capital = 1000000; 
double yearlyLoss = 9872; 
int yearsUntilBankruptcy = 0; 
while (capital != 0)
{
    capital -= yearlyLoss; 
    ++yearsUntilBankruptcy; 
}
```

(1p)

c) 

```cs
uint RectangleArea(ushort width, ushort height)
{
    return RectangleArea(width - 1) + height;
}
```

(1p)

## Uppgift 5 (3p)

Koden nedan läser in ett datum från användaren, men kraschar p.g.a. ett ``FormatException`` om datumet inte har ett korrekt format. Skriv om koden så felet hanteras genom att användaren ombes skriva in datumet på nytt. 

```cs 
Console.Write("Skriv in ditt födelsedatum:");
DateTime birthday = DateTime.Parse(Console.ReadLine());
```

## Uppgift 6 (7p)

Bilar kan ha olika accelerationsförmåga och olika toppfart. Fart är hur långt bilen rör sig i antal meter per sekund. Accelerationen är ökningen av farten per sekund. 

a) Skriv en klass för bilar med en aktuell position (i meter), hastighet (i meter/sekund), accelerationsförmåga(i hatighetsökning/sekund) och toppfart. Klassen skall också ha en metod ``Tick`` som anropas varje gång en sekund har passerat för att uppdatera bilens hastighet och position (antag att bilen alltid har full gas). (2p)

b) Skriv en klass för ett bilrace. Konstruktorn skall ta ett fält av bilar som argument samt hur långt racet är. Klassen har även en metod ``Race`` som tävlar bilarnarna mot varandra och returnerar den (eller de bilar) som vann racet. (2p)

c) Skriv en ny klass för turbobilar vars accelerationsförmåga ökar med 50% efter att turbon laddat upp (tar 3 sekunder). Klassen för turbobilar skall ärva klassen bil och överskugga metoden ``Tick``. Beskriv även eventuella nödvändiga modifikationer i klassen bil. (3p)

## Uppgift 7 (13p)

Förklara följande begrepp: 

a) Klass (1p)
b) Instans (1p)
c) Medlemsvariabel (1p)
d) Metod (1p)
e) Egenskap (1p)
f) Arv (1p)
g) Överlagring (1p)
h) Överskuggning (1p)
i) Castning (1p)
j) Gränssnitt (1p)
k) Delegattyp (1p)
l) Event (1p)
m) Lambdafunktion (1p)

## Uppgift 8 (5p)

Antag följande klass:

```cs
class Movie
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public string[] Actors { get; set; }
}
```

och en lista ``movies`` av typen ``List<Movie>``. Använd LINQ för att med en kodrad skapa ett fält av strängar som innehåller titlarna på alla filmer i ``movies`` producerade före år 2000 och som både hade skådespelarna Arnold Schwarzenegger och Danny DeVito.  

## Uppgift 9 (6p)

En *rastrerare* ritar en approximation av geometrisk form, t.ex. en cirkel eller en linje, på en skärmyta genom att färglägga pixlar. Varje pixel på ytan identifieras via indexet på dess rad respektive kolumn i skärmytan. 

Antag att API för rastrering tar ett objekt som uppfyller följande gränssnitt som argument: 

```cs
interface IScreen
{
    Clear();
    ColorPixel(int row, int column);
    event OnColorPixel ColoringOutsideScreen;
}
```

Ovanstående gränssnitt beror på följande delegattyp: 

```cs
delegate void OnColorPixel(int row, int column);
```

Skriv en klass ``ConsoleScreen`` som implementrar gränssnittet ovan genom att skriva ut ``X`` i textfönstret på angiven position. Tips: Utnyttja nedanstående metoder och egenskaper:

```cs
public static void Clear ();

public static void SetCursorPosition (int left, int top);

public static int WindowWidth { get; set; }

public static int WindowHeight { get; set; }
```

## Uppgift 10 (10p)

En rubiks kub är en tredimensionell kub bestående av 3 x 3 x 3 block. De yttre ytorna av blocken har från början färger enligt nedanstående bild. 

<img src="fig/rubiks_cube.png"/>

Kuben kan modifieras genom 90 graders rotation av ett av tre blockplan, i tre olika dimensioner. 

Kuben är korrekt om varje sida av kuben har en enda färg. 

a) Rita ett klassdiagram för en rubiks kub. Kuben i diagrammet skall ha metoder för att: 

- Konstruera en ny kub. 
- Rotera ett plan i någon dimension. 
- Läsa ut färgen på en av de 6 x 6 blockyta på främre, bakre, övre, undre, vänstra eller högra sidan.   

samt en egenskap som säger om kuben är korrekt. (4p)

b) Skriv komplett kod för för typerna i ditt diagram. (6p)








