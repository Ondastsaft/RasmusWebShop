namespace RasmusAB.Models
{
    public class Varukorg
    {
        public int Id { get; set; }
        public virtual ICollection<Produkt> Produkters { get; set; }
        public int AntalProdukter { get; set; }
        public int AnvändarId { get; set; }
        public int OrderId { get; set; }
        public Användare? Användare { get; set; }


        public Varukorg()
        {
            Produkters = new List<Produkt>();
        }


    }
}
