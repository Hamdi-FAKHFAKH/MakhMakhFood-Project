using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projet2.Data;
using projet2.Model;
using projet2.Repository.IRepository;

namespace projet2.Pages.catégorie
{
    public class IndexModel : PageModel
    {
        private IUnitOfWork _db;
        public IEnumerable < Categorie > categories { get; set; }
        public IndexModel(IUnitOfWork db)
        {
            _db = db;
           
        }

        public void OnGet()
        {
            categories = _db.Categorie.GetAll();
        }
    }
}
