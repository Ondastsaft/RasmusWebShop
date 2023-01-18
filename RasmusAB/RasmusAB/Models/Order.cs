namespace RasmusAB.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int VarukorgsId { get; set; }
        public int? Summa { get; set; }
        public double? Moms { get; set; }
        public virtual Leverantör leverantör { get; set; }
        public int? LeverantörId { get; set; }
        public string? BetalningsUppgifter { get; set; }
        public bool? Slutbetald { get; set; }
        public Order()
        {

        }
    }
}
