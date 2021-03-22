using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOwerflow.Models
{
    public class QuestionsDto
    {
        public int countQuestions { get; set; }
        public List<QuestionsArray> QuestionsArray { get; set; }
    }
}
