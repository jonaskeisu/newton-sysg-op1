# Fält och loopar
## Övningar

---

### Övning msj9nw (1)

Skriv en ``while``-loop med exakt samma funktion som följande ``for``-loop:

```cs
for (int i=0; i<10; i++) {
    Console.WriteLine(i);
}
```

### Övning k47qkb (1)

Skriv ett program som itererar över varannat element (inkl. första) i fältet ``a`` och skriver ut elementets värde på en och samma rad (använd metoden ``Console.Write`` istället för ``Console.WriteLine`` för att inte automatiskt lägga till ny rad efter varje utskrift):

```cs
char[] a = {'g', 'f', 'o', 'z', 'o', 'p', 'd', 'u', ' ', 'w', 'w', 'i', 'o', 'g', 'r', 'l', 'k'};
```

### Övning zgy2bd (1)

Skriv ett program som låter användaren skriva in ett ord som sedan skrivs ut baklänges.

#### Exempel
```text
Skriv in ett ord.
HelloWorld
dlroWolleH
```

### Övning w4pa4u (1)

Vad skriver följande kod ut? Varför? 

```cs
int[] x = { 1, 2, 3 };
int[] y = x; 
x[1] = 10;
y[1] = 20;
Console.WriteLine($"Talet är {x[1]}");
```

### Övning 


### Övning mab4rr (1)

I en konsolapplikations ``Main``-metod (där vi skrivit all kod hittills) är variabeln  ``string[] args`` definierad. Denna innehåller alla extraparametrar till applikationen vid körning från terminalen. Skriv ett program som tolkar extraparametrarna som ``double`` och skriver ut summan. 

#### Exempel 

```console
> dotnet run MyProject 1 2.5 -5
Summan är: -1.5
```

### Övning kt28H6 (1)

Skriv en ``for``-loop som ändrar värdet på varje element i en heltalsarray till dubbla värdet.

### Övning j4e7kb (1)

Skriv ett program som använder en ``do-while``-sats för att läsa in svaret på en ja/nej-fråga till dess svaret är ett giltigt alternativ. Efter att att giltigt svar lämnats av användaren skriver programmet ut ``OK``. 

#### Exempel

```text
Vill du avsluta programmet [ja/nej]?
nope
Ogiltigt svar.
Vill du avsluta programmet [ja/nej]?
no
Ogiltigt svar.
Vill du avsluta programmet [ja/nej]?
nej
OK
```

### Övning 4k7k6s (2)

Utan att implementera koden, lista ut vad följande program skriver ut.

```cs
int j = 0;
for (int i = 0; i+j < 10; i++) {
    j += i;
    System.out.println(i);
}
```

### Övning cf7mm5 (2)

Skriv en konsolapplikation där användaren matar in en siffra i taget, och som skriver ut "Störst hittills" om den nya siffran är större än alla tidigare inmatade siffror (under programmets aktuella körning).

#### Exempel

```console
10
Störst hittills
15 
Störst hittills
12
13
20
Störst hittills
```

### Övning ve9xuc (2)

Hur många iterationer går följande loopar genom innan de avlutas?

a)
```cs
for (int i = 0; i<=10; i++) {
    continue;
}
```

b)
```cs
int i = 0;
while (true) {
    if (i > 100) {
        break;
    }
    i++;
}
```

c) 
```cs
float x = 1;
do {
    x *= 2;
} while (x < 300);
```

d) 
```cs
for (int k=0; k<10; k++) {
    k -= 1;
}
```

### Övning 2zs9hr (2)

Vad skriver följande program ut? Varför?

```cs
string a[] = { "Karl", "Niclas", "Agnes" };
string b[] = a;
b[0] = "Fredrik";
Console.WriteLine(a[0]);
```

### Övning xw7quz (2)

Skriv ett program som läser in fem heltal från användaren och sparar dem som element i fältet ``a``. Skapa ett *nytt* fält ``b`` av samma längd som ``a`` och *kopiera* elementen från ``a`` till ``b`` med en ``for``-loop. Skriv till sist ut elementen i ``b``. Använd loopar även för inläsning och utskrift av tal. 

#### Exempel

```text
Skriv in fem tal.
5
1
4
7
3
Du skrev in talen:
5, 1, 4, 7, 3
```

### Övning 49g32x (2)

Gör om övning xw7quz men kopiera talen i omvänd ordning från ``a`` till ``b``.

#### Exempel

```text
Skriv in fem tal.
5
1
4
7
3
Du skrev in talen:
3, 7, 4, 1, 5
```

### Övning 9nk2ny (3)

Axel lägger in 50,000kr på ett räntegivande konto med 3% ränta per år, och rör inte kontot efter det. Efter hur många år har kapitalet på Axels konto överstigit 100,000kr? Skriv ett program som räknar ut svaret med hjälp av en loop. 

### Övning 973shf (3)
Skriv en konsolapplikation som anger vilka attraktioner på Liseberg man får åka på givet sin längd.
Användaren anger sin längd i konsolen. Därefter får användaren ett meddelande med vilka attraktioner som han/hon får åka.

|Attraktion|Minsta längd|
|----------|------------|
|kolorado|110cm|
|radiobilar| 120cm|
|flumeride| 120cm|
|lisebergståget| 130cm|
|balder | 140cm |
|sagoslottet|ingen gräns|

### Exempel 

```console
Vad är din längd?
135.4
kolorado, radiobilar, flumeride, sagoslottet
```

### Övning ne744y (3)

Skriv ett program som skriver ut de 100 första talen i Fibonaccis talföljd. 

Fibonaccis talföljd ges av att låta nästa tal vara summan av de två föregående talen, där de två första talen är 0 och 1. Alltså 0,1,1,2,3,5,8,13,21,....

**Kontroll:** Det 100:de talet är 218922995834555169026

### Övning w38qfr (4)

Skriv ett program som tolkar extraparametrar till applikationen som heltal och skriver ut en tom rad följt av ett histogram. Ta bara hänsyn till tal i intervallet [0, 9] i resultatet.

#### Exempel 

```text
> dotnet run 9 1 4 9 7 5 2 7 9 2 5 3 3 3 9

                #
    #           #
  # #       #   #
# # # # #   #   #
1 2 3 4 5 6 7 8 9
```


### Övning e8kwva (5)

Skriv luffarshack som konsolapplikation med användargränssnitt enligt exemplet nedan. Spelet avslutat automatiskt när någon av spelarna vunnit eller spelplanen är fylld utan att någon spelare vann med någon av utskrifterna: ``Ring vann!``, ``Kryss vann!`` eller ``Oavgjort``. 

#### Exempel

```text
  1 2 3
 =======
1| | | |
 =======
2| | | |
 =======
3| | | |
 =======

Ring?
13

  1 2 3
 =======
1| | |O|
 =======
2| | | |
 =======
3| | | |
 =======

Kryss?
22

  1 2 3
 =======
1| | |O|
 =======
2| |X| |
 =======
3| | | |
 =======

Ring?

...

Kryss?
33 

  1 2 3
 =======
1|X|O|O|
 =======
2| |X|O|
 =======
3| | |X|
 =======

Kryss vann!
```
