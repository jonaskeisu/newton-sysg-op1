# Inlämningsuppgift 1 - Minesweeper

## Översikt 

Uppgiften går ut på att skapa ett textbaserat minröj-spel i form av en konsol-applikation.

Spelet har en spelplan i form av ett rutnät med 10 x 10 positioner. Av dessa positioner är 10 slumpmässigt valda positioner minerade. Det är spelarens uppgift att röja alla ej minerade positioner utan att röja någon minerad position.

## Beskrivning av spelet

Inom programmering betyder *rendering* att skapa en grafisk representation av något. 

För denna uppgift renderas spelplanen som ett textblock för utskrift till konsolen. Textblocket består av en konstnant inramning samt rader av mellanslags-skiljda tecken som visar aktuell status för var och en av spelplanens positioner, se exemplet nedan. 

När spelet början är samtliga positioner varken röjda eller flaggade och renderas ```X```. 

När spelet startar renderas spelplanen följt av en tom rad och en prompt. Prompten består av ett större-än-tecken följt av ett mellanslag (``> ``) som indikerar att spelet är redo för inmatning av ett kommando från spelaren.

Första renderingen av spelplanen med efterföljande tomma rad och prompt ser ut så här:  

```
    A B C D E F G H I J
  +--------------------  
0 | X X X X X X X X X X
1 | X X X X X X X X X X
2 | X X X X X X X X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> 
```

### Positioner

En position på spelplanen kan refereras till med två tecken \<*K*\>\<*R*\> där *K* är en bokstav i intervallet A - J och *R* är en siffra i intervallet 0 - 9. Bokstaven anger postionens kolumn på spelplanen och siffran dess rad. Till exempel refererar ```A7``` positionen i första kolumnen och åttonde raden.

### Grannar

En given positions *grannar* är de tre till åtta angränsande postionererna på spelplanen. T.ex. har position ``B1`` åtta grannarna: ``A0``, ``B0``, ``C0``, ``A1``, ``C1``, ``A2``, ``B2`` och ``C2``. 

### Kommandon

Efter prompt kan spelaren mata in ett kommando som verkställs när när spelaren trycker på enter-tangenten. 

Syntaxen för ett kommando är en bokstav eller en bokstav följt av mellanslag och en position på spelplanen.

Exempel:

```
> f e7
```

```
> r g2
```

```
> q
```


#### Flaggning

Kommandot ```f <K><R>``` flaggar positionen ``<K><R>``. 

Endast en ej röjd position kan flaggas. 

En flaggad position renderas  ```F```. 

Maximalt 25 positioner kan vara flaggade samtidigt. 

Om spelaren flaggar en redan flaggad position tas flaggan bort.

Efter flaggning renderas spelplanen följt av en tom rad och prompt varpå spelaren kan ange ett nytt kommando.

#### Röjning

Kommandot ```r <K><R>``` röjer positionen ``<K><R>``. 

Endast en ej tidigare röjd position kan röjas. 

##### Röjning av ej minerad position

En röjd och ej minerad position som ej har en minerad granne benämns som en *nolla* och renderas som en punkt (``.``). 

En röjd och ej minerad position med minst en minerad granne renderas med en siffra i intervallet 1 - 8 motsvarande antalet minerade grannar.

Om spelaren röjer en nolla så avflaggas och röjs automatiskt även varje granne. För varje granne som är en nolla så avflaggas och röjs även grannens grannar, osv.

Efter röjningen renderas spelplanen på nytt följt av en tom rad. Om samtliga ej minerade positioner är röjda följer utskriften:

```
WELL DONE!
``` 

varpå applikationen avslutas med status ``0``. Annars följs den tomma raden av en prompt varpå spelaren kan ange ett nytt kommando.

##### Röjning av minerad position

Om spelaren röjer en minerad position så röjs spelplanens alla positioner automatiskt och spelplanen renderas en sista gång. 

Den aktuella positionen renderas ``M``. 

Övriga minerade postioner renderas ``ɯ`` om flaggad. Annars ``m``. 

Positioner som var flaggad men ej minerad position renderas ``Ⅎ``. 

Efter rendering av spelplanen följer en tom rad och utskriften: 

```
GAME OVER
``` 

varpå applikationen avslutas med status ``1``


#### Avslut

Kommandot ``q`` avslutar applikationen med status ``2``.

### Felmeddelanden

Ett felaktigt kommando resulterar i utskrift av ett felmeddelande, en tom rad och ny prompt. 

#### Syntex error

Om spelaren matat in ett kommando med felaktig syntax (dvs på fel form) skrivs följande rad ut: 

```
syntax error
``` 

En ogiltiga position som argument till kommandot räknas som felaktigt syntax.

#### Okänt kommando

Om spelaren matat in och verkställt ett kommando med korrekt syntax men som inte har en mening i spelet så skrivs följande rad ut: 

```
unknown command
``` 

#### Ej tillåtet kommando

Om spelaren matat in ett giltigt kommando som inte är tillåtet just nu enligt spelets regler så skrivs följande rad ut: 

```
not allowed
``` 

#### Exempel på felhantering

Om att ``A3`` redan är röjd så är följande exempel på felhantering:  

```
> r a3
not allowed

> f q6
syntax error

> m b7
unknown command
```

## Tekniska krav

Implementationen skall slumpa ut minorna med hjälp av ett bibliotek tillhandahållet av läraren. Biblioteket innehåller en statisk klass ``Helper`` i namespacet ``Minesweeper``.

Klassen ``Helper`` har två funktioner:

```
public static void Initialize(string[] args)
```

och

```
public static bool BoobyTrapped(int row, int column)
```

Innan funktionen ``BoobyTrapped`` anropas skall metoden ``Initialize`` anropas exakt en gång med konsol-applikationens ``Main``-funktions argument som argument.

Funktionen ```BoobyTrapped``` tar två heltal ``row`` och ``column`` som argument, båda i intervallet 0 - 9. Positien i rad *R* och kolumn *K* av spelplanen skall vara minerad om och endast om:

 ```
 Minesweeper.Helper.BoobyTrapped(R - 1, K - 1)
 ```

 returnerar ``true``.


## Exempelkörningar

Följande sidor visar exempel på exakt förväntad utskrift från programmet för olika körningar och kommandosekvenser för spelet:

- [Komplettering av spelet](exempelkörningar/game-completed.md)
- [Game over](exempelkörningar/game-over.md)
- [För många flaggor](exempelkörningar/too-many-flags.md)
- [Felhantering](exempelkörningar/error-handling.md)

Filer som användes för att skapa ovanstående sekver finns i följande [ziparkiv](./exempelkörningar/tests.zip). 
För den som vill omdirigera standard in för att skicka in användarinput till applikationen från fil så är det bra att veta att konsolen har en egenskap ``IsInputRedirected`` som är sann om och endast om input är omdirigerat från tangentbordsinmatning till terminalen till något annat. Genom att på lämpligt ställe i lösningen lägga in koden:

```cs
if (Console.IsInputRedirected)
{
    Console.WriteLine(input);
}
```

så kan input skrivas ut manuellt för att matcha förvantad utskrift från applikationen i ``out.txt``-filerna.

Två filer kan enkelt jämföras i terminalen för macOS/linux/git bash med hjälp av kommandot ``diff`` som har syntax:

```sh
diff <fil1> <fil2>
```

T.ex. kan filen ``my_output.txt`` i aktuell arbetskatalog jämföras med filen ``out.txt`` genom kommandot: 

```sh
$ diff my_output.txt out.txt
```
