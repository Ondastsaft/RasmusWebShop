namespace RasmusAB.Models
{
    public class Varukorg
    {
        public int Id { get; set; }
        public ICollection<Produkt> VarukorgensProdukter { get; set; }
        public int AnvändarId { get; set; }
        public int? OrderId { get; set; }
        public Användare Användare { get; set; }
        public int AnvädareVarukorgId { get; set; }
        
        
    }
}
