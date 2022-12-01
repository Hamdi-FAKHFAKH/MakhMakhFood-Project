using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projet2.Model;
using projet2.Repository;
using projet2.Repository.IRepository;

namespace projet2.Pages.catégorie
{
    // noter bien : binding c'est de relier les attribue de cette classe au page cshtml
    // (les valeur de cshtml son sauvgarder dans les proprieter de la classe) 
    
    [BindProperties]    // utiliser lorsque on veut binding all attribut in the classe 
    public class CreateModel : PageModel

    {
        public IUnitOfWork _db;

        // [BindProperty]    //utiliser lorsque on veut binding un seul attribue
        public Categorie categories { get; set; }
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
        public IActionResult OnPost(Categorie categories)
        {

             _db.Categorie.Add(categories);
             _db.Save();
            TempData["succes"] = "catégorie créé avec succées";
            return RedirectToPage("Index");
        }

    }
}
