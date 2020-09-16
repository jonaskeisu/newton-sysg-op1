### Övning g9u4qt (5+)

I schack finns följande typer pjäser: 

```cs 
enum PieceType
{
    Pawn, // Bonde 
    Bishop, // Löpare
    Knight, // Häst
    Rook, // Torn
    Queen, // Drottning
    King // Kung
}
```

Varje pjäs har någon av följande färger: 

```cs 
enum Color
{
    Black, 
    White
}
```

En värdetyp kan göras *nullable* genom att lägga till ett frågetecken efter typens namn. Detta gör att en variabel av typen utöver de vanliga värdena kan tilldelas värdet ``null`` som betyder att variabeln inte har något värde. För att använda värdet av en nullable variabel så måste först fallanalys göras på om variabeln har ett värde eller inte. Detta kan göras t.ex. med en ``if``-sats eller ett ``switch``-uttryck. 

```cs 
int? iAmNullable = 3; // kan också tilldels null  

// Plocka ut eventuellt värde som variabeln a med if
if (iAmNullable is int a) {
    Console.WriteLine($"Variabeln har värdet {a});
}
else {
    Console.WriteLine("Variabeln har inget värde.");
}

// Plocka ut värdet som variabeln a med switch
switch (iAmNullable) {
    case int a: 
        Console.WriteLine($"Variabeln har värdet {a});
        break;
    case null: 
        Console.WriteLine("Variabeln har inget värde.");
        break;
}
```