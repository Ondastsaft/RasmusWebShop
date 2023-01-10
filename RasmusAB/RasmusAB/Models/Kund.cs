using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RasmusAB.Models
{
    public class Kund : Användare
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
            ShowCategory = 1,
            SearchProduct,

            Quit = 9
        }
        public static void RunMe()
        {         
            bool loop = true;
            while (loop)
            {
                Console.WriteLine($"Välkommen till Rasmus AB!");

                Console.WriteLine($"{(int)MenuList.ShowCategory}. Kategorier");
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
                    case MenuList.ShowCategory:
                        VisaKategori();
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
        public static void VisaKategori()
        {
            var db = new RasmusABContext();
            int index = 1;
            foreach(var kategori in db.Kategorier)
            {
                Console.WriteLine(kategori.Namn + " = " + index);
                index++;
            }
            bool successfullchoise = false;
            int val = 0;
            while (!successfullchoise)
            {
                successfullchoise = int.TryParse(Console.ReadLine(),out val);
            }
            switch(val)
            {
                case 1:
                    VisaProdukter(1);
                    break;
                case 2:
                    VisaProdukter(2);
                    break;
                case 3:
                    VisaProdukter(3);
                    break;
            }
        }
        public static void VisaProdukter(int foreignKey)
        {
            var db = new RasmusABContext();
            var result = db.Produkter.Where(p => p.KategoriId == foreignKey);
            int index = 1;
            List<int> produktId = new List<int>();
            foreach (var produkt in result)
            {
                Console.WriteLine(index + ". " + produkt.Namn);
                produktId.Add(produkt.Id);
                index++;
            }
            bool successfullchoise = false;
            int val = 0;
            while (!successfullchoise)
            {
                successfullchoise = int.TryParse(Console.ReadLine(), out val);
            }
            switch (val)
            {
                case 1:
                    VisaSpecifikProdukt(produktId[val-1]);
                    break;
                case 2:
                    VisaSpecifikProdukt(produktId[val - 1]);
                    break;
                case 3:
                    VisaSpecifikProdukt(produktId[val - 1]);
                    break;
            }
        }
        public static void VisaSpecifikProdukt(int produktId)
        {
            var db = new RasmusABContext();

            var product = db.Produkter.Where(p => p.Id == produktId).SingleOrDefault();
            Console.WriteLine("Namn: " + product.Namn);
            Console.WriteLine("Färg: " + product.Färg);
            Console.WriteLine("Pris: " + product.Pris);
            Console.WriteLine("Antal i lager: " + product.Antal);
            Console.WriteLine("Lägg till produkt i varukorg? (J/N)");
            string val = Console.ReadKey().ToString().ToUpper();
            if(val == "J")
            {
                LäggProduktIVarukorg();
            }
            else if(val == "N")
            {

            }

        }
        public static void LäggProduktIVarukorg()
        {

        }
    }
}
