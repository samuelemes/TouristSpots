using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace TouristSpotCore
{
    public class StartupBase
    {
        public void ConfigureServicesBase(IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation();
            services.AddControllers(); // or services.AddMvcCore()
        }
        public void ConfigureBase(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
