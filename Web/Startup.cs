using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emosir.Dominio.Interface;
using Emsoir.Dominio.Cors;
using Emsoir.Infraestructura.Data;
using Emsoir.Infraestructura.Interface;
using Emsoir.Infraestructura.Repository;
using Emsoir.Transversal.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Web
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
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConectionFactory, ConectionFactory>();

            services.AddScoped<IUsuarioRollMenuPaginaRepositorio, UsuarioRollMunuDinamicoRepositorio>();
            services.AddScoped<IUsuarioRollManuDinamicoDominio, UsuarioRollMenuDinamicoDominio>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc();
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
