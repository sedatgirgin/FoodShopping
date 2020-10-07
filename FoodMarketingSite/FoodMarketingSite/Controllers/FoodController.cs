using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMarketingSite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodMarketingSite.Controllers
{
    public class FoodController : Controller
    {

        private readonly IFoodRepository _foodRepository;

        public FoodController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public IActionResult Index()
        {
           // FoodRepository foodRepository = new FoodRepository();
           //Garbelage collector ram deki datayı bu şekilde temizleyebilirsin
            // ((IDisposable)foodRepository).Dispose();
            //using (FoodRepository foodRepository = new FoodRepository())
            //{
            //}
            return View(_foodRepository.TList());
        }
    }
}
