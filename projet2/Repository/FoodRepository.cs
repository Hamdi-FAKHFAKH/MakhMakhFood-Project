using projet2.Data;
using projet2.Model;
using projet2.Repository.IRepository;
namespace projet2.Repository
{
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        public readonly ApplicationDbContext1 _db;
        public FoodRepository(ApplicationDbContext1 db) : base(db)
        {
            _db = db;
        }

        public void updateFood(Food food)
        {
            var myfood = _db.foods.Find(food.Id);
            myfood.Name = food.Name;
            _db.Update(myfood);
        }
     
    }
}
