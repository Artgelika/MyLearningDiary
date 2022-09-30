using LearningDiary.API.Models;
using LearningDiary.API.Services;
using LearningDiary.API.Services.Interfaces;
using Microsoft.Extensions.Options; 

namespace LearningDiary.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomMongoDbSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<LearningDiaryDatabaseSettings>(
                  configuration.GetSection(nameof(LearningDiaryDatabaseSettings)));

            services.AddSingleton<ILearningDiaryDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<LearningDiaryDatabaseSettings>>().Value);

            services.AddSingleton<SavePointService>();
        }

        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ISavePointService, SavePointService>();
        }


    }
}
