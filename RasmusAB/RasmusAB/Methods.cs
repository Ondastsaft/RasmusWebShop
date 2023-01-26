using Microsoft.EntityFrameworkCore;
using RasmusAB.Models;

namespace RasmusAB
{
    internal class Methods
    {
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
            Lägg_Till_produkt = 1,
            Ändra_Produkt,
            Ta_Bort_Produkt,
            Avsluta

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
        //Start
        public static bool StartMeny()
        {
            Console.Clear();
            bool quit = false;

            Console.WriteLine($"Välkommen till Rasmus AB! \n");

            Console.WriteLine($"{(int)MenuList.ShowCategory}. Kategorier");
            Console.WriteLine($"{(int)MenuList.SearchProduct}. Sök produkt");
            Console.WriteLine($"{(int)MenuList.Login}. Logga in");
            Console.WriteLine($"{(int)MenuList.Quit}. Avsluta");

            int nr;
            MenuList menu = (MenuList)66; // Default
            if (int.TryParse(Console.ReadLine(), out nr))
            {
                menu = (MenuList)nr;
                Console.Clear();
            }
            else
            {
                FelaktigInmatning();
                StartMeny();
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
                    break;
                case MenuList.Quit:
                    Console.WriteLine("Programmet avslutas");
                    Console.WriteLine("tryck valfri tangent för att fortsätta");
                    quit = true;
                    break;
            }
            return quit;
        }
        public static string LäggTillKund()
        {
            string name = " ";
            var db = new RasmusABContext();
            if (Program.AnvändarId == null)
            {
                Console.WriteLine("Ange Namn: ");
                name = Console.ReadLine();
                Console.WriteLine("Ange Adress: ");
                Console.WriteLine("Gata: ");
                var street = Console.ReadLine();
                Console.WriteLine("Stad: ");
                var city = Console.ReadLine();
                Console.WriteLine("Land: ");
                var country = Console.ReadLine();

                var användare = new Användare()
                {
                    Namn = name,
                    Gata = street,
                    Stad = city,
                    Land = country,
                };
                db.Användare.Add(användare);
                db.SaveChanges();
            }
            return name;
        }
        public static void LogIn()
        {
            //Console.WriteLine("Användarnamn: ");
            //string username = Console.ReadLine();

            ////Console.WriteLine("Lösenord: ");
            //string password = Console.ReadLine();
            string username = "Kund";
            string password = "Kund123";

            var db = new RasmusABContext();
            var user = db.Användare.Where(u => u.Username == username).FirstOrDefault();

            if (user != null)
            {
                if (user.Password == password && user.Password.Contains("Admin"))
                {
                    Program.IsAdmin = true;
                    Program.AnvändarId = user.AnvändareId;
                }
                else if (user.Password == password)
                {
                    var varukorgar = db.Varukorgar.Where(v => v.AnvändareId == user.AnvändareId).ToList();
                    Program.AnvändarId = user.AnvändareId;
                    if (varukorgar.Count() != 0)
                    {
                        bool påbörjadvarukorg = false;
                        foreach (Varukorg varukorg in varukorgar)
                        {
                            if (!varukorg.Slutbetald)
                            {
                                påbörjadvarukorg = true;
                            }
                        }
                        if (!påbörjadvarukorg)
                        {
                            user.Varukorgar.Add(new Varukorg());
                        }
                    }
                    else
                    {
                        user.Varukorgar.Add(new Varukorg());
                    }
                    db.SaveChanges();
                }
                else
                {
                    FelaktigInmatning();
                    LogIn();
                }
            }
        }

