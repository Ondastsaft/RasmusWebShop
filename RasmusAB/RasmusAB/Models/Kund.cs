using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasmusAB.Models
{
    public  class Kund : Användare
    {
        public int Id { get; set; }
        public Kund(string name, string password)
        {
            name = Username;
            password = Password;
        }
        private Kund()
        {

        }
        public void PrintKund()
        {
            Console.WriteLine("Jag är kund");
        }
        enum MenuList
        {
            ShowProducts = 1,
            LogIn = 2,
            SearchProduct = 3,

            Quit = 9
        }
        public override void RunMe()
        {
         
            bool loop = true;
            while (loop)
            {

                Console.WriteLine("test123");
                Console.WriteLine($"Välkommen {Username} till Rasmus AB!");

                Console.WriteLine($"{(int)MenuList.ShowProducts}. Kläder");
                //Console.WriteLine($"{(int)MenuList.LogIn}. Logga in");
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
            //base.RunMe();
        }
        public static void LogIn()
        {
            
            Console.WriteLine("Användarnamn: ");
            string username = Console.ReadLine();
            Console.WriteLine("Lösenord: ");
            string password = Console.ReadLine();

            for (int i = 0; i < Användarregister.kunder.Count; i++)
            {
                if (username.Contains(username))
                {
                    Console.WriteLine($"Välkommen {username}");
                }
            }
        }
    }
}
