using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasmusAB.Models
{
    public class Användare
    {
        public int Id { get; set; }
        //public string Usertype { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //public Användare(string name, string password)
        //{
        //    Username = name;
        //    Password = password;
        //}
    }
}
