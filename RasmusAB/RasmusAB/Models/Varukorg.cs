namespace RasmusAB.Models
{
    public class Varukorg
    {
        public int Id { get; set; }
        public virtual ICollection<Produkt> VarukorgensProdukter { get; set; }
        public int? OrderId { get; set; }
        public Användare VarukorgensAnvändare { get; set; }
        public Varukorg()
        {
            VarukorgensProdukter = new HashSet<Produkt>();
        }
    }
}
