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
        public class Mapper{
         }


        //GET api/questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> Get()
        {
            var a = await db.Questions
                .Include(x => x.Answer)
                .ToListAsync();

            var DTO = _mapper.Map<IEnumerable<Question>,IEnumerable<QuestionsDto>>(a);
            return Ok(DTO);
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

        
    }
}
