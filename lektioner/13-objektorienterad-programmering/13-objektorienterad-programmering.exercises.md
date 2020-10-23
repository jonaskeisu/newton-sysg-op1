# Klasser och objekt

## Övningar

---

### Övning (Fyll i luckorna)

- En underklass **\_\_\_** en förälderklass.
- Vi använder symbolen **\_\_\_** efter **\_\_\_** följt av **\_\_\_** för att åstadkomma arv i C#.
- En medlem med åtkomstmodifierare **\_\_\_** är tillgänglig för klassen och alla ärvda klasser.
- Vi kan använda nyckelordet **\_\_\_** för att använda förälderklassens konstruktor i underklassens konstruktor
- Vi kan ändra metoder som ärvs från förälderklassen i en underklass genom **\_\_\_**.
- Alla klasser i C# ärver av klassen **\_\_\_**.
- Genom att i definitionen av en metod använda modifieraren **\_\_\_** kan den överskuggas (override).
- När vi castar ett objekt till en mer specialserad typ gör vi en **\_\_\_**.
- När vi castar ett objekt till en mer generell typ gör vi en **\_\_\_**.
- En klass **\_\_\_** en abstrakt klass.
- En abstrakt metod har en **\_\_\_** men igen **\_\_\_**.
- En abstrakt klass kan inte **\_\_\_**.
- Man brukar säga att de fyra hörnstenarna inom objektorienterad programmering är, **\_\_\_**, **\_\_\_**, **\_\_\_** och **\_\_\_**.

---

### Övning

#### Sant eller falskt?

- Vi måste använda modifieraren `override` för att kunna överskugga en metod.
- Endast en metod med modifieraren `abstract` kan överskuggas i en ärvande klass.
- En klass kan direkt ärva flera klasser samtidigt i C#.
- En klass kan ärva av flera klasser i C#.
- Arv är ett fundamentalt koncept inom objektorienterad programmering.
- Vi kan alltid använda en instans av en klass som argument till `System.Console.WriteLine()`.
- Om `Dog : Animal`, och `Animal dog = new Dog();` så resulterar uttrycket `dog is Animal` i `true`.
- Om `Dog : Animal`, och `Animal dog = new Dog();` så resulterar uttrycket `dog is Dog` i `true`.
- En klass kan implementera flera interface.
- Ett interface kan ärva av ett annat interface.

---

### Övning

Inspektera klasserna `X` och `Y` nedan.

```cs
public class X {

    private int a;
    private int b;

    public X(int a, int b) {
        this.a = a;
        this.b = b;
    }

    virtual public int Sum() {
    	return a + b;
    }

}
```

```cs
public class Y : X {

    private int c;

    public Y(int a, int b, int c) {
    	base(a, b);
        this.c = c;
    }

    override public int Sum() {
    	return a + b + c;
    }

}
```

a) Varför får vi kompileringsfel när vi försöker kompilera klassen `Y`?

b) Gör en ändring i deklarationen av medlemsvariablerna  `a` och `b` så att båda klasser kompilerar.

---

### Övning

Inspektera koden nedan:

```cs
public abstract class Animal {
    protected float weight;
    public Animal(float weight) {
        this.weight = weight;
    }
    virtual public void Summarize() {
        System.Console.WriteLine("Animal with weight " + weight);
    }
}
```

```cs
public class Dog : Animal {
    protected float tailLength;
    public Dog(float weight, float tailLength) : base(weight) {
        this.tailLength = tailLength;
    }
    override public void Summarize() {
        System.Console.WriteLine("Dog with weight " + weight + " and tail length " + tailLength);
    }
    public void bark() {
        System.Console.WriteLine("Woof!");
    }
}
```

```cs
public class Program {
    public static void Main(string[] args) {
        Dog dog1 = new Dog(50.0f, 0.45f);
        Animal dog2 = new Dog(30.0f, 0.30f);
        Animal dog3 = new Dog(20.0f);
        dog1.Summarize();
        dog2.Summarize();
        dog3.Summarize();
        dog1.bark();
        dog2.bark();
    }
}
```

a) Förklara varför raden `dog2.bark();` leder till kompileringsfel.

b) Kommentera bort raden `dog2.bark();`. Vad blir nu utskrifterna? Varför?

---

# Övning

Inspektera följande klass:

```cs
public class Counter {

  protected int x;

  public Counter() {
    x = 0;
  }

  public Counter(int x) {
    this.x = x;
  }

  public int X => x;

  public void incrementX() {
    x++;
  }

}
```

Skriv en klass `DoubleCounter : Counter` med följande utökade funktionalitet:

