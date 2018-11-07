using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StackUnderflow.Entities;

namespace StackUnderflow.Data
{
    public class StackUnderflowDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Question> Questions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //At some point you'll switch this out for an actual database
            optionsBuilder.UseSqlServer(@"
                Data Source=(localdb)\mssqllocaldb; 
                Initial Catalog=StackUnderflow;
                Integrated Security=True");
        }
    }
}
