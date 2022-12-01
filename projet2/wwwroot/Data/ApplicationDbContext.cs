using Microsoft.EntityFrameworkCore;
using projet2.Model;

namespace projet2.wwwroot.Data
{
    public class ApplicationDbContext : DbContext

    {
        internal IEnumerable<Food> foods;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<Categorie> Categories { get; set; }
    }
}
