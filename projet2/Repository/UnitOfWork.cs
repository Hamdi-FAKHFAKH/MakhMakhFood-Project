using projet2.Data;
using projet2.Model;
using projet2.Repository.IRepository;

namespace projet2.Repository
{
    public class UnitOfWork : IUnitOfWork

    {
        public ApplicationDbContext1 _db;
        public UnitOfWork(ApplicationDbContext1 db)
        {
            _db = db;
            Categorie = new CategorieRepository(db);
            Food = new FoodRepository(db); 
            menuitem = new MenuItemRepository(db); 
            shoppingCart = new ShopingCartRepository(db);
        }
    
        public ICategorieRepository Categorie { get; private set; }
        public IFoodRepository Food { get; private set; }
        public IMenuItemRepository menuitem { get; private set; }
        public IShoppingCart shoppingCart { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            try {
                _db.SaveChanges(); 
            }
            catch (Exception ex) {
                
            }
           
        }
    }
}
