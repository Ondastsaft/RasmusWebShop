namespace RasmusAB.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string Namn { get; set; }
        public virtual ICollection<Produkt> Produkter { get; set; }
        public Kategori()
        {
            Produkter = new HashSet<Produkt>();
        }
    }
}
