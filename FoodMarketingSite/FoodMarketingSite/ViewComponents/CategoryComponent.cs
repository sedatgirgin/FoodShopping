using FoodMarketingSite.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.ViewComponents
{
    public class CategoryComponent : ViewComponent
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryRepository.TList());
        }
    }
}
