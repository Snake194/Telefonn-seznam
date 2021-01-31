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
            print("----------------------------------------------------------");
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
        static void end()
        {
            print("Stiskněte ENTER pro pokračování.");
            Console.ReadKey();
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
            return Contact.Trim();

        }

        static string inputNumber()
        {
            string Number;
            bool inputIsCorect = false;
            do
            {
                print("----------------------------------------------------------");
                print("Zadejte telefonní číslo:");
                Number = Console.ReadLine();
                for (int i = 0; i < Number.Length; i++)
                {
                    char c = Number[i];
                    if ((Char.IsDigit(c) == false) && (Char.IsWhiteSpace(c) == false) && (c != '-') && (c != '+'))
                    {
                        print("Špatný vstup - očekávám číslo, zadej znovu.");
                        inputIsCorect = false;
                        break;
                    }
                    else
                    {
                        inputIsCorect = true;
                    }
                }
            } while (!inputIsCorect);
            return Number.Trim();
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
                //Console.Clear();
                menu = menuVolba();
                switch (menu)
                {
                    case 0:
                        break;
                    case 1: // ADD USER
                        { 
                        var u = new User();
                        u.surname = inputSurname();
                        u.number = inputNumber();
                        users.Add(u);
                        print("Byl přidán uživatel: " + u.surname + " - " + u.number);
                        }
                        break;

                    case 2: // print USERS in origin order
                        printUserList(users);
                        end();
                        break;

                    case 3: // sort by surname
                        List<User> tempUsers = createUserListCopy(users);
                        tempUsers.Sort((u1, u2) => u1.surname.CompareTo(u2.surname));
                        printUserList(tempUsers);
                        end();
                        break;
                    case 4: // sort by number
                        List<User> tempnum = createUserListCopy(users);
                        tempnum.Sort((u1, u2) => u1.number.CompareTo(u2.number));
                        printUserList(tempnum);
                        end();
                        break;

                    case 5: // search by surname
                        string surnameToFind = inputSurname();
                        var findedUsers = from u in users
                                     where u.surname == surnameToFind
                                     select u;
                        if (findedUsers.Count() < 1)
                        {
                            print("Uživatel nenalezen!");
                        }
                        else
                        {
                            foreach (var findedUser in findedUsers)
                            {
                                print("Nalezen: " + findedUser.surname + " - " + findedUser.number);
                            }
                        }
                        end();
                        break;

                    case 6: // search by surname
                        string numberToFind = inputNumber();
                        var findedNums = from u in users
                                          where u.number == numberToFind
                                          select u;
                        if (findedNums.Count() < 1)
                        {
                            print("Číslo nenalezeno!");
                        }
                        else
                        {
                            foreach (var findedNum in findedNums)
                            {
                                print("Nalezeno: " + findedNum.number + " - " + findedNum.surname);
                            }
                        }
                        end();
                        break;

                    default:
                        Console.WriteLine("Neznámý příkaz: {0}", menu);
                        
                        end();
                        break;
                }
            } while (menu != 0);
            //Console.WriteLine(users[0].number + " - " + users[0].surname);
            //Console.ReadKey();
        }
    }
}
