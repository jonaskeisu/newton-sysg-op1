# Enumeratorer, fallanalys och bitfält
## Övningar

---

### Övning g3he36 (1)

Definiera lämpliga ``enum``-typer (med engelska namn på värdena) för: 

- Symbolerna i luffarshack.
- Ranken på spelkort (två, tre, ..., kung, äss).
- Pjäser i ett shackspel.
- Stjärntecken.

---

### Övning w83gdk (1)

Antag typdefinitionen: 

```cs
enum Enum {
    Value1 = -100
    Value2 
    Value3 = 100 
    Value4
}
```

Vad skriver följande program ut? 

```cs 
Enum[] enums = {
    Enum.Value1, Enum.Value2, 
    Enum.Value3, Enum.Value4
};

for (int i = 0; i < enums.Length; ++i)
{
    Console.WriteLine((int)enums[i]);
}  
```

---

### Övning n8nf59 (3-4)

Med två ``enum``-typer: 

```cs 
enum Suite 
{
    Hearts, 
    Diamonds, 
    Clubs,
    Spades
}
```

och: 

```cs
enum Rank 
{
    Two, 
    Three, 
    // o.s.v.
}
```

så kan en hand i poker representeras med två fält: 

```cs 
var ranks = new Rank[5];
var suits = new Suite[5];
```

Handen kan sorteras efter rank med följande implementation av *bubble sort*: 

```cs
for (int i = ranks.Length - 1; i > 0; --i) {
    for (int j = 0; j < i ; ++j) {
        if ((int)ranks[j] > (int)ranks[j+1]) {
            // Card j on the hand has higher rank than card j + 1
            // Therefore, swap card j with card j + 1
            var temp1 = ranks[j+1];
            var temp2 = suites[j+1];
            ranks[j+1] = ranks[j];
            suites[j+1] = suites[j];
            ranks[j] = temp1;
            suites[j] = temp2; 
        }
    }
    // Card i is now guaranteed to be in the right position
}
```

(Fundera gärna på hur oavanstående sorteringsalgoritm fungerar)

Skriv kod för att kontrollera om spelaren har: 

a) Färg. 

b) Ett par. 

c) Fyrtal.

d) Stege (antag att äss alltid har rank 14, inte 1).

---

### Övning pm23wy (2-3)

Antag följande variabler: 

```cs 
int a = 0b_1010_1010;
int b = 0b_0101_0101;
int x = 0x_FF_00; 
int y = 0x_00_FF;
```

Vad blir värdet på följande uttryck?

a) ``a | b``

b) ``a & b``

c) ``~a == b``

d) ``x >> 8``

e) ``(a >> 1) == b``

f) ``(b >> 1) == a``

g) ``(b << 1) == a``

h) ``a ^ b``

i) ``(x | y) ^ a) == ~a``

---

### Övning ystv87 (2)

Använd en ``for``-loop och bitvisa operatorer för att skriva ett program som räknar hur många ett or hur många nollor som ingår i den binära representation av ett ``int``-värde ``x``. 

---

### Övning k3af6v (2)

Antag variabeldefinitionen: 

```cs 
int x = ..; // något värde
```

Skriv kod som med en bitmask: 

a) Kontrollerar om bit 7 är satt i ``x``.

b) Kontrollerar om bit 7 och bit 14 är satt i ``x``. 

c) Sätter bit 31 i ``x``. 

d) Återställer bit 31 i ``x``.

e) Återställer bitarna bitarna 8-15 i ``x``. 

---

### Övning 62szxn (3)

Använd exklusivt-eller-operatorn för att skriva kod som som enbart inverterar värdena på bit 16-31 i värdet av ``x``. 

---

### Övning stu2ge (4)

Antag en variabel ``x`` av typen ``int``. Skriv kod som lagrar bitarna 0-7, 8-15, 16-23 respektive 24-31 i ``x`` som fyra  ``byte``-variabler med namn ``b0``, ``b1``, ``b2`` respektive ``b3``. 

---

### Övning 356hu2 (1)

Antag följande typdefinition: 

```cs 
enum Zodiac 
{
    Aries, 
    Taurus, 
    Gemini, 
    Cancer, 
    Leo, 
    Virgo, 
    Libra, 
    Scorpio, 
    Sagittarius,
    Capricorn,
    Aquarius,
    Pisces
}
```

a) Skriv om följande kod med hjälp av en ``switch``-sats: 

```cs
Zodiac starsign = ..;

string dateInterval = "";

if (starsign == Aries) {
    dateInterval = "Mar 20 - Apr 19";
} else if (starsign == Zodiac.Taurus) {
    dateInterval = "Apr 20 - May 20";
} else if (starsign == Zodiac.Gemini) {
    dateInterval = "May 21 - Jun 20";
} else if (starsign == Zodiac.Cancer) {
    dateInterval = "Jun 21 - Jul 22";
} else if (starsign == Zodiac.Leo) {
    dateInterval = "Jul 23 - Aug 22";
} else if (starsign == Zodiac.Virgo) {
    dateInterval = "Aug 23 - Sep 22";
} else if (starsign == Zodiac.Libra) {
    dateInterval = "Sep 23 - Oct 22";
} else if (starsign == Zodiac.Scorpio) {
    dateInterval = "Oct 23 - Nov 21";
} else if (starsign == Zodiac.Sagittarius) {
    dateInterval = "Nov 22 - Dec 21";
} else if (starsign == Zodiac.Capricorn) {
    dateInterval = "Dec 22 - Jan 19";
} else if (starsign == Zodiac.Aquarius) {
    dateInterval = "Jag 20 - Feb 17";
} else if (starsign == Zodiac.Pisces) {
    dateInterval = "Feb 18 - Mar 19";
}

Console.WriteLine($"You were born in the interval {dateInterval}");
```

b) Skriv om samma kod med hjälp av ett ``switch``-uttryck.

---

### Övning br9xvg (2)

En arbetsgivare måste betala arbetsgivaravgift till staten. Arbetsgivaravgiften är procentuell på bruttolönen för den anställde. Normal arbetsgivaravgift är 31,42% av bruttolönen. För personer över 65 år är arbetsgivaravgiften 10,21%. För ungdomar under 18 år är arbetsgivaravgiften också 10,21%, men bara om bruttolönen är maximalt 25 000 kr i månaden. Överstiger lönen 25 000 kr i månaden skall arbetsgivaren betala 31,42% i arbetsgivaravgift även för ungdom. 

a) Skriv en ``switch``-sats som gör fallanalys på både ålder och bruttomånadslön för en anställd och skriver ut beloppet för arbetsgivaravgiften. 

b) Gör om ``switch``-satsen till ett ``switch``-uttryck som beräknar beloppet på arbetsgivaravgiften från ålder och bruttomånadslön för en anställd. 


---

### Övning 


---

### Övning 


---

### Övning 


---

### Övning 


---

### Övning 


---

### Övning 


---