using projet2.Data;
using projet2.Model;
using projet2.Repository.IRepository;

namespace projet2.Repository
{
    public class CategorieRepository : Repository<Categorie>, ICategorieRepository
    {
        private readonly ApplicationDbContext1 _db;
        public CategorieRepository(ApplicationDbContext1 db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        public void updateCategorie(Categorie categorie )
        {
            var cat  = _db.Categories.Find(categorie.Id);
            cat.Name = categorie.Name;
            cat.Orderdisplay = categorie.Orderdisplay;
            _db.Update(cat);
        }
    }
}
