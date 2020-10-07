using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMarketingSite.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodMarketingSite.Controllers
{

    /// <summary>
    /// şeklinde Route eklersem eğer bu durumda Startup.cs deki Raouter i ezmiş olurum ve sayfa burdakini dinler
    /// https://localhost:44391/sedat/Index yazmak gerek çalışması için
    /// </summary>
    //[Route("sedat/[action]")]
    public class HomeController : Controller
    {
        private readonly IFoodRepository _foodRepository;

        public HomeController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public IActionResult Index()
        {
            SetCookie("ad", "SEDAT");
            SetSession("soyad", "GİRGİN");

            return View(_foodRepository.TList());
        }
        public IActionResult FoodDetail(int id)
        {
            ViewBag.Cook = GetCookie("ad");
            ViewBag.Ses = GetSession("soyad");

            return View(_foodRepository.TGet(id));
        }
        //önemli methodlar
        //document.cookie diyerek tarayıcıda görebiliriz
        public void SetCookie(string key,string value)
        {
            HttpContext.Response.Cookies.Append(key, value);
        }

        public string GetCookie(string key)
        {
            HttpContext.Request.Cookies.TryGetValue(key,out string value);
            return value;
        }

        public void SetSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
        }

        public string GetSession(string key)
        {
            string value = HttpContext.Session.GetString(key);

            return value;
        }

    }
}
