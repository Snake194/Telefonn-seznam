using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telefonni_seznam
{
    class Program
    {
       // static void menuVolba(string a = )
        //{
            


        //}
        static void print(string StringToPrint = "Neni definovana funkce")
        {
            Console.WriteLine(StringToPrint);
            //return StringToPrint;()
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
               // Console.Clear();
                print("Vitejte v menu telefonniho seznamu.");
                print("Nyni si v nasem menu vyberte jakou operaci chcete provest.");
                print("---------------------------------------------------------------------------");
                print("Pro vlozeni noveho kontaktu(jmeno + cislo) stisknete : 1");
                print("Pro serazeni seznamu stisknete : 2"); //potom  udelat jestli chce serazeni podle tel.cisla nebo jmena
                print("Pro hledani ulozenych kontaktu stisknete : 3"); //potom  udelat jestli chce hledani podle tel.cisla nebo jmena
                print("Pro ukonceni programu stisknete : 4");
                menu = int.Parse(Console.ReadLine());
                if (menu == 1)
                {
                    print("Zadejte jmeno noveho kontaktu:");
                    string new_kontakt = Console.ReadLine();
                    kontakt[count] = new_kontakt;
                    count=+ 1;
                    print("Zatejte telefonni cislo kontaktu:");
                }
            }
            while (menu != 4);
            string[] kontakty = kontakt.Distinct().ToArray();
            foreach (var s in kontakty)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
