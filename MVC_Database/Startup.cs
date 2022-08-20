using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database
{
    public class Startup
    {
        IConfiguration config;

        public Startup(IConfiguration configuration)
        {
            config = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<db1045Context>(db => db.UseSqlServer(config.GetConnectionString("mycon")));
            services.AddMvc(ep => ep.EnableEndpointRouting=false);

            // dependency injection
            services.AddTransient<IDept, DeptRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // which we see on exception occurance -  by default
                app.UseDeveloperExceptionPage();
            }
            else {
                // use this exception to handle exception in production env
                app.UseExceptionHandler("/Error");
            }


            app.UseStaticFiles();
            app.UseRouting();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "default",
                        template: "{controller=Dept}/{action=List}/{id?}"
                    );
            });

        }
    }
}
