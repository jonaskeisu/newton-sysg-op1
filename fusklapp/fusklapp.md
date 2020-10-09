# Fusklapp C# .NET

## Binär kodning och grundäggande typer

### Arbetsminnet

Program lagrar information i datorn *arbetsminnet* som sekvenser av *bitar*. 

Ett annat ord för information är *data*. 

Arbetsminnet kallas ofta enbart för *minnet*.  

En *bit* är ett värde som bara kan vara ``0`` eller ``1``. 

En *byte* är ett fält med 8 bitar, t.ex. ``11010001``. 

Arbetsminnet består av fält av *bytes*. 

Längden av fältet anges av storleken på arbetsminnet. 

### Talbaser
 
Ett tal har basen $B$ om representationen av talet kan innehålla $B$ olika unika symboler tilldelade värden $0$, $1$, .., $B-2$, $B-1$. 

Decimala har basen $B = 10$ och kan innehålla symbolerna: 


#### Decimala tal

| Tecken | ``0`` | ``1``  | ``2`` | ``3`` | ``4`` | ``5`` | ``6`` | ``7``  | ``8`` | ``9``  |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |--- |
| Värde| $0$ | $1$ |$2$ | $3$ | $4$ | $5$ | $6$ | $7$ | $8$ | $9$ |

#### Binära tal

Binära tal har basen $B = 2$ och kan innehålla symbolerna: 

| Tecken | ``0`` | ``1``  | 
| --- | --- | --- | 
| Värde| $0$ | $1$ |

#### Hexadecimala tal

Hexadecimala tal har basen $B = 16$ och kan innehålla symbolerna: 

| Tecken | ``0`` | ``1``  | ``2`` | ``3`` | ``4`` | ``5`` | ``6`` | ``7``  | ``8`` | ``9``  | ``A`` | ``B`` | ``c``  | ``D`` | ``E``  | ``F``  |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Värde| $0$ | $1$ |$2$ | $3$ | $4$ | $5$ | $6$ | $7$ | $8$ | $9$ | $10$ | $11$ | $12$ | $13$ | $14$ | $15$ |

### Notation för tal i olika baser

Ett tal $x$ i talbasen skrivs $(x)_B$. T.ex. gäller att:

> $(FF)_{16} = (11111111)_{2} = (255)_{10}$

Skrivs ingen talbas ut för ett tal så är den normalt  $10$.

### Konvertering till talbas 10

Ett tal $(S_{N-1}S_{N-2}..S_1S_0)_B$ kan konverteras till basen 10 genom formeln:

> $S_{N-1} × B^2 + S_{N-1} × B^2 + .. + S_1 × B^1 + S_1 × B^0$

T.ex. kan värdet $(A0F6)_{16}$ konverteras till basen 10 på följande sätt:

> $(A)_{16} × 16^3 + (0)_{16} × 16^2 + (F)_{16} × 16^1 + (6)_{16} × 16^0 =$ <br/>
> $10 × 16^3 + 0 × 16^2 + 15 × 16^1 + 6 × 16^0 =$ <br/>
> $10 × 4096 + 0 × 255 + 15 × 16 + 6 × 1 =$ <br/>
> $41 206$

### Antal koder

Antalet unika koder som kan lagras i ett fält av längden $N$ där elementen väljs bland $B$ unika symboler är $B^N$. T.ex. med två unika symboler ``0`` och ``1`` så kan ett fält med längden $16$ representera $2^{16} = 65536$ binära koder.

### Grundläggande typer

Heltal som bara kan vara 0 eller positiva kallas *naturliga tal*. 

