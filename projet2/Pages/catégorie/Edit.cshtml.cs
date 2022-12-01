using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projet2.Data;
using projet2.Model;
using projet2.Repository.IRepository;

namespace projet2.Pages.catégorie
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public IUnitOfWork db;
        public Categorie categorie { get; set; }
        public EditModel(IUnitOfWork db)
        {
            this.db = db;
  
        }

        public void OnGet(int id)
        {
            categorie = db.Categorie.GetFirstOrDefault(c => c.Id == id);
        }
         
        public IActionResult OnPost ()
        {
            if(categorie == null)
                return NotFound();
            db.Categorie.Update(categorie);
            db.Save();
            return RedirectToPage("Index");
        }
    }
}
