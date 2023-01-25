﻿namespace RasmusAB.Models
{
    public class Varukorg
    {
        public int Id { get; set; }
        public virtual ICollection<Varukorgsprodukt> Varukorgsprodukts { get; set; }
        public Användare Användare { get; set; }
        public int AnvändareId { get; set; }
        public virtual Order Order { get; set; }
        public int? OrderId { get; set; }
        public bool Slutbetald { get; set; }
        public Varukorg()
        {
            Varukorgsprodukts = new HashSet<Varukorgsprodukt>();
        }
    }
}
