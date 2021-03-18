using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOwerflow.Models
{
    public class Question
    {
        public int id { get; set; }
        public string QuestionText { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public List<Answer> Answer { get; set; }
    }
}
