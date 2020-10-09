using FoodMarketingSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodMarketingSite.Repositories
{
    public interface IFoodRepository :IGenericRepository<Food>
    {
        List<Category> GetCategoryList(int foodId);
        void AddFoodCategory(FoodCategory foodCategory);
        void DeleteFoodCategory(FoodCategory foodCategory);
        List<Food> GetFoodList(int CategoryId);
    
    }
}
