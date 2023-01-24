namespace RasmusAB.Models
{
    public class Leverantör
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Leverantör()
        {
            Orders = new HashSet<Order>();
        }


    }
}
