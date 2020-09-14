using System;

namespace EnumeratorerFallanalysOchBitfältNotes
{
    class Program
    {
        enum Suite
        {
            Hearts,
            Clubs,
            Diamonds,
            Spades
        }

        enum Rank
        {
            Two = 2,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Jack,
            Queen,
            King,
            Ace
        }

        enum Fruit
        {
            Apple = -13,
            Banan,
            Orange = 1094,
            Mellon
        }

        static void Main(string[] args)
        {
            {
                Suite suite = Suite.Diamonds;
                Console.WriteLine(suite); // Skriver ut "Diamonds"
                Console.WriteLine((int)suite); // Skriver "2"
                suite = (Suite)3;
                Console.WriteLine(suite); // Skriver "Spades"
            }

            {
                Suite[] suits = {
                    Suite.Hearts, Suite.Clubs, Suite.Diamonds, Suite.Spades
                };
                for (int i = 0; i < suits.Length; ++i)
                {
                    // Skriver ut "0", "1", "2", "3"
                    Console.WriteLine((int)suits[i]);
                }
            }

            {
                Fruit[] fruits = {
                    Fruit.Apple, Fruit.Banan, Fruit.Orange, Fruit.Mellon
                };
                for (int i = 0; i < fruits.Length; ++i)
                {
                    // Skriver ut "-13", "-12", "1094", "1095"
                    Console.WriteLine((int)fruits[i]);
                }
            }

            {
                object obj = "Det här är en lång text.";
                switch (obj)
                {
                    case string s when s.Length < 10:
                        Console.WriteLine("En kort text");
                        break;
                    case string s when s.Length >= 10:
                        Console.WriteLine("En lång text");
                        break;
                    case bool b:
                        Console.WriteLine($"Boolean with value: {b}");
                        break;
                    default:
                        Console.WriteLine("Känner inte igen värdet.");
                        break;
                }
            }

            {
                int score = 13;
                switch (score)
                {
                    case int x when x < 10:
                        Console.WriteLine("IG");
                        break;
                    case int x when x >= 10 && x < 20:
                        Console.WriteLine("G");
                        break;
                    case int x when x >= 10 && x < 20:
                        Console.WriteLine("VG");
                        break;
                    default:
                        Console.WriteLine("Ogiltig poäng");
                        break;
                }

                Console.WriteLine(score switch
                {
                    int x when x >= 0 && x < 10 => "IG",
                    int x when x >= 10 && x < 20 => "G",
                    int x when x >= 20 && x <= 30 => "VG",
                    _ => "Ogiltig poäng",
                });
            }

            {
                int age = 42;
                string name = "Bo";
                switch (age, name)
                {
                    case var x when x.Item2.Equals("Bo"):
                        Console.WriteLine($"Bo är {x.Item1} år");
                        break;
                    case (42, "Jonas"):
                        Console.WriteLine("Du verkar bekant!");
                        break;
                    case var (x, _) when x >= 18:
                        Console.WriteLine("Du är myndig.");
                        break;
                    default:
                        break;
                }
            }
        }


    }
}
