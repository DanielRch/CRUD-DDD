using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Petshop.Domain.Entities;
using Petshop.Infra.EntityConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Petshop.Infra.Context
{
    public class ContextPetShop : DbContext
    {

        public ContextPetShop(DbContextOptions options) : base(options)
        {
            Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pets> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            //modelBuilder.Entity<Cliente>(new ClienteConfiguration().Configure);
        }
    }
}
