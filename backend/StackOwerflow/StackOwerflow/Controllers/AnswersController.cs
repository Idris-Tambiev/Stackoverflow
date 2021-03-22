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

        //GET api/answers/id
        [HttpGet("{id}/{page}")]
        public async Task<ActionResult<Answer>> Get(int id,int page)
        {
            int number = page;
            int maxLength = 0;
            List<Answer> getArray = new List<Answer>();

            var answer = await db.Answers.Where(s => s.Questionid == id).ToListAsync();
            if (answer.Count() < number * 5 - 1)
                {
                 maxLength = answer.Count();
                }
            else
                {
                    maxLength = number * 5;
                }
            for (int j = number * 5 - 5; j < maxLength; j++)
                 {
                    getArray.Add(answer[j]);
                 }
            if (answer == null)
                return NotFound();
            return Ok(getArray);
        }

        //POST api/answers
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
