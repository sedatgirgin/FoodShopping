using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Data.Models.User
{
    public class IdentityInitializer
    {
        public static void CreateAdmin(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            //sedat adında kullanıcı var mı? 
            //burda "Async" olmasa "Result" ile işlem bitene kadar arkada başka tired çalıştımaz.
            IdentityUser appUser = new IdentityUser
            {
                PhoneNumber = "05399170935",
                Email = "sedatgirgin09@gmail.com",
                UserName = "Yoruk"
            };
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                //yoksa böyle bir kullanıcı kendi kullanıcımızı oluşturuyoruz.
                //password 3 olsun
                var identityUserResult = userManager.CreateAsync(appUser,"3").Result;

            }
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };
                //yoksa böyle bir kullanıcı kendi kullanıcımızı oluşturuyoruz.
                var identityRoleResult = roleManager.CreateAsync(role).Result;
                var result = userManager.AddToRoleAsync(appUser, role.Name).Result;
            }

        }


    }
}
