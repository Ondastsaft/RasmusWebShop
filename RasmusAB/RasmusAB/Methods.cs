using RasmusAB.Models;

namespace RasmusAB
{
    internal class Methods
    {
        public static void PrintKund()
        {
            var db = new RasmusABContext();
            Användare inloggadAnvändare = new Användare();

            inloggadAnvändare = db.Användare.Where(u => u.Id == Program.AnvändarId).SingleOrDefault();
            Console.WriteLine(inloggadAnvändare.Username);
        }
        public static void LäggTillKund()
        {
            var db = new RasmusABContext();

            ////LÄGGER TILL Kategori (TRÖJOR)
            Kund k = new Kund()
            {
                Username = "Kund1",
                Password = "Kund123",
                MinVarukorg = new Varukorg(),
                //VarukorgsId = db.Varukorgar.Count() + 1
            };
            db.Kunder.Add(k);
            db.SaveChanges();

        }
        public static void LäggTillAdmin()
        {
            var db = new RasmusABContext();

            ////LÄGGER TILL Kategori (TRÖJOR)
            Admin a = new Admin()
            {
                Username = "Admin",
                Password = "Admin123",
            };
            db.Administratörer.Add(a);
            db.SaveChanges();
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
        public static void VisaKategori()
        {
            var db = new RasmusABContext();
            int index = 1;
            foreach (var kategori in db.Kategorier)
            {
                Console.WriteLine(kategori.Namn + " = " + index);
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
                    VisaSpecifikProdukt(produktId[val - 1]);
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
            if (val == "J")
            {
                //LäggProduktIVarukorg(product.Id);

            }
            else if (val == "N")
            {

            }

        }
        public static void LäggProduktIVarukorg(int productId)
        {
            var db = new RasmusABContext();
            var product = db.Produkter.Where(p => p.Id == productId).SingleOrDefault();
            int VarukorgsId = db.Varukorgar.Where(v => v.KundId == Program.AnvändarId).SingleOrDefault().Id;
            db.Varukorgar.Where(v => v.Id == VarukorgsId).SingleOrDefault().VarukorgensProdukter.Add(product);
            db.SaveChanges();
        }
        public void PrintAdmin()
        {
            Console.WriteLine("Jag är admin");
        }
        public static void LäggTillProdukt()
        {
            var db = new RasmusABContext();
            ////LÄGGER TILL T-SHIRTS (TRÖJOR)
            //Produkt p = new Produkt()
            //{
            //    Namn = "T-shirt",
            //    KategoriId = 1,
            //    Färg = "Röd",
            //    Pris = 70,
            //    Antal = 100
            //};
            //db.Produkter.Add(p);
            //db.SaveChanges();

            ////LÄGGER TILL HOODIES (TRÖJOR)
            //Produkt hoodie = new Produkt()
            //{
            //    Namn = "Hoodie",
            //    KategoriId = 1,
            //    Färg = "Svart",
            //    Pris = 150,
            //    Antal = 200
            //};
            //db.Produkter.Add(hoodie);
            //db.SaveChanges();

            ////LÄGGER TILL SKOJRTA
            //Produkt skjorta = new Produkt()
            //{
            //    Namn = "Skjorta",
            //    KategoriId = 1,
            //    Färg = "Vit",
            //    Pris = 200,
            //    Antal = 50
            //};
            //db.Produkter.Add(skjorta);
            //db.SaveChanges();

            ////LÄGGER TILL JEANS
            //Produkt jeans = new Produkt()
            //{
            //    Namn = "Jeans",
            //    KategoriId = 2,
            //    Färg = "Blå",
            //    Pris = 250,
            //    Antal = 100
            //};
            //db.Produkter.Add(jeans);
            //db.SaveChanges();

            ////LÄGGER TILL MJUKISBYXOR
            //Produkt mjukisbyxor = new Produkt()
            //{
            //    Namn = "Mjukisbyxor",
            //    KategoriId = 2,
            //    Färg = "Grå",
            //    Pris = 125,
            //    Antal = 150
            //};
            //db.Produkter.Add(mjukisbyxor);
            //db.SaveChanges();

            ////LÄGGER TILL SHORTS
            //Produkt shorts = new Produkt()
            //{
            //    Namn = "Shorts",
            //    KategoriId = 2,
            //    Färg = "Grön",
            //    Pris = 75,
            //    Antal = 200
            //};
            //db.Produkter.Add(shorts);
            //db.SaveChanges();

            ////LÄGGER TILL LÖPARSKOR
            //Produkt löparskor = new Produkt()
            //{
            //    Namn = "Löparskor",
            //    KategoriId = 3,
            //    Färg = "Svart",
            //    Pris = 250,
            //    Antal = 200
            //};
            //db.Produkter.Add(löparskor);
            //db.SaveChanges();

            ////LÄGGER TILL SNEAKERS
            //Produkt sneakers = new Produkt()
            //{
            //    Namn = "Sneakers",
            //    KategoriId = 3,
            //    Färg = "Rosa",
            //    Pris = 275,
            //    Antal = 100
            //};
            //db.Produkter.Add(sneakers);
            //db.SaveChanges();

            ////LÄGGER TILL SANDALER
            //Produkt sandaler = new Produkt()
            //{
            //    Namn = "Sandaler",
            //    KategoriId = 3,
            //    Färg = "Beige",
            //    Pris = 225,
            //    Antal = 150
            //};
            //db.Produkter.Add(sandaler);
            //db.SaveChanges();

            ////TAR BORT PRODUKT
            //db.Produkter.Remove(db.Produkter.Find(10));
            //db.SaveChanges();
        }
        public static void LäggTillKategori()
        {
            var db = new RasmusABContext();

            ////LÄGGER TILL Kategori (TRÖJOR)
            //Kategori k = new Kategori()
            //{
            //    Namn = "Tröjor"
            //};
            //db.Kategorier.Add(k);
            //db.SaveChanges();

            ////LÄGGER TILL Kategori (BYXOR)
            //Kategori k = new Kategori()
            //{
            //    Namn = "Byxor"
            //};
            //db.Kategorier.Add(k);
            //db.SaveChanges();

            ////LÄGGER TILL Kategori (SKOR)
            //Kategori k = new Kategori()
            //{
            //    Namn = "Skor"
            //};
            //db.Kategorier.Add(k);
            //db.SaveChanges();
        }
        //public static void PrintMenu()
        //{
        //    Console.WriteLine("Välkommen till Rasmus AB!");
        //    bool loop = true;
        //    while (loop)
        //    {
        //        Console.WriteLine($"{(int)MenuList.ShowProducts}. Kläder");
        //        Console.WriteLine($"{(int)MenuList.LogIn}. Logga in");
        //        Console.WriteLine($"{(int)MenuList.SearchProduct}. Sök produkt");
        //        Console.WriteLine($"{(int)MenuList.Quit}. Avsluta");

        //        //foreach (int i in Enum.GetValues(typeof(MenuList)))
        //        //{
        //        //    Console.WriteLine($"{i}. {Enum.GetName(typeof(MenuList), i).Replace('_', ' ')}");
        //        //}

        //        int nr;
        //        MenuList menu = (MenuList)99; // Default
        //        if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
        //        {
        //            menu = (MenuList)nr;
        //            Console.Clear();
        //        }
        //        else
        //        {
        //            Console.WriteLine("Fel inmatning");
        //        }

        //        switch (menu)
        //        {
        //            case MenuList.ShowProducts:
        //                Console.WriteLine("Kläder");
        //                break;
        //            case MenuList.LogIn:
        //                LogIn();
        //                break;
        //            case MenuList.SearchProduct:
        //                Console.WriteLine("Sök produkt");
        //                break;
        //            case MenuList.Quit:
        //                loop = false;
        //                break;
        //        }
        //    }
        //}
        public static void LogIn()
        {
            //Console.WriteLine("Användarnamn: ");
            //string username = Console.ReadLine();

            //Console.WriteLine("Lösenord: ");
            //string password = Console.ReadLine();

            //var db = new RasmusABContext();
            //var user = db.Användare.Where(u => u.Username == username).FirstOrDefault();

            //if (user.Password == password)
            //{
            //    användare = user;
            //}

            //Console.WriteLine("Hej " + användare.Username + "!");

        }


    }
}
