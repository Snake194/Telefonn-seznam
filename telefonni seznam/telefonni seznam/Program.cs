using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telefonni_seznam
{
    public class User
    {
        public string number { get; set; }
        public string surname { get; set; }
    }
    class Program
    {
        static int menuVolba()
        {
            print("     1 - Vložení nového kontaktu(jméno + číslo)");
            print("     2 - Seřazení seznamu"); //potom  udelat jestli chce serazeni podle tel.cisla nebo jmena
            print("     3 - Hledání v uložených kontaktech"); //potom  udelat jestli chce hledani podle tel.cisla nebo jmena
            print("----------------------------------------------------------");
            print("     0 - Ukončení programu");
            string menu = Console.ReadLine();
            switch (menu)
            {
                case "1":
                case "2":
                case "3":
                case "0":
                    return Int32.Parse(menu);
                default:
                    return -1;
            }
        }
        

        static string addNewName()
        {
            print("Zadejte jméno nového kontaktu:");
            string newContact = Console.ReadLine();
            return newContact;
           
        }

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
            int menu;
            var users = new List<User>();
            do {
                Console.Clear();
                menu = menuVolba();
                switch (menu)
                {
                    case 1:
                        //var u = new User() { surname = addNewName(), number = addNewNumber() }
                        var u = new User();
                        u.number = addNewNumber();
                        u.surname = addNewName();
                        users.Add(u);
                        break;

                    default:
                        Console.WriteLine("Neznámý příkaz: {0}", menu);
                        break;
                }
                Console.ReadKey();
            } while (menu != 0);
            Console.WriteLine(users[0].number + " - " + users[0].surname);
            Console.ReadKey();
        }
    }
}