- En `private int y` som initialiseras till 0
- Konstruktor:
  - `DoubleCounter()` som sätter `x` och `y` till 0
  - `DoubleCounter(int x, int y)` som initialiserar `x` och `y` med argumentens värden.
- Get-accessor för `y`
- En metod `public void incrementY()` som ökar värdet på `y` med 1.

---

### Övning

Inspektera klassen `Employee` nedan som representerar en anställd på ett företag. En anställds personuppgifter (employee information) innehåller information om den anställde på företaget.

```cs
public class Employee {

	// Variables
	private int id;
	private int age;
	private int salary;
	private string title;
	private string department;

	// Constructor
	public Employee(int id, int age, int salary, string title, string department) {
		this.id = id;
		this.age = age;
		this.salary = salary;
		this.title = title;
		this.department = department;
	}

	// Property accessors
    public int Age {
        get => age;
        set => age = value;
    }

    public int Salary {
        get => salary;
        set => salary = value;
    }

    public int Title {
        get => title;
        set => title = value;
    }

    public int Department {
        get => department;
        set => department = value;
    }

    public int Id => id;

	//Methods
	public string getEmployeeInformation() {
		stringBuilder record = new stringBuilder();
		record.Append("ID: " + id + "\n");
		record.Append("Age: " + age + "\n");
		record.Append("Salary: " + salary+ "\n");
		record.Append("Title: " + title + "\n");
		record.Append("Department: " + department + "\n");
		return record.tostring();
	}

}
```

a) Implementera en klass `Manager` som ärver av `Employee` som representerar en chef på ett företag.

- En `Manager` är en anställd på ett företag som övervakar en grupp av anställda.
- En `Manager`s personuppgifter inkluderar all information som finns i en vanling anställds personuppgifter, samt en lista över ID:n hos de anställde som chefen övervakar. Detta ska reflekteras i värdet som returneras om man anropar metoden `getConfidentialRecord()` på ett `Manager`-objekt.
- En `Manager` ska ha en konstruktor initialiserar en `Manager` utifrån alla attribut som en `Employee` har, samt en `int[]` innehållandes ID:n för de anställda som `Manager`n övervakar.

**Tips:** Notera att `Employee`s attribut är `private`. Använd nyckeordet `base` på ett lämpligt sätt.

b) Implementera en klass `ExecutiveManager` som ärver av `Manager` som representerar en verkställande chef på ett företag.

- En `ExecutiveManager` är en chef på ett företag som erhåller en lönebonus som är en procentandel av företagets årliga vinst.
- En `ExecutiveManager`s personuppgifter inkluderar all information som finns i en vanlig chefs personuppgifter, samt den procentandelen av företagets årliga vinst.
- En `ExecutiveManager` ska ha en konstruktor initialiserar en `ExecutiveManager` utifrån alla attribut som en `Manager` har, samt en `double` motsvarande lönebonusen.

---

### Övning

a) Vad skriver följande program ut? Varför?

```cs
public class Program {
  public static void Main(string[] args) {
    Bread bread = new Bread("Pågen");
    System.Console.WriteLine(bread);
  }
}
```

```cs
public class Bread {
  private string name;
  public Bread(string name) {
    this.name = name;
  }
}
```

b) Utöka klassen `Bread` så att `Main`-programmet skriver ut "Pågen". (Rör ej `Main`-programmet)

---

### Övning

I filen _Apple.cs_ finns en klass `Apple` definierad.

```cs
class Apple {
    private int weight; // grams
    private int volume; // cubic centimeters
    private string color;

    public Apple(int weight, int volume, string color) {
        this.weight = weight;
        this.volume = volume;
        this.color = color;
    }

    public int Weight => weight;

    public int Value => volume;

    public string Color => color;
}
```

a) Överlagra konstruktorn så att vi har en konstruktor där man bara behöver ange vikt och volym för äpplet, och så att färgen blir `"Red"`

b) Överskugga metoden `Equals()` som ärvs från `Object` så att nedanstående kodstycke skriver ut `true`

```cs
Apple apple1 = new Apple(150, 270, "Red");
Apple apple2 = new Apple(150, 270, "Red");
System.Console.WriteLine(apple1.Equals(apple2));
```

c) Överskugga metoden `ToString()` som ärvs från `Object` så att nedanstående kodstycke skriver ut _"Apple with weight 150 grams, volume 270 cubic centimeters and color Red"_

```cs
Apple apple = new Apple(150, 270, "Red");
System.Console.WriteLine(apple);
```

d) Lägg till ett privat statiskt egenskap som räknar hur många äpplen som har skapats under programmets körtid, samt en statisk metod `int HowManyApples()` som returnerar detta värde.
Exempel:

