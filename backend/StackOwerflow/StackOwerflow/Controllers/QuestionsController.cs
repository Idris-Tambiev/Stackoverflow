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
    public class QuestionsController : ControllerBase
    {

        AppDbContext db;
        public QuestionsController(AppDbContext context)
        {
            db = context;
        }

        //GET api/questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> Get()
        {
            return await db.Questions.ToListAsync();
        }

        //GET api/questions/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> Get(int id)
        {
            Question question = await db.Questions.FirstOrDefaultAsync(x => x.id == id);
            if (question == null)
                return NotFound();
            return new ObjectResult(question);
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

        // DELETE api/questions/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Question>> Delete(int id)
        {
            Question question = db.Questions.FirstOrDefault(x => x.id == id);
            if (question == null)
            {
                return NotFound();
            }
            db.Questions.Remove(question);
            await db.SaveChangesAsync();
            return Ok(question);
        }
    }
}
