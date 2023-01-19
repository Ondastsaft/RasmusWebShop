namespace RasmusAB.Models
{
    public class Varukorgsprodukt
    {
        public int Id { get; set; }
        public virtual Produkt Produkt { get; set; }
        public int ProduktId { get; set; }
        public int Antal { get; set; }
        public Varukorg Varukorg { get; set; }
        public int VarukorgId { get; set; }

    }
}
