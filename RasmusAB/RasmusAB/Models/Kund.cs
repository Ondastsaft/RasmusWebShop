using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasmusAB.Models
{
    public class Kund : Användare
    {
        public int Id { get; set; }
        public Kund(string name, string password) : base (name,password)
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
            Console.WriteLine($"Välkommen {name} till Rasmus AB!");
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
            base.RunMe();
        }
    }
}
