using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FoodMarketingSite.Data.Models;
using FoodMarketingSite.Data.Models.AdminProcess;
using FoodMarketingSite.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodMarketingSite.Areas.Admin.Controllers
{
    //Admin area geçmez isem eğer 2 tane HomeController olduğu için hangisini çalıştıracağını anlayamaz
    //Authorize sayesinde sadece giriş yapmış kullanıcılar erişebilir
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IFoodRepository _foodRepository;

        public HomeController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public IActionResult Index()
        {
            return View(_foodRepository.TList());
        }
        public IActionResult Add()
        {
           return View(new FoodModel());
        }

        [HttpPost]
        public IActionResult Add(FoodModel foodModel)
        {
            if (ModelState.IsValid)
            {
                Food food = new Food();

                if (foodModel.ImageURL != null)
                {
                    //aynı isimde resim kaydetmemek için;
                    var uzanti = Path.GetExtension(foodModel.ImageURL.FileName);
                    var newImageName = Guid.NewGuid() + uzanti;
                    //Directory.GetCurrentDirectory uygulamanın path
                    //Path.Combine pathleri birleştirir.
                  
                    var NewImagePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/img/" + newImageName);
                    var stream = new FileStream(NewImagePath, FileMode.Create);

                    //resmi NewImagePath adresine kopyaladık
                    foodModel.ImageURL.CopyTo(stream);
                    food.ImageURL = newImageName;

                }
                food.Name = foodModel.Name;
                food.Description = foodModel.Description;
                food.Price = foodModel.Price;
                _foodRepository.TAdd(food);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(foodModel);
        }

        public IActionResult UpdateFood(int Id)
        {
           var food = _foodRepository.TGet(Id);

            FoodModel foodModel = new FoodModel
            {
                Id = food.Id,
                Name = food.Name,
                Description = food.Description,
                Price = food.Price
            };
            return View(foodModel);
        }

        [HttpPost]
        public IActionResult UpdateFood(FoodModel foodModel)
        {
            if (ModelState.IsValid)
            {
                var food = _foodRepository.TGet(foodModel.Id);
                if (foodModel.ImageURL != null)
                {
                    //aynı isimde resim kaydetmemek için;
                    var uzanti = Path.GetExtension(foodModel.ImageURL.FileName);
                    var newImageName = Guid.NewGuid() + uzanti;
                    //Directory.GetCurrentDirectory uygulamanın path
                    //Path.Combine pathleri birleştirir.

                    var NewImagePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/img/" + newImageName);
                    var stream = new FileStream(NewImagePath, FileMode.Create);

                    //resmi NewImagePath adresine kopyaladık
                    foodModel.ImageURL.CopyTo(stream);
                    food.ImageURL = newImageName;

                }
                food.Id = foodModel.Id;
                food.Name = foodModel.Name;
                food.Description = foodModel.Description;
                food.Price = foodModel.Price;

                _foodRepository.TUpdate(food);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(foodModel);
        }

        public IActionResult DeleteFood(int Id)
        {
            var food = _foodRepository.TGet(Id);

            _foodRepository.TDelete(food);

            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

    }
}
