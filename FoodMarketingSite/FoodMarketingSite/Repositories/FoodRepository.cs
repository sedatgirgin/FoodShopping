using FoodMarketingSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Repositories
{
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        private readonly ICategoryFoodRepository _categoryFoodRepository;

        public FoodRepository(ICategoryFoodRepository categoryFoodRepository)
        {
            _categoryFoodRepository = categoryFoodRepository;
        }

        public void AddFoodCategory(FoodCategory foodCategory)
        {
            var foodCategory1 = _categoryFoodRepository.TFindExpression(I => I.CategoryID == foodCategory.CategoryID &&
                       I.FoodID == foodCategory.FoodID);
            if (foodCategory1 == null)
            {
                _categoryFoodRepository.TAdd(foodCategory);
            }
        }

        public void DeleteFoodCategory(FoodCategory foodCategory)
        {
            var foodCategory1 = _categoryFoodRepository.TFindExpression(I => I.CategoryID == foodCategory.CategoryID &&
            I.FoodID == foodCategory.FoodID);
            if (foodCategory1 !=null)
            {
                _categoryFoodRepository.TDelete(foodCategory1);
            }
        }

        /// <summary>
        /// many to many ilişkide ilgili ürüne ait foodId ye göre 3 tabloyuı birleştirme
        /// </summary>
        /// <param name="foodId"></param>
        /// <returns></returns>
        public List<Category> GetCategoryList(int foodId)
        {
            //using var context = new Context();
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

        public List<Food> GetFoodList(int CategoryId)
        {
           return context.Foods.Join(context.FoodCategories, food => food.Id,
                foodCategory => foodCategory.FoodID, (food2, foodCategory2) => new
                {
                    food = food2,
                    foodCategory = foodCategory2
                }).Where(I => I.foodCategory.CategoryID == CategoryId).Select(I => new Food
                {
                    Id = I.food.Id,
                    Name = I.food.Name,
                    Description = I.food.Description,
                    ImageURL = I.food.ImageURL,
                    Stock = I.food.Stock,
                    Price = I.food.Price
                }).ToList();
        }
    }
}
