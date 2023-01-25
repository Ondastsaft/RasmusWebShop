namespace RasmusAB.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Färg { get; set; }
        public int Pris { get; set; }
        public int Antal { get; set; }
        public virtual Kategori Kategori { get; set; }
        public int KategoriId { get; set; }
        public virtual ICollection<Varukorgsprodukt> Varukorgsprodukter { get; set; }

        public Produkt()
        {
            Varukorgsprodukter = new HashSet<Varukorgsprodukt>();
        }


    }
}
