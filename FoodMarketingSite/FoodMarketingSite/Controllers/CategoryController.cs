using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMarketingSite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodMarketingSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            //CategoryRepository categoryRepository = new CategoryRepository();
            //categoryRepository.TFindExpression(x => x.CategoryID < 41);

            return View(_categoryRepository.TList());
        }
    }
}
