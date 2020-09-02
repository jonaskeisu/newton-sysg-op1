# Variabler, typer och operatorer
## Övningar

---

### Övning t732gc

Skriv ett program som läser in användarens namn och sedan skriver ut en personlig hälsning. 

#### Exempel

```text
Vad är ditt namn? 
Jonas
Hej Jonas!
```

### Övning 7cen9w

Vilket typ och vilket värde har följande uttryck? 

1. ``1 + 2 * 3 + 4``
2. ``(1 + 2) * (3 + 4)``
3. ``(1 + 2) * (3.0 + 4)``
4. ``2 * 2.5``
5. ``2 * (int)2.5``
6. ``17.0f + 13.0f``
7. ``13.0f + 17.0``
8. ``10 / 4.0``
9. ``10 / 4``
10. `` 10 % 4``
11. ``((byte) 100) * ((short) 5)``
12. ``1.0 / 2 * 4 / 2.0f``

### Övning 9gzh9g

Skriv ett program som läser in en text från användare och som skriver ut hur många tecken som ingår i strängen. 

#### Exempel

```text
Skriv text.
hej
Texten har 3 tecken.
```

### Övning r66ksx

Vilka av följande tilldelningar är korrekta? Om inte, varför?

1. ``double x = 15;``
2. ``int x = 15.0;``
3. ``int x = (int)15.0;``
4. ``double x = 15.0f;``
5. ``float x = 15.0;``
6. ``sbyte x = -128``
7. ``sbyte x = 128``
8. ``byte x = -1;``
9. ``short x = -19456;``
10. ``short x = 47874;``
11. ``ushort x = -19456;``
12. ``ushort x = 47874;``
13. ``int x = 5000000;``
14. ``long x = 5000000;``
15. ``uint x = -32768;``
16. ``long x = -32768;``
17. ``ulong x = -32768;``

### Övning 6p9bn2

Skriv ett program som läser in en text från användare och som skriver första och sista tecknet i texten. 

```text
Skriv text.
Hej på dig!
Första tecknet är: H
Sista tecknet är: !
```
### Övning rp6qj5

Skriv följande litteraler på icket-scientific format. 

1. ``1.234e5``
2. ``1.234e-3``

### Övning tf8k58

Vad är värdet av ``d`` i koden nedan?

```cs
int a = 0; 
int b = a--;
int c = ++b; 
int d = a + c; 
```

### Övning 9d8nz3

BMI (Body Mass Index) är ett mått på vikt i förhållande till längd. BMI räknas ut som vikt, i kg, genom läng, i meter, i kvadrag ([kg / m<sup>2</sup>]). Skriv ett program som frågar efter längd i cm och vikt i kg och sedan skriver ut personens BMI med två decimalers noggrannhet. Vad händer om det användaren skriver in inte kan tolkas som ett tal?

#### Exempel

```text
Skriv in din längd [cm].
178.5
Skriv in din vikt [kg].
78
Ditt BMI är: 24.48
```

### Övning av7gmy

Skriv ett program som läser in tre decimaltal och skriver ut talens summa, medel och varians med två decimalers noggrannhet. Variansen av tre tal x<sub>1</sub>, x<sub>2</sub> och x<sub>3</sub> är (x<sub>1</sub> - μ)<sup>2</sup> + (x<sub>2</sub> - μ)<sup>2</sup> + (x<sub>3</sub> - μ)<sup>2</sup> där μ är medel av de tre talen. 

### Exempel

```text
Skriv tre tal.
19.5
124
-17
Summan är 126.5
Medel är 42.17
Variansen är 10711.17
```

### Övning ruj3wt

Skriv ett program som tar ett antal personer och skriver: a) hur många bilar med plats för fem personer skulle krävas för att transportera personerna och b) hur många platser är lediga i bilarna. 

#### Exempel

```text
Hur många personer? 
13
Det krävs 3 bilar och 2 platser är lediga. 
```

### Övning gz5c8h

Vad skriver programmet nedan ut? 

```cs
Console.WriteLine("\"\\n\'\n\\\"");
```

Gissa först och skriv sedan ett program för att verifiera din gissning. 

### Övning 45tbeb

För en triangel i xy-planet med hörn, moturs, på postioner (x<sub>1</sub>, y<sub>1</sub>), (x<sub>2</sub>, y<sub>2</sub>) och (x<sub>3</sub>, y<sub>3</sub>) är (x<sub>2</sub> - x<sub>1</sub>) × (y<sub>3</sub> - y<sub>1</sub>) - (y<sub>2</sub> - y<sub>1</sub>) × (x<sub>3</sub> - x<sub>1</sub>) lika med två gånger arean. Skriv ett program som läser in x- och y-kordinaten för de tre hörnen av en triangel och sedan skriver ut arean av triangeln med tre decimalers noggrannhet. Vad händer om hörnen felaktigt anges medurs? 


#### Exempel

```text
Ange x1.
1.1
Ange y1.
1.3
Ange x2.
2.9
Ange y2.
2.2
Ange x3.
1.8
Ange y3.
3.6
Triangelns area är 1.755
```

### Övning etch2c (klurig)

Skriv ett program som läser in ett tal i intervallet [0, 255] och skriver ut hur många nollor och ettor den binära 8-bitars-representationen innehåller. _OBS: Använd endast det vi lärt oss i lektion 1-3._

### Exempel

```text
Skriv in ett tal mellan 0 och 255.
135
Antal nollor: 4
Antal ettor: 4
```






















