using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AngularASPNET.Models
{
    public class MyContext : DbContext
    {
        public DbSet<AngularASPNET.Models.Player> Players { get; set; }
        public DbSet<AngularASPNET.Models.Club> Clubs { get; set; }
    }
}