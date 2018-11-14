using System;
using System.Linq;
using System.Threading.Tasks;
using StackUnderflow.Data;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using StackUnderflow.Entities;

namespace StackUnderflow.Business
{
    public class AuthService
    {

        private StackUnderflowDbContext _context; 
        public AuthService(StackUnderflowDbContext context)
        {
            _context = context;
        }

        public User Register(CreateUser user)
        {
            if (_context.Users.Where(x => x.Username == user.Username).FirstOrDefaultAsync().Result != null)
            {
                throw new Exception("User already exists.");
            }
            var NewUser = new User()
            {
                Username = user.Username,
                DateJoined = DateTimeOffset.UtcNow,
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password),
            };
            
            _context.Users.Add(NewUser);
            _context.SaveChangesAsync();
            return NewUser;
        }

        public async Task<bool> Login(CreateUser user)
        {
            var dbUser = await _context.Users.Where(x => x.Username == user.Username).FirstOrDefaultAsync();
            if (dbUser == null || !BCrypt.Net.BCrypt.Verify(user.Password, dbUser.HashedPassword))
            {
                throw new Exception("Credentials Are Incorrect");
            }
            
            return true;
        }
    }
}