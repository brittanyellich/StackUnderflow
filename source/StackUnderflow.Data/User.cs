using System;
using Microsoft.AspNetCore.Identity;

namespace StackUnderflow.Data
{
    public class User : IdentityUser
    {
        public DateTime DateJoined { get; set; }
    }
}