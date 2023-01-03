using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasmusAB.Models
{
    public class Användarregister
    {
        public static ICollection <Kund> kunder { get; set; }
        public static ICollection <Admin> administratörer { get; set; }
        public int AdminId { get; set; }
        public int KundId { get; set; }
        public int Id { get; set; }
        public Användarregister()
        {
            kunder = new HashSet<Kund>();
            administratörer = new HashSet<Admin>();
        }

        //GÅR EJ ATT LÄGGA TILL ANÄVNDARE I REGSTRER (KOPPLAT TILL LOG IN)
        //public static void SkapaKunder()
        //{
        //    var db = new RasmusABContext();
        //    Kund k = new Kund("Kund1","Kund123")
        //    {
        //        Username = "Kund1",
        //        Password = "Kund123"
        //    };
        //    kunder.Add(k);
        //    Kund k1 = new Kund("Kund2", "Kund234")
        //    {
        //        Username = "Kund2",
        //        Password = "Kund234"
        //    };
        //    kunder.Add(k1);
           
        //    db.SaveChanges();
        //}

    }
}
