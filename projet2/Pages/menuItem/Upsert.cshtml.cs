using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using projet2.Model;
using projet2.Repository.IRepository;

namespace projet2.Pages.menuItem
{
    [BindProperties]
    public class UpsertModel : PageModel

    {
        private readonly IWebHostEnvironment Whe;  
        private readonly IUnitOfWork _db;

        // [BindProperty]    //utiliser lorsque on veut binding un seul attribue
        public MenuItem menuitem { get; set; }
        public IEnumerable<SelectListItem> categorieList { get; set; }
        public IEnumerable<SelectListItem> foodList { get; set; }
        public UpsertModel(IUnitOfWork db,IWebHostEnvironment iweb)
        {
            _db = db;
            Whe = iweb;
        }

        public void OnGet(int? id)

        {
            // SelectListItem utiliser pour realiser un liste déroulant avec text est le text a afficher dans le liste
            // et value et la valeur envoyer dans le formualaire 

            // on cas de update de menuitem  categorieList et foodList retourne le name coorespondant au id de food et categorie
            // puisque id est determiner par GetFirstOrDefault et binder par le tag [BindProperties]

            categorieList = _db.Categorie.GetAll().Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                foodList = _db.Food.GetAll().Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });

            if (id != null)
            {
               menuitem =  _db.menuitem.GetFirstOrDefault(u => u.Id == id);
            }
        }

        public IActionResult OnPost()
        {
            string webRootPath = Whe.WebRootPath; // recupérer le path de wwwroot 
            var files = HttpContext.Request.Form.Files; // recupérer les fichier envoyer dans le formulaire 
            if (menuitem.Id == 0)
            {
                string newFileName = Guid.NewGuid().ToString(); //pour donner un nom unique au images 
                var uplods = Path.Combine(webRootPath, @"images\MenuItem"); // pour combine le path de wwwroot avec /images/MenuItem
                var ext = Path.GetExtension(files[0].FileName);
                using (var fs = new FileStream(Path.Combine(uplods, newFileName + ext), FileMode.Create))
                {
                    files[0].CopyTo(fs);
                }
                menuitem.Image = @"\images\MenuItem\" + newFileName + ext;
                _db.menuitem.Add(menuitem);
                _db.Save();
            }
            else
            {    
                if (files.Count > 0)
                {
                    var path = Path.Combine(webRootPath, menuitem.Image.TrimStart('\\'));
                    //delete old image
                    // on utilise TrimStart pour suprimer le \ au premiére valeur de l'attribue image parce on utilise combine
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    // add new image 
                    string newFileName = Guid.NewGuid().ToString(); //pour donner un nom unique au images 
                    var uplods = Path.Combine(webRootPath, @"images\MenuItem"); // pour combine le path de wwwroot avec /images/MenuItem
                    var ext = Path.GetExtension(files[0].FileName);
                    using (var fs = new FileStream(Path.Combine(uplods, newFileName + ext), FileMode.Create))
                    {
                        files[0].CopyTo(fs);
                    }
                    menuitem.Image = @"\images\MenuItem\" + newFileName + ext;
                }
                _db.menuitem.Update(menuitem);
                _db.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
