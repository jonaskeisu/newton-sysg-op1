# Sammansatta typer
## Övningar

---

### Övning

Antag typerna:

```cs
enum Suite {
    Diamonds, Clover, Hearts, Spaded
}

struct Card {
    int rank;
    Suite suite;
}

struct Deck {
    static int DECK_SIZE = 52;
    public Card[] cards;

    public Deck(bool shuffle) {
        cards = new Card[DECK_SIZE];
        if (shuffle) {
            Shuffle();
        }
    }

    private void Shuffle() {
        Random rnd = new Random();
        for (int i = 0; i < DECK_SIZE; ++i) {
            int j rnd.Next(0, 52);
            Card tmp = cards[j];
            cards[j] = cards[i];
            cards[i] = tmp;
        }
    }
}
```

a) Hur mångra konstruerare har koden?
b) Hur många typmedlemmar?
c) Hur många instansmedlemmar?
d) Hur många medlemsvariabler?
e) Hur många metoder?
f) Hur många privata medlemmar?

### Övning

Följande kod kan inte byggas. Fixa alla fel.

```cs 
namespace A {
    namespace B {
        struct BT {
            struct BT {
                 AT x;   
            }
        }
    }

    struct AT {
        BT x;
        CT y;
        DT z;
    }

    namespace C {
        struct CT {
            BT x;
        }
    }
}

namespace D {
    struct DT {
        AT x;
        BT y;
        CT z;   
    }
}

### Övning (2)

Vad är fel i koden nedan?

```cs 
namespace Test {
    class Program {
        struct Data {
            int a;

            public Data(int a) {
                this.a = a;
            }
        }

        static public void Main(string[] args) {
            var d = new Data(1);
            Console.Write
        }
    }
}
```

### Övning

Antag följande typdefinition.

```cs
struct Person {
    public static int counter1;
    public int counter2;
    string name;
    int age; 

    public Person(string name, int age) {
        this.name = name;
        this.age = age;
        ++counter1;
        ++counter2;
    }
}
```

Vad skriver följande kod ut? Varför?

```cs 
var anna = new Person("Anna", 29);
var bo = new Person("Bo", 38);
var daniel = new Person("Daniel", 34);
Console.WriteLine(Person.counter1);
Console.WriteLine(Person.counter2);
```

### Övning xxxxxx (3)

Skapa en typ ``IntArraray`` som representerar ett fält av heltal. För typen skall gälla:

- Typen skall vara implicit konverterbar från och till ``int[]``. 
- Två ``IntArray`` kan konkateneras (sammanfogas till en ny instans av ``IntArray``) med operatorn `+`.


### Exempel

```cs 
IntArray x = new int [] { 1, 2, 3};
int[] y = x + new int[] {2, 3, 4};

for (int i = 0; i < y.Length; ++i) {
    Console.WriteLine(y[i] + " ");
}
```

ger utskriften:

```text
1 2 3 4 5 6
```
