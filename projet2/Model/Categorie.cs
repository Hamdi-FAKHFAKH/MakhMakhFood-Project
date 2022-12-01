using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace projet2.Model
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }
      
        public String Name  { get; set; }

        [DisplayName("Order Display")]
        public int Orderdisplay  { get; set; }
        public DateTime date { get; set; }
    }
}
