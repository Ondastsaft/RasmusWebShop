using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasmusAB.Models
{
    public class Varukorg
    {
        public int Id { get; set; }
        public Produktlista VarukorgensProdukter { get; set; }
        public int ProduktListaId { get; set; }
        public int? KundId { get; set; }
        public int? OrderId { get; set; }
    }
}
