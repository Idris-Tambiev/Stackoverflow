using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StackOwerflow.Models;

namespace StackOwerflow.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Question, QuestionsDto>().ForMember(dest => dest.id, act => act.MapFrom(src => src.id))
                    .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description))
                    .ForMember(dest => dest.QuestionText, act => act.MapFrom(src => src.QuestionText))
                    .ForMember(dest => dest.Date, act => act.MapFrom(src => src.Date))
                    .ForMember(dest => dest.AnswersCount, act => act.MapFrom(src => src.Answer.Count));
        }
    }
}
