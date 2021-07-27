using HON.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HON
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            //services.AddSingleton<IStudentRepository, MockStudentRepository>();
            services.AddScoped<IStudentRepository, SqlStudentRepository>();
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
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("M1: Incoming Request\n");
            //    await next();
            //    await context.Response.WriteAsync("M1: Outgoing Response\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("M2: Incoming Request\n");
            //    await next();
            //    await context.Response.WriteAsync("M2: Outgoing Response\n");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("M3: Incoming Request handled and response generated\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Getting Response from 1st Middleware");
            //    await next();
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Getting Response from 2nd Middleware");
            //});
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseMvc(routes => {
            //    routes.MapRoute("default", "{controller}/{action}/{id}");
            //});


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
