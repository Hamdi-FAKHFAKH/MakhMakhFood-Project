using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projet2.Model;
using projet2.Repository.IRepository;
using System.ComponentModel.DataAnnotations;

namespace projet2.Pages.customer
{
    [BindProperties]
    //[Authorize] pour obliger l'authentification apres le direction vers cette page 
    public class DetailModel : PageModel
    {
        private readonly IUnitOfWork db;

        public DetailModel(IUnitOfWork db)
        {
            this.db = db;
        }

        //public MenuItem menuItem { get; set; }
        //[Range(1,100,ErrorMessage ="count should be beteween 1 and 100 ")]
        //public int count { get; set; }

        public ShoppingCart cart { get; set; }
        public void OnGet(int id)
        {
            cart = new()
            {
                menuItem = db.menuitem.GetFirstOrDefault(x => x.Id == id, includeProp: "categorie,food")
            };
        }
        public IActionResult OnPost()
        {
            //db.shoppingCart.Add(cart);
            //db.Save();
            return RedirectToPage("Index");
        }
    }
}
