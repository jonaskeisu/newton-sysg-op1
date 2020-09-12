---
presentation:
  width: 800
  height: 600
  theme: 'black.css'
---

<!-- slide -->

# Funktioner

<!-- slide -->

## Funktion

- I C# är en funktion ett namngivet kodblock
- Koden i blocket körs genom att funktionen anropas
- Kodblocket kallas funktionens *kropp*

<!-- slide -->

## Parametrar

- Funktionen har en lista med parametrar
- En parameter är en speciell typ av lokal variabel för funktionens kodblocket
- Varje parameter måste ges ett värde vid varje anropa funktionen

<!-- slide -->

## Resultat 

- Ett funktionsanrop kan resultera i ett värde
- Kallas att funktionen *returnerar* ett värde

<!-- slide -->

## Syntax för en funktion

- Syntexen för att definiera en funktion är:

    ```cs
    <typ> <identifierare> (<param 1>, <param 2>, .., <param k>) 
    {
        // kod som körs vid anrop av funktionen
    }
    ``` 

    där ``<typ>`` är typen på värdet som funktionen returnerar. 
- Hela raden före funktionens kropp kallas fuktionens *huvud*

## Syntax för en parameter

En parameter hara samma syntax som definition av en lokal variabel:

```cs
<typ> <identifierare>
```

<!-- slide -->

## Return

Om en funktion resulterar i ett värde måste varje körningsflöde genom funktionens kropp måste sluta med en sats bestånde av nyckelordet ``return`` följt av ett uttryck av funktionens resultattyp.

<!-- slide -->

### Exempel

```cs
// definition av ny funktion `add`
int add(int a, int b) 
{
    return b; 
}

var x = add(1, 2); // x = 3
var y = add(3, 4); // y = 7
```

<!-- slide -->

## Funktioner utan returvärde

- En funktion måste inte reslutera i ett värde
- I så fall ges resultattypen av funktionen av nyckelordet ``void``
- Vid anrop återvänder körningsflödet från funktionens kropp:
  - Vid körning av satsen ``return; `` körs, eller
  - När körningsflödet når slutet på kodblocket.

## Användningsområden för funktioner

- Återanvändning av logik
- Strukturera kod för att göra den enklare att läsa och underhålla
- Callbacks - injiicera egen kod i körning av ramverkskod
- Metoder

<!-- slide -->

### Exempel - Luffarschack

```cs
var board = new char[3,3]; 

for (int r = 0; r < 3; ++r) {
    for (int k = 0; k < 3; ++k) {
        board[r, k] = ' ';
    }
}

bool gamedEnded = false;
char player = 'X';

while (!gameEnded) {
    Console.WriteLine($"========");
    for (int r = 0; i < 3; ++r) {
        Console.WriteLine($"|{board[r, 0]}|{board[r, 1]}|{board[r, 2]}|");
    }
    Console.WriteLine($"========");
    Console.WriteLine("");
    
}










