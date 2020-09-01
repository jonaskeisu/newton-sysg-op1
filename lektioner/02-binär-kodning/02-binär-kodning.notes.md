---
marp: true
theme: default
footer: © 2020 BIT ADDICT
style: | 
  section {
      @extend .markdown-body;
      display: block;
      flex-direction: column;
      font-size: 32px
  }

  @import '../css/lecture_slides.css'

---

<div class="title-page">

# Binär kodning

</div>

---

## Sekvenser och fält

- En ***sekvens*** är en ordnad följd av ***element***. 
  - T.ex. är S = 1, 0, 0, 1, 1, 1, 0 en sekvens av ettor och nollor.
- Ett elements position i en sekvens kallas för elementets *index*. 
  - Index kan börja på vilket heltal som helst, ofta 0 eller 1.
- Element i en sekvens betecknas ofta med så kallad *indexnotation*. 
  - T.ex. kan vi beteckna elementen i sekvensen ovan S<sub>0</sub>, S<sub>1</sub>, .., S<sub>6</sub>
- En sekvens ***längd*** är antalet element i sekvensen. 
- Ett ***fält*** är en sekvens med en bestämd och konstant längd.   

---

<div class="title-page">

# Datorns programmeringsgränssnitt

</div>

---

## Datorns centrala komponenter 

<table 
      class="abscenter" 
      style="
        text-align: center; 
        margin: 0; 
        width: auto;">
  <tr>
    <td>Program 1
    <td>Program 2
    <td>Program 3
  </tr>
  <tr>
    <td bgcolor="aliceblue" colspan="3">Operativsystem
  </tr>
  <tr>
    <td >Arbetsminne
    <td >Processor
    <td >I/O-enheter
  </tr>
</table>

---

## Minne 

- Datorer lagrar information (*data*) i ***minne***
- Minne är sekvens av bytes 
- Index för en byte i minnet kallas för ***adress***
- Adressen för första byten i minnet är *0*

---

## Bit

- Datorer lagrar information som ettor och nollor
- Ett värde som är vara antingen ``0`` eller ``1`` kallas för ***bit***

---

## Byte

- En ***byte*** är en fält av åtta bitar. 

### Exempel

``00101001``

---

## Arbetsminne

- Datorn lagrar information den arbetar med för tillfället i ***arbetsminnet***
- Datorn kan läsa/skriva direkt till vilken adress som helst i arbetsminnet
- Arbetsminnet kallas därför på eng. ***Random Access Memory*** (***RAM***)
- När strömmen till datorn bryts går all information i arbetsminnet förlorad

---

## Enheter för storlek på datorminne

<div class="abscenter">

1 ***KB*** = 1024 byte
1 ***MB*** = 1024 KB =  1 048 576 byte
1 ***GB*** = 1024 MB = 1 073 741 824 byte
</div>

---

### Exempel

<div style="display: flex; width: 1080px; flex-direction: column; align-items: center">
32 GB RAM

<table style="display: inline; width: auto">
    <tr><th>Adress</th><th>Data</th></tr>
    <tr><td>0</td><td><code>10100111</code></td></tr>
    <tr><td>1</td><td><code>01111101</code></td></tr>
    <tr><td>2</td><td><code>10100111</code></td></tr>
    <tr><td>..</td><td>..</td></tr>
    <tr><td>34 359 720 773</td><td><code>10010010</code></td></tr>
    <tr><td>34 359 720 774</td><td><code>01011111</code></td></tr>
</table>
</div>

---

## Vad betyder datat i arbetsminnet?

Det skall vi titta på i detalj senare under i denna lektion.

---

## Processorn

- ***Processorn*** utför programets instruktioner
- Instruktionerna utför operationer på små mängder data i arbetsminnet

---

## Olika typer av instruktioner

En instruktion kan exempelvis vara:
  - Läsa data från eller skriv data till adress i arbetsminne
  - ***Aritmeteisk*** (*addition*, *subtraktion*, *multiplikation*,  ..)
  - ***Jämförelser*** (*större än*, *mindre än*,  ..)
  - ***Logisk*** (dra enkla slutsatser från påståenden)
  - ***Bitwise*** (bitmönster-manipulation)

---

## I/O-enheter

- Förkortningen ***I/O*** står för *Input/Output* 
- ***Input*** är när ett program tar emot data från omvärlden
- ***Output*** är när ett program skickar ut data till omvärlden
- En ***I/O-enhet*** är en sändare och/eller en mottagare av data

---

### Exempel

  - Hårddisk
  - Mus / tangentbord
  - Ljudkort / mikrofon
  - Grafikkort / kamera
  - Wifi / Bluetooth / USB

---

# Operativsystemet

- ***Operativsystemet (OS)*** är ett lager mellan program och hårdvara
- Har uppgifter som att:
  - Administrera program/resurser
  - Förenkla resurstillgång
  - Skyddar systemet

---

### Exempel

- Windows 10 
- macOS
- Linux
- Android
- iOS

---

<div class="title-page">

# Talrepresentation 

</div>

---

## Heltalsintervall

Ett intervall av heltal kan betecknas: [*start*, *slut*]


### Exempel

[1, 5] är heltalen 1, 2, 3, 4, 5
[-10, 10] är alla heltal -10, -9, -8, .., -1, 0, 1, .. 9, 10.

---

## Potenser

- Talet *X* upphöjt till *Y* betyder *X* multiplicerat med sig själv *Y* gånger.
- Talet *X* upphöjt till *Y* betecknas *X*<sup>*Y*</sup>.
  - T.ex. 3<sup>4</sup> = 3 x 3 x 3 x 3 = 81 och 2<sup>3</sup> = 2 x 2 x 2 = 8
- Ett tal gånger sig själv 0 gånger är alltid 1, så för alla *X* gäller att *X*<sup>0</sup> = 1. 
  - Tex. 10<sup>0</sup> = 1, 2<sup>0</sup> = 1, 16<sup>0</sup> = 1, osv
- Om *Y* är negativt är *X*<sup>*Y*</sup> samma som 1 genom *X* upphöjt till beloppet av *Y*.
  - T.ex. 2<sup>-3</sup> = 1 / 2<sup>3</sup> = 1 / 8 = 0.125 och 10<sup>-2</sup> = 1 / 10<sup>2</sup> = 1 / 100 = 0.01

---

## Talrepresentation

- Tal representeras med sekvenser av symboler som ibland kallas *siffror*.
- Elementen i sekvensen skrivs från höger till vänster. 


<center>
<table style="display:inline">
    <tr>
        <th colspan="6">Kolumner</th>
    </tr>
    <tr>
        <th>K</th><th>K - 1</th><td> ... </td><th>2</th><th>1</th><th>0</th>
    </tr>
    <tr>
        <td>S<sub>K</sub></td>
        <td>S<sub>K - 1</sub></td>
        <td>...</td>
        <td>S<sub>2</sub></td>
        <td>S<sub>1</sub></td>
        <td>S<sub>0</sub></td>
    </tr>
