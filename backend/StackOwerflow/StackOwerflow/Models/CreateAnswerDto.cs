using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOwerflow.Models
{
    public class CreateAnswerDto
    {
        public string AnswerText { get; set; }
        public int Questionid { get; set; }
    }
}
