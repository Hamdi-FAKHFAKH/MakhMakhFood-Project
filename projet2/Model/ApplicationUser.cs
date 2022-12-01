using Microsoft.AspNetCore.Identity;

namespace projet2.Model
{
    public class ApplicationUser : IdentityUser 
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
