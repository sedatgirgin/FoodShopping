using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMarketingSite.Data.Models;
using FoodMarketingSite.Data.Models.User;
using FoodMarketingSite.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace FoodMarketingSite
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Identity kullanımı için eklenmeli
            services.AddDbContext<Context>();
            //userManager => aspnetUsers | roleManager => aspnetrole | signManager
            //burda şifre ye bazı opsionlar verebiliriz
            services.AddIdentity<IdentityUser,IdentityRole>(opt=>
                {
                    opt.Password.RequireDigit = false;//sayı olmasın
                    opt.Password.RequireLowercase = false;//küçük harf zorunlulu kapalı
                    opt.Password.RequiredLength = 1;//1 uzunlulu olsun
                    opt.Password.RequireUppercase = false; //Büyük fark zorunlugunu kaldır
                    opt.Password.RequireNonAlphanumeric = false; //alphanumerik karekterleri  kaldır
               }).AddEntityFrameworkStores<Context>();
            //Identity kullanımı için eklenmeli




           //Scope ile her request de baştan data cekmiyorum interface i gören obje doluyor
           services.AddScoped<ICategoryRepository, CategoryRepository>();
           services.AddScoped<IFoodRepository, FoodRepository>();
           services.AddScoped<ICategoryFoodRepository, CategoryFoodRepository>();



            //session için eklendi
            services.AddSession();


           // services.AddControllersWithViews();
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
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


            //eklemiş olduğum admin rolündeki kulanıcıyı oluşturuyorum.
            // bir defa oluşturacak daha sonra tekrar oluşturmayacak çünkü artık null degil
            IdentityInitializer.CreateAdmin(userManager,roleManager);

            //app.UseRouting();
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