        //Admin
        public static void AdminMeny()
        {
            var db = new RasmusABContext();

            Console.Clear();
            MenuListAdmin menuAdmin = (MenuListAdmin)99;

            if (Program.IsAdmin == true)
            {
                bool loop = true;
                while (loop)
                {
                    int nr;
                    Console.Clear();
                    Console.WriteLine("Hej " + db.Användare.Where(a => a.AnvändareId == Program.AnvändarId).SingleOrDefault().Namn + "! \n");

                    Console.WriteLine($"{(int)MenuListAdmin.Produkt}. Produkter");
                    Console.WriteLine($"{(int)MenuListAdmin.Kategori}. Kategorier");
                    Console.WriteLine($"{(int)MenuListAdmin.Kunder}. Kunder");
                    Console.WriteLine($"{(int)MenuListAdmin.Quit}. Avsluta");



                    if (int.TryParse(Console.ReadLine(), out nr))
                    {
                        menuAdmin = (MenuListAdmin)nr;
                        Console.Clear();
                    }
                    else
                    {
                        FelaktigInmatning();
                        AdminMeny();
                    }

                    switch (menuAdmin)
                    {
                        case MenuListAdmin.Produkt:
                            Console.Clear();
                            AdminProduktMeny();
                            break;
                        case MenuListAdmin.Kategori:
                            Console.Clear();
                            AdminKategoriMeny();
                            break;
                        case MenuListAdmin.Kunder:
                            Console.Clear();
                            AdminKundMeny();
                            break;
                        case MenuListAdmin.Quit:
                            Environment.Exit(0);
                            break;
                    }
                }

            }

        }
        public static void AdminProduktMeny()
        {
            var db = new RasmusABContext();
            Console.Clear();
            int nr;
            ProduktMenyAdmin ProduktMenuAdmin = (ProduktMenyAdmin)99; // Default

            bool loop = true;
            while (loop)
            {
                Console.Clear();

                Console.WriteLine("Hej " + db.Användare.Where(a => a.AnvändareId == Program.AnvändarId).SingleOrDefault().Namn + "! \n");

                Console.WriteLine($"{(int)ProduktMenyAdmin.Lägg_Till_produkt}. Lägg till Produkt");
                Console.WriteLine($"{(int)ProduktMenyAdmin.Ändra_Produkt}. Ändra Produkt");
                Console.WriteLine($"{(int)ProduktMenyAdmin.Ta_Bort_Produkt}. Ta bort Produkt");
                Console.WriteLine($"{(int)ProduktMenyAdmin.Avsluta}. Avsluta");

                if (int.TryParse(Console.ReadLine(), out nr))
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
                    case ProduktMenyAdmin.Lägg_Till_produkt:
                        LäggTillProdukt();
                        break;
                    case ProduktMenyAdmin.Ändra_Produkt:
                        ÄndraProdukt();
                        break;
                    case ProduktMenyAdmin.Ta_Bort_Produkt:
                        TaBortProdukt();
                        break;
                    case ProduktMenyAdmin.Avsluta:
                        loop = false;
                        break;
                }
            }

        }
        public static void AdminKategoriMeny()
        {
            Console.Clear();
            int nr;
            KategoriMenyAdmin KategoriMenuAdmin = (KategoriMenyAdmin)99; // Default

            Console.WriteLine($"{(int)KategoriMenyAdmin.Lägg_Till_Kategori}. Lägg till Kategori");
            Console.WriteLine($"{(int)KategoriMenyAdmin.Ta_Bort_Kategori}. Ta bort Kategori");

            if (int.TryParse(Console.ReadLine(), out nr))
            {
                KategoriMenuAdmin = (KategoriMenyAdmin)nr;
                Console.Clear();
            }
            else
            {
                FelaktigInmatning();
                AdminKategoriMeny();
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
        }
        public static void AdminKundMeny()
        {
            Console.Clear();
            int nr;
            KundMenyAdmin KundMenuAdmin = (KundMenyAdmin)99; // Default
            Console.WriteLine($"{(int)KundMenyAdmin.Ändra_Kunduppgift}. Ändra Kunduppgifter");
            if (int.TryParse(Console.ReadLine(), out nr))
            {
                KundMenuAdmin = (KundMenyAdmin)nr;
                Console.Clear();
            }
            else
            {
                FelaktigInmatning();
                AdminKundMeny();
            }
            switch (KundMenuAdmin)
            {
                case KundMenyAdmin.Ändra_Kunduppgift:
                    ÄndraKunduppgifter();
                    break;
            }

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
                Console.WriteLine("Id: " + kategori.KategoriId + " - " + kategori.Namn);
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

            Console.Clear();
            Console.WriteLine("Ny produkt tillagd:\n" +
                "Namn: " + namn + "\n" +
                "Färg: " + färg + "\n" +
                "Kategori-Id: " + kategoriId + "\n" +
                "Pris: " + pris + "\n" +
                "Antal: " + antal + "\n");
            GåTillbaka();
        }
        public static void ÄndraProdukt()
        {
            Console.Clear();
            var db = new RasmusABContext();
            foreach (var produkt in db.Produkter)
            {
                Console.WriteLine(produkt.Namn + " - ID: " + produkt.ProduktId);
            }
            bool changeProduct = true;
            while (changeProduct == true)
            {
                Console.WriteLine("Vilken produkt vill du ändra? (Skriv ProduktID)");
                var chosenProductId = int.Parse(Console.ReadLine());
                Console.Clear();
                var chosenProduct = db.Produkter.Where(p => p.ProduktId == chosenProductId).SingleOrDefault();

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
                if (answer == "J" || answer == "j")
                {
                    db.SaveChanges();
                    changeProduct = false;
                    GåTillbaka();
                }
                if (answer == "N")
                {

                }
            }

        }
        public static void TaBortProdukt()
        {
            Console.Clear();
            var db = new RasmusABContext();
            foreach (var produkt in db.Produkter)
            {
                Console.WriteLine(produkt.Namn + " - ID: " + produkt.ProduktId);
            }

            Console.WriteLine("Vilken produkt vill du ta bort? (Skriv ProduktID)");
            var chosenProductId = int.Parse(Console.ReadLine());
            var chosenProduct = db.Produkter.Where(p => p.ProduktId == chosenProductId).SingleOrDefault();
            db.Remove(chosenProduct);
            db.SaveChanges();
        }
        public static void LäggTillKategori()
        {
            Console.Clear();
            var db = new RasmusABContext();

            Console.WriteLine("Ange namn: ");
            string kategoriNamn = Console.ReadLine();


            Kategori nyKategori = new Kategori()
            {
                Namn = kategoriNamn
            };

            db.Kategorier.Add(nyKategori);
            db.SaveChanges();
            Console.WriteLine("Ny kategori tillagd: \n" + kategoriNamn);
            GåTillbaka();
        }
        public static void TaBortKategori()
        {
            var db = new RasmusABContext();
            foreach (var kategori in db.Kategorier)
            {
                Console.WriteLine(kategori.Namn + " - ID: " + kategori.KategoriId);
            }

            Console.WriteLine("Vilken kategori vill du ta bort? (Skriv KategoriID)");
            var chosenCategoryId = int.Parse(Console.ReadLine());
            var chosenCategory = db.Kategorier.Where(k => k.KategoriId == chosenCategoryId).SingleOrDefault();
            db.Remove(chosenCategory);
            db.SaveChanges();
        }
        public static void ÄndraKunduppgifter()
        {
            var db = new RasmusABContext();

            foreach (var användare in db.Användare)
            {
                Console.WriteLine(användare.Username + " - ID: " + användare.AnvändareId);
            }
            bool changeanvändare = true;
            while (changeanvändare == true)
            {
                Console.WriteLine("Vilken användare vill du ändra? (Skriv AnvändarID)");
                var chosenUserId = int.Parse(Console.ReadLine());
                var chosenUser = db.Användare.Where(a => a.AnvändareId == chosenUserId).SingleOrDefault();

                Console.WriteLine(chosenUser.Username + "\n" + "Nytt användarnamn: ");
                var newUsername = Console.ReadLine();
                chosenUser.Username = newUsername;
                Console.WriteLine(chosenUser.Password + "\n" + "Nytt lösenord: ");
                var newPassword = Console.ReadLine();
                chosenUser.Password = newPassword;
                Console.WriteLine(chosenUser.Namn + "\n" + "Nytt namn: ");
                var newName = Console.ReadLine();
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

                Console.WriteLine("Ändrad användare: " + "\n" + newUsername + "\n" + newPassword + "\n" + newName + "\n" + "Adress: " + newStreet + " " + newCity + " " + newCountry + "\n" + "+46" + newTel + "\n" + newEmail);

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
        public static void FelaktigInmatning()
        {
            Console.WriteLine("Fel inmatning");
            Console.WriteLine("Tryck valfri tangent för att fortsätta");
            Console.ReadKey();
            Console.Clear();
        }


        //Kund
        public static void KundMeny()
        {
            var db = new RasmusABContext();

            bool quit = false;
            int nr;
            MenyKund menuCustomer = (MenyKund)99;

            bool loop = true;

            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Hej " + db.Användare.Where(k => k.AnvändareId == Program.AnvändarId).SingleOrDefault().Namn + "! \n");

                Console.WriteLine($"{(int)MenyKund.ShowCategory}. Visa Kategorier");
                Console.WriteLine($"{(int)MenyKund.SearchProduct}. Sök Produkt");
                Console.WriteLine($"{(int)MenyKund.ShopingCart}. Varukorg");
                Console.WriteLine($"{(int)MenyKund.Quit}. Avsluta");

                // Default
                if (int.TryParse(Console.ReadLine(), out nr))
                {
                    Console.Clear();
                    menuCustomer = (MenyKund)nr;
                }
                else
                {
                    FelaktigInmatning();
                    KundMeny();
                }
                switch (menuCustomer)
                {
                    case MenyKund.ShowCategory:
                        VisaKategori();
                        break;
                    case MenyKund.SearchProduct:
                        FritextSöka();
                        break;
                    case MenyKund.ShopingCart:
                        VisaVarukorg();
                        break;
                    case MenyKund.Quit:
                        Environment.Exit(0);
                        break;
                }
            }


            //Console.WriteLine($"{(int)MenyKund.ShowCategory}. Kategorier");
            //Console.WriteLine($"{(int)MenyKund.SearchProduct}. Sök produkt");
            //Console.WriteLine($"{(int)MenyKund.ShopingCart}. Varukorg");
            //Console.WriteLine($"{(int)MenyKund.Quit}. Avsluta");

            //MenyKund menuKund = (MenyKund)99; // Default
            //if (int.TryParse(Console.ReadLine(), out nr))
            //{
            //    menuKund = (MenyKund)nr;
            //    Console.Clear();
            //}
            //else
            //{
            //    Console.WriteLine("Fel inmatning");
            //}
            //switch (menuKund)
            //{
            //    case MenyKund.ShowCategory:
            //        VisaKategori();
            //        break;
            //    case MenyKund.SearchProduct:
            //        break;
            //    case MenyKund.ShopingCart:

            //        break;
            //    case MenyKund.Quit:
            //        break;
            //}


        }
        public static void PrintAnvändare()
        {
            var db = new RasmusABContext();
            Användare inloggadAnvändare = new Användare();

            inloggadAnvändare = db.Användare.Where(u => u.AnvändareId == Program.AnvändarId).SingleOrDefault();
            Console.WriteLine(inloggadAnvändare.Username);
        }
        public static void FritextSöka()
        {
            var db = new RasmusABContext();

            Console.WriteLine("Sök produkt: ");
            var searchedProduct = Console.ReadLine();
            var foundProducts = db.Produkter.Where(p => p.Namn.Contains(searchedProduct));

            if (foundProducts != null)
            {

                foreach (var p in foundProducts)
                {
                    Console.WriteLine(p.ProduktId + ". " + p.Namn);

                }
                if (Program.AnvändarId != 0)
                {
                    Console.WriteLine("Vill du lägga till produkten i din varukorg? (J/N)");
                    var choise = Console.ReadLine();
                    if (choise == "j" || choise == "J")
                    {
                        int id;
                        Console.WriteLine("Ange index för vald produkt");
                        int.TryParse(Console.ReadLine(), out id);
                        LäggProduktIVarukorg(id);
                    }
                }
            }
            else if (foundProducts == null)
            {
                Console.WriteLine("Tyvärr finns ingen produkt med ditt sökord :(");
            }
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
            Console.Clear();
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
            Console.Clear();
            var db = new RasmusABContext();
            var result = db.Produkter.Where(p => p.KategoriId == foreignKey);
            int index = 1;
            List<int> produktId = new List<int>();
            foreach (var produkt in result)
            {
                Console.WriteLine(index + ". " + produkt.Namn);
                produktId.Add(produkt.ProduktId);
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
            Console.Clear();
            var db = new RasmusABContext();

            var product = db.Produkter.Where(p => p.ProduktId == produktId).SingleOrDefault();
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
                GåTillbaka();
            }
            else
            {
                GåTillbaka();
            }

        }
        public static void LäggProduktIVarukorg(int productId)
        {
            Console.Clear();
            var db = new RasmusABContext();
            var product = db.Produkter.Where(p => p.ProduktId == productId).SingleOrDefault();
            Console.WriteLine("Välj antal: ");
            var amount = int.Parse(Console.ReadLine());
            var shopingcartProduct = new Varukorgsprodukt();
            shopingcartProduct.Produkt = product;
            shopingcartProduct.Antal = amount;
            if (Program.AnvändarId != 0)
            {
                db.Varukorgar.Where(v => v.Slutbetald == false && v.AnvändareId == Program.AnvändarId).SingleOrDefault().Varukorgsprodukter.Add(shopingcartProduct);
                //var varukorg = user.Varukorgar.Where(v => v.Slutbetald == false).SingleOrDefault();
                //varukorg.;

                //user.Varukorgar.Add(varukorg);
                //Program.TempVarukorg.Varukorgsprodukts.Add(shopingcartProduct);
                //var varukorg = db.Varukorgar.Where(v => v.Id == Program.TempVarukorg.Id).SingleOrDefault();
                //varukorg = Program.TempVarukorg;

                db.SaveChanges();
                db.Produkter.Where(p => p.Equals(product)).SingleOrDefault().Antal = (db.Produkter.Where(p => p.Equals(product)).SingleOrDefault().Antal - amount);
            }

            else
            {
                Program.TempVarukorg = new Varukorg();
                Program.TempVarukorg.Varukorgsprodukter.Add(shopingcartProduct);
                db.SaveChanges();
            }

        }
        public static void VisaVarukorg()
        {
            Console.Clear();
            var db = new RasmusABContext();
            var varukorg = db.Varukorgar.Where(v => v.Slutbetald == false && v.AnvändareId == Program.AnvändarId).SingleOrDefault();
            var varukorgsprodukter = db.Varukorgsprodukter.Where(v => v.VarukorgId == varukorg.VarukorgId).ToList();
            int index = 1;
            Console.WriteLine("Såhär ser din varukorg ut!");
            Console.WriteLine("--------------------------------------------------------------");
            foreach (var varukorgsprodukt in varukorgsprodukter)
            {
                var produkt = db.Produkter.Where(p => p.ProduktId == varukorgsprodukt.ProduktId).SingleOrDefault();
                Console.WriteLine(varukorgsprodukt.VarukorgsproduktId + ". " + produkt.Namn + "\n    Färg: " + produkt.Färg + "\n    Antal: " + varukorgsprodukt.Antal + "\n    Pris: " + produkt.Pris + "kr");
                index++;
            }
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Vänligen välj ett utav alternativen nedan för att gå vidare: \n");
            Console.WriteLine("Ändra produkt = 1");
            Console.WriteLine("Ta bort produkt = 2");
            Console.WriteLine("Gå vidare till frakt = 3");
            Console.WriteLine("Tillbaka = 4");

            bool successfullchoise = false;
            int val = 0;
            while (!successfullchoise)
            {
                successfullchoise = int.TryParse(Console.ReadLine(), out val);
            }
            switch (val)
            {
                case 1:
                    ÄndraAntalIVarukorg();
                    break;
                case 2:
                    TaBortProduktIVarukorg();
                    break;
                case 3:
                    Frakt();
                    break;
                case 4:
                    break;
            }

        }
        public static void LäggTillAnvändare()
        {
            Console.Clear();
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

            var användare = new Användare()
            {
                Namn = name,
                Gata = street,
                Stad = city,
                Land = country,
            };
            db.Användare.Add(användare);
            db.SaveChanges();
            int Id = db.Användare.Where(a => a.Namn == name).SingleOrDefault().AnvändareId;
            Program.AnvändarId = Id;

        }
        public static void Frakt()
        {
            if (Program.AnvändarId == null)
            {
                LäggTillAnvändare();
            }

            if (Program.AnvändarId != null)
            {
                var db = new RasmusABContext();
                int varukorgsid = 0;
                varukorgsid = db.Varukorgar.Where(v => v.AnvändareId == Program.AnvändarId && !v.Slutbetald).FirstOrDefault().VarukorgId;
                if (varukorgsid != null)
                {
                    var order = new Order();
                    Console.Clear();
                    Console.WriteLine("Leverantörer");
                    Console.WriteLine("-------------------------------------");

                    foreach (var leverantör in db.Leverantörer)
                    {
                        Console.WriteLine(leverantör.LeverantörId + ". " + leverantör.Name + " " + leverantör.Price + "Kr");
                    }
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Välj en leverantör (Id)");
                    int choise = int.Parse(Console.ReadLine());
                    order.Leverantör = db.Leverantörer.Where(L => L.LeverantörId == choise).SingleOrDefault();
                    db.Leverantörer.Where(L => L.LeverantörId == choise).SingleOrDefault().Orders.Add(order);
                    Console.WriteLine("Slutför beställning? (J/N)");
                    string val = Console.ReadLine();
                    if (val == "J" || val == "j")
                    {
                        var varukorg = db.Varukorgar.Where(v => v.VarukorgId == varukorgsid).SingleOrDefault();
                        varukorg.Order = order;
                        Console.Clear();
                        order = BetalaOrder(order);
                        varukorg.Slutbetald = true;
                        order.Summa = SummeraVarukorg(varukorg);
                        order.Moms = order.Summa * 0.2;
                        db.SaveChanges();
                        var user = db.Användare.Where(v => v.AnvändareId == varukorg.AnvändareId).FirstOrDefault();
                        user.Varukorgar.Add(new Varukorg());
                        db.SaveChanges();
                    }




                }

            }
        }
        public static int SummeraVarukorg(Varukorg varukorg)
        {
            var db = new RasmusABContext();
            int summa = 0;
            var varukorgsprodukter = db.Varukorgsprodukter.Where(v => v.VarukorgId == varukorg.VarukorgId).ToList();

            foreach (Varukorgsprodukt varukorgsprodukt in varukorgsprodukter)
            {
                var produkt = db.Produkter.Where(p => p.ProduktId == varukorgsprodukt.VarukorgsproduktId).SingleOrDefault();
                summa = summa + (produkt.Pris * produkt.Antal);
            }
            return summa;
        }
        public static Order BetalaOrder(Order order)
        {
            SummeraVarukorg();
            Console.WriteLine();
            Console.WriteLine("\nBetalningsmetod \n---------------\n " +
                "Vänligen skriv ett utav alternativen nedan: " +
                "\n - Swish " +
                "\n - Kort");
            order.BetalningsUppgifter = Console.ReadLine();
            Console.WriteLine("--------------------------------------------");
            string val;
            Console.WriteLine("Slutför betalning? (J/N)");
            val = Console.ReadLine();
            if (val == "J" || val == "j")
            {
                order.Slutbetald = true;
                Console.Clear();
                Console.WriteLine("Order slutbetald, order skickas inom en arbetsdag!\n");
                GåTillbaka();

            }

            else
            {
                Console.WriteLine("Du har valt att inte slutbetala ordern");
                GåTillbaka();
            }
            return order;

        }
        public static void ÄndraAntalIVarukorg()
        {
            Console.Clear();
            var db = new RasmusABContext();
            var varukorgsprodukter = db.Varukorgsprodukter.Where(v => v.VarukorgId == 1).ToList();

            foreach (var varukorgsprodukt in varukorgsprodukter)
            {
                var produkt = db.Produkter.Where(p => p.ProduktId == varukorgsprodukt.ProduktId).SingleOrDefault();
                Console.WriteLine(varukorgsprodukt.VarukorgsproduktId + ". " + produkt.Namn + "\n    Färg: " + produkt.Färg + "\n    Antal: " + varukorgsprodukt.Antal + "\n    Pris: " + produkt.Pris + "kr");
            }

            Console.WriteLine("Välj produkt att ändra antal på: ");
            var chosenProductAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("Välj nytt antal: ");
            var newAmount = int.Parse(Console.ReadLine());
            int id = db.Varukorgsprodukter.Where(p => p.VarukorgsproduktId == chosenProductAmount).SingleOrDefault().VarukorgsproduktId;
            db.Varukorgsprodukter.Where(v => v.VarukorgsproduktId == id).SingleOrDefault().Antal = newAmount;
            db.SaveChanges();
            Console.WriteLine("Ändringen lyckades! :)");
            GåTillbaka();
        }
        public static void TaBortProduktIVarukorg()
        {
            Console.Clear();
            var db = new RasmusABContext();
            var varukorgsprodukter = db.Varukorgsprodukter.Where(v => v.VarukorgId == 1).ToList();

            foreach (var varukorgsprodukt in varukorgsprodukter)
            {
                var produkt = db.Produkter.Where(p => p.ProduktId == varukorgsprodukt.ProduktId).SingleOrDefault();
                Console.WriteLine(varukorgsprodukt.VarukorgsproduktId + ". " + produkt.Namn + "\n    Färg: " + produkt.Färg + "\n    Antal: " + varukorgsprodukt.Antal + "\n    Pris: " + produkt.Pris + "kr");
            }

            Console.WriteLine("Vänligen välj produkt att ta bort (Ange produktId):");
            var chosenProductDelete = int.Parse(Console.ReadLine());

            int id = db.Varukorgsprodukter.Where(p => p.VarukorgsproduktId == chosenProductDelete).SingleOrDefault().VarukorgsproduktId;
            db.Remove(db.Varukorgsprodukter.Where(v => v.VarukorgsproduktId == id).SingleOrDefault());
            db.SaveChanges();
            Console.Clear();
            Console.WriteLine("Produkten du har valt har tagits bort!");
            GåTillbaka();
        }
        public static void SummeraVarukorg()
        {
            var db = new RasmusABContext();
            var varukorgsId = db.Varukorgar.Where(v => v.AnvändareId == Program.AnvändarId).FirstOrDefault().VarukorgId;

            var varukorgsprodukter = db.Varukorgsprodukter.Where(v => v.VarukorgId == varukorgsId).ToList();
            int index = 1;
            int orderSumma = 0;
            Console.WriteLine("Produkter");
            Console.WriteLine("------------------------------------------------");
            foreach (var varukorgsprodukt in varukorgsprodukter)
            {
                var produkt = db.Produkter.Where(p => p.ProduktId == varukorgsprodukt.ProduktId).SingleOrDefault();
                Console.WriteLine(varukorgsprodukt.VarukorgsproduktId + ". " + produkt.Namn + "\n    Färg: " + produkt.Färg + "\n    Antal: " + varukorgsprodukt.Antal + "\n    Pris: " + produkt.Pris + "kr");
                index++;
                orderSumma = orderSumma + (varukorgsprodukt.Antal * produkt.Pris);
            }
            Console.WriteLine("------------------------------------------------");
            //int varukorgsId = db.Användare.Where(a => a.Id == Program.AnvändarId).SingleOrDefault().VarukorgsId;
            double moms = (orderSumma * 0.2);
            Console.WriteLine("Ordersumma total = " + orderSumma + " var av moms = " + moms);
        }
        public static void GåTillbaka()
        {
            Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn :)");
            Console.ReadKey();
        }


        //Dev
        public static void LäggTillTestAnvändare()
        {
            var db = new RasmusABContext();

            Användare k = new Användare()
            {
                Username = "Kund",
                Password = "Kund123",
                Namn = "Hassan",
                Gata = "Kundgatan 1",
                Stad = "Kundstaden",
                Land = "Sverige",
                Telefonnummer = 0701234567,
                Email = "Kund@hotmail.com",
                Admin = false,

            };
            db.Användare.Add(k);

            Användare a = new Användare()
            {
                Username = "Admin",
                Password = "Admin123",
                Namn = "Sara",
                Gata = "Admingatan 1",
                Stad = "Adminstaden",
                Land = "Sverige",
                Telefonnummer = 0739876543,
                Email = "Admin@hotmail.com",
                Admin = true,

            };
            db.Användare.Add(a);
            db.SaveChanges();

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
        public static void SkapaLeverantör()
        {
            var db = new RasmusABContext();

            Leverantör PostNord = new Leverantör()
            {
                Name = "PostNord",
                Price = 49,
            };
            Leverantör DHL = new Leverantör()
            {
                Name = "DHL",
                Price = 29,
            };
            Leverantör EarlyBird = new Leverantör()
            {
                Name = "EarlyBird",
                Price = 99,
            };

            db.Leverantörer.Add(PostNord);
            db.Leverantörer.Add(DHL);
            db.Leverantörer.Add(EarlyBird);
            db.SaveChanges();
        }
        public static void LäggTillTestKategorier()
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

        //public static bool RunMe()
        //{
        //    bool quit = false;

        //    Console.WriteLine($"Välkommen till Rasmus AB!");

        //    Console.WriteLine($"{(int)MenuList.ShowCategory}. Kategorier");
        //    Console.WriteLine($"{(int)MenuList.SearchProduct}. Sök produkt");
        //    Console.WriteLine($"{(int)MenuList.Login}. Logga in");
        //    Console.WriteLine($"{(int)MenuList.Quit}. Avsluta");

        //    int nr;
        //    MenuList menu = (MenuList)99; // Default
        //    if (int.TryParse(Console.ReadLine(), out nr))
        //    {
        //        menu = (MenuList)nr;
        //        Console.Clear();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Fel inmatning");
        //    }

        //    switch (menu)
        //    {
        //        case MenuList.ShowCategory:
        //            VisaKategori();
        //            break;
        //        case MenuList.SearchProduct:
        //            Console.WriteLine("Sök produkt");
        //            break;
        //        case MenuList.Login:
        //            LogIn();
        //            if (Program.IsAdmin == true)
        //            {
        //                Console.WriteLine($"{(int)MenuListAdmin.Produkt}. Produkter");
        //                Console.WriteLine($"{(int)MenuListAdmin.Kategori}. Kategorier");
        //                Console.WriteLine($"{(int)MenuListAdmin.Kunder}. Kunder");
        //                Console.WriteLine($"{(int)MenuListAdmin.Quit}. Avsluta");

        //                MenuListAdmin menuAdmin = (MenuListAdmin)99; // Default
        //                if (int.TryParse(Console.ReadLine(), out nr))
        //                {
        //                    menuAdmin = (MenuListAdmin)nr;
        //                    Console.Clear();
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Fel inmatning");
        //                }
        //                switch (menuAdmin)
        //                {
        //                    case MenuListAdmin.Produkt:
        //                        ProduktMenyAdmin ProduktMenuAdmin = (ProduktMenyAdmin)99; // Default

        //                        Console.WriteLine($"{(int)ProduktMenyAdmin.Lägg_Till_produkt}. Lägg till Produkt");
        //                        Console.WriteLine($"{(int)ProduktMenyAdmin.Ändra_Produkt}. Ändra Produkt");
        //                        Console.WriteLine($"{(int)ProduktMenyAdmin.Ta_Bort_Produkt}. Ta bort Produkt");

        //                        if (int.TryParse(Console.ReadLine(), out nr))
        //                        {
        //                            ProduktMenuAdmin = (ProduktMenyAdmin)nr;
        //                            Console.Clear();
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("Fel inmatning");
        //                        }
        //                        switch (ProduktMenuAdmin)
        //                        {
        //                            case ProduktMenyAdmin.Lägg_Till_produkt:
        //                                LäggTillProdukt();
        //                                break;
        //                            case ProduktMenyAdmin.Ändra_Produkt:
        //                                ÄndraProdukt();
        //                                break;
        //                            case ProduktMenyAdmin.Ta_Bort_Produkt:
        //                                TaBortProdukt();
        //                                break;
        //                        }
        //                        break;
        //                    case MenuListAdmin.Kategori:
        //                        KategoriMenyAdmin KategoriMenuAdmin = (KategoriMenyAdmin)99; // Default

        //                        Console.WriteLine($"{(int)KategoriMenyAdmin.Lägg_Till_Kategori}. Lägg till Kategori");
        //                        Console.WriteLine($"{(int)KategoriMenyAdmin.Ta_Bort_Kategori}. Ta bort Kategori");

        //                        if (int.TryParse(Console.ReadLine(), out nr))
        //                        {
        //                            KategoriMenuAdmin = (KategoriMenyAdmin)nr;
        //                            Console.Clear();
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("Fel inmatning");
        //                        }
        //                        switch (KategoriMenuAdmin)
        //                        {
        //                            case KategoriMenyAdmin.Lägg_Till_Kategori:
        //                                LäggTillKategori();
        //                                break;
        //                            case KategoriMenyAdmin.Ta_Bort_Kategori:
        //                                TaBortKategori();
        //                                break;
        //                        }
        //                        break;
        //                    case MenuListAdmin.Kunder:
        //                        KundMenyAdmin KundMenuAdmin = (KundMenyAdmin)99; // Default
        //                        Console.WriteLine($"{(int)KundMenyAdmin.Ändra_Kunduppgift}. Ändra Kunduppgifter");
        //                        if (int.TryParse(Console.ReadLine(), out nr))
        //                        {
        //                            KundMenuAdmin = (KundMenyAdmin)nr;
        //                            Console.Clear();
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("Fel inmatning");
        //                        }
        //                        switch (KundMenuAdmin)
        //                        {
        //                            case KundMenyAdmin.Ändra_Kunduppgift:
        //                                ÄndraKunduppgifter();
        //                                break;
        //                        }
        //                        break;
        //                }
        //            }
        //    }
        //}
    }
}
