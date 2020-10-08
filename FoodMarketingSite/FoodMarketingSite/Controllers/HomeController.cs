using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMarketingSite.Data.Models.Login;
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

        //cooklie nin gösterdigi login sayfası
        [HttpGet]
        public IActionResult Login()
        {
            return View(new UserLoginModel());
        }

        //login sayfsından alınan username -password bilgisi gelir
        //login.cshtml sayfadında asp-for sayesinde UserLoginModel map lendi
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            //UserLoginModel - içinde tanımladığımız [Required] ların sağlanıp sağlanmadığını
            //ModelState.IsValid ile kontrol edebiliriz
            //sağlamıyor ise aynı sayfaya gitsin
            //sağlıyor ise giriş yapsın
            //!LİNK BAK: https://docs.microsoft.com/tr-tr/aspnet/mvc/overview/older-versions/getting-started-with-aspnet-mvc3/cs/adding-validation-to-the-model
            //get - post  - ModelState.IsValid durumunu açıklıyor
            if (ModelState.IsValid)
            {

            }
            return View(userLoginModel);
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
