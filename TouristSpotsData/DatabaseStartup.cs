using Microsoft.Extensions.DependencyInjection;
using TouristSpotsData.Repositories;
using TouristSpotsDomain.Interface.Repositories;

namespace Database
{
    public class DatabaseStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IFavoriteTouristSpotRepository, FavoriteTouristSpotRepository>();
            services.AddTransient<ITouristSpotPhotoRepository, TouristSpotPhotoRepository>();
            services.AddTransient<ITouristSpotRepository, TouristSpotRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
