namespace LearningDiary.API.Models
{
    public class LearningDiaryDatabaseSettings : ILearningDiaryDatabaseSettings
    {
        public string LearningDiaryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ILearningDiaryDatabaseSettings
    {
        string LearningDiaryCollectionName { get; set; }
        string ConnectionString { get; set; }   
        string DatabaseName { get; set; }
    }
}
