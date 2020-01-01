using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PEngine.Common.Components;
using PEngine.Common.Components.Database;
using PEngine.Common.Components.Database.Contexts;
using PEngine.Common.Models.Schema;

namespace PEngine
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            /*
             * Enable Runtime Compilation
             * Well, It seems that ASP.NET Core no longer support
             * runtime view compilation from 3.x,
             * So I had to add RazorRuntimeCompilation Package from NuGet.
             *
             * However, This feature will not be activated in Release Build.
             */
#if (DEBUG)
            services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();
#else
            services.AddControllersWithViews();
#endif
            
            /*
             * Configure Razor View Engine
             * - ViewLocationExpanders (Refer PEngineViewLocationExpander)
             */
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new PEngineViewLocationExpander());
            });

            // Load DB Connection String from appsettings.json
            var dbms = (DBMSType) Configuration.GetValue("Dbms", 0);
            var connectionString = Configuration.GetConnectionString("Database"); 
            
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidDataException("ConnectionString must be specified");
            }

            services.UseDatabase(dbms, connectionString);
            
            // Authentication
            services.AddSession();
            services.AddAuthentication();
            services.AddIdentity<UserModel, IdentityRole<long>>(
                options =>
                {
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 3;

                    options.User.RequireUniqueEmail = true;
                    options.Password.RequiredLength = 8;
                }
            ).AddEntityFrameworkStores<BlogDbContext>();
            
            // Configure DI Containers
            services.AddHttpContextAccessor();
        }

        public static void Configure(IApplicationBuilder app)
        {
#if (DEBUG)
            app.UseDeveloperExceptionPage();
#else
            app.UseExceptionHandler("/Error");
            app.UseHsts();
#endif

            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.UseHttpsRedirection()
               .UseStaticFiles("/Static")
               .UseRouting();

            app.UseSession()
               .UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
