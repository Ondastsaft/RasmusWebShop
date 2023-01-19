﻿namespace RasmusAB.Models
{
    public class Varukorg
    {
        public int Id { get; set; }
        public virtual ICollection<Varukorgsprodukt> Varukorgsprodukts { get; set; }
        public int? AnvändarId { get; set; }
        public int? OrderId { get; set; }
        public Varukorg()
        {
            Varukorgsprodukts = new HashSet<Varukorgsprodukt>();

        }


    }
}
