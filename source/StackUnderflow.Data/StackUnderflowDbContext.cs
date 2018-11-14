using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackUnderflow.Entities;

namespace StackUnderflow.Data
{
    public class StackUnderflowDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionVote> QuestionVotes { get; set; }
        public DbSet<ResponseVote> ResponseVotes { get; set; }
        public DbSet<CommentVote> CommentVotes { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
