namespace RasmusAB.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Summa { get; set; }
        public double Moms { get; set; }
        public string? BetalningsUppgifter { get; set; }
        public bool Slutbetald { get; set; }
        public Varukorg Varukorg { get; set; }
        public int VarukorgId { get; set; }
        public Leverantör Leverantör { get; set; }
        public int LeverantörId { get; set; }
        public Order()
        {

        }
    }
}
