﻿using Microsoft.EntityFrameworkCore;
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
                Gata = "Kundgatan 1",
                Stad = "Kundstaden",
                Land = "Sverige",
                Telefonnummer = 0701234567,
                Email = "Kund@hotmail.com",
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
        enum MenyKund
        {
            ShowCategory = 1,
            SearchProduct,
            ShopingCart,

            Quit = 9
        }
        enum MenuListAdmin
        {
            Produkt = 1,
            Kategori,
            Kunder,
            Quit = 9

        }
        enum ProduktMenyAdmin
        {
            Lägg_Tiill_produkt = 1,
            Ändra_Produkt,
            Ta_Bort_Produkt,
            
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
                        Console.WriteLine($"{(int)MenuListAdmin.Produkt}. Produkter");
                        Console.WriteLine($"{(int)MenuListAdmin.Kategori}. Kategorier");
                        Console.WriteLine($"{(int)MenuListAdmin.Kunder}. Kunder");
                        Console.WriteLine($"{(int)MenuListAdmin.Quit}. Avsluta");

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

                                Console.WriteLine($"{(int)ProduktMenyAdmin.Lägg_Tiill_produkt}. Lägg till Produkt");
                                Console.WriteLine($"{(int)ProduktMenyAdmin.Ändra_Produkt}. Ändra Produkt");
                                Console.WriteLine($"{(int)ProduktMenyAdmin.Ta_Bort_Produkt}. Ta bort Produkt");

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

                                Console.WriteLine($"{(int)KategoriMenyAdmin.Lägg_Till_Kategori}. Lägg till Kategori");
                                Console.WriteLine($"{(int)KategoriMenyAdmin.Ta_Bort_Kategori}. Ta bort Kategori");

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
                                        LäggTillKategori();
                                        break;
                                    case KategoriMenyAdmin.Ta_Bort_Kategori:
                                        TaBortKategori();
                                        break;
                                }
                                break;
                            case MenuListAdmin.Kunder:
                                KundMenyAdmin KundMenuAdmin = (KundMenyAdmin)99; // Default
                                Console.WriteLine($"{(int)KundMenyAdmin.Ändra_Kunduppgift}. Ändra Kunduppgifter");
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
                                        ÄndraKunduppgifter();
                                        break;
                                }
                                break;
                        }
                    }
                    else if (Program.IsAdmin != true)
                    {
                        Console.WriteLine($"{(int)MenyKund.ShowCategory}. Visa Kategorier");
                        Console.WriteLine($"{(int)MenyKund.SearchProduct}. Sök Produkt");
                        Console.WriteLine($"{(int)MenyKund.ShopingCart}. Varukorg");
                        Console.WriteLine($"{(int)MenyKund.Quit}. Avsluta");

                        MenyKund menuCustomer = (MenyKund)99; // Default
                        if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                        {
                            menuCustomer = (MenyKund)nr;
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Fel inmatning");
                        }
                        switch(menuCustomer)
                        {
                            case MenyKund.ShowCategory:
                                VisaKategori();
                                break;
                            case MenyKund.SearchProduct:

                                break;
                            case MenyKund.ShopingCart:

                                break;
                            case MenyKund.Quit:
                                break;
                        }
                    }
                    {
                        Console.WriteLine($"{(int)MenyKund.ShowCategory}. Kategorier");
                        Console.WriteLine($"{(int)MenyKund.SearchProduct}. Sök produkt");
                        Console.WriteLine($"{(int)MenyKund.ShopingCart}. Varukorg");
                        Console.WriteLine($"{(int)MenyKund.Quit}. Avsluta");

                        MenyKund menuKund = (MenyKund)99; // Default
                        if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                        {
                            menuKund = (MenyKund)nr;
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Fel inmatning");
                        }
                        switch(MenyKund)
                        {
                            case MenyKund.ShowCategory:
                                VisaKategori();
                                break;
                            case MenyKund.SearchProduct:
                                break;
                            case MenyKund.ShopingCart:

                                break;
                            case MenyKund.Quit:
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
            Console.WriteLine("Välj antal: ");
            var amount = int.Parse(Console.ReadLine());
            var shopingcartProduct = new Varukorgsprodukt();
            shopingcartProduct.Produkt = product;
            shopingcartProduct.Antal = amount;
            db.Varukorgar.Where(v => v.AnvändarId == Program.AnvändarId).SingleOrDefault().Varukorgsprodukts.Add(shopingcartProduct);
            db.Produkter.Where(p => p.Equals(product)).SingleOrDefault().Antal = (db.Produkter.Where(p => p.Equals(product)).SingleOrDefault().Antal - amount);
            db.SaveChanges();
        }
        public static void VisaVarukorg()
        {
            var db = new RasmusABContext();

            var varukorgsprodukter = db.Varukorgar.Where(v => v.AnvändarId == Program.AnvändarId).SingleOrDefault().Varukorgsprodukts.ToList();
            int index = 1;
            foreach(var varukorgsprodukt in varukorgsprodukter)
            {
                var produkt = db.Produkter.Where(p => p.Id == varukorgsprodukt.ProduktId).SingleOrDefault();
                Console.WriteLine(index + ". " + produkt.Namn + " " + produkt.Färg + " " + varukorgsprodukt.Antal + " " + produkt.Pris);
                index++;
            }
            Console.WriteLine("Ändra produkt = 1");
            Console.WriteLine("Ta bort produkt = 2");
            Console.WriteLine("Gå vidare till frakt = 3");
            Console.WriteLine("Tillbaka = 4");

            int choise = int.Parse(Console.ReadKey().KeyChar.ToString());

            switch(choise)
            {
                case 1:
                    Console.WriteLine("Välj produkt att ändra antal på: ");
                    var chosenProductAmount = int.Parse(Console.ReadLine());
                    ÄndraAntalIVarukorg(varukorgsprodukter[chosenProductAmount].Produkt.Namn);
                    break;
                case 2:
                    var chosenProductDelete = int.Parse(Console.ReadLine());
                    TaBortProduktIVarukorg(varukorgsprodukter[chosenProductDelete].Produkt.Namn);
                    break;
                case 3:
                    Frakt();
                    break;
                case 4:
                    break;
            }

        }
        public static void Frakt()
        {
            var db = new RasmusABContext();

            

            Console.WriteLine("Ange Namn: ");
            var name = Console.ReadLine();
            Console.WriteLine("Ange Adress: ");
            Console.WriteLine("Gata: ");
            var street = Console.ReadLine();
            Console.WriteLine("Stad: ");
            var city = Console.ReadLine();
            Console.WriteLine("Land: ");
            var country = Console.ReadLine();

            Console.WriteLine("Välj leverantör: " + "\n" + 
                              "1. PostNord  49kr" + "\n" +
                              "2. DHL  29kr");
            var choise = int.Parse(Console.ReadLine());
            if (choise == 1)
            {

            }
            
        }
        public static void ÄndraAntalIVarukorg(string produktnamn)
        {
            var db = new RasmusABContext();

            Console.WriteLine("Välj nytt antal: ");
            var newAmount = int.Parse(Console.ReadLine());
            int id = db.Produkter.Where(p => p.Namn == produktnamn).SingleOrDefault().Id;
            db.Varukorgsprodukts.Where(v => v.ProduktId == id).SingleOrDefault().Antal = newAmount;
            db.SaveChanges();
        }
        public static void TaBortProduktIVarukorg(string produktnamn)
        {
            var db = new RasmusABContext();

            int id = db.Produkter.Where(p => p.Namn == produktnamn).SingleOrDefault().Id;            
            db.Remove(db.Varukorgsprodukts.Where(v => v.ProduktId == id).SingleOrDefault());
            db.SaveChanges();
        }
        public static void LäggTillProdukt()
        {
            var db = new RasmusABContext();

            //bool IsAdmin = db.Användare.Where(a => a.Id == Program.AnvändarId).SingleOrDefault().IsAdmin;
            //if (IsAdmin)
            //{
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

            //}


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

            Console.WriteLine("Ange namn: ");
            string kategoriNamn = Console.ReadLine();


            Kategori nyKategori = new Kategori()
            {
                Namn = kategoriNamn
            };
            db.Kategorier.Add(nyKategori);
            db.SaveChanges();

            ////LÄGGER TILL Kategori (TRÖJOR)
            //Kategori k = new Kategori()
            //{
            //    Namn = "Tröjor"
            //};
            //db.Kategorier.Add(k);
            //db.SaveChanges();

            ////LÄGGER TILL Kategori (BYXOR)
            //Kategori k1 = new Kategori()
            //{
            //    Namn = "Byxor"
            //};
            //db.Kategorier.Add(k1);
            //db.SaveChanges();

            ////LÄGGER TILL Kategori (SKOR)
            //Kategori k2 = new Kategori()
            //{
            //    Namn = "Skor"
            //};
            //db.Kategorier.Add(k2);
            //db.SaveChanges();
        }
        public static void TaBortKategori()
        {
            var db = new RasmusABContext();
            foreach (var kategori in db.Kategorier)
            {
                Console.WriteLine(kategori.Namn + " - ID: " + kategori.Id);
            }

            Console.WriteLine("Vilken kategori vill du ta bort? (Skriv KategoriID)");
            var chosenCategoryId = int.Parse(Console.ReadLine());
            var chosenCategory = db.Kategorier.Where(k => k.Id == chosenCategoryId).SingleOrDefault();
            db.Remove(chosenCategory);
            db.SaveChanges();
        }
        public static void ÄndraKunduppgifter()
        {
            var db = new RasmusABContext();

            foreach (var användare in db.Användare)
            {
                Console.WriteLine(användare.Username + " - ID: " + användare.Id);
            }
            bool changeanvändare = true;
            while (changeanvändare == true)
            {
                Console.WriteLine("Vilken användare vill du ändra? (Skriv AnvändarID)");
                var chosenUserId = int.Parse(Console.ReadLine());
                var chosenUser = db.Användare.Where(a => a.Id == chosenUserId).SingleOrDefault();

                Console.WriteLine(chosenUser.Username + "\n" + "Nytt namn: ");
                var newName = Console.ReadLine();
                chosenUser.Username = newName;
                Console.WriteLine(chosenUser.Password + "\n" + "Nytt lösenord: ");
                var newPassword = Console.ReadLine();
                chosenUser.Password = newPassword;
                Console.WriteLine("Adress: \n" + chosenUser.Gata + "\n" + "Ny gata: ");
                var newStreet = Console.ReadLine();
                Console.WriteLine(chosenUser.Stad + "\n" + "Ny stad: ");
                var newCity = Console.ReadLine();
                Console.WriteLine(chosenUser.Land + "\n" + "Nytt land: ");
                var newCountry = Console.ReadLine();
                Console.WriteLine(chosenUser.Telefonnummer + "\n" + "Nytt telefonnummer: ");
                var newTel = int.Parse(Console.ReadLine());
                Console.WriteLine(chosenUser.Email + "\n" + "Ny email: ");
                var newEmail = Console.ReadLine();
                chosenUser.Gata = newStreet;
                chosenUser.Stad = newCity;
                chosenUser.Land = newCountry;
                chosenUser.Telefonnummer = newTel;
                chosenUser.Email = newEmail;

                Console.WriteLine("Ändrad användare: " + "\n" + newName + "\n" + newPassword + "\n" + "Adress: " + newStreet + " " + newCity + " " + newCountry + "\n" + "+46" + newTel + "\n" + newEmail);

                Console.WriteLine("Vill du spara? (J/N)");
                var answer = Console.ReadLine();
                if (answer == "J")
                {
                    db.SaveChanges();
                    changeanvändare = false;
                }
                if (answer == "N")
                {
                    
                }
            }

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
