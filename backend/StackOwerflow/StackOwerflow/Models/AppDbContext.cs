using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StackOwerflow.Models
{
    public class AppDbContext :DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();  
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
           .HasOne(p => p.Question)
           .WithMany(b => b.Answer);

            modelBuilder.Entity<Question>()
                .Property(u => u.Description)
                .HasColumnType("varchar(5000)");

            modelBuilder.Entity<Question>()
                .Property(u => u.QuestionText)
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Answer>()
                .Property(u => u.AnswerText)
                .HasColumnType("varchar(5000)");
        }
    }
}
