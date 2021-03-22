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
            CreateMap<Question, QuestionDto>().ForMember(dest => dest.id, act => act.MapFrom(src => src.id))
                    .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description))
                    .ForMember(dest => dest.QuestionText, act => act.MapFrom(src => src.QuestionText))
                    .ForMember(dest => dest.Date, act => act.MapFrom(src => src.Date))
                    .ForMember(dest => dest.AnswersCount, act => act.MapFrom(src => src.Answer.Count));

            CreateMap<Answer, AnswerDto>().ForMember(dest => dest.id, act => act.MapFrom(src => src.id))
                    .ForMember(dest => dest.AnswerText, act => act.MapFrom(src => src.AnswerText))
                    .ForMember(dest => dest.Date, act => act.MapFrom(src => src.Date))
                    .ForMember(dest => dest.Questionid, act => act.MapFrom(src => src.Questionid));

            CreateMap<CreateQuestion , Question>()
                    .ForMember(dest => dest.QuestionText, act => act.MapFrom(src => src.QuestionText))
                    .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Date, act => act.MapFrom(src => DateTime.Now));

            CreateMap<CreateAnswer, Answer>()
                    .ForMember(dest => dest.AnswerText, act => act.MapFrom(src => src.AnswerText))
                    .ForMember(dest => dest.Questionid, act => act.MapFrom(src => src.Questionid))
                    .ForMember(dest => dest.Date, act => act.MapFrom(src => DateTime.Now));

        }
    }
}
