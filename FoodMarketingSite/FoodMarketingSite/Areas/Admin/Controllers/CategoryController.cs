using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMarketingSite.Data.Models;
using FoodMarketingSite.Data.Models.AdminProcess;
using FoodMarketingSite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodMarketingSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(_categoryRepository.TList());
        }


        public IActionResult AddCategory()
        {
            return View(new CategoryModel());
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.CategoryName = categoryModel.CategoryName;
                category.CategoryDescription = categoryModel.CategoryDescription;
                _categoryRepository.TAdd(category);
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View(categoryModel);
        }

        public IActionResult UpdateCategory(int Id)
        {
            var category = _categoryRepository.TGet(Id);

            CategoryModel categoryModel = new CategoryModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription
            };
            return View(categoryModel);
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryRepository.TGet(categoryModel.Id);

                category.Id = categoryModel.Id;
                category.CategoryName = categoryModel.CategoryName;
                category.CategoryDescription = categoryModel.CategoryDescription;

                _categoryRepository.TUpdate(category);
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View(categoryModel);
        }

        public IActionResult DeleteCategory(int Id)
        {
            var category = _categoryRepository.TGet(Id);

            _categoryRepository.TDelete(category);

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}
