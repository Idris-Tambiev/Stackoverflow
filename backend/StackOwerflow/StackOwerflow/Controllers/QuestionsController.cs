using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackOwerflow.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace StackOwerflow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        AppDbContext db;
        private readonly IMapper _mapper;
        public QuestionsController(AppDbContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        //GET api/questions/id/page
        [HttpGet("{id}/{page}")]
        public async Task<ActionResult<QuestionsDto>> Get(int id,int page)
        {
            if (page >= 1 && id>=1)
            {
                int number = page;
                var questions = await db.Questions
                    .OrderBy(i => i.id)
                    .Skip(number * 5 - 5)
                    .Take(5)
                    .Include(x => x.Answer)
                    .ToListAsync();

                var totalCount = await db.Questions.CountAsync();
                return Ok(FormDto(questions, totalCount));
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpGet("{words}/search/{page}")]
        public async Task<ActionResult<QuestionsDto>> Get(string words,int page)
        {
            if (page >= 1 && words != "")
            {
                int number = page;
                var findedQuestions = await db.Questions
                    .OrderBy(i => i.id)
                    .Where(p => p.QuestionText.Contains(words))
                    .Skip(number * 5 - 5)
                    .Take(5)
                    .Include(x => x.Answer)
                    .ToListAsync();

                var count = await db.Questions.Where(p => p.QuestionText.Contains(words)).CountAsync();
                return Ok(FormDto(findedQuestions, count));
            }else
            {
                return NotFound();
            }
        }

        //GET api/questions/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> Get(int id)
        {
            if (id >= 1)
            {
                Question question = await db.Questions.Include(x => x.Answer).FirstOrDefaultAsync(x => x.id == id);
                if (question == null)
                    return NotFound();
                var array = _mapper.Map<Question, QuestionDto>(question);
                return Ok(array);
            }
            else
            {
                return NotFound();
            }
           
        }

        
        //POST api/questions
        [HttpPost]
        public async Task<ActionResult<Question>> Post(CreateQuestionDto question)
        {
            if (question == null)
            {
                return BadRequest();
            }
            var NewQuestion = _mapper.Map<CreateQuestionDto, Question>(question);
            
            db.Questions.Add(NewQuestion);
            await db.SaveChangesAsync();
            return Ok(question);
        }

        private QuestionsDto FormDto(List<Question> a, int count)
        {
            var array = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDto>>(a);
            var result = new QuestionsDto
            {
                CountQuestions = count,
                QuestionsArray = array
            };
            return result;
        }
    }
}
