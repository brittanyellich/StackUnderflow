using System;
using Microsoft.AspNetCore.Identity;

namespace StackUnderflow.Data
{
    public class User
    {
        public int Id { get; set; }
        public DateTimeOffset DateJoined { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
    }
}