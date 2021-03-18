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

        public QuestionsController(AppDbContext context)
        {
            db = context;
        }
        public class Mapper{
         }


        //GET api/questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> Get()
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Question, QuestionsDto>()
                    .ForMember(dest => dest.id, act => act.MapFrom(src => src.id))
                    .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description))
                    .ForMember(dest => dest.QuestionText, act => act.MapFrom(src => src.QuestionText))
                    .ForMember(dest => dest.Date, act => act.MapFrom(src => src.Date))
                    .ForMember(dest => dest.AnswersCount, act => act.MapFrom(src => src.Answer.Count))
                );

            var a = await db.Questions
                .Include(x => x.Answer)
                .ToListAsync();

            IMapper iMapper = config.CreateMapper();
            var DTO = iMapper.Map<IEnumerable<Question>,IEnumerable<QuestionsDto>>(a);

            return new ObjectResult (DTO);
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
