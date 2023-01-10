using RasmusAB.Models;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace RasmusAB
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Användarregister.SkapaKunder();
            //Admin.LäggTillProdukt();
            //Admin.LäggTillKategori();
            Kund.RunMe();
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

            //FÖRSÖKTE LOGGA IN, SYFTE: SE OM ANVÄNDARE HADE SAMMA ANVÄNDARNAMN
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

            //LÄGGER TILL TESTKUND
            //var db = new RasmusABContext();
            //Kund k = new Kund("Kund1", "Kund123")
            //{
            //    Username = "Kund1",
            //    Password = "Kund123"
            //};
            //db.Kunder.Add(k);

            ////TAR BORT KUDNER FRÅN DATABAS
            ////db.Kunder.Remove(db.Kunder.Find(7));
            ////db.SaveChanges();

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (Exception err)
            //{
            //    Console.WriteLine("Det gick inte att spara personen");
            //    Console.WriteLine("Du försökte spara en person med följande data: " + k.Username + "-" + k.Password);
            //    Console.WriteLine(err.InnerException.Message);
            //}
            //k.RunMe();
        }
    }
}