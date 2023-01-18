namespace RasmusAB.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Varukorg Varukorg { get; set; }
        public int VarukorgsId { get; set; }
        public int Summa { get; set; }
        public double Moms { get; set; }
        public Leverantör leverantör { get; set; }
        public int LeverantörId { get;set; }
        public string BetalningsUppgifter { get; set; }
        public bool Slutbetald { get; set; }
        public void SummeraProdukter()
        {
            var db = new RasmusABContext();
            int sum = 0;
            var produkt = new Produkt();

            foreach (var varukorgsprodukt in db.Varukorgar.Where(v => v.Id == VarukorgsId).SingleOrDefault().Varukorgsprodukts)
            {
                produkt = db.Produkter.Where(p => p.Id == varukorgsprodukt.ProduktId).SingleOrDefault();
                sum = sum + produkt.Antal;
            }
            Summa = sum;
            Moms = (Summa * 0.2);
        }
        public Order(Varukorg varukorg )
        {
            Varukorg = varukorg;
            SummeraProdukter();
        }
        public Order()
        {

        }
    }
}
