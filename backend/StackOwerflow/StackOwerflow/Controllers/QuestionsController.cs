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
        public async Task<ActionResult<IEnumerable<Question>>> Get(int id,int page)
        {
            int number = page;
            int maxLength = 0;
            List<Question> getArray = new List<Question>();
            var a = await db.Questions
                .Include(x => x.Answer)
                .ToListAsync();

            if (a.Count() < number * 5 - 1)
            {
                maxLength = a.Count();
            }
            else
            {
                maxLength = number * 5;
            }
             for (int j = number * 5 - 5; j < maxLength; j++)
            {
             getArray.Add(a[j]);
            }

            var array = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionsArray>>(getArray);
            
            var result = new QuestionsDto
            {
                countQuestions =  db.Questions.Count(),
                QuestionsArray = array.ToList()
            };
            return Ok(result);
        }

        [HttpGet("{words}/search/{page}")]
        public async Task<ActionResult<IEnumerable<Question>>> Get(string words,int page)
        {
            
            int number = page;
            int maxLength = 0;
            List<Question> getArray = new List<Question>();

            var a = await db.Questions
                .Where(p=>p.QuestionText.Contains(words))
                .Include(x => x.Answer)
                .ToListAsync();

            if (a.Count() < number * 5 - 1)
            {
                maxLength = a.Count();
            }
            else
            {
                maxLength = number * 5;
            }
            for (int j = number * 5 - 5; j < maxLength; j++)
            {
                getArray.Add(a[j]);
            }

            var array = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionsArray>>(getArray);

            var result = new QuestionsDto
            {
                countQuestions = a.Count(),
                QuestionsArray = array.ToList()
            };
            return Ok(result);
        }


        //GET api/questions/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> Get(int id)
        {
            Question question = await db.Questions.Include(x => x.Answer).FirstOrDefaultAsync(x => x.id == id);
            var array = _mapper.Map<Question, QuestionsArray>(question);
            if (question == null)
                return NotFound();
            return Ok(array);
        }

        //POST api/questions
        [HttpPost]
        public async Task<ActionResult<Question>> Post(Question question)
        {
            if (question == null)
            {
                return BadRequest();
            }
            db.Questions.Add(question);
            await db.SaveChangesAsync();
            return Ok(question);
        }
    }
}