| Antal bytes | Beskrivning | Kodning | .NET-typ | Alias | Range | 
| --- | --- | --- | --- | --- | --- | 
| 1 | Naturliga tal | bas 2 | System.Byte | byte | 0 - 255 | 
| 1 | Heltal | två-komplement | System.SByte | sbyte | -128 - 127 | 
| 2 | Naturliga tal | bas 2 | System.UInt16 | ushort |  0 - 65&nbsp;536 | 
| 2 | Heltal | två-komplement | System.Int16 | short | -32&nbsp;768 - 32&nbsp;767 | 
| 4 | Naturliga tal | bas 2 | System.UInt32 | uint | 0 - 4&nbsp;294&nbsp;967&nbsp;296 | 
| 4 | Heltal | två-komplement | System.Int32 | int | -2&nbsp;147&nbsp;483&nbsp;648 - 2&nbsp;147&nbsp;483&nbsp;647
| 8 | Naturliga tal | bas 2 | System.UInt64 | ulong | 0 -  1,8 × 10<sup>19</sup> (ungefär) |  
| 8 | Heltal | två-komplement | System.Int64 | long | -9,2 × 10 <sup>18</sup> - 9,2 × 10<sup>18</sup> (ungefär) |
| 2 | Tecken | UTF-16 | System.Char | char |
|  | Sanningsvärde |  | System.Boolean | bool | 


Den binära representationen av ``bool``-värden är inte definierad av .NET-standarden och kan därför variera.

### Unicode 

Standard med målsättning att täcka alla viktiga tecken i hel världen, inklusive alla språks alfabeten, symboler, emoijis, etc. Delar upp tecken i totalt 17 plan med upp till 65536 tecken i varje plan. Alla bokstäver och andra vanligt förekommande tecken i text finns i plan plan 0. Emoijis ligger i plan 1. 

### Textkodning

| Kodning | Egenskaper | 
| --- | --- | 
| ASCII | 1 byte per tecken, 128 tecken, engelska tecken |
| ISO-8859-1 | 1 byte per tecken, 255 tecken, utökning av ASCII med tecken för språk med rötterna i Latin, t.ex. svenska. 
| UTF-8 | 1-4 byte per tecken, kodning av Unicode-tecken, samtliga ASCII-tecken representeras med 1 byte | 
| UTF-16 | 2 eller 4 byte per tecken, kodning av alla Unicode-tecken |
| UTF-32 | 4 byte per tecken, kodning av alla Unicode-tecken | 


### Char

