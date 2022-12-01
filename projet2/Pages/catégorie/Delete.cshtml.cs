using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projet2.Data;
using projet2.Model;
using projet2.Repository.IRepository;

namespace projet2.Pages.catégorie
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public IUnitOfWork _db;
        public Categorie categorie { get; set; }
        public DeleteModel (IUnitOfWork db)
        {
            _db = db;
            
        }

        public void OnGet(int id)
        {
             categorie = _db.Categorie.GetFirstOrDefault(c=>c.Id==id);
        }
        public IActionResult OnPost()
            // NB: il faut toujour envoyer l Id (on utilise généralement input type='hidden') dans le formulaire
            // pour permet de spécifier la catégorie a supprimer  
        {
            if (categorie != null)
            {
                _db.Categorie.Remove(categorie);
                _db.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
