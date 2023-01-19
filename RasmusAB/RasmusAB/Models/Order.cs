namespace RasmusAB.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? Summa { get; set; }
        public double? Moms { get; set; }
        public string? BetalningsUppgifter { get; set; }
        public bool? Slutbetald { get; set; }
        public virtual Varukorg Varukorg { get; set; }
        public int? VarukorgsId { get; set; }
        public virtual Leverantör Leverantör { get; set; }
        public int? LeverantörsId { get; set; }
        public Order()
        {

        }
    }
}
