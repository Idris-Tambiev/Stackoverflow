using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StackOwerflow.Models
{
    public class AnswersContext:DbContext
    {
        public DbSet<Question> Answers { get; set; }
        public AnswersContext(DbContextOptions<AnswersContext> options)
            : base(options)
        {
           // Database.EnsureCreated();
        }
    }
}
