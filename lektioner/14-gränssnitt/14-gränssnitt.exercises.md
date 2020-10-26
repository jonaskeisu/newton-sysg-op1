# Gränssnitt
## Övningar

---

### Övning

Fyll i luckan. 

1) Det engelska ordet för gränssnitt är _______.
2) Ett gränssnitt beskriver ett _______ som typer kan uppfylla.
3) Innehåller _______ för medlemmar som en typ som implementerar gränssnittet måste innehålla.

---

### Övning 

Sant eller falskt? 

1) Ett klass kan ärva ett gränssnitt.
2) En klass kan implementera hur många gränssnitt som helst.
3) Ett gränssnitt kan innehålla egenskaper. 
4) Ett gränssnitt kan innehålla metoder. 
5) Ett gränssnitt kan ärva en klass. 
6) Ett gränssnitt kan ärva ett gränssnitt.

---

### Övning

En funktinonskurva mappar varje punkt på en x-axel till en punkt på y-axeln. 

Ett gränssnitt för en funktionskurva skulle kunna se ut så här:

```cs
interface ICurve
{
	// användarangiven beskrivning av kurvan
	string Description; 

	// Beräkna y-värdet motsvarande angivet värde för x.
	double CalculateY(double x)
}
```

a) Skriv en klass ``Line`` för en linje med lutningskoefficient ``k`` och förskjutning ``m``. Tips: relationen mellan ``x`` och ``y`` ges av: $y = m + k⋅x$.

b) Skriv en klass ``Sine`` för en sinuskurva med våglängd ``l`` och amplitud ``a`` som implementerar gränssnittet ``Curve``. Tips: relationen mellan ``x`` och ``y`` ges av: $y = a ⋅ sin((2\pi⋅x)/l)$.  

c) Skriv en klass ``Plot`` med metoder med följande signaturer:

```cs
class Plot
{
	void Add(ICurve curve, char symbol);
	void Draw();
}
```

för att plotta kurvor i intervallet $1 <= x <= 30$ och $-5 <= y <= 5

T.ex. skall koden: 

```cs
Plot plot = new Plot();
plot.Add(new Line("line", m: -5, k: 0.33), '*');
plot.Add(new Sine("sine", a: 5, l: 30), '#');
plot.Draw();
```

ge utskriften:


Tips: Använd ett fält av typen ``char[,]``. 

---

### Övning

Alla samlingstyper i standardbiblioteket, inkl. fält, implementerar följande gränssnitt:

```cs
interface IEnumerable
{
	IEnumerator GetEnumerator();
}
```

för att skapa en ett objekt, kallad *enumerator*, som tillåter användaren att löpa igenom alla element i samlingen t.ex. med en ``foreach``-sats. I ett tärningsspel finns två klasser:

```cs
class Dice
{
	private Random rnd = new Random();
	private value;
	public void Roll() => value = rnd.GetNext(1, 6);
	public int Value => value;
}

class DiceCup
{
	private Dice[] dice = new Dice[5];
	public void Roll() { foreach(Dice d in dices) d.Roll(); }
}
```

Uppdatera klassen ``DiceCup`` så att den implementerar ``IEnumerable`` med en enumerator som löper igenom alla tärningar i koppen. Tips: Utnyttja det faktum att ett fält av ``Dice`` redan implementerar gränssnittet.

---

### Övning

Standardbiblioteket definierar ett gränssnitt: 

```cs
interface IEnumerator
{
	// Aktuellt element
	object Current { get; }

	// Om det finns fler element, flytta till nästa element och returnera 'true'.
	// Annars returnera 'false.
	bool MoveNext();

	// Börja om från elementet före första elementet
	void Reset();
}
```

för att löpa igenom element i samlingar. 

Definiera en klass ``RangeEnumerator`` för att löpa igenom ett intervall av heltal och som implementerar ``IEnumerator``. T.ex. skall koden nedan:

```cs
foreach (int i in RangeEnumerator(-3, 3))
{
	Console.WriteLine(i);
}
```

ge utskriften:

```cs
-3
-2
-1
0
1
2
```

---

### Övning

Inspektera interfacet ``Shape2D`` nedan:

```cs
public interface Shape2D {
	
	double PI = 3.1415; 
	double getArea();
	double getPerimiter();
	
}
```

## a) Skriv en klass ``RegularTriangle implements Shape2D`` som representerar en triangel vars sidor och vinklar alla är lika stora.

## b) Skriv en klass ``Square implements Shape2D`` som representerar en kvadrat (fyrkant vars sidor och vinklar alla är lika stora).

## c) Skriv en klass ``RegularPentagon implements Shape2D`` som representerar en femhörning vars sidor och vinklar alla är lika stora.

## d) Du vill nu att alla dina ``Shape2D``-klasser ska implementera standardinterfacet ``Shape2D`` så att en ``Shape2D`` kan jämföras med en annan ``Shape2D`` baserat på deras *areor*. Beskriv tre sätt detta kan åstadkommas, och implementera åtminstone ett av dem.

## e) Bekräfta att du har implementerat klasserna korrekt genom att skapa en ``RegularTriangle`` med sidlängd ``5.0``, en ``Square`` med sidlängd ``5.0`` och en ``RegularPentagon`` med sidlängd ``5.0``. Din ``Square`` ska vara större än din ``RegularTriangle``, och din ``RegularPentagon`` ska vara större än din ``Square``.

## f) Overrida ``tostring()`` metoden för ``RegularTriangle``, ``Square`` och ``RegularPentagon`` så att metoden returnerar en ``string`` som innehåller a) klassens namn, b) arean och c) omkretsen (perimiter).

## g) Skriv en metod ``void sortAndPrint(Shape2D[] shapes)`` som tar en ``Shape2D``-array, sorterar den från minst objekt till störst, och skriver ut strängrepresentationerna av objekten i den sorterade ordningen.
**Tips:** Använd klassmetoden [``void parallelSort(T[] a)`` från klassen ``cs.util.Arrays``](https://docs.oracle.com/en/cs/csse/11/docs/api/cs.base/cs/util/Arrays.html#parallelSort(T%5B%5D)) för att sortera en array ``a`` vars element implementerar ``Comparable<T>``-interfacet. 

## h) **(överkurs)** Skapa en klass ``RegularPolygon implements Shape2D`` som representerar en polygon vars sidor och vinklar alla är lika stora.

---

## e) Skriv ett interface ``Rollable`` som ``Dice``, ``DiceMultiSided`` och ``DiceCup`` alla kan implementera.

