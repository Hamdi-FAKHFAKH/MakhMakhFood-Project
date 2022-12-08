using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projet2.Model;

namespace projet2.Data;
// permet de faire convertir une entité en un tableau dans le Base de donnée
// pour faire les opération de CRUD sur une entité en crée son repository
// ( interface + implémentation ) 
public class ApplicationDbContext1 : IdentityDbContext

    {
        public ApplicationDbContext1(DbContextOptions<ApplicationDbContext1> option) : base(option)
        {

        }
        public DbSet<Food> foods { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        public DbSet<MenuItem> menuItems { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
    }

