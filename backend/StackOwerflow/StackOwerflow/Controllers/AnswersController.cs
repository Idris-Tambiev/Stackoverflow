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
    public class AnswersController : ControllerBase
    {
        AppDbContext db;
        private readonly IMapper _mapper;
        public AnswersController(AppDbContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        //GET api/answers/id
        [HttpGet("{id}/{page}")]
        public async Task<ActionResult<IEnumerable<AnswerDto>>> Get(int id,int page)
        {
            if(id>=1 && page >= 1)
            {
                int number = page;
                var answers = await db.Answers
                    .Where(s => s.Questionid == id)
                    .Skip(number * 5 - 5)
                    .Take(5)
                    .ToListAsync();

                if (answers == null)
                    return NotFound();

                var array = _mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerDto>>(answers);
                return Ok(array);
            }
            else
            {
                return NotFound();
            }
            
        }

        //POST api/answers
        [HttpPost]
        public async Task<ActionResult<Answer>> Post(CreateAnswer answer)
        {
            if (answer == null)
            {
                return BadRequest();
            }

            var NewAnswer = _mapper.Map<CreateAnswer, Answer>(answer);
            db.Answers.Add(NewAnswer);
            await db.SaveChangesAsync();
            return Ok(NewAnswer);
        }

     
    }
}
