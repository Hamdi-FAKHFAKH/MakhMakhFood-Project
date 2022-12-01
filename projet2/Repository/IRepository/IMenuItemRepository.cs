using projet2.Model;

namespace projet2.Repository.IRepository
{
    public interface IMenuItemRepository:IRepository<MenuItem>
    {
        void updateMenuItem(MenuItem item);
    }
}
