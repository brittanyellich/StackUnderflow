using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser;

namespace StackUnderflow.Data
{
    public class SecurityContext : IdentityDbContext<IdentityUser>
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {
        }
    }
}