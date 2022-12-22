using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasmusAB.Models
{
    public class Admin : Användare
    {
        public int Id { get; set; }
        public Admin(string name, string password) : base(name, password)
        {

        }
        public void PrintAdmin()
        {
            Console.WriteLine("Jag är admin");
        }
    }
}
