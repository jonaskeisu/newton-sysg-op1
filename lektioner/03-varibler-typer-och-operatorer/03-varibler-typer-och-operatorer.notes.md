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

# Variabler, typer och operatorer
</div>

---

## Syntax

***Syntax*** är formella regler för hur man skriver giltig kod.

---

## Variabler

- En variabel är ett lagringsutrymme i minnet för att lagra data 
- En variabel representeras i koden av ett unikt namn
- Det unika namnet för en variabel kallas  ***identifierare*** 

---

## Identifierare

Syntax för en identifierare:
  - är en sekvens av tecken
  - sekvensen består endast av bokstäver, siffror eller ``_``
  - måste börja med ``_`` eller en bokstav, inte en siffra

---

### Exempel

Giltiga identifierare:
  - ``length``, ``width``, ``color``, ``myName``, ``object1``, ``_variable``

Inte giltiga identifierare: 
  - ``1object``, ``my name``, ``object:1``

--- 

## Typer

- En variabel måste ha en känd *typ* som anger:
  -  formatet och storleken på variabeln data
  -  vilka operationer som får göras på datat

---

## Heltals-typer i C#

<center>
<table style="font-size: 80%; display: inline">
    <tr><th>Keyword</th><th>Intervall</th><th>Bytes</th><th>.NET-typ</th></tr>
    <tr>
        <td><code>sbyte</code></td>
        <td>[-128, 127]</td>
        <td>1</td>
        <td><code>System.SByte</code></td>
    </tr>
    <tr>
        <td><code>byte</code></td>
        <td>[0, 255]</td>
        <td>1</td>
        <td><code>System.Byte</code></td>
    </tr>
    <tr>
        <td><code>short</code></td>
        <td>[-32 768, 32 767]</td>
        <td>2</td>
        <td><code>System.Int16</code></td>
    </tr>
    <tr>
        <td><code>ushort</code></td>
        <td>[0, 65'535]</td>
        <td>2</td>
        <td><code>System.UInt16</code></td>
    </tr>
    <tr>
        <td><code>int</code></td>
        <td>[-2 147 483 648, 2 147 483 647]</td>
        <td>4</td>
        <td><code>System.Int32</code></td>
    </tr>
    <tr>
        <td><code>uint</code></td>
        <td>[0, 4 294 967 295]</td>
        <td>4</td>
        <td><code>System.UInt32</code></td>
    </tr>
    <tr>
        <td><code>long</code></td>
        <td>[-9 223 372 036 854 775 808,<br/> 9 223 372 036 854 775 807] </td>
        <td>8</td>
        <td><code>System.Int64</code></td>
    </tr>
    <tr>
        <td><code>ulong</code></td>
        <td>[0, 18 446 744 073 709 551 615]</td>
        <td>8</td>
        <td><code>System.UInt64</code></td>
    </tr>
</table>
</center>

---

## Keyword

- Ett ***keyword*** är ett ord med speciell betydelse i programmeringspsråket.
- Keywords är inte giltiga identifierare. 

---

## Variabeldefinition

- Innan en variabel kan användas i koden så måste den *definieras*.
- Syntax för definition av en variabel:
    ``<typ> <identifierare>;``
- Identifieraren får inte redan vara definierad i samma block av kod.

---

### Exempel

```cs
byte shoeSize; // 1 byte allokerad
uint pixels; // 4 bytes allokerad
long credit; // 8 bytes allokerad
sbyte shoeSize; // FEL! redan definierad i kodblocket
int ulong; // FEL! ulong är ett keyword
int @ulong; // 4 bytes allokerade
```

*``//`` och efterföljande text på samma kodrad en *kommentar* i dokumenterande syfte och och påverkar inte programmets beteende*.

---

# Tilldelning

- Efter definition av en variabel är det möjligt att skriva till dess minne
- Att skriva till en variabels minne kallas att ***tilldela*** variabeln
- Syntaxen för tilldeling av en variabel är: 
    ``<variabel> = <uttryck>;``
- Ett ***utryck*** är kod som kan beräknas till ett värde 
- Uttrycket till höger i en tilldelning måste ha samma typ som variabeln

---

### Exempel

```cs 
int a;
a = 1 + 2; 
```

## Uttryck

Exempel på uttryck är:
  - variabler

---