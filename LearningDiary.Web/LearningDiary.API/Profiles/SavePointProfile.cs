using AutoMapper;
using LearningDiary.API.Models.DTOs;
using LearningDiary.API.Models.Entities;

namespace LearningDiary.API.Profiles
{
    public class SavePointProfile : Profile
    {
        public SavePointProfile()
        {
            CreateMap<SavePointCreate, SavePoint>();
            CreateMap<SavePointUpdate, SavePoint>();
            CreateMap<SavePoint, SavePointRead>();
        }
    }
}
