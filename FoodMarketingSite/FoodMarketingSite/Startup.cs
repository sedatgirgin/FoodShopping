using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMarketingSite.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FoodMarketingSite
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddScoped<ICategoryRepository, CategoryRepository>();
           services.AddScoped<IFoodRepository, FoodRepository>();
           services.AddScoped<ICategoryFoodRepository, CategoryFoodRepository>();

            //session için eklendi
            services.AddSession();

            //Identity kullanımı için eklenmeli
           // services.AddIdentity().AddEntityFrameworkStores();

           services.AddMvc();
           services.AddMvc(options => options.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //uygulama development modda ise;
            //launchSettings.json dosyasından anlıyor dev olup olmadığını
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            //session için eklendi
            app.UseSession();

            app.UseMvc(rauters =>
            {
                rauters.MapRoute(
                      name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseEndpoints(endpoint =>
            //{
            //    endpoint.MapControllerRoute(
            //        name: "default",
            //        pattern: "{ Controller = Home}/{ Action = Index}/{ id ?}"
            //        );
            //});
            //sadece int girebilir
            //app.UseMvc(rauters =>
            //{
            //    rauters.MapRoute(
            //          name: "default", template: "{controller=Home}/{action=Index}/{id:int sadece int veya "alpha" olursa string girebilir sadece}");

            //});
        }
    }
}
