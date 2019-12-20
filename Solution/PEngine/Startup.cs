using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Security;
using PEngine.Common.Components;

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

            // Authentication
            /*
            services.AddIdentity<UserModel, IdentityRole>(
                    options =>
                    {
                        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                        options.Lockout.MaxFailedAccessAttempts = 3;

                        options.User.RequireUniqueEmail = true;

                        options.Password.RequiredLength = 8;
                    }
                ).AddEntityFrameworkStores<BlogDbContext>();
             

            // Load DB Connection String from appsettings.json
            var dbms = (DBMSType) Configuration.GetValue("Dbms", 0);
            var connectionString = Configuration.GetConnectionString("Database"); 
            
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidDataException("ConnectionString must be specified");
            }

            services.UseDatabase(dbms, connectionString);
            */ 
            
            // Configure DI Containers
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
#if (DEBUG)
            app.UseDeveloperExceptionPage();
#else
            app.UseExceptionHandler("/Error");
            app.UseHsts();
#endif

            app.UseHttpsRedirection()
               .UseStaticFiles("/Static")
               .UseRouting();

//            app.UseSession()
//               .UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
