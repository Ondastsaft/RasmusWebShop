namespace RasmusAB.Models
{
    public class Varukorg
    {
        public int VarukorgId { get; set; }
        public virtual ICollection<Varukorgsprodukt> Varukorgsprodukter { get; set; }
        public Användare Användare { get; set; }
        public int AnvändareId { get; set; }
        public virtual Order Order { get; set; }
        public bool Slutbetald { get; set; }
        public Varukorg()
        {
            Varukorgsprodukter = new HashSet<Varukorgsprodukt>();
        }
    }
}
