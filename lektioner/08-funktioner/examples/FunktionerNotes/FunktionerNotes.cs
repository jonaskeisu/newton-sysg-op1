using System;
using static System.Console;

namespace FunktionerNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // BMI
            {
                // Definition av funktion `Bmi`
                double Bmi(double lengthCm, double weightKg)
                {
                    var lengthMeters = lengthCm / 100;
                    return weightKg / (lengthMeters * lengthMeters);
                }

                // Ett anrop till funktionen 'Bmi' 
                // med argumenten '178' och '78.5'
                var bmi = Bmi(178, 78.5); // x = 24.77.. 

                Console.WriteLine($"BMI: {bmi}");

                bmi = Bmi(lengthCm: 178, weightKg: 78.5);

                Console.WriteLine($"BMI: {bmi}");
            }

            // BMI 2 
            {
                double Bmi(double lengthCm, double weightKg) =>
                    weightKg / Math.Pow(lengthCm / 100, 2);

                var bmi = Bmi(lengthCm: 178, weightKg: 78.5);

                Console.WriteLine($"BMI: {bmi}");
            }

            // Frame 
            {
                void Frame(string text, int width = 0, char border = '#')
                {
                    int w = Math.Max(width, text.Length + 4); // outer width
                    int iw = w - 2; // inner width
                    char b = border;

                    string Repeat(char c, int times) => new string(c, times);

                    WriteLine(Repeat(b, w) + '\n' + b + Repeat(' ', iw) + b);
                    string padl = Repeat(' ', (iw - text.Length) / 2);
                    string padr = Repeat(' ', padl.Length + (iw - text.Length) % 2);
                    WriteLine(b + padl + text + padr + b);
                    WriteLine(b + Repeat(' ', iw) + b + '\n' + Repeat(b, w));
                }


                Frame("Daniel", 0, '#');
                Console.WriteLine();
                Frame("Bo", 0, '#');

                Frame("Anna");
                Console.WriteLine();
                Frame("Mattias", border: '$');
            }
        }
    }
}

