using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodMarketingSite.Data.Models
{
    public class Context:IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseNpgsql("User ID=postgres;Password=Strong2020.;Server=localhost;Port=5432;Database=ShopDb;Integrated Security=true;Pooling=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasMany(I => I.FoodCategories).
                WithOne(I=>I.Food).HasForeignKey(I=>I.FoodID);
            modelBuilder.Entity<Category>().HasMany(I => I.FoodCategories).
              WithOne(I => I.Category).HasForeignKey(I => I.CategoryID);
            //Tekrarlı data girmesinin önüne geçmek için
            modelBuilder.Entity<FoodCategory>().HasIndex(I => new
            {
                I.CategoryID,
                I.FoodID
            }).IsUnique();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }

    }
}
