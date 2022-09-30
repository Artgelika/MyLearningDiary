using AutoMapper;
using LearningDiary.API.Models;
using LearningDiary.API.Models.DTOs;
using LearningDiary.API.Models.Entities;
using LearningDiary.API.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using MongoDB.Driver;

namespace LearningDiary.API.Services
{
    public class SavePointService : ISavePointService
    {        
        private readonly IMongoCollection<SavePoint> _points;
        private readonly IMapper _mapper;

        public SavePointService(ILearningDiaryDatabaseSettings settings, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _points = database.GetCollection<SavePoint>(settings.LearningDiaryCollectionName);
            _mapper = mapper;
        }

        public List<SavePoint> GetAll()
            => _points.Find(point => true).ToList();

        public SavePoint Get(string id)
            => _points.Find(point => point.SavePointId == id).FirstOrDefault();
        

        public SavePointRead Create(SavePointCreate savePointCreateDTO)
        {
            var newSavePoint = _mapper.Map<SavePoint>(savePointCreateDTO);
            _points.InsertOne(newSavePoint);
            return _mapper.Map<SavePointRead>(newSavePoint);
        }

        public void Update(string id, SavePointUpdate savePointIn)
        {
            var updatedSavePoint = _mapper.Map<SavePoint>(savePointIn);
            _points.ReplaceOne(point => point.SavePointId == id, updatedSavePoint);
        }

        public void Remove(SavePoint savePointIn)
            => _points.DeleteOne(point => point.SavePointId == savePointIn.SavePointId);

        public void Remove(string id)
            => _points.DeleteOne(point => point.SavePointId == id);
    }
}
