using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projet2.Data;
using projet2.Model;
using projet2.Repository.IRepository;

namespace projet2.Pages.Foods
{
    [BindProperties]
    public class EditModel : PageModel
    {

        public IUnitOfWork _db;
        public Food food { get; set; }
        public EditModel(IUnitOfWork db)
        {
            _db = db;

        }

        public void OnGet(int id)
        {
            food = _db.Food.GetById(id);
        }
        public IActionResult OnPost()
        // NB: il faut toujour envoyer l Id (on utilise g�n�ralement input type='hidden') dans le formulaire
        // pour permet de sp�cifier la cat�gorie a supprimer  
        {
            if (food != null)
            {
                _db.Food.Update(food);
                TempData["succes"] = "food mise a jour avec succ�es";
                _db.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
