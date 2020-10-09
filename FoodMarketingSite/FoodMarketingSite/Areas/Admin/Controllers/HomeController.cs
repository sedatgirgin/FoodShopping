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
        private readonly ICategoryRepository _categoryRepository;
        public HomeController(IFoodRepository foodRepository,ICategoryRepository categoryRepository)
        {
            _foodRepository = foodRepository;
            _categoryRepository = categoryRepository;
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

        //ilgili ürüne category atama işlemi
        public IActionResult AssignCategory(int Id)
        {
            //sadece ürüne ait kategorilerin ismini dön
            var uruneAitKategorilerinİsmi =_foodRepository.GetCategoryList(Id).Select(I=>I.CategoryName);
            var tumKategoriler = _categoryRepository.TList();

            //AssignCategory methodunun httppost u na data taşımak için
            TempData["UrunId"] = Id;

            List<FoodAssignCatagoryModel> list = new List<FoodAssignCatagoryModel>();
            foreach (var item in tumKategoriler)
            {
                FoodAssignCatagoryModel model = new FoodAssignCatagoryModel();
                model.CategoryID = item.Id;
                model.CategoryName = item.CategoryName;
                model.CategoryDescription = item.CategoryDescription;
                model.IsThere = uruneAitKategorilerinİsmi.Contains(item.CategoryName);

                list.Add(model);
            }
            return View(list);
        }

        [HttpPost]
        public IActionResult AssignCategory(List<FoodAssignCatagoryModel> list)
        {
            int foodId = (int)TempData["UrunId"];
             foreach (var item in list)
            {
                //kullanıcı ilgili ürüne kategori eklemiş mi? click atmış mı?
                if (item.IsThere)
                {
                    _foodRepository.AddFoodCategory(new FoodCategory
                    {
                        CategoryID = item.CategoryID,
                        //foodID olmaıdı içim
                        FoodID = foodId
                    });
                }
                else
                {

                    _foodRepository.DeleteFoodCategory(new FoodCategory
                    {
                        CategoryID = item.CategoryID,
                        //foodID olmaıdı içim
                        FoodID = foodId
                    });
                }

            }
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}
