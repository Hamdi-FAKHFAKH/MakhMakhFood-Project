using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projet2.Data;
using projet2.Model;
using projet2.Repository.IRepository;

namespace projet2.Pages.menuItem
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        public IUnitOfWork _db;

        // [BindProperty]    //utiliser lorsque on veut binding un seul attribue
        public MenuItem menuitem { get; set; }
        public CreateModel(IUnitOfWork db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }
        // noter bien : il faut le nom de variable entré en paramétre a le méme nom que l'attribue de la classe CreateModel
        // 1 ére Méthode mode asynchrone
        /*
        public async Task<IActionResult> OnPost(Categorie categories)
        {

            await _db.Categories.AddAsync(categories);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
        */

        // 2émé Méthode mode synchrone 
        public IActionResult OnPost()
        {

            _db.menuitem.Add(menuitem);
            _db.Save();
            TempData["succes"] = "food créé avec succées";
            return RedirectToPage("Index");
        }
    }
}
