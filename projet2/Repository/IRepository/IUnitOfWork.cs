namespace projet2.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategorieRepository Categorie { get; }
        public IFoodRepository Food { get; }

        public IMenuItemRepository menuitem { get; }
        public IShoppingCart shoppingCart { get; }
        void Save();
    }
}
