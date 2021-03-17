using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOwerflow.Models
{
    public class Answer
    {
        public int id { get; set; }
        public string AnswerText { get; set; }
        public string idQuestion { get; set; }
        public DateTime Date { get; set; }
    }
}