```cs
Apple apple1 = new Apple(150, 270, "Red");
Apple apple2 = new Apple(200, 360, "Red");
System.Console.WriteLine(Apple.howManyApples());
```

ska skriva ut `2` om inga andra instanser av `Apple` har skapats tidigare.

e) Lägg till en metod `void TakeBite(float volume)`. Metoden ska ta subtrahera äpplets volym med metodens argument, samt reducera äpplets vikt med motsvarande siffra (t.ex. om man biter av halva äpplet så ska vikten halveras)

Exempel:

```cs
Apple apple = new Apple(150, 270, "Red");
apple.TakeBite(90);
System.Console.WriteLine(apple.getVolume());
System.Console.WriteLine(apple.getWeight());
```

ska skriva ut

```console
180
100
```

eftersom 270-90=180, och 150-150\*(90/270)=100.

---

### Övning

Efter att ha implementerat din klass `Apple` från föregående uppgift så inser du att du vill implementera en klass `Pear` som också ska beskrivas med en vikt, en volym och en färg, samt ha en metod `void TakeBite(float volume)` som fungerar som ovan beskrivet. Du bestämmer dig för att antigen skriva en `abstract class Fruit` som `Apple` och `Pear` extendar, eller ett `interface Fruit` som `Apple` och `Pear` implementerar.

b) Skriv en lösning som använder sig av en `abstract class Fruit` där klasserna `Apple` och `Pear` ärver av `Fruit`.

Efter att klasserna är implementerade ska följande kodstycke resultera i följande kod:

```cs
public class Program {
    public static void Main(string[] args) {
        Fruit apple = new Apple(300, 100);
        Fruit pear = new Pear(200, 100);
        pear.TakeBite(50);
        System.Console.WriteLine("Pear after taking bite weighs: " + pear.getWeight() + " grams");
    }
}
```

utskriften:

```console
Pear after taking bite weighs 100 grams
```

---

# Övning

Inspektera följande klasser:

```cs
class A {
    abstract public void Print() {
        System.Console.WriteLine("a");
    }
}

class B : A {
    override public void Print() {
        System.Console.WriteLine("b");
    }
}
```

Inspektera följande metoder.

```cs
public static void f(A a) {
    a.Print();
}
public static void g(B b) {
    ((A)b).Print();
}
public static void h(A a) {
    ((A)a).Print();
}
public static void j(B b) {
    b.Print();
}
```

Vad händer när vi anropar de angivna metoderna med en instans av `A` respektive `B`?

|     | f   | g   | h   | j   |
| --- | --- | --- | --- | --- |
| A   | ?   | ?   | ?   | ?   |
| B   | ?   | ?   | ?   | ?   |

---

### Övning

Nedan följer en deklaration av en klass `Remote` som representerar en fjärrkontroll.
`Remote` har följande egenskaper:

- Kan vara på eller avstängd
- Har en vald kanal
- Kan bläddra upp och ned bland 100 kanaler (från 0 till och med 99)
- Om man bläddrar upp när kanalen är den högsta tillgängliga sätts kanalen till den minsta, vice versa.
- Kan endast byta kanal om den är på

```cs
public class Remote {

	protected int channel;
	protected bool isOn;

	protected const int NUMBER_OF_CHANNELS = 100; // channel 0, 1, 2, ... NUMBER_OF_CHANNELS-1

	public Remote() {
		channel = 0;
		isOn = true;
	}

	public void ChannelUp() {
		if (isOn) {
			channel = (channel + 1) % NUMBER_OF_CHANNELS; // Resets to 0 if channel too big
		}
	}

	public void ChannelDown() {
		if (isOn) {
			channel = (channel - 1);
			if (channel < 0) channel = NUMBER_OF_CHANNELS - 1; // Resets to NUMBER_OF_CHANNELS-1 if channel too big
		}
	}

	public void PowerButton() {
		isOn = !isOn;
	}

	// Getter
	public int Channel => channel;

	// Getter
	public bool IsOn => isOn;
}

```

a) Implementera en klass `DirectRemote : Remote` som är en `Remote` med följande utökade funktionalitet:

- Låter användaren hoppa till en specifik kanal direkt genom en metod `public void setChannel(int channel)`
  - Försöker användaren hoppa till en kanal högre än den största kanalen sätts kanalen till den största kanalen, vice versa
- Låter användaren hoppa tillbaka till föregående kanal genom en metod `public void LastChannel()`
- Precis som för `Remote` ska kanaler endast kunna bytas om `DirectRemote` är på.

