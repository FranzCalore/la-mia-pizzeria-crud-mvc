using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace la_mia_pizzeria.Database
{
    public class PizzeriaContext:IdentityDbContext<IdentityUser>
    {
        public DbSet<Pizza> Pizze { get; set; }

        public DbSet<Categoria> Categorie { get; set; }

        public DbSet<Ingrediente> Ingredienti { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzeriaDb"));
        }
    }
}
