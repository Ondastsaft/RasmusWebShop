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
        public Kategori Kategori { get; set; }
        public virtual ICollection<Varukorg> Varukorgs { get; set; }

        public Produkt()
        {
            Varukorgs = new List<Varukorg>();
        }

        //public Produkt(string name, int categoryId, string colour, int price, int antal)
        //{
        //    name = Namn;
        //    categoryId = KategoriId;
        //    colour = Färg;
        //    price = Pris;
        //    antal = Antal;  
        //}

    }
}
