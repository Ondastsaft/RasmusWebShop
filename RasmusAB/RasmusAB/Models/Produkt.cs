using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasmusAB.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public int KategoriId { get; set; }
        public string Färg { get; set; }
        public int Pris { get; set; }
        public int Antal { get; set; }
        //public Produkt(string name, int categoryId, string colour, int price, int antal)
        //{
        //    name = Namn;
        //    categoryId = KategoriId;
        //    colour = Färg;
        //    price = Pris;
        //    antal = Antal;  
        //}
        private Produkt()
        {

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
    }
}