</table>
</center>

### Exempel

*517* är ett tal med S<sub>0</sub> = 7, S<sub>1</sub> = 1 och S<sub>2</sub> = 5.

--- 

## Talbas

- En talrepresentation med ***talbas*** *N* har *N* unika symboler.
- Symbolerna tilldelas värden 0, 1, 2, ..., *N* - 1 

---

### Exempel 

En talrepresentation med talbas 3 kan ha symboler: 

<table style="zoom: .8; width: auto; margin-left: 1em">
    <tr><th>Symbol</th><th>Värde</hd></tr>
    <tr><td><code>A</code></td><td>0</td></tr>
    <tr><td><code>B</code></td><td>1</td></tr>
    <tr><td><code>C</code></td><td>2</td></tr>
</table>

Med denna representation är:

 ```text
 BAC
 ``` 

 ett tal med S<sub>0</sub> = ``C``, S<sub>1</sub> = A och S<sub>2</sub> = ``B``.

---

## Rotation av symboler

- *S*<sub>0</sub> kan representera tal från 0 till *N* - 1.
- När en symbol når N *roterar* den och börjar om från 0 igen. 
- En rotation av symbol *S*<sub>K</sub> läggs i minnet genom att öka *S*<sub>K - 1</sub> med 1.

---

### Exempel

Vi räknar från 0 till 31 med vår nya talbas 3:

<div style="display:flex">

<code>
AAAA (0)<br/>
AAAB (1)<br/>
AAAC (2)<br/>
AABA (3)<br/>
AABB (4)<br/>
AABC (5)<br/>
AACA (6)<br/>
AACB (7)
</code>

<code style="margin-left:0.5em">
AACC (8)<br/>
ABAA (9)<br/>
ABAB (10)<br/>
ABAC (11)<br/>
ABBA (12)<br/>
ABBB (13)<br/>
ABBC (14)<br/>
ABCA (15)
</code>

<code style="margin-left:0.5em">
ABCB (16)<br/>
ABCC (17)<br/>
ACAA (18)<br/>
ACAB (19)<br/>
ACAC (20)<br/>
ACBA (21)<br/>
ACBB (22)<br/>
ACBC (23)
</code>

<code style="margin-left:0.5em">
ACCA (24)<br/>
ACCB (25)<br/>
ACCC (26)<br/>
BAAA (27)<br/>
BAAB (28)<br/>
BAAC (29)<br/>
BABA (30)<br/>
BABB (31)
</code>

</div>

Notera att *S*<sub>0</sub> roterar för mutliplar av N = N<sup>1</sup> (3, 6, 9, 12 och 15) samt att *S*<sub>1</sub> roterar för mutiplar av N x N = N<sup>2</sup> (9, 18 och 27).

---

## Symbolernas värde

I talet:

<center>
<table style="display:inline">
    <tr>
        <th>K</th><th>K - 1</th><td> ... </td><th>2</th><th>1</th><th>0</th>
    </tr>
    <tr>
        <td>S<sub>K</sub></td>
        <td>S<sub>K - 1</sub></td>
        <td>...</td>
        <td>S<sub>2</sub></td>
        <td>S<sub>1</sub></td>
        <td>S<sub>0</sub></td>
    </tr>
</table>
</center>

så har:

- S<sub>0</sub> värdet av S<sub>0</sub>.
- S<sub>1</sub> värdet av S<sub>1</sub> x *N* eftersom S<sub>1</sub> ökar med 1 varje gång S<sub>0</sub> når *N*.
- S<sub>2</sub> värdet av S<sub>2</sub> x *N* x *N* eftersom den ökar med 1 varje gång S<sub>1</sub> når *N*. 
- Allmänt S<sub>K</sub> värdet av S<sub>K</sub> x *N*<sup>K</sup>

---

## Talets totala värde

Det totala värdet av:

<center>
<table style="display:inline">
    <tr>
        <th>K</th><th>K - 1</th><td> ... </td><th>2</th><th>1</th><th>0</th>
    </tr>
    <tr>
        <td>S<sub>K</sub></td>
        <td>S<sub>K - 1</sub></td>
        <td>...</td>
        <td>S<sub>2</sub></td>
        <td>S<sub>1</sub></td>
        <td>S<sub>0</sub></td>
    </tr>
</table>
</center>

är summan av symbolernas värden:

<center>

S<sub>K</sub> x *N* <sup>K</sup> + S<sub>K - 1</sub> x *N* <sup>K - 1</sup> + .. + S<sub>2</sub> x *N* <sup>2</sup> + S<sub>1</sub> x *N* <sup>1</sup> + S<sub>0</sub> x *N* <sup>0</sup>
</center>

---

### Exempel

I talet ``CAB`` gäller att: 
- S<sub>2</sub> har värdet ``C`` x 3<sup>2</sup> = 2 x 9 = 18
- S<sub>1</sub> har värdet ``A`` x 3<sup>1</sup> = 0 x 3 = 0
- S<sub>0</sub> har värdet ``B`` x 3<sup>0</sup> = 1 x 1 = 1

Alltså är det totala värdet av ``CAB`` lika med: 

<center>

``C`` x 3<sup>2</sup> + ``A`` x 3<sup>1</sup> + ``B`` x 3<sup>0</sup> = 2 x 3<sup>2</sup> + 0 x 3<sup>1</sup> + 1 x 3<sup>0</sup> = <u>19</u> 
</center>

---

## Hur många värden kan representeras?

  Ett tal med bas *N* som har maximal längd *K* symboler kan representera N<sup>K</sup> olika värden. 

---

### Exempel

Ett tal med bas 10 med 3 siffror kan representera 10<sup>3</sup> = 1000 olika värden. Dessa värden är 0, 1, 2, .., 998, 999.

Ett tal med bas 2 (binärt) med 8 siffror (*bitar*) kan representera 2<sup>8</sup> = 256 olika värden.

Ett tal med bas 16 (hexadecimalt) med 4 siffror kan representera 16<sup>4</sup> = 65 536 olika värden.

---

<div class="title-page">

# Viktiga talrepresentationer 

</div>

--- 

## Decimaltal (bas 10)

- Vanliga talrepresentationen vi lär oss i grundskolan.
- Tal består av sekvenser av symbolerna 0, 1, 2, 3, 4, 5, 6, 7, 8 och 9.

---

## Binära tal (bas 2)

- Tal med bas 2 kallas ***binära tal***. 
- Tal består av sekvenser av 0 och 1. 
- En symbol som bara kan vara 0 eller 1 kallas för en ***bit***.
- Datorer lagrar all information som binära tal. 

---

### Exempel

Följande sekvens är ett 8-bitars binärt tal:

```text
10011101
```

Värdet av talet är:

