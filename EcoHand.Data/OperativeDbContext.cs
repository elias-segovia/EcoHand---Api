using EcoHand.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHand.Data
{
    public class OperativeDbContext : DbContext
    {

        public OperativeDbContext() : base("Operative")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Secuencia> Secuencias { get; set; }
        public DbSet<Gesto> Gestos { get; set; }
        
    }
}
