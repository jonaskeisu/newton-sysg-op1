### Övning

Inspektera interfacet ``Shape2D`` nedan:

```cs
public interface Shape2D {
	
	double PI = 3.1415; 
	double getArea();
	double getPerimiter();
	
}
```

## a) Skriv en klass ``RegularTriangle implements Shape2D`` som representerar en triangel vars sidor och vinklar alla är lika stora.

## b) Skriv en klass ``Square implements Shape2D`` som representerar en kvadrat (fyrkant vars sidor och vinklar alla är lika stora).

## c) Skriv en klass ``RegularPentagon implements Shape2D`` som representerar en femhörning vars sidor och vinklar alla är lika stora.

## d) Du vill nu att alla dina ``Shape2D``-klasser ska implementera standardinterfacet ``Shape2D`` så att en ``Shape2D`` kan jämföras med en annan ``Shape2D`` baserat på deras *areor*. Beskriv tre sätt detta kan åstadkommas, och implementera åtminstone ett av dem.

## e) Bekräfta att du har implementerat klasserna korrekt genom att skapa en ``RegularTriangle`` med sidlängd ``5.0``, en ``Square`` med sidlängd ``5.0`` och en ``RegularPentagon`` med sidlängd ``5.0``. Din ``Square`` ska vara större än din ``RegularTriangle``, och din ``RegularPentagon`` ska vara större än din ``Square``.

## f) Overrida ``tostring()`` metoden för ``RegularTriangle``, ``Square`` och ``RegularPentagon`` så att metoden returnerar en ``string`` som innehåller a) klassens namn, b) arean och c) omkretsen (perimiter).

## g) Skriv en metod ``void sortAndPrint(Shape2D[] shapes)`` som tar en ``Shape2D``-array, sorterar den från minst objekt till störst, och skriver ut strängrepresentationerna av objekten i den sorterade ordningen.
**Tips:** Använd klassmetoden [``void parallelSort(T[] a)`` från klassen ``cs.util.Arrays``](https://docs.oracle.com/en/cs/csse/11/docs/api/cs.base/cs/util/Arrays.html#parallelSort(T%5B%5D)) för att sortera en array ``a`` vars element implementerar ``Comparable<T>``-interfacet. 

## h) **(överkurs)** Skapa en klass ``RegularPolygon implements Shape2D`` som representerar en polygon vars sidor och vinklar alla är lika stora.

---

## e) Skriv ett interface ``Rollable`` som ``Dice``, ``DiceMultiSided`` och ``DiceCup`` alla kan implementera.