1 x 2<sup>7</sup> + 0 x 2<sup>6</sup> + 0 x 2<sup>5</sup> + 1 x 2<sup>4</sup>  + 1 x 2<sup>3</sup>  + 1 x 2<sup>2</sup>  + 0 x 2<sup>1</sup> + 1 x 2<sup>0</sup> = <br/>
1 x 128 + 0 x 64 + 0 x 32 + 1 x 16 + 1 x 8 + 1 x 4 + 0 x 2 + 1 x 1 = <br/>
<u>156</u>

---

 ## Hexadecimala tal (bas 16)

 - Inom programmering används ofta hexadecimala tal.

<div style="display: flex; flex-direction: column; align-items: center">
<div style="display: flex">
<center>
<table style="display: inline; zoom: 0.8;">
    <tr><th>Symbol</th><th>Värde</th></tr>
    <tr><td>0</td><td>0</td></tr>
    <tr><td>1</td><td>1</td></tr>
    <tr><td>2</td><td>2</td></tr>
    <tr><td>3</td><td>3</td></tr>
    <tr><td>4</td><td>4</td></tr>
    <tr><td>5</td><td>5</td></tr>
    <tr><td>6</td><td>6</td></tr>
    <tr><td>7</td><td>7</td></tr>
</table>
</center>

<center style="margin-left: 1em">
<table style="display: inline; zoom: 0.8;">
    <tr><th>Symbol</th><th>Värde</th></tr>
    <tr><td>8</td><td>8</td></tr>
    <tr><td>9</td><td>9</td></tr>
    <tr><td>A</td><td>10</td></tr>
    <tr><td>B</td><td>11</td></tr>
    <tr><td>C</td><td>12</td></tr>
    <tr><td>D</td><td>13</td></tr>
    <tr><td>E</td><td>14</td></tr>
    <tr><td>F</td><td>15</td></tr>
</table>
</center>
</div>
</div>

--- 

### Exempel

Följande är ett hexadecimalt tal med fyra tecken:

```text
A1F7
```

med värdet:

``A`` x 16<sup>3</sup> + ``1`` x  16<sup>2</sup> + ``F`` x 16 <sup>1</sup> + ``7`` x 16 <sup>0</sup> = <br/>
10 x 16<sup>3</sup> + 1 x  16<sup>2</sup> + 15 x 16<sup>1</sup> + 7 x 16<sup>0</sup> = <br/> 
10 x 4096 + 1 x 256 + 15 x 16 + 7 x 1 = <u>41 463</u>

--- 

## Konvertering mellan binärt och hexadecimalt

En bitsekvens med med längd som är en multipel av 4 kan enkelt översättas till hexadecimal form.

---

### Översättningstabell mellan binärt och hexadecimalt

<div style="display: flex; flex-direction: column; align-items: center">
<div style="display: flex">
<center>
<table style="display: inline; zoom: 0.9;">
    <tr><th>Symbol</th><th>Värde</th></tr>
    <tr><td>0</td><td>0000</td></tr>
    <tr><td>1</td><td>0001</td></tr>
    <tr><td>2</td><td>0010</td></tr>
    <tr><td>3</td><td>0011</td></tr>
    <tr><td>4</td><td>0100</td></tr>
    <tr><td>5</td><td>0101</td></tr>
    <tr><td>6</td><td>0110</td></tr>
    <tr><td>7</td><td>0111</td></tr>
</table>
</center>

<center style="margin-left: 1em">
<table style="display: inline; zoom: 0.9;">
    <tr><th>Symbol</th><th>Värde</th></tr>
    <tr><td>8</td><td>1000</td></tr>
    <tr><td>9</td><td>1001</td></tr>
    <tr><td>A</td><td>1010</td></tr>
    <tr><td>B</td><td>1011</td></tr>
    <tr><td>C</td><td>1100</td></tr>
    <tr><td>D</td><td>1101</td></tr>
    <tr><td>E</td><td>1110</td></tr>
    <tr><td>F</td><td>1111</td></tr>
</table>
</center>
</div>
</div>

---

### Exempel

Den binära sekvensen:

```text
10111011 00011100 00011101 01011000 
11101000 11011000 11001011 10001011 
10000101 11100011
```

blir på hexadecimal form: 

```text
BB 1C 1D 58 E8 D8 CB 8B 85 E3
```

---

### Exempel

Tabellen nedan listar några primitiva heltalstyper i C#.
<br/>

<center>
<table style="display:inline;">
    <tr><th>Datatyp</th><th>Beskrivning</th></tr>
    <tr><td><code>byte</code></td><td>8 bitars heltal</td></tr>
    <tr><td><code>ushort</code></td><td>16 bitars heltal</td></tr>
    <tr><td><code>uint</code></td><td>32 bitars heltal</td></tr>
    <tr><td><code>ulong</code></td><td>64 bitars heltal</td></tr>
</table>
</center>

---

## Kodning

- Översättnng av en symbolisk representation till en annan kallas ***kodning***. 
- Resultatet av kodningen kallas för ***kod***.

---

### Exempel

- Talet 14 kan kodas binärt som ``1110``. Alltså är ``1110`` binär kod för 14. 
- Det binära talet 1111000011110000 kan kodas hexadecimalt som ``F0F0``. Alltså är ``F0F0`` hexadecimal kod för 1111000011110000.

---

<div class="title-page">

# Binär kodning av negativa heltal 

</div>

---

## Binär kodning av heltal
 
- Ett fält med *N* bitar kan koda heltalen [0, 2<sup>*N*</sup> - 1]
- Ett fält med *N* bitar kan också koda heltal [-2<sup>*N* - 1</sup>, 2<sup>*N* - 1</sup> - 1] genom så kallad ***två-komplements-kodning***

---

### Exempel

Tabellen nedan visar för olika antal bitar intervallet av heltal som kan kodas med vanlig binär kodning respektive två-komplements-kodning.

<center>
<table style="display: inline">
    <tr><th>Antal bitar</th><th>Vanlig binär kodning</th><th>Två-komplement-kodning</th></tr>
    <tr><td>8</td><td>[0, 255]</td><td>[-128, 127]</td></tr>
    <tr><td>16</td><td>[0, 65 536]</td><td>[-32 768, 32 767]</td></tr>
    <tr><td>32</td><td>[0, 4 294 967 296]</td><td>[-2 097 152, 2 097 151]</td></tr>
</table>
</center>

---
 ## Två-komplement-kodning

 - För en två-komplement-kodningen med *N* bitar gäller att:
   - De 2<sup>*N* - 1</sup> första koderna de icket-negativa heltalen
   - De 2<sup>*N* - 1</sup> följande koderna är de negativa talen *baklänges*
  
---

### Exempel

Fyra bitar kan koda talen i intervallet [0, 15] eller [-8, 7].

<center>
<div style="display: flex; zoom: 0.7">

