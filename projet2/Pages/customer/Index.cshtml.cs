using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projet2.Model;
using projet2.Repository.IRepository;

namespace projet2.Pages.customer
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        readonly IUnitOfWork db;
        public IEnumerable<MenuItem> menuItems { get; set; }
        public IEnumerable<Categorie> cat { get; set; }
        public IndexModel(IUnitOfWork db)
        {
            this.db = db;
        }

        public void OnGet()
        {
            menuItems = db.menuitem.GetAll(includeProp: "food,categorie");
            cat = db.Categorie.GetAll();
        }
    }
}
