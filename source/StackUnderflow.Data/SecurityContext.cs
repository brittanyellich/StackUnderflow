using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StackUnderflow.Data
{
    public class SecurityContext : IdentityDbContext<User>
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {
        }
    }
}