<div style="display: flex; flex-direction: column; align-items: center; margin-left: 6em">
<b style="font-size: 130%">Vanlig kodning</b>
<table style="width: auto">
    <tr><th>Kod</th><th>Värde</th><th>Kod</th><th>Värde</th></tr>
    <tr><td>0000</td><td>0</td><td>1000</td><td>8</td></tr>
    <tr><td>0001</td><td>1</td><td>1001</td><td>9</td></tr>
    <tr><td>0010</td><td>2</td><td>1010</td><td>10</td></tr>
    <tr><td>0011</td><td>3</td><td>1011</td><td>11</td></tr>
    <tr><td>0100</td><td>4</td><td>1100</td><td>12</td></tr>
    <tr><td>0101</td><td>5</td><td>1101</td><td>13</td></tr>
    <tr><td>0110</td><td>6</td><td>1110</td><td>14</td></tr>
    <tr><td>0111</td><td>7</td><td>1111</td><td>15</td></tr>
</table>
</div>

<div style="display: flex; flex-direction: column; align-items: center; margin-left: 6em">
<b style="font-size: 130%">Två-komplement</b>
<table style="width: auto">
    <tr><th>Kod</th><th>Värde</th><th>Kod</th><th>Värde</th></tr>
    <tr><td>0000</td><td>0</td><td>1000</td><td>-8</td></tr>
    <tr><td>0001</td><td>1</td><td>1001</td><td>-7</td></tr>
    <tr><td>0010</td><td>2</td><td>1010</td><td>-6</td></tr>
    <tr><td>0011</td><td>3</td><td>1011</td><td>-5</td></tr>
    <tr><td>0100</td><td>4</td><td>1100</td><td>-4</td></tr>
    <tr><td>0101</td><td>5</td><td>1101</td><td>-3</td></tr>
    <tr><td>0110</td><td>6</td><td>1110</td><td>-2</td></tr>
    <tr><td>0111</td><td>7</td><td>1111</td><td>-1</td></tr>
</table>
</div>
</div>
</center>

---

## Signed och unsigned

- Typer av heltal inom programmering som kan representera  både positiva och negativa heltal kallas ***signed***.
- Typer av heltal inom programmering som kan representera endast noll och positiva heltal kallas ***unsigned***.

--- 

### Exempel

Tabellen nedan ger exempel på *signed* och *unsigned* heltalstyper i C#.

<center>
<table style="display: inline">
    <tr><th>Datatyp</th><th>Heltalsintervall</th></tr>
    <tr><td><code>byte</code></td><td>[0, 255]</td></tr>
    <tr><td><code>sbyte</code></td><td>[-128, 127]</td></tr>
    <tr><td><code>ushort</code></td><td>[0, 65 536]</td></tr>
    <tr><td><code>short</code></td><td>[-32 768, 32 767]</td></tr>
    <tr><td><code>uint</code></td><td>[0, 4 294 967 296]</td></tr>
    <tr><td><code>int</code></td><td>[-2 097 152, 2 097 151]</td></tr>
</table>
</center>

---

<div class="title-page">

# Binär kodning av reella tal

</div>

---

## Reella tal

- ***Reella tal*** beskriver tal som ligger mellan heltalen.
- I grundskolan studeras reella tal i bas 10, så kallas *decimaltal*.
- Ett reelt tal känns igen på *punkten* mellan heltalsdelen och "decimalerna". 
- Heltal och bråk är också reella tal. 

---

### Exempel

Samtliga tal nedan är exempel på reella tal.

- -1/3 = -0.33333...
- π = 3.14159265359...
- 174.00000 ... 

Notera punkten som skiljer heltalsdel från decimaler samt att ett decimaltal kan ha oändligt många decimaler. 

--- 

## Notation för reella tal

Allmänt kan ett reellt tal skrivas på formen:

<center>
S<sub>K</sub>S<sub>K-1</sub>..S<sub>3</sub>S<sub>2</sub>S<sub>1</sub>S<sub>0</sub><b style="font-size: 150%">.</b>S<sub>-1</sub>S<sub>-2</sub>S<sub>-3</sub>...
</center>

### Exempel

``12.34`` är ett reellt tal med S<sub>1</sub> = ``1``, S<sub>0</sub> = ``2``, S<sub>-1</sub> = ``3``och S<sub>-2</sub> = ``4``

---

## Decimaltal

Faktorerna för värdet av symbolerna i decimaltalet (bas 10):

<table style="white-space:no-wrap">
    <tr>
        <th colspan="9">Kolumner</th>
    </tr>
    <tr>
        <th>Kolumn</th>
        <th>K</th>
        <th>K-1</th>
        <th>..</th>
        <th>3</th>
        <th>2</th>
        <th>1</th>
        <th>0</th>
        <th>-1</th>
        <th>-2</th>
        <th>-3</th>
        <th>...</th>
    </tr>
    <tr>
        <th>Faktor</th>
        <td>10<sup>K</sup></td>
        <td>10<sup>K-1</sup></td>
        <td>..</td>
        <td>10<sup>3</sup> </td>
        <td>10<sup>2</sup></td>
        <td>10<sup>1</sup></td>
        <td>10<sup>0</sup></td>
        <td>1 / 10<sup>1</sup></td>
        <td>1 / 10<sup>2</sup></td>
        <td>1 / 10<sup>3</sup></td>
        <td>..</th>
    </tr>
</table>

--- 

### Exempel

I bas 10 är värdet av ``12.75`` är ett reellt tal med värdet: 

<center>
1 x 10<sup>1</sup> + 2 x 10<sup>0</sup> + 7 x (1 / 10<sup>1</sup>)  + 5 x (1 / 10<sup>2</sup>) = <br/>
1 x 10 + 2 x 1 + 7 x 0.1 + 5 x 0.01 =<br/> <u>12.75</u>
</center>

---

## Binära reella tal

Reella tal kan också kodas binärt (bas 2). 
  - T.ex. 1100.11

Faktorerna för värdet av symbolerna i det binära talet är då:

<table style="white-space:no-wrap">
    <tr>
        <th colspan="9">Kolumner</th>
    </tr>
    <tr>
        <th>Kolumn</th>
        <th>K</th>
        <th>K-1</th>
        <th>..</th>
        <th>3</th>
        <th>2</th>
        <th>1</th>
        <th>0</th>
        <th>-1</th>
        <th>-2</th>
        <th>-3</th>
        <th>...</th>
    </tr>
    <tr>
        <th>Faktor</th>
        <td>2<sup>K</sup></td>
        <td>2<sup>K-1</sup></td>
        <td>..</td>
        <td>2<sup>3</sup> </td>
        <td>2<sup>2</sup></td>
        <td>2<sup>1</sup></td>
        <td>2<sup>0</sup></td>
        <td>1 / 2<sup>1</sup></td>
        <td>1 / 2<sup>2</sup></td>
        <td>1 / 2<sup>3</sup></td>
        <td>..</th>
    </tr>
</table>

--- 

### Exempel

I bas 2 är värdet av ``1100.11`` är ett reellt tal med värdet: 

