using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FoodMarketingSite.Areas.Admin.Controllers
{
    //Admin area geçmez isem eğer 2 tane HomeController olduğu için hangisini çalıştıracağını anlayamaz
    [Area("admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
