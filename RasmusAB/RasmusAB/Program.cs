using RasmusAB.Models;

namespace RasmusAB
{
    public class Program
    {
        public static Användare användare { get; set; }


        static void Main(string[] args)
        {
            //Användarregister.SkapaKunder();
            //Admin.LäggTillProdukt();
            //Admin.LäggTillKategori();
            //Kund.RunMe();
            //Kund.LäggTillKund();
            användare = new Användare();
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

            var db = new RasmusABContext();
            var user = db.Användare.Where(u => u.Username == username).FirstOrDefault();

            if (user.Password == password)
            {
                användare = user;
            }

            Console.WriteLine("Hej " + användare.Username + "!");

        }
    }
}