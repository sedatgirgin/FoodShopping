using FoodMarketingSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Repositories
{
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        /// <summary>
        /// many to many ilişkide ilgili ürüne ait foodId ye göre 3 tabloyuı birleştirme
        /// </summary>
        /// <param name="foodId"></param>
        /// <returns></returns>
        public List<Category> GetCategoryList(int foodId)
        {
            using var context = new Context();
           return context.Foods.Join(context.FoodCategories, food => food.Id,
                foodCategory => foodCategory.FoodID, (u, uc) => new
                {
                    food = u,
                    foodCategory = uc
                }).Join(context.Categories, twoTable => twoTable.foodCategory.CategoryID,
                   category => category.Id, (uc, k) => new
                   {
                       food = uc.food,
                       category = k,
                       foodCategory = uc.foodCategory
                   }
                   ).Where(I => I.food.Id == foodId).Select(I => new Category
                   {
                       CategoryName = I.category.CategoryName,
                       Id = I.category.Id,
                       CategoryDescription = I.category.CategoryDescription
                   }).ToList();
        }
    }
}
