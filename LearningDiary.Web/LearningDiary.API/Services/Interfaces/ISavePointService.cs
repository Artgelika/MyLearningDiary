using LearningDiary.API.Models.DTOs;
using LearningDiary.API.Models.Entities;

namespace LearningDiary.API.Services.Interfaces
{
    public interface ISavePointService
    {
        List<SavePoint> GetAll();
        List<SavePoint> GetAllByTags(string tagName);
        SavePoint Get(string id);
        SavePointRead Create(SavePointCreate savePoint);
        void Update(string id, SavePointUpdate savePointIn);
        void Remove(SavePoint savePointIn);
        void Remove(string id);
    }
}