using System.Reflection;
using Meetup.Authorization.IdentityServer.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Meetup.Authorization.IdentityServer
{
    public class Startup
    {
        private readonly IHostEnvironment _environment;

        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            _environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(config =>
            {
                config.UseInMemoryDatabase("DEMO_ONLY");
            })
                .AddIdentity<IdentityUser, IdentityRole>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "IdentityServer.Cookies";
            });

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentityServer()
                .AddAspNetIdentity<IdentityUser>()
                .AddInMemoryClients(IdentityServerConfiguration.GetClients())
                .AddInMemoryApiResources(IdentityServerConfiguration.GetApiResources())
                .AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResources())
                .AddInMemoryApiScopes(IdentityServerConfiguration.GetApiScopes()) // IdentityServer4 version 4.x.x changes
                .AddDeveloperSigningCredential();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
