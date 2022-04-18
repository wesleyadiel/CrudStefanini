using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Data
{
    public class StefaniniDBContext : DbContext
    {
        public StefaniniDBContext(DbContextOptions<StefaniniDBContext> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
