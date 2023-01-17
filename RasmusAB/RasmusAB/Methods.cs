using Microsoft.EntityFrameworkCore;
using RasmusAB.Models;

namespace RasmusAB
{
    internal class Methods
    {
        public static void PrintAnvändare()
        {
            var db = new RasmusABContext();
            Användare inloggadAnvändare = new Användare();

            inloggadAnvändare = db.Användare.Where(u => u.Id == Program.AnvändarId).SingleOrDefault();
            Console.WriteLine(inloggadAnvändare.Username);
        }
        public static void LäggTillAnvändare()
        {
            var db = new RasmusABContext();

            Användare k = new Användare()
            {
                Username = "Kund",
                Password = "Kund123",
                AnvändareVarukorg = new Varukorg(),
                IsAdmin = false,

            };
            db.Användare.Add(k);

            Användare a = new Användare()
            {
                Username = "Admin",
                Password = "Admin123",
                AnvändareVarukorg = new Varukorg(),
                IsAdmin = true,

            };
            db.Användare.Add(a);

            db.SaveChanges();

        }
        enum MenuList
        {
            ShowCategory = 1,
            SearchProduct,
            Login,

            Quit = 9
        }
        enum MenuListAdmin
        {
            Produkt = 1,
            Kategori,
            Kunder

        }
        enum ProduktMenyAdmin
        {
            Lägg_Tiill_produkt = 1,
            Ändra_Produkt,
            Ta_Bort_Produkt
        }
        enum KategoriMenyAdmin
        {
            Lägg_Till_Kategori = 1,
            Ta_Bort_Kategori
        }
        enum KundMenyAdmin
        {
            Ändra_Kunduppgift = 1,
        }
        public static bool RunMe()
        {
            bool quit = false;

            Console.WriteLine($"Välkommen till Rasmus AB!");


            Console.WriteLine($"{(int)MenuList.ShowCategory}. Kategorier");
            Console.WriteLine($"{(int)MenuList.SearchProduct}. Sök produkt");
            Console.WriteLine($"{(int)MenuList.Login}. Logga in");
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
                case MenuList.Login:
                    LogIn();
                    if(Program.IsAdmin == true)
                    {
                        MenuListAdmin menuAdmin = (MenuListAdmin)99; // Default
                        if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                        {
                            menuAdmin = (MenuListAdmin)nr;
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Fel inmatning");
                        }
                        switch (menuAdmin)
                        {
                            case MenuListAdmin.Produkt:
                                ProduktMenyAdmin ProduktMenuAdmin = (ProduktMenyAdmin)99; // Default
                                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                                {
                                    ProduktMenuAdmin = (ProduktMenyAdmin)nr;
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Fel inmatning");
                                }
                                switch (ProduktMenuAdmin)
                                {
                                    case ProduktMenyAdmin.Lägg_Tiill_produkt:
                                        LäggTillProdukt();
                                        break;
                                    case ProduktMenyAdmin.Ändra_Produkt:
                                        ÄndraProdukt();
                                        break;
                                    case ProduktMenyAdmin.Ta_Bort_Produkt:
                                        TaBortProdukt();
                                        break;
                                }
                                break;
                            case MenuListAdmin.Kategori:
                                KategoriMenyAdmin KategoriMenuAdmin = (KategoriMenyAdmin)99; // Default
                                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                                {
                                    KategoriMenuAdmin = (KategoriMenyAdmin)nr;
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Fel inmatning");
                                }
                                switch (KategoriMenuAdmin)
                                {
                                    case KategoriMenyAdmin.Lägg_Till_Kategori:
                                        break;
                                    case KategoriMenyAdmin.Ta_Bort_Kategori:
                                        break;
                                }
                                break;
                            case MenuListAdmin.Kunder:
                                KundMenyAdmin KundMenuAdmin = (KundMenyAdmin)99; // Default
                                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                                {
                                    KundMenuAdmin = (KundMenyAdmin)nr;
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Fel inmatning");
                                }
                                switch (KundMenuAdmin)
                                {
                                    case KundMenyAdmin.Ändra_Kunduppgift:
                                        break;
                                }
                                break;
                        }
                    }
                    break;
                case MenuList.Quit:
                    quit = true;
                    break;
            }
            //base.RunMe();
            return quit;
        }
        public static bool RunMeCheckAdmin(bool isadmin)
        {
            bool quit = false;
            if (isadmin)
            {
                RunAdmin();
            }
            else
            {
                RunCustomer();
            }
            return quit;
        }
        public static bool RunCustomer()
        {
            bool quit = false;
            return quit;
        }
        public static bool RunAdmin()
        {
            bool quit = false;
            return quit;
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
            string val = Console.ReadLine();
            if (val == "J" || val == "j")
            {
                LäggProduktIVarukorg(produktId);
                Console.WriteLine("Produkt " + product.Namn + " tillagd");
            }
            else if (val == "N")
            {

            }

        }
        public static void LäggProduktIVarukorg(int productId)
        {
            var db = new RasmusABContext();
            var product = db.Produkter.Where(p => p.Id == productId).SingleOrDefault();
            db.Varukorgar.Where(v => v.AnvändarId == Program.AnvändarId).SingleOrDefault().Produkters.Add(product);
            db.SaveChanges();
        }
        public static void LäggTillProdukt()
        {
            var db = new RasmusABContext();

            bool IsAdmin = db.Användare.Where(a => a.Id == Program.AnvändarId).SingleOrDefault().IsAdmin;
            if (IsAdmin)
            {
                Console.WriteLine("Ange namn: ");
                string namn = Console.ReadLine();

                Console.WriteLine("Ange färg: ");
                string färg = Console.ReadLine();

                foreach (var kategori in db.Kategorier)
                {
                    Console.WriteLine("Id: " + kategori.Id + " - " + kategori.Namn);
                }
                Console.WriteLine("Ange kategori-Id: ");
                int kategoriId = int.Parse(Console.ReadLine());

                Console.WriteLine("Ange pris: ");
                int pris = int.Parse(Console.ReadLine());

                Console.WriteLine("Ange antal: ");
                int antal = int.Parse(Console.ReadLine());

                Produkt nyprodukt = new Produkt()
                {
                    Namn = namn,
                    Färg = färg,
                    KategoriId = kategoriId,
                    Pris = pris,
                    Antal = antal,
                };
                db.Produkter.Add(nyprodukt);
                db.SaveChanges();

            }


        }
        public static void ÄndraProdukt()
        {
            var db = new RasmusABContext();
            foreach (var produkt in db.Produkter)
            {
                Console.WriteLine(produkt.Namn + " - ID: " + produkt.Id );
            }
            bool changeProduct = true;
            while(changeProduct = true)
            {
                Console.WriteLine("Vilken produkt vill du ändra? (Skriv ProduktID)");
                var chosenProductId = int.Parse(Console.ReadLine());
                var chosenProduct = db.Produkter.Where(p => p.Id == chosenProductId).SingleOrDefault();

                Console.WriteLine(chosenProduct.Namn + "\n" + "Nytt namn: ");
                var newName = Console.ReadLine();
                chosenProduct.Namn = newName;
                Console.WriteLine(chosenProduct.Färg + "\n" + "Ny färg: ");
                var newColor = Console.ReadLine();
                chosenProduct.Färg = newColor;
                Console.WriteLine(chosenProduct.Antal + "\n" + "Nytt antal: ");
                var newAmount = int.Parse(Console.ReadLine());
                Console.WriteLine(chosenProduct.Pris + "\n" + "Nytt pris: ");
                var newPrice = int.Parse(Console.ReadLine());
                Console.WriteLine("Ändrad produkt: " + "\n" + newName + "\n" + newColor + "\n" + newAmount + "\n" + newPrice);

                Console.WriteLine("Vill du spara? (J/N)");
                var answer = Console.ReadLine();
                if (answer == "J")
                {
                    db.SaveChanges();
                    changeProduct = false;
                }
                if (answer == "N")
                {

                }
            }

        }
        public static void TaBortProdukt()
        {
            var db = new RasmusABContext();
            foreach (var produkt in db.Produkter)
            {
                Console.WriteLine(produkt.Namn + " - ID: " + produkt.Id);
            }

            Console.WriteLine("Vilken produkt vill du ta bort? (Skriv ProduktID)");
            var chosenProductId = int.Parse(Console.ReadLine());
            var chosenProduct = db.Produkter.Where(p => p.Id == chosenProductId).SingleOrDefault();
            db.Remove(chosenProduct);
            db.SaveChanges();
        }
        public static void LäggTillKategori()
        {
            var db = new RasmusABContext();

            //LÄGGER TILL Kategori (TRÖJOR)
            Kategori k = new Kategori()
            {
                Namn = "Tröjor"
            };
            db.Kategorier.Add(k);
            db.SaveChanges();

            //LÄGGER TILL Kategori (BYXOR)
            Kategori k1 = new Kategori()
            {
                Namn = "Byxor"
            };
            db.Kategorier.Add(k1);
            db.SaveChanges();

            //LÄGGER TILL Kategori (SKOR)
            Kategori k2 = new Kategori()
            {
                Namn = "Skor"
            };
            db.Kategorier.Add(k2);
            db.SaveChanges();
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
            Console.WriteLine("Användarnamn: ");
            string username = Console.ReadLine();

            Console.WriteLine("Lösenord: ");
            string password = Console.ReadLine();

            var db = new RasmusABContext();
            var user = db.Användare.Where(u => u.Username == username).FirstOrDefault();

            if (user.Password == password && user.Password.Contains("Admin"))
            {
                Program.IsAdmin = true;
                Program.IsAdmin = user.IsAdmin;
                Console.WriteLine("Hej " + user.Username + "!");
            }
            else if (user.Password == password)
            {
                Program.AnvändarId = user.Id;
                Console.WriteLine("Hej " + user.Username + "!");

            }
            else
            {
                Console.WriteLine("Felaktigt namn eller lösenord, försök igen! ");
            }

        }

