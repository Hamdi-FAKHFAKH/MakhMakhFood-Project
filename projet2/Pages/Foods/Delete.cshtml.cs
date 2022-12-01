using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projet2.Data;
using projet2.Model;
using projet2.Repository.IRepository;

namespace projet2.Pages.Foods
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public IUnitOfWork _db;
        public Food food { get; set; }
        public DeleteModel(IUnitOfWork db)
        {
            _db = db;

        }

        public void OnGet(int id)
        {
            food = _db.Food.GetFirstOrDefault(u=>u.Id==id);
        }
        public IActionResult OnPost()
        // NB: il faut toujour envoyer l Id (on utilise généralement input type='hidden') dans le formulaire
        // pour permet de spécifier la catégorie a supprimer  
        {
            if (food != null)
            {
                _db.Food.Remove(food);
                TempData["succes"] = "food Supprimer avec succées";
                _db.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
