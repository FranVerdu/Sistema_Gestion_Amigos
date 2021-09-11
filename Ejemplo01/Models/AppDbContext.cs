using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo01.Models
{
    //public class AppDbContext : DbContext
    public class AppDbContext : IdentityDbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Amigo> Amigos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Amigo>().HasData(
            //    new Amigo()
            //    {
            //        Id = 1,
            //        Nombre = "Pepe",
            //        Ciudad = Provincia.Madrid,
            //        Email = "pepe@algo.com"
            //    },
            //    new Amigo()
            //    {
            //        Id = 2,
            //        Nombre = "Julia",
            //        Ciudad = Provincia.Almería,
            //        Email = "julia@algo.com"
            //    });

        }
    }
}
