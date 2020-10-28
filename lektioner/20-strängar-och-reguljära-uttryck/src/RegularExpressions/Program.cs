using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "The red fox jumped over the brown dog!";
            string str2 = "The early bird gets the worm";

            Regex re = new Regex(@"fox");
            re.IsMatch(str1); // true
            re.IsMatch(str2); // false

            // Character sets 

            Regex re2 = new Regex(@"[Dd]og");

            string str3 = "The dog is mans best friend";
            string str4 = "Dogs and cats often fight";

            re2.IsMatch(str3); // true
            re2.IsMatch(str4); // also true

            // Character spans

            Regex letter = new Regex(@"[a-z]");
            Regex number = new Regex(@"[0-9]");

            string noNumbers = "One, two, three";
            string noLetters = "1 + 1 = 2";

            letter.IsMatch(noNumbers); // true
            letter.IsMatch(noLetters); // false
            number.IsMatch(noNumbers); // false
            number.IsMatch(noLetters); // true

            // Inverted char span
            Regex nonDigit = new Regex(@"[^0-9]");
            Regex consonant = new Regex(@"[^aeiouyåäö ]");

            nonDigit.IsMatch("846847643"); // false
            nonDigit.IsMatch("1234a4321"); // true
            var vovels = consonant.Matches("jonas keisu").Count; // 6 

            // Wildcard

            Regex re3 = new Regex(@"a.c");

            string str5 = "a1c";
            string str6 = "ac";
            string str7 = "lätt som abc!";

            re3.IsMatch(str5); // true
            re3.IsMatch(str6); // false
            re3.IsMatch(str7); // true


            // Multiples

            Regex zeroOrMore = new Regex(@"a*b");
            Regex oneOrMore = new Regex(@"a+b");
            Regex zeroOrOne = new Regex(@"a?b");
            string str8 = "b";
            string str9 = "ab";
            string str10 = "aab";
            zeroOrMore.IsMatch(str8); // true
            zeroOrMore.IsMatch(str9); // true
            zeroOrMore.IsMatch(str10); // true
            oneOrMore.IsMatch(str8); // false
            oneOrMore.IsMatch(str9); // true
            oneOrMore.IsMatch(str10); // true

            // Specific count

            Regex count1 = new Regex("ab{3}a");
            Regex count2 = new Regex("ab{3,}a");
            Regex count3 = new Regex("ab{3,4}a");

            count1.IsMatch("abba"); // false
            count2.IsMatch("abba");// false
            count3.IsMatch("abba"); // false
            count1.IsMatch("abbba"); // true
            count2.IsMatch("abbba"); // true
            count3.IsMatch("abbba"); // true
            count1.IsMatch("abbbbbba"); // false
            count2.IsMatch("abbbbbba"); // true
            count3.IsMatch("abbbbbba"); // false

            // Check if a string is all numbers

            /*
            string str8 = "928363984";
            string str9 = "123.456";
            
            Regex allNumbers = new Regex(@"[0-9]+");
            
            allNumbers.IsMatch(str8); // true
            allNumbers.IsMatch(str9); // false
            */

            // Start and end of string

            Regex re4 = new Regex(@"^abc");
            Regex re5 = new Regex(@"abc$");

            string str11 = "abc 123 xyz";
            string str12 = "123 abc xyz"; 
            string str13 = "123 xyz abc";

            re4.IsMatch(str11); // true 
            re4.IsMatch(str12); // false 
            re4.IsMatch(str13); // false 
            re5.IsMatch(str11); // false 
            re5.IsMatch(str12); // false 
            re5.IsMatch(str13); // true

            // Grouping of patterns

            Regex re6 = new Regex(@"^abc( abc)*$");

            re6.IsMatch("abc"); // true
            re6.IsMatch("abc abc abc abc"); // true
            re6.IsMatch("abc ab"); // false

            // Reference to group

            Regex re7 = new Regex(@"^(a.c).*\1*$");

            re7.IsMatch("abc def abc"); // true
            re7.IsMatch("a ca c"); // true
            re7.IsMatch("abc def a c"); // false
            
            // Or-operator

            Regex colors = new Regex("red|green|blue");

            colors.IsMatch("red button"); // true
            colors.IsMatch("look at the blue sky"); // true
            colors.IsMatch("purple haze"); // false

            // Character classes
            
            Regex whitespace = new Regex(@"\s");
            Regex notWhitespace = new Regex(@"\S");
            Regex wordCharacter = new Regex(@"\w");
            Regex notWordCharacter = new Regex(@"\W");
            Regex digit = new Regex(@"\d");
            Regex notDigit = new Regex(@"\D");

            // Look-ahead

            Regex re8 = new Regex(@"\w+(?=!)");

            re8.IsMatch("Hello"); // false
            re8.IsMatch("Hello!"); // true, matching "Hello"

            // Password-check

            Regex password = new Regex(@"(?=.*\d)(?=.*[A-Z]).{8,20}");

            password.IsMatch("password123"); // false
            password.IsMatch("Password!"); // false
            password.IsMatch("Pass!"); // false
            password.IsMatch("Password123"); // true
            
            // Replace with regexp

            var line2 = "\"To be or not to be\", William Shakespear";
            var newLine = Regex.Replace(line2, @"""([^""])*)""", @"'$1'");
            // "'To be or not to be', William Shakespear"

            // Get matching group value

            Regex validLine = new Regex(@"^(\d+) ""(\w+)"" (\d{4}-\d{2}-\d{2})$");
            var line = "123 \"Jonas Keisu\" 1978-05-17";
            if (validLine.IsMatch(line))
            {
                var groups = validLine.Match("123 \"Jonas Keisu\" 1978-05-17").Groups;
                int id = int.Parse(groups[1].Value); // 123
                string name = groups[2].Value; // Jonas Keisu
                var bday = DateTime.Parse(groups[3].Value, new CultureInfo("se-SE"));
            }




                


















        }
    }
}
