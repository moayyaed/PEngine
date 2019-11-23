using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using PEngine.Models.Data;

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
            services.AddSession();


#if (DEBUG)
            var mvcService = services.AddControllersWithViews();
            mvcService.AddRazorRuntimeCompilation();
#else
            services.AddControllersWithViews();
#endif

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options => {
                        options.LoginPath = new PathString("/User/Login");
                        options.LogoutPath = new PathString("/User/Logout");
                    });

            services.UseDatabase((DBMSType)Configuration.GetValue("Dbms", 0),
                Configuration.GetValue("ConnectionString", string.Empty));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                if (string.IsNullOrEmpty(BlogContextFactory.ConnectionString))
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "Install/{action=Index}/{id?}"
                        );
                }
                else
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                }
            });
        }
    }
}
