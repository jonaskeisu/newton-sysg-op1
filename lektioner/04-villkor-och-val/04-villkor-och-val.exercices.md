# Villkor och val
## Övningar

---

### Övning 29t8vm

Hitta tre fel i koden nedan.

```cs 
int a = 1;
{
    b = 2;
    int b;
    {
        int c = 3;
    }
    c = 5;
}
a = b;
```

### Övning a2gzch

Skriv ett program som tar in en sträng som är fyra tecken lång och testar om strängen är identisk framlänges och baklänges, dvs ett palindrom. 

#### Exempel

```
Skriv in en text med fyra tecken. 
anna
Texten är ett palindrom. 
```

```
Skriv in en text med fyra tecken. 
knut
Texten är inte ett palindrom. 
```

### Övning k6w73c

Skriv ett program som läser in ett heltal och testar om talet är udda eller jämnt. 

#### Exempel 

```
Skriv in heltal.
101
Talet 101 är udda. 
```

```
Skriv in heltal.
44
Talet 44 är jämnt. 
```

### Övning gmr9yz (lite lurig)

Skriv ett program som läser in tre heltal och skriver ut dem sorterade. 

#### Exempel 

```
Skriv in tre heltal.
16
-8
9
Talen i sorterad ordning: 
-8
9
16
```

### Övning 5urrww

En magisk fyrkant av storlek 3 x 3 är ett rutnät av talen [1, 9] där summan av talen i varje rad, varje column och varje diagonal är lika. Skriv ett program som läser in ett rutnät av tal och testar om rutnätet är en magisk fyrkant. 

#### Exempel 

```
Skriv talen. 
2 7 6
9 5 1
8 3 4
Inte en magisk fyrkant.
```

```
Skriv talen. 
2 7 6
9 5 1
4 3 8
Magisk fyrkant!
```

### Övning ra9naz

Varför fungerar är de två kodexemplen nedan inte korrekt kod?

```cs
int a; 
.. // kod som tilldelar a ett värde
if (! a >= 0 && a <= 10) {
    Console.WriteLine("a måste ligga i intervallet [0, 10]");
}
```

```cs
int b; 
.. // kod som tilldelar b ett värde
if (0 <= b <= 10) {
    Console.WriteLine("b måste ligga i intervallet [0, 10]");
}
```

### Övning 35zg2t

Skriv ett program som tar in ett födelsedatum och skriver ut vilket stjärntecken personen är född i. 

#### Exempel

```
Vilken månad är du född i?
maj
Vilken dag i maj är du född på?
17
Du är en oxe.
```

### Övning 2sma5q

Vad är värdet på ``b`` respektive ``x`` efter körning var och ett av de fyra kodexemplen nedan?

```cs
int x = 0;
int a = 10; 
bool b = a > 10 && ++x == 100;
```

```cs
int x = 0;
int a = 10; 
bool b = a <= 10 && ++x == 100;
```


```cs
int x = 0;
int a = 10; 
bool b = a != 9 && ++x > 0;
```

```cs
int x = 0;
int a = 10; 
bool b = a == 9 && ++x > 0;
```











