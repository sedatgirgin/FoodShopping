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

            //HttpContext e BasketRepository içinden Controller veya ControllerBase den kalıtmadan erişmek için kullandım. Kullanmaz isen erişemezsin
            services.AddHttpContextAccessor();

            //Authorize işemini kontrol edilebilmesi için UseAuthentication ve UseAuthorization için
            services.AddAuthentication();


            //userManager => aspnetUsers | roleManager => aspnetrole | signManager
            //ŞİFRE nin özelliklerini belirleyebiliyoruz
            services.AddIdentity<IdentityUser,IdentityRole>(opt=>
                {
                    opt.Password.RequireDigit = false;//sayı olmasın
                    opt.Password.RequireLowercase = false;//küçük harf zorunlulu kapalı
                    opt.Password.RequiredLength = 1;//1 uzunlulu olsun
                    opt.Password.RequireUppercase = false; //Büyük fark zorunlugunu kaldır
                    opt.Password.RequireNonAlphanumeric = false; //alphanumerik karekterleri  kaldır
                    
               }).AddEntityFrameworkStores<Context>();
            //Identity kullanımı için eklenmeli


            //Cookie bilgilerini ayarlama Identity - entityFramework 
            services.ConfigureApplicationCookie(opt =>
            {
                //cookie için bir adres vermez isek eğer cok farklı bir adrese bakıyor
                opt.LoginPath = new PathString("/Home/Login");
                opt.Cookie.Name = "SedatCookie";//cookie name degiştirilebilir
                opt.Cookie.HttpOnly = true;//javascript tarafından bu cookie çekilebilir olsun mu? HAYIR
                opt.Cookie.SameSite = SameSiteMode.Strict;// Dış kaynaklarda yani başka siteler kullanabilsin mi? sadece ben(Strict),  herkes kullanabilir(LAX).
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);// Bu cookie ne kadar süre kullanıcın bilgisayarından tutulsun? 30 dakika tutulsun
            });



           //Scope ile her request de baştan data cekmiyorum interface i gören obje doluyor
           services.AddScoped<ICategoryRepository, CategoryRepository>();
           services.AddScoped<IFoodRepository, FoodRepository>();
           services.AddScoped<ICategoryFoodRepository, CategoryFoodRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();


            //session kullanımını aktif etmek için 
            services.AddSession();


            //app.UseEndpoints için;
            services.AddControllersWithViews();
            services.AddMvc();

            //app.UseMvc ile URL verecek isem bunu aktive ediyorum
            //services.AddMvc(options => options.EnableEndpointRouting = false);

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

            //olmayan bir sayfaya girildiğinde {0} ile hata kodunu yakalayabiliriz.
            app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");


            //olmayan bir sayfa gitildiğinde URL ye 404 hatası verir.
            // app.UseStatusCodePages();


            //eklemiş olduğum admin rolündeki kulanıcıyı oluşturuyorum.
            // bir defa oluşturacak daha sonra tekrar oluşturmayacak çünkü artık null degil
            IdentityInitializer.CreateAdmin(userManager,roleManager);

            //ekli bütün dosyaları tarayıcıdan görmemizi sağlar
            app.UseStaticFiles();

            //session için eklendi
            app.UseSession();

            app.UseRouting();


            //Authorize için;
            //UseAuthentication ilgili kullanıcı giriş yapmış mı? yapmamış mı?
            //UseAuthorization giriş yapan kullanıcının rolu bahsi gecen durumları karşılıyor mu?
            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoint =>
            {
                //https://localhost:44391/
                endpoint.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                endpoint.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                ////https://localhost:44391/admin
                //endpoint.MapControllerRoute(
                // name: "area",
                // pattern: "{area?}/{controller=Home}/{action=Index}/{id?}"
                // );
            });






            //app.UseMvc(rauters =>
            //{
            //    rauters.MapRoute(
            //          name: "default", template: "{controller=Home}/{action=Index}/{id?}");
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
