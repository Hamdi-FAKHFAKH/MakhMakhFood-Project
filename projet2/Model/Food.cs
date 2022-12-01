using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet2.Model
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}
