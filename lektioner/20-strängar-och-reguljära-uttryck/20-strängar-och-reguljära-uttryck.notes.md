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

# Strängar och reglujära uttryck 

<!-- slide -->

## Strängar

- Objekt av typen ``string`` och klassen ``String`` har många metoder som underlättar arbetet med strängar.

<!-- slide -->

### ``ToUpper()`` och ``ToLower()``

Konvertering till bara små eller bara stora bokstäver:

```cs
string wiseSaying = "The Early Bird Gets The Worm";

wiseSaying.ToUpper(); // "THE EARLY BIRD GETS THE WORM
wiseSaying.ToLower(); // "the early bird gets the worm"
```

<!-- slide -->

### ``Contains(..)``

Kontrollera om en sträng innehåller en delsträngd:

```cs
string str = "The red fox jumped over the brown dog!";

str.Contains("fox"); // true
str.Contains("elephant"); // false
```

<!-- slide -->

### ``StartsWith(..)`` och ``EndsWith(..)``

Kontrollera om en sträng börjar eller slutar med en annan sträng: 

```cs
string str = "The red fox jumped over the brown dog!";

str.StartsWith("The red fox"); // true
str.StartsWith("The green fox"); // false
str.EndsWith("the brown dog!"); // true
str.EndsWith("the purple dog!"); // false
```

<!-- slide -->

### ``IndexOf(..)``

Hitta index av första förekomsten av delsträng:

```cs
string str = "The red fox jumped over the brown dog!";

str.IndexOf("fox"); // 4
str.IndexOf("dog"); // 28
str.IndexOf("elephant"); // -1
```

<!-- slide -->

### ``Trim()``

Ta bort blanka tecken i ytterkanterna:

```cs
string str = "   padded word   ";

str.Trim(); // "padded word"
```

<!-- slide -->

### ``Join(..)``

Sammanfoga strängar med skiljesträng:

```cs
string[] fruits = { "apple", "orange", "pear", "mellon"};

String.Join(" ", fruits); // "apple orange pear mellon"
String.Join(", ", fruits); // "apple, orange, pear, mellon"
```

<!-- slide -->

#### ``Split(..)``

Partitionera sträng med hjälp av skiljesträng:

```cs
string fruitMix = "apple, orange, pear, mellon";
string carPark = "volvo testla  skoda";

fruitMix.Split(','); 
// { "apple", " orange", " pear", " mellon" }
fruitMix.Split(',').Select(s => s.Trim()); 
// { "apple", "orange", "pear", "mellon" }
carPark.Split(' '); 
// { "volvo", "tesla", "", "skoda" }
carPark.Split(' ', StringSplitOptions.RemoveEmptyEntries); 
// { "volvo", "tesla", skoda" }
```

<!-- slide -->

### ``Substring(..)``

Skapa kopia av delsträng:

```cs
string str = "The red fox jumped over the brown dog!"; 
str.Substring(6, 7); // "red fox"
str.Substring(28, 9); // "brown dog"
```

<!-- slide -->

### ``Replace(..)``

Byt ut alla förekomster av en delsträng till något annat: 

```cs
string str7 = "Life is full of problems.";

str7.Replace("problems", "opportunities"); 
// "Life is full of opportunities."
```

<!-- slide -->

## Reguljära uttryck

- Reguljära uttryck är en syntax för att beskriva mönster i text
- Integrerat i alla populära programmeringsspråk
- *Det finns olika dialekter av reguljära uttryck med skillnader i syntax!*

<!-- slide -->

### Enkla mönster

Enklaste typen av mönster är en sekvens ett eller flera tecken:

```cs
string str1 = "The red fox jumped over the brown dog!";
string str2 = "The early bird gets the worm";

Regex re = new Regex(@"fox");
re.IsMatch(str1); // true
re.IsMatch(str2); // false
```

<!-- slide -->

### Teckenmängder

Hakparenteser (``[]``) används för att besriva ett mönster som matchar ett tecken i en mängd av tecken:

```cs
Regex re = new Regex(@"[Dd]og");

string str = "The dog is mans best friend";
string str2 = "Dogs and cats often fight";

re.IsMatch(str); // true
re.IsMatch(str2); // also true
```

<!-- slide -->

### Teckenspann

En teckenmängd kan innehålla spann av tecken:

