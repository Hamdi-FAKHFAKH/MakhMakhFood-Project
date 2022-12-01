using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet2.Model
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [Required]
        public int count { get; set; }
        public int menuItemId { get; set; }
        [ForeignKey("menuItemId")]
        public MenuItem menuItem { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
