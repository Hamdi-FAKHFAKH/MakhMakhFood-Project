using projet2.Data;
using projet2.Model;
using projet2.Repository.IRepository;
namespace projet2.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        public readonly ApplicationDbContext1 _db;
        public MenuItemRepository(ApplicationDbContext1 db) : base(db)
        {
            _db = db;
        }

        public void updateMenuItem(MenuItem item)
        {
            var it = _db.menuItems.Find(item.Id);
            it.Name = item.Name;   
            it.Price = item.Price;
            it.Description = item.Description; 
            it.categorie = item.categorie;
            //it.categorieId = item.categorieId;
            //it.foodId = item.foodId;
            _db.Update(it);

        }
    }
}
