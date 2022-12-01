using projet2.Data;
using projet2.Model;
using projet2.Repository.IRepository;

namespace projet2.Repository
{
    public class ShopingCartRepository : Repository<ShoppingCart>, IShoppingCart

    {
        public readonly ApplicationDbContext1 _db;
        public ShopingCartRepository(ApplicationDbContext1 db) : base(db)
        {
            _db = db;
        }
    }
}
