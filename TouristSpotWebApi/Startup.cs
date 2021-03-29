using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TouristSpotsData;
using TouristSpotsDomain.Entities.Security;

namespace TouristSpotWebApi
{
    public class Startup : TouristSpotCore.StartupBase
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServicesBase(services);

            Database.DatabaseStartup.ConfigureServices(services);
            Domain.DomainStartup.ConfigureServices(services);
            Service.ServiceStartup.ConfigureServices(services);

            services.AddDbContext<AppDbContext>();

            services.AddAuthentication();
            //services.AddAuthentication()
            //        .AddFacebook(options => {
            //            options.AppId = Configuration["Authentication:Facebook:2886996594903513"];
            //            options.AppSecret = Configuration["Authentication:Facebook:2886996594903513"];
            //            options.AccessDeniedPath = "/AccessDeniedPathInfo";
            //        });


            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressConsumesConstraintForFormFileParameters = true;
                    options.SuppressInferBindingSourcesForParameters = true;
                    options.SuppressModelStateInvalidFilter = true;
                    options.SuppressMapClientErrors = true;
                });



            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();

            //services.AddRazorPages();
            services.AddControllersWithViews();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.ConfigureBase(app, env);

          

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
                app.UseDatabaseErrorPage();
                //builder.AddUserSecrets();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(cor =>
            {
                cor.AllowAnyHeader();
                cor.AllowAnyMethod();
                cor.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
