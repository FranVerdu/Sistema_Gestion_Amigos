using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks; 
using Ejemplo01.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 

namespace Ejemplo01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940 

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        } 
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string conexion = Configuration.GetConnectionString("ConexionSQL_Amigos");
             
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(conexion));
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddSingleton<IAmigoAlmacen, MockAmigoRepositorio>();
            services.AddScoped<IAmigoAlmacen, SQLAmigoRepositorio>();
            //Agrega la configuracion predeterminada para el sistema de gestion de identidades, gesiton de usuarios y roles
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions d = new DeveloperExceptionPageOptions() { SourceCodeLineCount = 2 }; 
                app.UseDeveloperExceptionPage(d);
            }
            else if(env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }
             
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseAuthentication();
             

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{Controller=Home}/{action=Index}/{id?}");
            });


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
