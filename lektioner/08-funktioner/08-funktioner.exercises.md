# Fält och loopar
## Övningar

---

### Övning tn9vfh (1)

Ange returtyp och parametertyp(er) för följande metodsignaturer:

a) ``int Sum(int a, int b)``

b) ``bool IsAllCaps(String s)``

c) ``double Power(double x, int e)``

### Övning u9qmue (1)

a) Implementera en klassmetod med signaturen ``double Cube(double x)`` som returnerar ``x`` gånger sig själv tre gånger.

b) Implementera en klassmetod med signaturen ``int Min(int x, int y)`` som returnerar det minsta värdet av ``x`` och ``y``.

c) Implementera en klassmetod med signaturen ``void WriteTwice(string str)`` som skriver ut strängen str två gånger till konsolen.

d) Implementera en klassmetod med signaturen ``string GetUserInput(string prompt)`` som vid anrop skriver ut prompt till konsolen, begär användarinput i form av en sträng, och returnerar användarens input.

### Övning pkq697 (1-2)

a) Skriv en klassmetod ``int TriangleSum(int n)`` som beräknar summan av alla heltal från ``0`` till ``n`` med hjälp av en ``for``-loop.

b) Skriv en klassmetod ``int TriangleSum(int n)`` som beräknar summan av alla heltal från ``0`` till ``n`` genom rekursion.

### Övning p6uggf (2)

a) Skriv en klassmetod med signaturen ``void multiplyArray(double[] arr, int factor)`` som multiplicerar elementen i ``arr`` med faktorn ``factor``.

b) Skriv ett kort program som initialiserar en ``int``-array och använder metoden för att gångra värdena med 4.

### Övning u36tue (3)

Skriv en klassmetod ``int DigitSum(int x)`` som returnerar summan av siffrorna i ett heltal.

#### Exempel

Koden nedan: 

```cs
int x = DigitSum(365); 
Console.WriteLine(x);
```

ger utskriften: 

```text
14
```

### Övning 3u3ktu (2)

Skriv en klassmetod ``bool CheckMultiplesOfTen(int[] arr)`` som svarar på om alla element i en ``int``-array är multiplar av 10.

#### Exempel

Koden nedan:

```cs
int[] arr1 = {10, 20, 500};
int[] arr2 = {10, 100, 1001};
System.out.println(checkMultiplesOfTen(arr1));
System.out.println(checkMultiplesOfTen(arr2));
```

ger utskriften:

```text
true
false
```

### Övning j2b6h6 (1)

Inspektera koden nedan. Vilka av ``x``, ``y``, ``a`` och ``b`` är parametrar respektive argument?

```cs
class Program {
    
    static double Hypotenuse(double x, double y) {
        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    }

    static void Main(String[] args) {
        double a = 4, b = 5;
        double h = Hypotenuse(a, b);
        Console.WriteLine($"A right triangle with sides of length {a} and {b} has the hypotenuse {h}.");
    }
}
```

### Övning re74fr (3)

Skriv en klassmetod ``double[,] Transpose(double[,] array)`` som returnerar ett tvådimensionellt fält vars rader är argumentets kolumner och vars kolumner är argumentets rader. 

#### Exempel

Koden nedan: 

```cs
double[,] table = {
    { 1, 2, 3},
    { 4, 5, 6}
};

double[,] transpose = Transpose(table);

for (int r = 0; r < transpose.GetLengt(0); ++r) {
    for (int c = 0; c < transpose.GetLengt(1); ++c) {
        Console.Write(transpose[r, c] + " ");
    }
    Console.WriteLine();
}
```

ger utskriften: 

```text
1 4
2 5
3 6
```

### Övning 6p854m (3)

Följande kod: 

