using FoodMarketingSite.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.ViewComponents
{
    public class FoodComponent:ViewComponent
    {
        private readonly IFoodRepository _foodRepository;
        public FoodComponent(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(_foodRepository.TList());
        }
    }
}
