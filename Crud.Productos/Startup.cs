
using Emosir.Dominio.Interface;
using Emsoir.Dominio.Cors;
using Emsoir.Dominio.Entity;
using Emsoir.Dominio.Entity.Models;
using Emsoir.Infraestructura.Data;
using Emsoir.Infraestructura.Interface;
using Emsoir.Infraestructura.Repository;
using Emsoir.Transversal.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Crud.Productos
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

            services.AddScoped<ICategoriaDominio, CategoriaDominio>();
            services.AddScoped<Irepository<Categoria>, Repositoy<Categoria>>();
            services.AddScoped<IProductoDominio,ProductoDominio>();
            services.AddScoped<Irepository<Producto>, Repositoy<Producto>>();

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
