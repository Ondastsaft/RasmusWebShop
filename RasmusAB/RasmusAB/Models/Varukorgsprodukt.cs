namespace RasmusAB.Models
{
    public class Varukorgsprodukt
    {
        public int VarukorgsproduktId { get; set; }
        public Produkt Produkt { get; set; }
        public int ProduktId { get; set; }
        public int Antal { get; set; }
        public int VarukorgId { get; set; }
    }
}
