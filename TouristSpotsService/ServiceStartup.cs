using Microsoft.Extensions.DependencyInjection;
using TouristSpotsService;
using TouristSpotsService.Interfaces;

namespace Service
{
    public class ServiceStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IFavoriteTouristSpotService, FavoriteTouristSpotService>();
            services.AddTransient<ITouristSpotPhotoService, TouristSpotPhotoService>();
            services.AddTransient<ITouristSpotService, TouristSpotService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
