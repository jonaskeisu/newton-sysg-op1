# Fält och loopar
## Övningar

---

### Övning j4e7kb

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

### Övning 2zs9hr

Vad skriver följande program ut? Varför?

```cs
int a[] = { "Karl", "Niclas", "Agnes" };
int b[] = a;
b[0] = "Fredrik";
Console.WriteLine(a[0]);
```

### Övning xw7quz

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
5
1
4
7
3
```

### Övning 49g32x

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
3
7
4
1
5
```
