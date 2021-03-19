using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackOwerflow.Models;
using Microsoft.EntityFrameworkCore;

namespace StackOwerflow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        AppDbContext db;
        public AnswersController(AppDbContext context)
        {
            db = context;
        }

        //GET api/answers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> Get()
        {
            return await db.Answers.ToListAsync();
        }

        //GET api/answers/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> Get(int id)
        {
           // Answer answer;
                var answer = await db.Answers.Where(s => s.Questionid == id).ToListAsync(); 
            if (answer == null)
                return NotFound();
            return new ObjectResult(answer);
        }

        //POST api/questions
        [HttpPost]
        public async Task<ActionResult<Question>> Post(Answer answer)
        {
            if (answer == null)
            {
                return BadRequest();
            }
            db.Answers.Add(answer);
            await db.SaveChangesAsync();
            return Ok(answer);
        }

     
    }
}