Efter korrekt implementation av `DirectRemote` skall följande kodstycke resultera i följande utskrift:

```cs
public class Program {
	public static void Main(string[] args) {
		DirectRemote remote = new DirectRemote();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelUp();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelUp();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelDown();
		System.Console.WriteLine(remote.Channel);
		remote.PowerButton();
		remote.ChannelUp();
		System.Console.WriteLine(remote.Channel);
		remote.PowerButton();
		remote.ChannelDown();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelDown();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelDown();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelUp();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelUp();
		System.Console.WriteLine(remote.Channel);
		remote.setChannel(55);
		System.Console.WriteLine(remote.Channel);
		remote.LastChannel();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelUp();
		System.Console.WriteLine(remote.Channel);
		remote.PowerButton();
		remote.setChannel(99);
		System.Console.WriteLine(remote.Channel);
		remote.PowerButton();
		remote.setChannel(99);
		System.Console.WriteLine(remote.Channel);
	}
}
```

```console
0
1
2
1
1
0
99
98
99
0
55
0
1
1
99
```

b) Implementera en klass `PrintingRemote : Remote` som är en `Remote` med följande utökad funktionalitet:

- Efter att kanalen har ändrats ska kanalen efter ändring skrivas ut till konsolen
- Efter att fjärrkontrollen sätts på eller stängts av ska detta tillstånd (on eller off) skrivas ut till konsolen
- Vid konstruktion av en `PrintingRemote` ska den nuvarande kanalen och strömtillståndet (on eller off) skrivas ut till konsolen.

**TIPS:**

- Utnyttja `base`-nyckelordet på ett lämpligt sätt.
- Om fjärrkontrollen är avstängd kan man inte byta kanal, och behöver därmed inte göra någon utskrift om kanalbyte

Efter korrekt implementation av `PrintingRemote` skall följande kodstycke resultera i en utskrift lik följande:

```cs
public class Program {
	public static void Main(string[] args) {
		PrintingRemote remote = new PrintingRemote();
		remote.ChannelUp();
		remote.ChannelUp();
		remote.ChannelDown();
		remote.PowerButton();
		remote.ChannelUp();
		remote.PowerButton();
		remote.ChannelDown();
		remote.ChannelDown();
		remote.ChannelDown();
		remote.ChannelUp();
		remote.ChannelUp();
	}
}
```

```console
Remote is ON
Channel 0
Channel 1
Channel 2
Channel 1
Remote is OFF
Remote is ON
Channel 0
Channel 99
Channel 98
Channel 99
Channel 0
```

---

### Övning

Nedan följer en deklaration av en klass `RemotePrivate` som representerar en fjärrkontroll som `Remote` i föregående övning. Den enda skillnaden är att attributen `channel` och `isOn` har access level `private` istället för `protected`.

```cs
public class RemotePrivate {

	private int channel;
	private bool isOn;

	protected final int NUMBER_OF_CHANNELS = 100; // channel 0, 1, 2, ... NUMBER_OF_CHANNELS-1

	public RemotePrivate() {
		channel = 0;
		isOn = true;
	}

	public void ChannelUp() {
		if (isOn) {
			channel = (channel + 1) % NUMBER_OF_CHANNELS; // Resets to 0 if channel too big
		}
	}

	public void ChannelDown() {
		if (isOn) {
			channel = (channel - 1);
			if (channel < 0) channel = NUMBER_OF_CHANNELS - 1; // Resets to NUMBER_OF_CHANNELS-1 if channel too big
		}
	}

	public void PowerButton() {
		isOn = !isOn;
	}

	// Getter
	public int Channel => channel;

	// Getter
	public bool IsOn => isOn;

}
```

Implementera en klass `DirectRemotePrivate : RemotePrivate` som är en har samma funktionalitet som `DirectRemote` i föregående uppgift.

**TIPS:** Hur kan man ändra `channel` utan direkt tillgång till attributet?

Efter korrekt implementation av `DirectRemotePrivate` skall följande kodstycke resultera i följande utskrift:

```cs
public class Program {
	public static void Main(string[] args) {
		DirectRemotePrivate remote = new DirectRemotePrivate();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelUp();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelUp();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelDown();
		System.Console.WriteLine(remote.Channel);
		remote.PowerButton();
		remote.ChannelUp();
		System.Console.WriteLine(remote.Channel);
		remote.PowerButton();
		remote.ChannelDown();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelDown();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelDown();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelUp();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelUp();
		System.Console.WriteLine(remote.Channel);
		remote.setChannel(55);
		System.Console.WriteLine(remote.Channel);
		remote.LastChannel();
		System.Console.WriteLine(remote.Channel);
		remote.ChannelUp();
		System.Console.WriteLine(remote.Channel);
		remote.PowerButton();
		remote.setChannel(99);
		System.Console.WriteLine(remote.Channel);
		remote.PowerButton();
		remote.setChannel(99);
		System.Console.WriteLine(remote.Channel);
	}
}
```

