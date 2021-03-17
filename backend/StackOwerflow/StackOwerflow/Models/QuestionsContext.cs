using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StackOwerflow.Models
{
    public class QuestionsContext :DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public QuestionsContext(DbContextOptions<QuestionsContext> options)
            : base(options)
        {
            Database.EnsureCreated();  
        }
    }
}
