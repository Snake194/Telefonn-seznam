using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telefonni_seznam
{
    class Program
    {
        static void print(string StringToPrint = "Není definovaná funkce")
        {
            Console.WriteLine(StringToPrint);
        }

        static void Main(string[] args)
        {
            int menu,count = 0;
            string[] kontakt = new string[1000];
            for (int i = 0; i < 1000; i++)
            {
                kontakt[i] = "0";
            }
            do
            {
                Console.Clear();
                print("     1 - Vložení nového kontaktu(jméno + číslo)");
                print("     2 - Seřazení seznamu"); //potom  udelat jestli chce serazeni podle tel.cisla nebo jmena
                print("     3 - Hledání v uložených kontaktech"); //potom  udelat jestli chce hledani podle tel.cisla nebo jmena
                print("----------------------------------------------------------");
                print("     0 - Ukončení programu");
                menu = int.Parse(Console.ReadLine());
                if (menu == 1)
                {
                    print("Zadejte jméno nového kontaktu:");
                    string new_kontakt = Console.ReadLine();
                    kontakt[count] = new_kontakt;
                    count=+ 1;
                    print("Zadejte telefonní číslo kontaktu:");
                }
            }
            while (menu != 0);
            string[] kontakty = kontakt.Distinct().ToArray();
            foreach (var s in kontakty)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
