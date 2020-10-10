using FoodMarketingSite.CustomExtentions;
using FoodMarketingSite.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Generic;

namespace FoodMarketingSite.Repositories
{
    public class BasketRepository: IBasketRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BasketRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void AddToBasket(Food food)
        {
           var getList = _httpContextAccessor.HttpContext.Session.GetObject<List<Food>>("sepet");
            if (getList == null)
            {
                getList = new List<Food>();
                getList.Add(food);
            }
            else
            {
                getList.Add(food);
            }
            _httpContextAccessor.HttpContext.Session.SetObject("sepet", getList);
        }

        public void ExitFromBasket(Food food)
        {
            var getList = _httpContextAccessor.HttpContext.Session.GetObject<List<Food>>("sepet");
            //IEquatable<Food> kullanmaz isek nesne eşitmi bilemiyor bu yüzden silmiyor.
            getList.Remove(food);
            _httpContextAccessor.HttpContext.Session.SetObject<List<Food>>("sepet",getList);
        }

        public List<Food> GetAllFoodAtTheBasket()
        {
           return _httpContextAccessor.HttpContext.Session.GetObject<List<Food>>("sepet");
        }

        public void DeleteAllBasket()
        {
            _httpContextAccessor.HttpContext.Session.Remove("sepet");
        }

    }
}