<center>
1 x 2<sup>3</sup> + 1 x 2<sup>2</sup> + 0 x 2<sup>1</sup> + 0 x 2<sup>0</sup> + 1 x (1 / 2<sup>1</sup>)  + 1 x (1 / 10<sup>2</sup>) = <br/>
1 x 8 + 1 x 4 + 0 x 2 + 0 x 1 + 1 x (1 / 2) + 1 x (1 / 4) =<br/> 
1 x 8 + 1 x 4 + 0 x 2 + 0 x 1 + 1 x 0.5 + 1 x 0.25 =<br/> 
<u>12.75</u>
</center>

---

## Representation av reella tal i datorer

- I verkligenheten har reella tal oändligt många decimaler. 
- Datorer har begränsat med arbetsminne, så reella tal måste approximeras.
- Datorer approximerar reella tal genom att begränsa antalet decimaler. 
  - T.ex. π = 3.14159265359.. ≈ 3.141593 (om 6 decimler är nära nog)
- ***Flyttal*** är en vanlig binära kodningen för approximation av reella tal. 

--- 

## Flyttal

- Flyttal är en binär kodning av en approximation för reella tal. 
- Kodningen har tre delar:
  - En ***teckenbit*** - 1 om talet är negativt, annars 0
  - En ***exponent*** - ett heltalsfält som anger förskjutningen av punkten
  - En ***signifikand*** - ett fält med binära "decimaler"

---

## Single-precision floating-point

En ***single-precision floating-point***, i vardagligt tal ***float***, är ett flyttalsformat med 8 bitars exponent och 23 bitars signifikand, t.ex.:


<table style="zoom: 0.65; text-align: center">
    <tr>
        <td>Teckenbit</td>
        <td colspan="8">Exponent</td>
        <td colspan="23">Signifikand</td>
    <tr>
        <td style="background-color: pink">0</td>
        <td style="background-color: lightgreen">1</td>
        <td style="background-color: lightgreen">0</td>
        <td style="background-color: lightgreen">0</td>
        <td style="background-color: lightgreen">0</td>
        <td style="background-color: lightgreen">0</td>
        <td style="background-color: lightgreen">0</td>
        <td style="background-color: lightgreen">1</td>
        <td style="background-color: lightgreen">0</td>
        <td style="background-color: lightblue">1</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">1</td>
        <td style="background-color: lightblue">1</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
</table>

där:
  - det reella talet är ``1.`` följt av signifikanden, ovan ``1.10011``
  - förskjutningen av punkten är exponenten minus 127, ovan 130 - 127 = <u>3</u>
    - Positivt resultat förskjuter punkten höger, negativt vänster.

I exemplet ovan är alltså värdet 1100.11 binärt, eller 12.75 decimalt. 

---

## Double-precision floating-point

En ***double-precision floating-point***, i vardagligt tal ***double***, är ett flyttalsformat som fungerar precis som *float* med skillnaden att formatet har:
- 11 bitar exponent
- 52 bitar siginifikand
- Förskjutningen av punkten ges av exponenten minus 1023

Double kan alltså representera större och mindre tal än float och innehåller fler decimaler. 

---

## Precision

- Resultatet för beräkningar med double är korrekt  ca. 7 decimaler
  - Det relativa felet är maximalt ca. 0.0000001%
- Resultatet för beräkningar med double är korrekt med ca. 16 decimaler
  - Det relativa felet är maximalt ca. 0.0000000000000001%

---

## Storlek

- En float är 4 bytes = 32 bitar
- En double är 8 bytes = 32 bitar

--- 

## Float eller double?

- Moderna CPU:er arbetar ungefär lika snabbt på double som float. 
- Double har högre precision och kan representera större/mindre tal = säkrare
- Som regel är double förstavalet framför float. 
- Float kan vara användbart ibland om minnesåtgång är ett problem.

---

## Kom ihåg! Flyttal är INTE en exakt representation 

- Matematiskt har reella tal oändligt många decimaler
- Double är en god approximation men ingen exakta representation

T.ex. ger koden:

```cs 
Console.WriteLine((0.3 * 3) + 0.1);
```

utskriften:

```
0.9999999999999999
```

Det är säkert att jämföra storleken på resultat av flyttalsberäkningar men var mycket försiktig med att kontrollera om resultaten är exakt lika!

---

### Exempel

Ett andragradspolynom är en funktion av *x* på formen: 

p(x) = a + bx + cx<sup>2</sup> 

där *a*, *b* och *c* är konstanter. 

T.ex. om *a* = -8.03, *b* = 2.95 och *c* = 1.00 så är polyonmet:  

p(x) = -8.03 + 2.95x + 1.00x<sup>2</sup>

En *rot* till polynomet är ett värde på *x* sådant att *p*(*x*) = 0. 

Skriv kod som kontrollerar om aktuellt värde på *x* är en rot.

---

Till synes matematiskt korrekt men ej tillförlitlig kod: 

```cs
double p = a + b * x + c * x * x;
if (p == 0.0) { // Ej tillförlitlig lösning!
    // p(x) == 0 
}
```

Finns inget exakt sätt med flyttal att kontrollera om värdet på *x* är en rot.

Vi kan dock kontroller om *x* är tillräckligt nära att vara en rot för vårt syfte.

```cs
double p = a + b * x + c * x * x;
if (-0.005 > p && p < 0.005) {
    // p(x) avrundat till två decimalers nogranhet är 0
}
```

---

<div class="title-page">

# Binär kodning av text

</div>

---

## Binär kodning av text

- Text är en sekvens av tecken i minnet
- Varje tecken kodas med en eller flera bytes enligt en kodningsstandard
- Det finns olika kodningsstandarder
- Försöker man avkoda en bytesekvens som text med fel kodningsstardard så blir resultatet sannolikt fel. 
- Viktigt veta vilken kodningsstandard som gäller!

---

## ASCII-kodning

- ASCII-kodning är en gammal standard med anor från telegrafmaskiner
  - Americal Standard Core for Information Exchange
  - Första versionen definierad 1963
- Varje tecken kodas med 7 bits
  - I datorer en byte med första biten alltid 0

---

## ASCII-tabell

