using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackOwerflow.Models;

namespace StackOwerflow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> Get(int id)
        {
            //Question question = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            Question question = await db.Questions.FirstOrDefaultAsync(x => x.Id == id);
            if (question == null)
                return NotFound();
            return new ObjectResult(question);
        }
    }
}
