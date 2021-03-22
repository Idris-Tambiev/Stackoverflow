using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOwerflow.Models
{
    public class QuestionsArray
    {
        public int id { get; set; }
        public string QuestionText { get; set; }
        public string Description { get; set; }
        public int AnswersCount { get; set; }
        public DateTime Date { get; set; }
    }
}
