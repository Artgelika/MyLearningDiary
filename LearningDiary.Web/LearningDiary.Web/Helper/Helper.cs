namespace LearningDiary.Web.Helper
{
    public class SavePointAPI
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7268/");
            return Client;
        }

    }
}
