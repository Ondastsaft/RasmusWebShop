namespace RasmusAB.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public ICollection<Produkt> Produkter { get; set; }
        public Kategori()
        {
            Produkter = new HashSet<Produkt>();
        }
    }
}
