using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet2.Model
{
    public class MenuItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }

        [Range(1,1000,ErrorMessage ="price should be between 1$ and 1000$")]
        public double Price { get; set; }
        [Display(Name ="Food Type")]
        public int foodId { get; set; }
        [Display(Name = "Category")]

        // il faut utliser l'annotation nomdetableId(exp :categorieId) pour indiquer que cette propriéter un clé étranger au table (exp categorie)
        public int categorieId { get; set; } 
        [ForeignKey("foodId")]
        public Food? food { get; set; } // pour definie un clé etrangé au table food 
        public Categorie? categorie { get; set; }   // pour definie un clé etranger au table categorie 

        // les attribue food et categorie n'existe pas dans la table MenuItem on a juste les colonnes foodId
        // et categorieId sont des clé etranger au table food et categorie



    }
}
