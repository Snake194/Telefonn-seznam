using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telefonni_seznam
{
    class Program
    {
        static int menuVolba()
        {
            print("     1 - Vložení nového kontaktu(jméno + číslo)");
            print("     2 - Seřazení seznamu"); //potom  udelat jestli chce serazeni podle tel.cisla nebo jmena
            print("     3 - Hledání v uložených kontaktech"); //potom  udelat jestli chce hledani podle tel.cisla nebo jmena
            print("----------------------------------------------------------");
            print("     0 - Ukončení programu");
            int menu = int.Parse(Console.ReadLine());
            return menu;
        }

        static string addNewName()
        {
            print("Zadejte jméno nového kontaktu:");
            string newContact = Console.ReadLine();
            return newContact;
           
        }

       /* static string addArrays(string[] kontakty, string[] numbers, int countItems)
        {
            //string[] kontakt = new string[numberOfUsers];
            string[] arrayP1P2 = new string[countItems];
            /*for (int i = 0; i < countItems; i++)
            {
                return arrayP1P2;
            }*/
            /*return arrayP1P2.ToArray();
        }*/
        static string addNewNumber()
        {
            print("Zadejte telefonní číslo kontaktu:");
            string newNumber = Console.ReadLine();
            return newNumber;
        }
        static void print(string StringToPrint = " ")
        {
            Console.WriteLine(StringToPrint);
        }
        static void Main(string[] args)
        {
            int menu, count = 0;
            const int numberOfUsers = 1000;
            string[] kontakt = new string[numberOfUsers];
            string[] number = new string[numberOfUsers];
            for (int i = 0; i < numberOfUsers; i++)
            {
                number[i] = "0";
                kontakt[i] = "0";
            }
            do {
                Console.Clear();
                menu = menuVolba();
                if (menu == 1)
                {
                    kontakt[count] = addNewName();
                    number[count] = addNewNumber();
                    count = count + 1;
                }
            } while (menu != 0);

            string[] kontakty = kontakt.Take(count).Distinct().ToArray();
            string[] numbers = number.Take(count).Distinct().ToArray();

            string[] arrayContactNumber = new string[kontakty.Length];
            arrayContactNumber = kontakty.Concat(numbers).ToArray();
            for (int i = 0; i < kontakty.Length; i++)
            {
                print(arrayContactNumber[i]);
            }
            Console.WriteLine(arrayContactNumber);
            /*string[] arrayContactNumber = new string[kontakty.Length];
            for (int i = 0; i < arrayContactNumber.Length; i++)
            {
                arrayContactNumber[i] = kontakty[i] + numbers[i];
            }*/
            foreach (var s in kontakty)
            {
                Console.WriteLine(s);
            }
            foreach (var s in numbers)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
