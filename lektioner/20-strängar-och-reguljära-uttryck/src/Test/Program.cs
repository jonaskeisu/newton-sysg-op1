using System;
using System.Text.RegularExpressions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] a = new long[100];
            long[] b = new long[700]; 
            long[] c = new long[500]; 
            long[] d = new long[0]; 
            long[] e = new long[1]; 


            Regex re = new Regex(@" a{0,2} b");

            System.Console.WriteLine(re.IsMatch("  b"));
            System.Console.WriteLine(re.IsMatch(" a b"));
            System.Console.WriteLine(re.IsMatch(" aa b"));
            System.Console.WriteLine(re.IsMatch(" aaa b"));
            System.Console.WriteLine(re.IsMatch(" aaaa b"));
            System.Console.WriteLine(re.IsMatch(" aaaaa b"));
        }
    }
}
