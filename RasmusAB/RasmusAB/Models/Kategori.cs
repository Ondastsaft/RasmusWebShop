namespace RasmusAB.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string? Namn { get; set; }
        public virtual ICollection<Produkt> Produkter { get; set; }
        public Kategori()
        {
            Produkter = new HashSet<Produkt>();
        }
    }
}
