using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projet2.Data;
using projet2.Model;
using projet2.Repository;
using projet2.Repository.IRepository;

namespace projet2.Pages.menuItem
{
    public class IndexModel : PageModel
    {
        private  IUnitOfWork _db;
        public IEnumerable<MenuItem> menuitems { get; set; }
        public IndexModel (IUnitOfWork db)
        {
            _db = db;

        }

        public void OnGet()
        {
            menuitems = _db.menuitem.GetAll();
        }
    }
}


   