```cs
class Program {

    static void Main(string[] args) {
        float[] arr1 = {1.4f, 5.3f};
        float[] arr2 = MultiplyByTwo(arr1);

        WriteArray(arr1);
        WriteArray(arr2);
    }

    static void WriteArray(int[] arr) {
        for (int i = 0; i < arr.Length; ++i) {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    static float[] MultiplyByTwo(float[] arr) {
        for (int i=0; i<arr.length; i++) {
            arr[i] = 2*arr[i];
        }
        return arr;
    }
}
```

ger utskriften: 

```cs 
2.8 10.6
2.8 10.6
```

a) Varför skrivs inte ``1.4 5.3`` ut på den övre raden som man kan förvänta sig?

b) Skriv om metoden ``float[] MultiplyByTwo(float[] arr)`` så att koden fungerar som tänkt, dvs. att den returnerar en float-array vars element är två gånger motsvarande element i ``arr`` utan att ändra på elementen i ``arr``.

### Övning da5jjf (2)

Följande funktion är tänkt att dubbla värdet för variabeln som ges som argument. Vad är fel i koden? Hur borde det se ut?

```cs
void Double(out int a) {
    a *= 2;
}
```

### Övning 65whcj (3)

Skriv en klassmetod ``int ParseBinary(string binaryString)`` som tar en sträng som representerar ett binärt tal och returnerar motsvarande heltalsvärde.

#### Exempel

Koden nedan: 

```cs
string b = "11001";
int value = ParseBinary(b);
Console.WriteLine(value);
```

ger utskriften:  

```text
25
```

### Övning 26t4fg (3)

Skriv en variadisk klassmetod med signatur ``string Join(string separator, params string[] strings)`` som konkatenerar alla argument efter ``separator`` med separerade med texten ``separator``.  

#### Exempel

Koden nedan:

```cs
Console.WriteLine(Join(" - ", "1", "2", "3", "4")); 
```

ger utskriften: 

```text
1 - 2 - 3 - 4
```

### Övning 2je3v8 (3)

Ett primtal är ett heltal större än 1 som endast är jämnt delbart med 1 och sig själv. Skriv en klassmetod med signatur ``bool IsPrime(int num)`` som svarar på frågan om ``num`` är ett primtal.

### Övning tx2axe (4)

Skriv en klassmetod som tar in som argument: 
- Ett tvådimensionellt fält med strängar (första index motsvarar rad, andra motsvarar kolumn).
- En kolumnbredd i antal tecken.
- Ett värde av en egendefinierad ``enum``-typ som anger justering (vänster, höger eller centrerat).

Metoden har också en ut-parameter av typen sträng. När strängen t.ex. skrivs ut i konsolen är resultatet en tabell med fältdatat formaterat enligt argumentens värden. 

Metoden returnerar också ett värde av typen ``bool`` som anger om tabellen kunde konstrueras enligt argumentens värden. Kravet för att tabellen skall kunna konstrueras är att med angiven kolumnbredd det alltid finns minst ett mellanslag mellan två intilliggande element. Om metoden returnerar ``false`` skall ut-parametern tilldelas värdet ``null``. 

Defaultvärdet på kolumnbredden skall vara 10 och defaultvärdet på justering skall vara vänster. 

### Övning qhj94e (5)

Skriv en klassmetod med signatur ``void SquigglyWrite(string text, int amplitude)`` som skriver ut text i mönstret av en sinusvåg som spänner över ``2 * amplitude + 1`` rader. Våglängden på sinusvågen skall vara 10 tecken.  

#### Hjälp på vägen

Indexet ``r`` i intervallet ``[0, 2 * amplitude]`` motsvarande raden där tecknet ``text[i]`` skall skrivas ut kan beräknas: 

```cs 
int r = amplitude + (int)Math.Round(amplitude*Math.Sin(i * ((2*Math.PI)/(double)wavelength)));
```

#### Exempel

Koden nedan: 

```cs 
SquigglyWrite("abcdefghijklmnopqrustuvwxyz", 1);
```

ger utskriften: 

```text
      ghij      qrst      
a    f    k    p    u    z
 bcde      lmno      vwxy 
```

