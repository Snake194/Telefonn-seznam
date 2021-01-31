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
            print("     5 - Hledání v uložených kontaktech dle jména");
            print("     6 - Hledání v uložených kontaktech dle čísla");
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
        static string inputSurname()
        {
            print("Zadejte příjmení:");
            string Contact = Console.ReadLine();
            return Contact;

        }

        static string inputNumber()
        {
            print("Zadejte telefonní číslo:");
            string Number = Console.ReadLine();
            return Number;
        }
        static void print(string StringToPrint = " ")
        {
            Console.WriteLine(StringToPrint);
        }
        static void Main(string[] args)
        {
            int menu;
            var users = new List<User>();
            do
            {
                Console.Clear();
                menu = menuVolba();
                switch (menu)
                {
                    case 1: // ADD USER
                        var u = new User();
                        u.number = inputNumber();
                        u.surname = inputSurname();
                        users.Add(u);
                        break;

                    case 2: // print USERS in origin order
                        printUserList(users);
                        break;

                    case 3: // sort by surname
                        List<User> tempUsers = createUserListCopy(users);
                        tempUsers.Sort((u1, u2) => u1.surname.CompareTo(u2.surname));
                        printUserList(tempUsers);
                        break;
                    case 4:
                        List<User> tempnum = createUserListCopy(users);
                        tempnum.Sort((u1, u2) => u1.number.CompareTo(u2.number));
                        printUserList(tempnum);
                        break;

                    default:
                        Console.WriteLine("Neznámý příkaz: {0}", menu);
                        break;
                }
                Console.ReadKey();
            } while (menu != 0);
            //Console.WriteLine(users[0].number + " - " + users[0].surname);
            //Console.ReadKey();
        }
    }
}
