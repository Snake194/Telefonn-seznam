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
            print("     2 - Vypsání seznamu");
            print("     3 - Vypsání seznamu dle příjmení");
            print("     4 - Vypsání seznamu dle čísla");
            print("     5 - Hledání v uložených kontaktech");
            print("----------------------------------------------------------");
            print("     0 - Ukončení programu");
            Char menu = char.Parse(Console.ReadLine());
            if (Char.IsDigit(menu))
            {
                int i = (int)Char.GetNumericValue(menu);
                return i;
            }
            else
            {
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
                    case 1: // ADD USER
                        var u = new User();
                        u.number = addNewNumber();
                        u.surname = addNewName();
                        users.Add(u);
                        break;
                    case 2: // print USERS in origin order
                        for (int i = 0; i < users.Count; i++)
                        {
                            User user = users[i];
                            print(i + 1 + ". " + user.surname + ": " + user.number);
                        }
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
