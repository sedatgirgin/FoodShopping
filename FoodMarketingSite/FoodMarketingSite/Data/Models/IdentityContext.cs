using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Data.Models
{
    public class IdentityContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-OOIG6GG\\SQLEXPRESS; Database=DbFoodMarketingIdentity; Integrated Security=True");
            //CMD aşağıdaki gibi olmalı DB ismini farklı yaptım çünkü Identity için farklı bir DB istiyorum
            //add-migration IdentityCreateContex -context IdentityContext
            // update-database -context IdentityContext
            //base i kaldırmıyoruz çünkü IdentityDbContext DbContext in alt sınıfıdır.
            base.OnConfiguring(optionsBuilder);
        }
    }
}