```console
0
1
2
1
1
0
99
98
99
0
55
0
1
1
99
```

Notera att kodstycket ovan är samma som i föregående övning, fast `DirectRemote` har ersatts med en `DirectRemotePrivate`.

---

### Övning

[Liskov substitution principle](https://en.wikipedia.org/wiki/Liskov_substitution_principle) säger att om en klass `B` ärver av en klass `A` så ska en instans av `B` kunna ersätta en instans av `A` i alla sammanhang.

Undersök klasserna nedan:

```cs
public class Rectangle {

	protected double height;
	protected double width;

	public Rectangle(double height, double width) {
		this.height = height;
		this.width = width;
	}

    virtual public double Height {
        get => height;
        set => height = value;
    }

    virtual public double Width {
        get => width;
        set => width = value;
    }

	virtual public double Area => height*width;

}
```

```cs
public class Square : Rectangle {

	public Square(double side) {
		base(side, side);
	}

	override public double Height {
        get => height;
        set {
            height = widht = value;
        }
    }

	override public double Width {
        get => width;
        set {
            height = widht = value;
        }
    }
}
```

I detta fall har en klass `Square` skapats som ärver av `Rectangle` eftersom en kvadrat _är en_ rekangel där båda sidor alltid är lika stora.

a) Skriv en metod `void setRectangleWidth(Rectangle rect, double newWidth)` som sätter en `Rectangle`-instans bredd till `newWidth`

b) Förklara hur klasshierarkin i detta exempel bryter mot Liskov Subsitution Principle.

---

### Övning

I en tidigare övning implementerade du:

- en klass `Dice` som representerade en sexsidigtärning
- en klass `DiceMultiSided` som representerade en tärning med godtyckligt många sidor
- en klass `DiceCup` som representerade en mugg med flera sexsidiga tärningar

a) Anser du att `DiceMultiSided` bör ärva av `Dice`? Varför? Varför inte?
b) Anser du att `Dice` bör ärva av `DiceMultiSided`? Varför? Varför inte?
c) Anser du att `DiceCup` bör ärva av `Dice`? Varfö? Varför inte?
d) Anser du att `Dice` bör ärva av `DiceCup`? Varför? Varför inte?

---

### Övning

Para ihop rätt kod med rätt UML-diagram och namn på klassrelation.

1:

```cs
class Boo {
    private Foo foo;
    public Boo(Foo foo) {
        this.foo = foo;
    }
}
```

2:

```cs
class Boo : Foo {...}
```

3:

```cs
class Boo {
    private Foo foo;
    class Foo {...}
}
```


a:
```plantuml
class Boo
class Foo
Foo <|-- Boo
```



b:
```plantuml
class Boo
class Foo
Foo *-- Boo
```

c:
```plantuml
class Boo
class Foo
Foo o-- Boo
```

I: Composition (_part-of_)

II: Aggregation (_has-a_)

III: Inheritance (_is-a_)

---

### Övning

Rita ett UML-diagram som representerar klasserna `Dice` och `DiceCup` från tidigare övningsuppgifter och klassernas relation.

Detaljnivån i klassdiagram ska vara hög nog att inkludera:

- Egenskapers typer
- Metoders returtyper
- Metodparamtrars typer

---

# Övning

Implementera klasserna `Person`, `Student`, `Professor` och `Address` enligt följande konceptuella UML-diagram:
- Tolka fritt lämpliga namn, synligheter, typer och signaturer fritt för attributer och metoder.
- Lägg till ytterligare privata attributer och metoder om det behövs enligt din vision

**OBS:** Siffrorna vid associationspilen mellan `Person` och `Address` syftar på _multiplicitet_: En `Person` kan bo på en `Address` och en `Address` kan ha 0 eller 1 `Person`s som bor på den.


```plantuml
class Person
{
    Name
    PhoneNumber
    Email
    PurchaseParkingPass()
}

class Student
{
    StudentNumber
    AverageGrade
    IsEligableToEnroll()
    GetSeminarsTaken()
}

class Professor
{
    Salary
}

class Address
{
    Street
    City
    PostalCode
    Country
    Validate()
    ToString()
}

Person <|-- Student
Person <|-- Professor
Person "0..1" -right-> "1" Address: lives at
```