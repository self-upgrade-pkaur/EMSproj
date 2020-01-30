using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeLib.Abstractions;
using EMS_Data.Models;
using EMS_Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EMS_Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method we use for DI
        //Configuration Variable will look for the environment settings in these files
        /*
             launchSettings.json
             Secrets.json
             appsettings.<environment>.json
             appsettings.json
             */
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //looks for connections string from one of the .json files
            string connectionString = Configuration.GetConnectionString("TestDb");

            services.AddDbContext<EmployeeDbContext>(options=>
                options.UseSqlServer(connectionString));
            // Adding Dependency to your Controller to use Db
            services.AddTransient<IRepositoryEmployee<EmployeeLib.Employee>, RepositoryEmployee>();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute();//{Controller}/{Action}/{id?}
            app.UseRouting();// this is the middleware for routing
           
            app.UseAuthorization();

            // conventional Routing
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute(
                //    name:"Employee",
                //    pattern:"Employee/{action=Index}/{id?}"
                //    );

            });
            app.UseSession();
        }
    }
}
