using System;
using System.Collections.Generic;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 2, 3};
            // En lista kan konstrueras från vilken samling som helst.
            List<int> list = new List<int>(array);
            // Lägg till ett element till slutet av listan
            list.Add(4); 
            // Lägg till en sekvens av element till slutet av listan
            list.AddRange(new int[] { 5, 6, 7});
            // Ta bort först förekomsten av ett elementvärde
            list.Remove(6);
            // Lägg in ett element på specifik posoition mellan två element 
            list.Insert(5, 6);
            
        }
    }
}