<table style="zoom: 0.6; text-align: center">
    <tr>
        <td/>
        <td/>
        <th colspan="16">b<sub>3</sub>b<sub>2</sub>b<sub>1</sub>b<sub>0</sub></th>
    </tr>
    <tr>
        <td/>
        <td/>
        <td>0000</td>
        <td>0001</td>
        <td>0010</td>
        <td>0011</td>
        <td>0100</td>
        <td>0101</td>
        <td>0110</td>
        <td>0111</td>
        <td>1000</td>
        <td>1001</td>
        <td>1010</td>
        <td>1011</td>
        <td>1100</td>
        <td>1101</td>
        <td>1110</td>
        <td>1111</td>
    </tr>
    <tr>
        <th rowspan="16">b<sub>6</sub>b<sub>6</sub>b<sub>5</sub>b<sub>4</sub></th>
        <td>0000</td>
        <td>NUL</td>
        <td>SOH</td>
        <td>STX</td>
        <td>ETX</td>
        <td>EOT</td>
        <td>ENQ</td>
        <td>ACK</td>
        <td>BEL</td>
        <td>BS</td>
        <td>HT</td>
        <td>LF</td>
        <td>VT</td>
        <td>FF</td>
        <td>CR</td>
        <td>SO</td>
        <td>SI</td>
    </tr>
    <tr>
        <td>0001</td>
        <td>DLE</td>
        <td>DC1</td>
        <td>DC2</td>
        <td>DC3</td>
        <td>DC4</td>
        <td>NAK</td>
        <td>SYN</td>
        <td>ETB</td>
        <td>CAN</td>
        <td>EM</td>
        <td>SUB</td>
        <td>ESC</td>
        <td>FS</td>
        <td>GS</td>
        <td>RS</td>
        <td>US</td>
    </tr>
    <tr>
        <td>0010</td>
        <td>SP</td>
        <td>!</td>
        <td>"</td>
        <td>#</td>
        <td>$</td>
        <td>%</td>
        <td>&</td>
        <td>'</td>
        <td>(</td>
        <td>)</td>
        <td>*</td>
        <td>+</td>
        <td>,</td>
        <td>-</td>
        <td>.</td>
        <td>/</td>
    </tr>
    <tr>
        <td>0011</td>
        <td>0</td>
        <td>1</td>
        <td>2</td>
        <td>3</td>
        <td>4</td>
        <td>5</td>
        <td>6</td>
        <td>7</td>
        <td>8</td>
        <td>9</td>
        <td>:</td>
        <td>;</td>
        <td><</td>
        <td>=</td>
        <td>></td>
        <td>?</td>
    </tr>
    <tr>
        <td>0100</td>
        <td>@</td>
        <td>A</td>
        <td>B</td>
        <td>C</td>
        <td>D</td>
        <td>E</td>
        <td>F</td>
        <td>G</td>
        <td>H</td>
        <td>I</td>
        <td>J</td>
        <td>K</td>
        <td>L</td>
        <td>M</td>
        <td>N</td>
        <td>O</td>
    </tr>
    <tr>
        <td>0101</td>
        <td>P</td>
        <td>Q</td>
        <td>R</td>
        <td>S</td>
        <td>T</td>
        <td>U</td>
        <td>V</td>
        <td>W</td>
        <td>X</td>
        <td>Y</td>
        <td>Z</td>
        <td>[</td>
        <td>\</td>
        <td>]</td>
        <td>^</td>
        <td>_</td>
    </tr>
    <tr>
        <td>0110</td>
        <td>`</td>
        <td>a</td>
        <td>b</td>
        <td>c</td>
        <td>d</td>
        <td>e</td>
        <td>f</td>
        <td>g</td>
        <td>h</td>
        <td>i</td>
        <td>j</td>
        <td>k</td>
        <td>l</td>
        <td>m</td>
        <td>n</td>
        <td>o</td>
    </tr>
    <tr>
        <td>0111</td>
        <td>p</td>
        <td>q</td>
        <td>r</td>
        <td>s</td>
        <td>t</td>
        <td>u</td>
        <td>v</td>
        <td>w</td>
        <td>x</td>
        <td>y</td>
        <td>z</td>
        <td>{</td>
        <td>|</td>
        <td>}</td>
        <td>~</td>
        <td>DEL</td>
    </tr>
</table>

---

### Exempel

T.ex. blir bytesekvensen: 

```text
01001000 01100101 01101100 01101100 01101111 00100000
01110100 01101000 01100101 01110010 01100101 00100001
```

avkodad med ASCII-standarden texten: 

```
Hello there!
```

---

## Kontrolltecken

- Vissa tecken i ASCII-standarden är inte grafiska 
  - ``PAD``, ``HOP``, ``BPH``, etc
- Dessa tecken är så kallade ***kontrolltecken***
- Kontrolltecken är istruktioner till konsolen som tolkar texten
- Många kontrolltecken är föråldrade och används inte längre
- Vissa kontrolltecken har viktiga användningsområden än idag

---

### Exempel

T.ex. Följande tecken är viktiga än idag.

<center>
<table style="display: inline; zoom: 0.8">
    <tr><th>Tecken</th><th>Betydelse</th></tr>
    <tr><td><code>BS</code></td><td>Backspace</td></tr>
    <tr><td><code>LF</code></td><td>Linefeed (New line)</td></tr>
    <tr><td><code>CR</code></td><td>Carrige return</td></tr>
    <tr><td><code>BEL</code></td><td>Bell</td></tr>
    <tr><td><code>HT</code></td><td>Horizontal tab</td></tr>
    <tr><td><code>DLE</code></td><td>Delete</td></tr>
    <tr><td><code>BS</code></td><td>Backspace</td></tr>
    <tr><td><code>BS</code></td><td>Backspace</td></tr>
</table>
</center>

---

### Exempel 

T.ex. innehåller följande bytesekvens avkodad som ASCII ett ``LF``-tecken:

```cs
01001000 01100101 01101100 01101100 01101111 
00101100 00001010 01010111 01101111 01110010 
01101100 01100100 00100001
```

och skrivs i konsolen ut som:

```text
Hello,
World!
```

---

## ISO-8859-1

- Eftersom ASCII är en 7-bitarsstandard så kan standarden utökas med betydelse för alla bitkoder som börjar på 1 och ända vara bakåtkompatibel 
- För icket-amerikaner saknas flera viktiga tecken i ASCII-standarden
  - T.ex. som svenskar behöver vi tecknen ``å``, ``ä`` och ``ö`` 
- En vanlig standardutökning av ASCII är ISO-8859-1
  - Standarden kallas även Latin-1
  - Anpassat för språk som använder det latinska alfabetet
  - Används t.ex. i Unix/Linux och därför även vanlig på Internet

---

## ISO-8859-1-tabell

<table style="zoom: 0.6; text-align: center">
    <tr>
        <td/>
        <td/>
        <th colspan="16">b<sub>3</sub>b<sub>2</sub>b<sub>1</sub>b<sub>0</sub></th>
    </tr>
    <tr>
        <td/>
        <td/>
        <td>0000</td>
        <td>0001</td>
        <td>0010</td>
        <td>0011</td>
        <td>0100</td>
        <td>0101</td>
        <td>0110</td>
        <td>0111</td>
        <td>1000</td>
        <td>1001</td>
        <td>1010</td>
        <td>1011</td>
        <td>1100</td>
        <td>1101</td>
        <td>1110</td>
        <td>1111</td>
    </tr>
    <tr>
        <th rowspan="16">b<sub>7</sub>b<sub>6</sub>b<sub>5</sub>b<sub>4</sub></th>
        <td>1000</td>
        <td>PAD</td>
        <td>HOP</td>
        <td>BPH</td>
        <td>NBH</td>
        <td>IND</td>
        <td>NEL</td>
        <td>SSA</td>
        <td>ESA</td>
        <td>HTS</td>
        <td>HTJ</td>
        <td>VTS</td>
        <td>PLD</td>
        <td>PLU</td>
        <td>RI</td>
        <td>SS2</td>
        <td>SS3</td>
    </tr>
    <tr>
        <td>1001</td>
        <td>DCS</td>
        <td>PU1</td>
        <td>PU2</td>
        <td>STS</td>
        <td>CCH</td>
        <td>MW</td>
        <td>SPA</td>
        <td>EPA</td>
        <td>SOS</td>
        <td>SGCI</td>
        <td>SCI</td>
        <td>CSI</td>
        <td>ST</td>
        <td>OSC</td>
        <td>PM</td>
        <td>APC</td>
    </tr>
    <tr>
        <td>1010</td>
        <td>NBSP</td>
        <td>¡</td>
        <td>¢</td>
        <td>£</td>
        <td>¤</td>
        <td>¥</td>
        <td>¦</td>
        <td>§</td>
        <td>¨</td>
        <td>©</td>
        <td>ª</td>
        <td>«</td>
        <td>¬</td>
        <td>SHY</td>
        <td>®</td>
        <td>¯</td>
    </tr>
    <tr>
        <td>1011</td>
        <td>°</td>
        <td>±</td>
        <td>²</td>
        <td>³</td>
        <td>´</td>
        <td>µ</td>
        <td>¶</td>
        <td>·</td>
        <td>¸</td>
        <td>¹</td>
        <td>º</td>
        <td>»</td>
        <td>¼</td>
        <td>½</td>
        <td>¾</td>
        <td>¿</td>
    </tr>
    <tr>
        <td>1100</td>
        <td>À</td>
        <td>Á</td>
        <td>Â</td>
        <td>Ã</td>
        <td>Ä</td>
        <td>Å</td>
        <td>Æ</td>
        <td>Ç</td>
        <td>È</td>
        <td>É</td>
        <td>Ê</td>
        <td>Ë</td>
        <td>Ì</td>
        <td>Í</td>
        <td>Î</td>
        <td>Ï</td>
    </tr>
    <tr>
        <td>1101</td>
        <td>Ð</td>
        <td>Ñ</td>
        <td>Ò</td>
        <td>Ó</td>
        <td>Ô</td>
        <td>Õ</td>
        <td>Ö</td>
        <td>×</td>
        <td>Ø</td>
        <td>Ù</td>
        <td>Ú</td>
        <td>Û</td>
        <td>Ü</td>
        <td>Ý</td>
        <td>Þ</td>
        <td>ß</td>
    </tr>
    <tr>
        <td>1110</td>
        <td>à</td>
        <td>á</td>
        <td>â</td>
        <td>ã</td>
        <td>ä</td>
        <td>å</td>
        <td>æ</td>
        <td>ç</td>
        <td>è</td>
        <td>é</td>
        <td>ê</td>
        <td>ë</td>
        <td>ì</td>
        <td>í</td>
        <td>î</td>
        <td>ï</td>
    </tr>
    <tr>
        <td>1111</td>
        <td>ð</td>
        <td>ñ</td>
        <td>ò</td>
        <td>ó</td>
        <td>ô</td>
        <td>õ</td>
        <td>ö</td>
        <td>÷</td>
        <td>ø</td>
        <td>ù</td>
        <td>ú</td>
        <td>û</td>
        <td>ü</td>
        <td>ý</td>
        <td>þ</td>
        <td>ÿ</td>
    </tr>
</table>

--- 

### Exempel

T.ex. blir bytesekvensen: 

```text
01001000 01100101 01101010 00100000
01100100 11100100 01110010 00100001
```

avkodad med ISO-8850-1 texten:

```text
Hej där!
```

---

## Unicode

- ISO-8859-1 är inte tillräckligt för modern internationell text använding:
  - Saknar alfabeten som arabiskt, persiskt, japanskt, kinesiskt, m.fl.
  - Inga emojis eller andra vanligt förekommande symboler
- Unicode är en standard med ambition att täcka alla tecken i världen!
- Tecknen är uppdelade i 17 plan med vardera upp till 2<sup>16</sup> = 65 536 tecken
- Varje tecken har en textkod, i form av ``U+`` följt av 4 eller 5 hexadecimala tal

---

### Exempel

T.ex. står ``U+1F642`` för tecknet 🙂

De fyra sista siffrorna i koden för tecknets hexadecimala position i planet: 

``F642`` = 63 042

De ett eller två första siffrorna är hexadecimalt index på planet (0-10): 

``1`` = andra planet

---

## Teckenplan i Unicode

- Plan 0 - innehåller alla de vanligaste skrivtecknen 
  - Kallas *Basic Multilingual Plane*
  - Dessa tecken är vanligast förekommande i text
  - De första 256 koderna sammanfaller med ISO-8859-1
- Plan 1 - Innehåller extra skrivtecken t.ex. ovanliga alfabeten och emoijis 
- Plan 2 - 16 - Fler tecken, används mer sällan

Beskrivning av samtliga plan och tecken i Unicode finns t.ex. [här](https://en.wikipedia.org/wiki/Unicode).

--- 

## Binär kodning av Unicode

- Koder som ``U+1F642`` är en textkod
- Datorer lagrar Unicodetecken som binärkoder
- Två viktig binärkodningar är UTF-8 och UTF-16
- Först tittar vi på UTF-32 dock

---

## UTF-32

- Vilket unciodetecken som helst kan lagras med 20 bitar
  - 5 bitar för planet och 16 för tecknet i planet
- Datorer arbetar mest effektivt med block om 1, 2, 4 eller 8 byte
- 21 bitar kräver 4 byte per tecken
- Tabellen nedan visar UTF-32-kodning av ``U+1F642`` (🙂)

<table style="zoom: 0.6">
    <tr>
        <th colspan="11">
            Ej utnyttjade
        </th>
        <th colspan="5">
            Plan
        </th>
        <th colspan="12">
            Tecken
        </th>
    <tr>
        <td style="background-color: lightgray">0</td>
        <td style="background-color: lightgray">0</td>
        <td style="background-color: lightgray">0</td>
        <td style="background-color: lightgray">0</td>
        <td style="background-color: lightgray">0</td>
        <td style="background-color: lightgray">0</td>
        <td style="background-color: lightgray">0</td>
        <td style="background-color: lightgray">0</td>
        <td style="background-color: lightgray">0</td>
        <td style="background-color: lightgray">0</td>
        <td style="background-color: lightgray">0</td>
        <td style="background-color: lightgreen">0</td>
        <td style="background-color: lightgreen">0</td>
        <td style="background-color: lightgreen">0</td>
        <td style="background-color: lightgreen">0</td>
        <td style="background-color: lightgreen">1</td>
        <td style="background-color: lightblue">1</td>
        <td style="background-color: lightblue">1</td>
        <td style="background-color: lightblue">1</td>
        <td style="background-color: lightblue">1</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">1</td>
        <td style="background-color: lightblue">1</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">1</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">0</td>
        <td style="background-color: lightblue">1</td>
        <td style="background-color: lightblue">0</td>
    </tr>
</table>

--- 

## UTF-8

- UTF-8 kodar varje Unicodetecken med 1-4 byte
- Bakåtkompatibel med ASCII

<table style="zoom:0.9">
    <tr>
        <th>Antal<br/>bytes</th>
        <th>Från<br/>tecken</th>
        <th>Till<br/>tecken</th>
        <th>Byte 0</th>
        <th>Byte 1</th>
        <th>Byte 2</th>
        <th>Byte 3</th>
    </tr>
    <tr>
        <td>1</td>
        <td><code>U+0000</code></td>
        <td><code>U+007F</code></td>
        <td><code>0xxxxxxx</code></td>
        <td>--</td>
        <td>--</td>
        <td>--</td>
    </tr>
    <tr>
        <td>2</td>
        <td><code>U+0080</code></td>
        <td><code>U+07FF</code></td>
        <td><code>110xxxxx</code></td>
        <td><code>110xxxxx</code></td>
        <td>--</td>
        <td>--</td>
    </tr>
    <tr>
        <td>3</td>
        <td><code>U+0800</code></td>
        <td><code>U+FFFF</code></td>
        <td><code>1110xxxx</code></td>
        <td><code>10xxxxxx</code></td>
        <td><code>10xxxxxxx</code></td>
        <td>--</td>
    </tr>
    <tr>
        <td>4</td>
        <td><code>U+10000</code></td>
        <td><code>U+10FFFF</code></td>
        <td><code>11110xxx</code></td>
        <td><code>10xxxxxx</code></td>
        <td><code>10xxxxxx</code></td>
        <td><code>10xxxxxx</code></td>
    </tr>
</table>

---

### Exempel

Nedan visas UTF-8-kodning av tre olika tecken.

``U+00041`` (``A``) är ett ASCII-tecken och kräver bara en byte:

```text
01000001
```

``U+000C3`` (``Ä``) ligger i två-bytes-intervallet:

```text
11000011 10000100
```


``U+1F642`` (🙂) ligger utanför första planet och kräver fyra bytes:

```text
11110000 10011111 10011001 10000010
```

---

## UTF-16

- UTF-16 lagrar alla Unicode-tecken i första planet med två bytes
- Tecken i hägre plan kan lagras med två så kallade *surrogattecken*

<table style="zoom:0.9">
    <tr>
        <th>Antal<br/>bytes</th>
        <th>Från<br/>tecken</th>
        <th>Till<br/>tecken</th>
        <th>Byte 0</th>
        <th>Byte 1</th>
        <th>Byte 2</th>
        <th>Byte 3</th>
    </tr>
    <tr>
        <td>2</td>
        <td><code>U+00000</code></td>
        <td><code>U+0D7FF</code></td>
        <td><code>xxxxxxxx</code></td>
        <td><code>xxxxxxxx</code></td>
        <td>--</td>
        <td>--</td>
    </tr>
    <tr>
        <td>2</td>
        <td><code>U+0E000</code></td>
        <td><code>U+0FFFF</code></td>
        <td><code>xxxxxxxx</code></td>
        <td><code>xxxxxxxx</code></td>
        <td>--</td>
        <td>--</td>
    </tr>
    <tr>
        <td>4</td>
        <td><code>U+0E000</code></td>
        <td><code>U+10FFFF</code></td>
        <td><code>110110xx</code></td>
        <td><code>xxxxxxxx</code></td>
        <td><code>110111xx</code></td>
        <td><code>xxxxxxxx</code></td>        
    </tr>
</table>

---

### Exempel

Nedan visas UTF-16-kodning av två olika tecken.

``U+00041`` (``A``) blir två bytes:

```text
00000000 01000001
```

``U+1F642`` (🙂) blir fyra bytes:

```text
11011000 00111101 11011110 01000010
```

---

<div class="title-page">

# Byteordning

</div>

---

## Byteordning

- Primitiva datatyper kan lagras i minnet på två sätt
  - *Big endian* - högsta byten
  - *Little endian* - lägsta byten först
- T.ex. är Intels processorer Little endian och ARM-processorer Big endian

---

### Exempel

Talet 1962939861 blir som ett 32-bitars binärt tal:

```
01110101 00000000 00010101 11010101
```

Lagrat i minnet: 

<div style="display: flex; flex-direction: column; align-items: center">
<div style="display: flex; zoom: 0.7">
<div style="display: flex; flex-direction: column; align-items: center">
<span style="font-size: 130%">Big endian</span>
<table>
    <tr><th>Adress</th><th>Data</th></tr>
    <tr><td>..</td><td>..</td></tr>
    <tr><td>K</td><td><code>01110101</code></td></tr>
    <tr><td>K + 1</td><td><code>00000000</code></td></tr>
    <tr><td>K + 2</td><td><code>00010101</code></td></tr>
    <tr><td>K + 3</td><td><code>11010101</code></td></tr>
    <tr><td>..</td><td>..</td></tr>
</table>
</div>
<div style="display: flex; flex-direction: column; align-items: center; margin-left: 6em">
<span style="font-size: 130%">Little endian</span>
<table>
    <tr><th>Adress</th><th>Data</th></tr>
    <tr><td>..</td><td>..</td></tr>
    <tr><td>K</td><td><code>11010101</code></td></tr>
    <tr><td>K + 1</td><td><code>00010101</code></td></tr>
    <tr><td>K + 2</td><td><code>00000000</code></td></tr>
    <tr><td>K + 3</td><td><code>01110101</code></td></tr>
    <tr><td>..</td><td>..</td></tr>
</table>
</div>
</div>
</div>

---

### Exempel

Med UTF-16 blir symbolen ``U+1F642`` (🙂) 2 16-bitarstecken:

```text
11011000 00111101 11011110 01000010
```

Lagrat i minnet:

<div style="display: flex; flex-direction: column; align-items: center">
<div style="display: flex; zoom: 0.7">
<div style="display: flex; flex-direction: column; align-items: center">
<span style="font-size: 130%">Big endian</span>
<table>
    <tr><th>Adress</th><th>Data</th></tr>
    <tr><td>..</td><td>..</td></tr>
    <tr><td>K</td><td><code>11011000</code></td></tr>
    <tr><td>K + 1</td><td><code>00111101</code></td></tr>
    <tr><td>K + 2</td><td><code>11011110</code></td></tr>
    <tr><td>K + 3</td><td><code>01000010</code></td></tr>
    <tr><td>..</td><td>..</td></tr>
</table>
</div>
<div style="display: flex; flex-direction: column; align-items: center; margin-left: 6em">
<span style="font-size: 130%">Little endian</span>
<table>
    <tr><th>Adress</th><th>Data</th></tr>
    <tr><td>..</td><td>..</td></tr>
    <tr><td>K</td><td><code>00111101</code></td></tr>
    <tr><td>K + 1</td><td><code>11011000</code></td></tr>
    <tr><td>K + 2</td><td><code>01000010</code></td></tr>
    <tr><td>K + 3</td><td><code>11011110</code></td></tr>
    <tr><td>..</td><td>..</td></tr>
</table>
</div>
</div>
</div>
