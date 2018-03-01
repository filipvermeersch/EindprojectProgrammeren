using Projectwerk.Vermeersch.f.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projectwerk.Vermeersch.f.Data
{
    public class TriatlonContext : DbContext
    {
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Putter> Putters { get; set; }
        public DbSet<Sport> Sporten { get; set; }
        public DbSet<Afstand> Afstanden { get; set; }
        public DbSet<Wedstrijd> Wedstrijden { get; set; }
        public DbSet<Resultaat> Resultaten { get; set; }

    }
}