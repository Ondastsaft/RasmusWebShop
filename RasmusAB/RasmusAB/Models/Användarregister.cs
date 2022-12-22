﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasmusAB.Models
{
    public class Användarregister
    {
        public virtual ICollection <Kund> kunder { get; set; }
        public virtual ICollection <Admin> administratörer { get; set; }
        public Användarregister()
        {
            kunder.Add(new Kund("Kund 1", "Kund123"));
            administratörer.Add(new Admin("Admin 1", "Admin123"));
        }
    }
}
