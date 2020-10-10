using FoodMarketingSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Repositories
{
    public interface IBasketRepository
    {
        void AddToBasket(Food food);
        void ExitFromBasket(Food food);
        List<Food> GetAllFoodAtTheBasket();
        void DeleteAllBasket();

    }
}
