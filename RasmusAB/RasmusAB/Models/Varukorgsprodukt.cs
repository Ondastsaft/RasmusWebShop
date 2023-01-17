using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasmusAB.Models
{
    public class Varukorgsprodukt
    {
        public int Id { get; set; }
        public Produkt Produkt { get; set; }
        public int ProduktId { get; set; }
        public int Antal { get; set; }

    }
}
