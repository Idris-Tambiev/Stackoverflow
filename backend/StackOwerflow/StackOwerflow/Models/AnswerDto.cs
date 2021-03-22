using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOwerflow.Models
{
    public class AnswerDto
    {
        public int id { get; set; }
        public string AnswerText { get; set; }
        public DateTime Date { get; set; }
        public int Questionid { get; set; }
    }
}
