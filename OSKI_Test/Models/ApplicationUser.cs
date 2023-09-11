using Microsoft.AspNetCore.Identity;

namespace OSKI_Test.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
    }
}