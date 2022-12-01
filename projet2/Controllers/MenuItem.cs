using Microsoft.AspNetCore.Mvc;
using projet2.Data;
using projet2.Repository.IRepository;
// Trés important : noter bien il faut le nom de dossier étre Controllers 
namespace projet2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItem : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment Whe;

        public MenuItem(IUnitOfWork db, IWebHostEnvironment whe)
        {
            _db = db;
            Whe = whe;
        }
        [HttpGet]
        public IActionResult Index()


        {
            // pour faire la mapping de clé etranger est récupérer les info de food et categorie a partir de ses id
            // en utilise include dans repository et on entre les attribue de food et categorie  
            var menuitem = _db.menuitem.GetAll(includeProp: "categorie,food");
            // _db.menuItems.Include(u => u.food).Include(u => u.categorie); //si on travaille avec ApplicationDbContext
            return Json(new { Data = menuitem });
        }
        // [HttpDelete("{id}")] on cas ou on a un url parametre 
        [HttpDelete]
        public IActionResult delete (int id)
        {
            var menuitem = _db.menuitem.GetFirstOrDefault(u => u.Id == id);
            var path = Path.Combine(Whe.WebRootPath, menuitem.Image.TrimStart('\\'));
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _db.menuitem.Remove(menuitem);
            _db.Save();
            return Json(new { success = true, message = " menu item deleted with succes ! " });
        }
    }
}
