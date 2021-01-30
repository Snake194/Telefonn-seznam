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
            string menu = Console.ReadLine();
            if (menu.Length != 1)
            {
                return -1;
            }
            char menuChar = char.Parse(menu);
            if (Char.IsDigit(menuChar))
            {
                int i = (int)Char.GetNumericValue(menuChar);
                return i;
            }
            else
            {
                return -1;
            }
        }
        static List<User> createUserListCopy(List<User> users)
        {
            var tempUsers = new List<User>();
            foreach (var user in users)
            {
                var u = new User();
                u.number = user.number;
                u.surname = user.surname;
                tempUsers.Add(u);
            }
            return tempUsers;
        }
        static void printUserList(List<User> userList)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                User user = userList[i];
                print(i + 1 + ". " + user.surname + ": " + user.number);
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
                        printUserList(users);
                        break;

                    case 3: // sort by surname
                        List<User> tempUsers = createUserListCopy(users);
                        //users.Sort((u1, u2) => u1.LastName.CompareTo(u2.LastName));
                        tempUsers.Sort((u1, u2) => u1.surname.CompareTo(u2.surname));
                        printUserList(tempUsers);
                        break;

                    default:
                        Console.WriteLine("Neznámý příkaz: {0}", menu);
                        break;
                }
                Console.ReadKey();
            } while (menu != 0);
            //Console.WriteLine(users[0].number + " - " + users[0].surname);
            Console.ReadKey();
        }
    }
}
