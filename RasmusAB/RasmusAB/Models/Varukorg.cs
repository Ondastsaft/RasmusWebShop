namespace RasmusAB.Models
{
    public class Varukorg
    {
        public int Id { get; set; }
        public virtual ICollection<Varukorgsprodukt> Varukorgsprodukts { get; set; }
        public int AnvändarId { get; set; }
        public Användare Användare { get; set; }
        public Order Order { get; set; }
        public int? OrderId { get; set; }
        public Varukorg()
        {
            Varukorgsprodukts = new HashSet<Varukorgsprodukt>();
            Order = new Order();
        }
        public Varukorg(Användare användare)
        {
            Varukorgsprodukts = new HashSet<Varukorgsprodukt>();
            Användare = användare;
        }


    }
}
