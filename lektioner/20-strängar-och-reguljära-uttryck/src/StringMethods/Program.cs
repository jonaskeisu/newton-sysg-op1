using System;
using System.Linq;

namespace StringMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            // Contains

            string str = "The red fox jumped over the brown dog!";

            str.Contains("fox"); // true
            str.Contains("elephant"); // false

            // ToUpper/ToLower

            string str2 = "The Early Bird Gets The Worm";
            str2.ToUpper(); // "THE EARLY BIRD GETS THE WORM
            str2.ToLower(); // "the early bird gets the worm"

            // StartsWith/EndsWith

            string str3 = "The red fox jumped over the brown dog!";

            str3.StartsWith("The red fox"); // true
            str3.StartsWith("The green fox"); // false
            str3.EndsWith("the brown dog!"); // true
            str3.EndsWith("the purple dog!"); // false

            // IndexOf

            string str4 = "The red fox jumped over the brown dog!";

            str4.IndexOf("fox"); // 4
            str4.IndexOf("dog"); // 28
            str4.IndexOf("elephant"); // -1

            // Join

            string[] fruits = { "apple", "orange", "pear", "mellon"};

            String.Join(" ", fruits); // "apple orange pear mellon"
            String.Join(", ", fruits); // "apple, orange, pear, mellon"

            // Trim

            string str5 = "   padded word   ";

            str5.Trim(); // "padded word"

            // Split

            string fruitMix = "apple, orange, pear, mellon";
            string carPark = "volvo testla  skoda";

            fruitMix.Split(','); // { "apple", " orange", " pear", " mellon" }
            fruitMix.Split(',').Select(s => s.Trim()); // { "apple", "orange", "pear", "mellon" }
            carPark.Split(' '); // { "volvo", "tesla", "", "skoda" }
            carPark.Split(' ', StringSplitOptions.RemoveEmptyEntries); // { "volvo", "tesla", skoda" }

            // Substring 

            string str6 = "The red fox jumped over the brown dog!"; 

            str6.Substring(6, 7); // "red fox"
            str6.Substring(28, 9); // "brown dog"

            // Replace

            string str7 = "Life is full of problems.";

            str7.Replace("problems", "opportunities"); // "Life is full of opportunities"
        }
    }
}
