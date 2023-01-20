using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria.Database
{
    public class PizzeriaContext:IdentityDbContext<IdentityUser>
    {
        public DbSet<Pizza> Pizze { get; set; }

        public DbSet<Categoria> Categorie { get; set; }

        public DbSet<Ingrediente> Ingredienti { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=PizzeriaDB;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
