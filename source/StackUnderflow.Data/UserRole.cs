using Microsoft.AspNetCore.Identity;

namespace StackUnderflow.Data
{
    public class UserRole : IdentityRole
    {
        public string Description { get; set; }
    }
}