```cs
Regex letter = new Regex(@"[a-z]");
Regex number = new Regex(@"[0-9]");

string noNumbers = "One, two, three";
string noLetters = "1 + 1 = 2";

letter.IsMatch(noNumbers); // true
letter.IsMatch(noLetters); // false

number.IsMatch(noNumbers); // false
number.IsMatch(noLetters); // true
```

<!-- slide -->

## Inverterade teckenmängder

Om första tecknet efter ``[`` är ``^`` så är teckenmängden inverterad:

```cs
Regex nonDigit = new Regex(@"[^0-9]");
Regex consonant = new Regex(@"[^aeiouyåäö ]");

nonDigit.IsMatch("846847643"); // false
nonDigit.IsMatch("1234a4321"); // true

var vovelCount = consonant.Matches("jonas keisu").Count; // 6 
```

<!-- slide -->

## Wildcard

Symbolen ``.`` är ett wildcard (joker) i reguljära uttryck och matchar vilket tecken som helst:

```cs

Regex re = new Regex(@"a.c");

re.IsMatch("a1c"); // true
re.IsMatch("ac"); // false
re.IsMatch("lätt som abc!"); // true
```

<!-- slide -->

### Valfritt mönster

Ett mönster följt av ``?`` kan förekomma noll eller en gång:

```cs
Regex zeroOrOneTime = new Regex(@"a?b");

zeroOrOneTime.IsMatch("b"); // true
zeroOrOneTime.IsMatch("ab"); // true
zeroOrOneTime.IsMatch("aab"); // false
zeroOrOneTime.IsMatch("aaab"); // false
```

<!-- slide -->

### Upprepade mönster 

Ett mönster följt av ``*`` kan förekomma noll eller fler gånger:

```cs
Regex zeroOrManyTimes = new Regex(@"a*b");

zeroOrManyTimes.IsMatch("b"); // true
zeroOrManyTimes.IsMatch("ab"); // true
zeroOrManyTimes.IsMatch("aab"); // true
zeroOrManyTimes.IsMatch("aaab"); // true
```

<!-- slide -->

Ett mönster följt av ``+`` kan förekomma en eller fler gånger:

```cs
Regex oneOrManyTimes = new Regex(@"a+b");

oneOrManyTimes.IsMatch("b"); // false
oneOrManyTimes.IsMatch("ab"); // true
oneOrManyTimes.IsMatch("aab"); // true
oneOrManyTimess.IsMatch("aaab"); // true
```

<!-- slide -->

Ett mönster följt av ``{j}`` måste förekomma exakt $j$ gånger: 

```cs
Regex exactNumberOfTimes = new Regex(@"a{2}b");

exactNumberOfTimes.IsMatch("b"); // false
exactNumberOfTimes.IsMatch("ab"); // false
exactNumberOfTimes.IsMatch("aab"); // true
exactNumberOfTimes.IsMatch("aaab"); // false
```

<!-- slide -->

Ett mönster följt av ``{j,}`` måste förekomma $j$ eller fler gånger: 

```cs
Regex atLeastNumberOfTimes = new Regex(@"a{2,}b");

atLeastNumberOfTimes.IsMatch("b"); // false
atLeastNumberOfTimes.IsMatch("ab"); // false
atLeastNumberOfTimes.IsMatch("aab"); // true
atLeastNumberOfTimes.IsMatch("aaab"); // true
```

<!-- slide -->

Ett mönster följt av ``{j,k}`` måste förekomma mellan $j$ och $k$ gånger: 

```cs
Regex rangeOfNumberOfTimes = new Regex(@"a{2,3}b");

rangeOfNumberOfTimes.IsMatch("b"); // false
rangeOfNumberOfTimes.IsMatch("ab"); // false
rangeOfNumberOfTimes.IsMatch("aab"); // true
rangeOfNumberOfTimes.IsMatch("aaab"); // true
rangeOfNumberOfTimes.IsMatch("aaaab"); // false
```

<!-- slide -->

### Ankare

Ett ``^`` matchar början på en sträng:

```cs
Regex startsWith = new Regex(@"^abc");

starsWith.IsMatch("abc 123 xyz"); // true 
starsWith.IsMatch("123 abc xyz"); // false
starsWith.IsMatch("123 xyz abc"); // false
```

<!-- slide -->

Ett ``$`` matchar slutet på en sträng:

```cs
Regex endsWith = new Regex(@"abc$");

endsWith.IsMatch("abc 123 xyz"); // false 
endsWith.IsMatch("123 abc xyz"); // false
endsWith.IsMatch("123 xyz abc"); // true
```

<!-- slide -->

### Gruppering

Mönster kan grupperas med parenteser:

```cs
Regex grouping = new Regex(@"^abc( abc)*$");

grouping.IsMatch("abc"); // true
grouping.IsMatch("abc abc abc abc"); // true
grouping.IsMatch("abc ab"); // false
```

<!-- slide -->

## Referens till gruppmatching

Mönstret ``\k`` matchar samma sträng som matchad av grupp nummer $k$: 

```cs
Regex groupMatchReference = new Regex(@"^(a.c).*\1*$");

groupMatchReference.IsMatch("abc def abc"); // true
groupMatchReference.IsMatch("a ca c"); // true
groupMatchReference.IsMatch("abc def a c"); // false
```
<!-- slide -->

### Eller-operatorn

Mönstret ``<a>|<b>`` matchar mönstret ``<a>`` eller mönstret ``<b>``: 

```cs
Regex colors = new Regex("red|green|blue");

colors.IsMatch("red button"); // true
colors.IsMatch("look at the blue sky"); // true
colors.IsMatch("purple haze"); // false
```

<!-- slide -->

### Teckenklasser

Mönstren ``\s``, ``\S``, ``\w``, ``\W``, ``\d``, ``\D``, m.fl. matchar klasser av tecken:

```cs
Regex whitespaceCharacter = new Regex(@"\s");
Regex notWhitespaceCharacter = new Regex(@"\S");
Regex wordCharacter = new Regex(@"\w");
Regex notWordCharacterChar = new Regex(@"\W");
Regex digitCharacter = new Regex(@"\d");
Regex notDigitCharacter = new Regex(@"\D");
```

<!-- slide -->
### Hämta ut text matchande specifika grupper

Ur en matchning av ett reguljärt uttryck kan texten matchande specifika grupper hämtas ut via gruppens index:

```cs
Regex validLine = new Regex(@"^(\d+) ""(\w+)"" (\d{4}-\d{2}-\d{2})$");
var line = "123 \"Jonas Keisu\" 1978-05-17";
if (validLine.IsMatch(line))
{
    var groups = validLine.Match("123 \"Jonas Keisu\" 1978-05-17").Groups;
    int id = int.Parse(groups[1].Value); // 123
    string name = groups[2].Value; // Jonas Keisu
    var bday = DateTime.Parse(groups[3].Value, new CultureInfo("se-SE"));
}
```
*OBS: Indexieringen av grupperna börjar på $1$, inte $0$.*

<!-- slide -->

### Look ahead

Mönstret ``(?=<a>)`` matchar noll tecken om mönstret ``<a>`` matchar strängen på aktuell position:

```cs
Regex re = new Regex(@"\w+(?=!)");

re.IsMatch("Hello"); // false
re.IsMatch("Hello!"); // true, men mönstret matchar bara "Hello"
```

<!-- slide -->

### Exempel - substitution

- Reguljära uttryck kan användas för substitution. 
- I ersättningsmönstret refererar mönstret ``$k`` till texten som matchade grupp $k$ i sökmönstret. 
- Följande kod byter ord inom citattecken till ord inom apostrofer: 
```cs
var line2 = "\"To be or not to be\", William Shakespear";
var newLine = Regex.Replace(line2, @"""([^""])*)""", @"'$1'");
// "'To be or not to be', William Shakespear"
```
*OBS: I råa strängar (med prefix ``@``) är escapesekvensen för tecknet ``"`` två citattecken (``""``) och inte ``\"``.*

<!-- slide -->

### Exempel - kontroll av lösenord

- En typisk lösenordskontroll är att lösenordet måste:
  - Vara mellan 8 och 20 tecken långt.
  - Innehålla minst en stor bokstav.
  - Innehålla minst en siffra. 

```cs
Regex validPassword = new Regex(@"(?=.*\d)(?=.*[A-Z]).{8,20}");
validPassword.IsMatch("password123"); // false
validPassword.IsMatch("Password!"); // false
validPassword.IsMatch("Pass123"); // false
validPassword.IsMatch("Password123"); // true
```

<!-- slide -->

### Mer information av reguljära uttryck

- [Snabbreferns till reguljära uttryck i C# .NET](https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference)
- [Interaktiv tutorial på nätet för att lära sig reguljära uttryck](https://regexone.com/)