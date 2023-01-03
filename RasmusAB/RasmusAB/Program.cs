using RasmusAB.Models;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace RasmusAB
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new RasmusABContext();
            Kund testkund = new Kund("Kund1", "Kund123");
            db.Add(testkund);
            //db.Add(new Kund("Kund1", "Kund123"));

            db.SaveChanges();
            PrintMenu();

        }
        enum MenuList
        {
            ShowProducts = 1,
            LogIn = 2,
            SearchProduct = 3,

            Quit = 9
        }
        public static void PrintMenu()
        {
            Console.WriteLine("Välkommen till Rasmus AB!");
            bool loop = true;
            while (loop)
            {
                Console.WriteLine($"{(int)MenuList.ShowProducts}. Kläder");
                Console.WriteLine($"{(int)MenuList.LogIn}. Logga in");
                Console.WriteLine($"{(int)MenuList.SearchProduct}. Sök produkt");
                Console.WriteLine($"{(int)MenuList.Quit}. Avsluta");

                //foreach (int i in Enum.GetValues(typeof(MenuList)))
                //{
                //    Console.WriteLine($"{i}. {Enum.GetName(typeof(MenuList), i).Replace('_', ' ')}");
                //}

                int nr;
                MenuList menu = (MenuList)99; // Default
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {
                    menu = (MenuList)nr;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Fel inmatning");
                }

                switch (menu)
                {
                    case MenuList.ShowProducts:
                        Console.WriteLine("Kläder");
                        break;
                    case MenuList.LogIn:
                        LogIn();
                        break;
                    case MenuList.SearchProduct:
                        Console.WriteLine("Sök produkt");
                        break;
                    case MenuList.Quit:
                        loop = false;
                        break;
                }
            }
        }
        public static void LogIn()
        {
            Console.WriteLine("Användarnamn: ");
            string username = Console.ReadLine();

            Console.WriteLine("Lösenord: ");
            string password = Console.ReadLine();
            
            var Db = new RasmusABContext();

            var result = from a in Db.Användare                       
                         select a;

            result.ToList();
            foreach (var Användare in result)
            {
                Console.WriteLine(Användare.Username);
                Console.ReadKey();
            }
            //foreach(var Användare in result)
            //{
            //    if (Användare.Username == username && Användare.Password == password)
            //    {
            //        Användare.RunMe();
            //    }
            //}
            //if (result != null)
            //{
            //    result.RunMe
            //}
        }
    }
}