        public static void LäggTillTestprodukter()
        {

            var db = new RasmusABContext();
            ////LÄGGER TILL T-SHIRTS (TRÖJOR)
            Produkt p = new Produkt()
            {
                Namn = "T-shirt",
                KategoriId = 1,
                Färg = "Röd",
                Pris = 70,
                Antal = 100
            };
            db.Produkter.Add(p);
            db.SaveChanges();

            //LÄGGER TILL HOODIES (TRÖJOR)
            Produkt hoodie = new Produkt()
            {
                Namn = "Hoodie",
                KategoriId = 1,
                Färg = "Svart",
                Pris = 150,
                Antal = 200
            };
            db.Produkter.Add(hoodie);
            db.SaveChanges();

            //LÄGGER TILL SKOJRTA
            Produkt skjorta = new Produkt()
            {
                Namn = "Skjorta",
                KategoriId = 1,
                Färg = "Vit",
                Pris = 200,
                Antal = 50
            };
            db.Produkter.Add(skjorta);
            db.SaveChanges();

            //LÄGGER TILL JEANS
            Produkt jeans = new Produkt()
            {
                Namn = "Jeans",
                KategoriId = 2,
                Färg = "Blå",
                Pris = 250,
                Antal = 100
            };
            db.Produkter.Add(jeans);
            db.SaveChanges();

            //LÄGGER TILL MJUKISBYXOR
            Produkt mjukisbyxor = new Produkt()
            {
                Namn = "Mjukisbyxor",
                KategoriId = 2,
                Färg = "Grå",
                Pris = 125,
                Antal = 150
            };
            db.Produkter.Add(mjukisbyxor);
            db.SaveChanges();

            //LÄGGER TILL SHORTS
            Produkt shorts = new Produkt()
            {
                Namn = "Shorts",
                KategoriId = 2,
                Färg = "Grön",
                Pris = 75,
                Antal = 200
            };
            db.Produkter.Add(shorts);
            db.SaveChanges();

            //LÄGGER TILL LÖPARSKOR
            Produkt löparskor = new Produkt()
            {
                Namn = "Löparskor",
                KategoriId = 3,
                Färg = "Svart",
                Pris = 250,
                Antal = 200
            };
            db.Produkter.Add(löparskor);
            db.SaveChanges();

            //LÄGGER TILL SNEAKERS
            Produkt sneakers = new Produkt()
            {
                Namn = "Sneakers",
                KategoriId = 3,
                Färg = "Rosa",
                Pris = 275,
                Antal = 100
            };
            db.Produkter.Add(sneakers);
            db.SaveChanges();

            //LÄGGER TILL SANDALER
            Produkt sandaler = new Produkt()
            {
                Namn = "Sandaler",
                KategoriId = 3,
                Färg = "Beige",
                Pris = 225,
                Antal = 150
            };
            db.Produkter.Add(sandaler);
            db.SaveChanges();
        }

        public static void RensaTabell(string tabellensNamn)
        {
            var db = new RasmusABContext();
            //TAR BORT PRODUKT
            db.Database.ExecuteSqlRaw($"TRUNCATE TABLE [{tabellensNamn}]");
            db.SaveChanges();
        }


    }
}
