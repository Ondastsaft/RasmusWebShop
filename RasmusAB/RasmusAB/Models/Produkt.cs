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
        public virtual ICollection<Varukorgsprodukt> Varukorgsprodukts { get; set; }

        public Produkt()
        {
            Varukorgsprodukts = new HashSet<Varukorgsprodukt>();
        }


    }
}
