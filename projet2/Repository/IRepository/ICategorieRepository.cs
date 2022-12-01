using projet2.Model;

namespace projet2.Repository.IRepository
{
    public interface ICategorieRepository: IRepository <Categorie>
    {
        public void updateCategorie(Categorie categorie);
    }
}
