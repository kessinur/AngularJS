using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularASPNET.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        public virtual Club Clubs { get; set; }
    }
}