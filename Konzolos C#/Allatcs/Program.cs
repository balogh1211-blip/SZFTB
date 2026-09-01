using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Vedett
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Allat> allatok = new List<Allat>();

            foreach (var sor in File.ReadAllLines("vedett.csv", Encoding.UTF8).Skip(1))
            {
                if (string.IsNullOrWhiteSpace(sor)) continue;
                var m = sor.Split(';');
                allatok.Add(new Allat(
                    int.Parse(m[0]),
                    m[1],
                    int.Parse(m[2]),
                    int.Parse(m[3]),
                    m[4]
                ));
            }

            Console.WriteLine($"4. feladat: Az állatfajok száma: {allatok.Count}");

            Console.WriteLine("5. feladat: 1000000 Ft értékű:");
            var milliósok = allatok.Where(a => a.Ertek == 1000000);
            foreach (var a in milliósok)
            {
                Console.WriteLine(a.Nev);
            }

            Console.Write("7. feladat: Kérem a kategóriát: ");
            string kat = Console.ReadLine();

            var szurt = allatok.Where(a => a.Kategoria.Equals(kat, StringComparison.OrdinalIgnoreCase));

            if (szurt.Any())
            {
                double atlag = szurt.Average(a => a.Ertek);
                Console.WriteLine($"Az állatok átlagos értéke: {atlag:F1}");
            }
            else
            {
                Console.WriteLine("Nem található állatfaj a megadott kategóriából.");
            }

            Console.ReadKey();
        }
    }
}