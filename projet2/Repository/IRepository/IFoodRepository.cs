using projet2.Model;

namespace projet2.Repository.IRepository
{
    public interface IFoodRepository:IRepository<Food>
    {
        void updateFood(Food food);
    }
}
