using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMarketingSite.Data.Models.Login;
using FoodMarketingSite.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IFoodRepository _foodRepository;

        private readonly IBasketRepository _basketRepository;
        public HomeController(IFoodRepository foodRepository, SignInManager<IdentityUser> signInManager, IBasketRepository basketRepository)
        {
            _signInManager = signInManager;
            _foodRepository = foodRepository;
            _basketRepository = basketRepository;
        }

        public IActionResult Index(int? CategoryId)
        {
            SetCookie("ad", "SEDAT");
            SetSession("soyad", "GİRGİN");

            ViewBag.CategoryId = CategoryId;
            return View();
        }
        public IActionResult FoodDetail(int id)
        {
            ViewBag.Cook = GetCookie("ad");
            ViewBag.Ses = GetSession("soyad");

            return View(_foodRepository.TGet(id));
        }





        /*sepet işlemleri*/


        public IActionResult Basket()
        {
            return View(_basketRepository.GetAllFoodAtTheBasket());
        }

        public IActionResult AddToBasket(int id)
        {
            var food =_foodRepository.TGet(id);
            _basketRepository.AddToBasket(food);
            TempData["SepetBildirim"] = "Ürün sepete eklendi";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteAllBasket(decimal toplamAlinan)
        {
            _basketRepository.DeleteAllBasket();
            return RedirectToAction("ThankYou", new { toplamAlinan });
        }

        public IActionResult ThankYou(decimal fiyatToplam)
        {
            ViewBag.Fiyat = fiyatToplam;
            return View();
        }

        public IActionResult DeleteBasket(int id)
        {
           var food = _foodRepository.TGet(id);
            _basketRepository.ExitFromBasket(food);
            return RedirectToAction("Basket", "Home");
        }


        /*sepet işlemleri*/







        //cooklie nin gösterdigi login sayfası
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


            //!!!!!!!!!!!!!!!!!!!Bu dogrulama işlemleri server- site olarak kontol edilir.!!!!!!!!!! 
            //Bunu Client site yapabiliriz bunun için jquery-validation-unobtrusiv ve jquery-validate ve jquery kütüphanlerini ekledim. bunları kullanmam yeterli
            if (ModelState.IsValid)
            {
                // PasswordSignInAsync(userLoginModel.UserName,userLoginModel.Password,userLoginModel.RememberMe,false)   =>  lockoutOnFailure false ise şifreyi yanlış da girseniz sizi kitlemez.
                // PasswordSignInAsync(userLoginModel.UserName,userLoginModel.Password,userLoginModel.RememberMe,true)   =>  lockoutOnFailure true ise sizi şifre yanlış ise 5 dakika kitler.

             var signInResult = _signInManager.PasswordSignInAsync(userLoginModel.UserName, userLoginModel.Password, userLoginModel.RememberMe, true);

                //if(signInResult.Result.IsLockedOut) // ilgili kullanıcı kilitlimi değil mi?
                // if(signInResult.Result.IsNotAllowed) // imail - şifre - tel onayı onaylama gibi bir şart varsa buraya düşer?
                //if (signInResult.Result.RequiresTwoFactor)//telefona yada maile gelen mesaj ile giriş
                if (signInResult.Result.Succeeded)//başarılı ise
                {
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                //    <div asp-validation-summary="ModelOnly" class="text-danger"></div> tag inde hata mesajını yazar
                ModelState.AddModelError("", "UserName or Password Fail");
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




        //Startup da {0} ile yakaladığımız kod dur.
        public IActionResult NotFound(int code)
        {
            ViewBag.code = code;
            return View();
        }

    }
}