Värden av typen ``char`` är ett tal i intervallet 0 - 65&nbsp; 536 som motsvarar ett tecken i [Unicode-plan 0](https://en.wikipedia.org/wiki/Plane_(Unicode)). 

#### Surrogatpar

Värden av typen ``char`` på binär har formen:

 > $11011x_{10}x_9x_8x_7x_6x_5x_4x_3x_2x_1x_0$

har saknar motsvarande tecken i Unicode-plan 0. 

Två UTF-16-värden på denna form i rad: 

> $110110x_9x_8x_7x_6x_5x_4x_3x_2x_1x_0$

följt av

> $110110y_9y_8y_7y_6y_5y_4y_3y_2y_1y_0$
formar ett *surrogatpar* som kodar tecknet:

> $(x_5x_4x_3x_2x_1x_0y_9y_8y_7y_6y_5y_4y_3y_2y_1y_0)_2$

i Unicode-plan nummer:

> $(x_9x_8x_7x_6)_2 + 1$ 

### String

En sträng är ett fält av element av typen ``char``. 

Om $x$ är antalet tecken i strängen från Unicode-plan 0 och $y$ är antalet övriga tecken så är längden på strängen: 
> $x  +  2y$

## Identifierare

Namn som definieras i koden kallas för *identifierare*. En identifierare är *synlig* i scopet där den definieras och i nästad scope.

## Variabler

En variabel är ett namngivet lagringsutrymme i namngivet för att lagra värden av en viss typ. 

## Scope

| Typ av scope | Kan innehålla |
| --- | --- |
| Kodblock | <ul><li>Lokala variabler</li><li>Lokala funktioner</li><li>Nästade kodblock</li><li>Parametrar</ul>
| Klass eller struktur | <ul><li>Variabler</li><li>Metoder</li><li>Egenskaper</li><li>Nästade typer</li><li>Indexierare</li><li>Event</li><li>Operatorer</li> | 
| ``namespace`` | <ul><li>Typdefinitioner</li><li>Nästade namespace</li></ul> | 


## Uttryck

Ett uttryck är ett komplett segment kod som kan beräknas till ett värde. Ett uttryck är inte fristående kod utan måste ingå i en sats.


### Litteraler

Litteraler är konkreta värden som beskrivs boktstavligen i koden, t.ex. ``0``, ``1``, ``3.14``, ``7e-10``, ``true``, ``false``, ``"abc"`` och ``'a'``. 

### Variabler

En synlig och åtkomlig variabel är ett uttryck som beräknas till värdet lagrat i variabeln minne. En variabel får endast användas efter att den blivit tilldelad. Tilldening av en variabel i samma sats som definierar variabeln kallas för *initalisering*. 

### Metodanrop

Ett anrop till en synlig och åtkomlig metod är ett uttryck som beräknas genom att anropets argument beräknas och tilldelas metodens parametrar varefter metodens kropp körs. Resultatet blir värdet av uttrycket som metoden returnerar. 

### Operatoruttryck

Operatorer beräknar värden från värdet av andra uttryck som kallas operatorns operander. Exempel på operatorer är: 

| Kategori | Exempel |
| --- | --- |
| Tilldelning | ``=``, ``+=``, ``-=``, ``*=``, ``/=``
| Aritmetisk | ``+``, ``-``, ``*``, ``/``, ``%``, ``++``, ``--`` |
| Jämförelse | ``<``, ``>``, ``<=``, ``>=``, ``==``, ``!=`` |
| Logiska | ``&&``, <code>&#124;&#124;</code>, ``!`` |
| Bitvisa | <code>&#124;</code>, ``&``, ``^``, ``~`` |
| Shift | ``<<``, ``>>`` | 


### Switch-uttryck

Beräkning av ett värde genom mönstermatchning mot ett argumentvärde. 

```cs
(<argument>) switch {
    <mönster> => <resultat>,
    <mönster> => <resultat>,
    ..
    _ => <resultat>
}
```

## Satser

Kod är en sekvens av *satser*. En sats är den minsta enheten av kod som kan köras självständigt. 

### Variabeldefinition

Deklarerar en ny variabel i aktuellt scope. 

```cs
<typ> <identifierare> = <initaliserare>;
``` 

### Blocksats

```cs
{
    <sats1>
    <sats2>
    ...
}
```

### If-else-sats

```cs
if (<villkor>) 
    <sats>  
else 
    <sats>
```

### Switch-sats

```cs
switch (<argument>) {
    case <mönster>: 
        <kod>
        break;
    case <mönster>
        <kod>
        break;
    ..
    default:
        <kod>;
        break;
}
```

### For-sats

```cs
for (<initalisering>; <villkor>; <stegning>)
    <sats>
```

### Foreach-sats

```cs
foreach (<variabel> in <IEnumerable>)
    <sats>
```

### While-sats

```cs 
while (<villkor>)
    <sats>
```

### Do-while-sats

```cs
do
    <sats>
while (<villkor>);
```

### Break

Hoppa ut kroopen på en loop- eller switch-sats.

```cs
break;
```

### Continue

Hoppa direkt till slutet på kroppen för en loop-sats.

```cs
continue;
```

### Return 

Avsluta ett anrop till en metod. Om returtypen för metoden inte är ``void`` skall nyckelordet ``return`` följas av ett uttryck ger som beräknas till metodens resultat.

```cs
return <resultat>;
```

### Uttryck som sats

Ett uttryck vars beräkning har sidoeffekt är följt av ett semikolon en giltig sats. 

```cs
<uttryck>;
```

## Uttrycksföreträde

Företrädesnivåer för operatorer från högsta till lägsta.

| Operator |
| --- | 
| ``f(x)``, ``x.y``, ``a[i]``, ``x++``, ``x--``, ``new`` |
| ``-x``, ``++x``, ``--x``, ``!x``, ``^x``, ``~x`` |
| ``switch`` | 
| ``x * y``, ``x / y``, ``x % y`` | 
| ``x + y``, ``x - y`` | 
| ``x << y``, ``x >> y`` |
| ``x <= y``, ``x < y``, ``x => y``, ``x > y``, ``as``, ``is`` |
| ``x == y``, ``x != y`` |
| ``x & y`` | 
| ``x ^ y`` | 
| <code>x &#124; y</code> |
| ``x && y`` | 
| <code>x &#124;&#124; y</code> |
| ``c ? t : f`` | 
| ``=``, ``+=``, ``-=``, ``*=``, ``/=``, ``x %= y``, ``x &= y``,<code>x &#124;= y</code>, ``x <<= y``, ``x >>= y`` |

## Värdetyper vs. referenstyper

Variabler är namngivet lagringsuttrymme i minnet för att lagra värden av en viss typ. För värdetyper är värdet som lagras i variabelns minne ett *objekt*. Ett objekt lagras i minnet som de aktuella värdena på objektets alla *medlemsvariabler*. För referenstyper är värdet som lagras i variabelns minne en *referens* till ett objekt som skapats med nyckelordet ``new`` och lagras i en minnesarea som kallas *heapen*.  

```plantuml
node " "Jonas", 42" as person
note left
    Värdetyp
end note

node "<referens>" as ref
note left 
    Referenstyp
end note

cloud Heap {
    node " "Tesla", "ABC123" " as car
}

ref --> car
```


### Värdetyper

Alla taltyper, ``bool``, ``char``, ``enum`` och typer skapade med nyckelordet ``struct`` är värdetyper. För en variabel av värdetyp så så skapas objektet i variabelns minne automatiskt när programmets körningen går in i kodblocket där variabeln är definierad. Objektet lagrat i variabelns minne kasseras automatiskt när programmets körning lämnar kodblocket där variabeln är definierad.

### Referenstyper

Alla fälttyper, ``string`` och alla typer skapade med nyckelordet ``class`` är referenstyper. En variabel av referenstyp lagrar en referens till ett objekt på heapen eller ``null`` i sitt minne. När programmets körning går in i kodblocket där variabeln är definierad skapas automatiskt variabelns minnesutrymme. Referens lagrad i variabelns minne kasseras automatisk när programmets körning lämnar kodblocket där variabeln är definierad. När det inte längre finns några kopior av referensen till ett objekt på heapen så kasseras objektet automatiskt av garbage collectorn. 


### Kopiering av värden

När ett värde av referenstyp kopieras skapas en ny kopia av en referens. När ett värde av värdetyp kopieras tilldelas varje medlemsvariabel för ett annat objekt av samma typ det aktuella värdet för motsvarande medlemsvariabel hos originalobjektets.

```plantuml
node " "Jonas", 42" as person1
note left 
    Original
end note

node " "Jonas", 42" as person2
note left 
    Kopia
end note

person1 ..> person2: Kopiering

node "<referens>" as ref1
note left 
    Original
end note
node "<referens>" as ref2
note right 
    Kopia
end note

ref1 ..> ref2: Kopiering

cloud Heap {
    node " "Tesla", "ABC123" " as car
}

ref1 --> car
ref2 --> car
```


Värden kopieras t.ex. när ett värde:
- Tilldelas av en variabel, egenskap eller indexierare.
- Returnerneras från en metod.
- Används som argument till en metod.
- Används som operand till en operator.

## Defaultvärden

Ett oiniterat värden har defaultvärde enligt typ. 

| Typ | Defaultvärde
| --- | --- | 
| Alla taltyper | $0$ | 
| ``enum`` | $0$ | 
| ``char`` | ``'\0'`` | 
| ``bool`` | ``false`` | 
| Fält | ``null`` | 
| ``class`` | ``null`` | 
| ``struct`` | Medlemsvariabler har defaultvärde. |

## Fält

Exempel på definition och initierare av fält:
```cs 
int[] numbers = { 1, 2, 3 }; // Endimensionellt fält
string[,] texts = { // Tvådimensionellt fält
    { "anna", "karl" }, 
    { "jimmy", "daniel" }, 
    { "fredrik", "veronica" }
};
```

För fälten ovan är nedanstående villkor uppfyllda: 

```cs
numbers[0] == 1
numbers[2] == 3
texts[2, 1] == "veronica"
numbers.Rank == 1
numbers.Length == 3
texts.Rank == 2
texts.GetLength(0) == 3
texts.GetLength(1) == 2
```

Skapa nya fält:

```cs 
new string[10]; // nytt fält av 10 strängreferenser
new bool[5, 2]; // nytt fält med 5 rader och 2 kolumner av boolvärden
```

Element för nya fält utan initiering har defaultvärde.
