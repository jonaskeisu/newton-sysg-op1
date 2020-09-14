using System;

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

            // WriteInFrame 
            {
                void WriteInFrame(string text, int width = 0, char border = '*')
                {
                    width = Math.Max(width, text.Length + 4);

                    var line = new String(border, width);
                    var spacer = border + new String(' ', width - 2) + border;

                    var paddingNeeded = width - 2 - text.Length;
                    var padLeft = new String(' ', paddingNeeded / 2);
                    var padRight = new String(' ', paddingNeeded - padLeft.Length);

                    Console.WriteLine(
                        line + '\n' + spacer + '\n' + 
                        border + padLeft + text + padRight + border + '\n' + 
                        spacer + '\n' + line
                    );
                }

                WriteInFrame("Daniel", 0, '#');
                Console.WriteLine();
                WriteInFrame("Bo", 0, '#');

                WriteInFrame("Anna");
                Console.WriteLine();
                WriteInFrame("Mattias", border: '$');
            }
        }
    }
}
