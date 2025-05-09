using Covauto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Covauto.Domain.Data
{
    public class AutosContext : System.Data.Entity.DbContext
    {
        public AutosContext(DbContextOptions<AutosContext> options) : base(options) { }

        public DbSet<Auto> Auto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Auto>().HasData(new Auto { Id = 1, naamAuto = "Mark J. Prijs", kilometerstand = "2500km", startAdres = "Doetinchem", eindAdres = "Amsterdam", beschikbaarheid = false});

        }
    }
}
