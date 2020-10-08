using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Data.Models.Login
{
    public class UserLoginModel
    {
        //Required ile bu alan gerekli hale gelir boş geçemez.
        //boş bırakılırsa mesaj ekleyelim
        //!LİNK BAK: https://docs.microsoft.com/tr-tr/aspnet/mvc/overview/older-versions/getting-started-with-aspnet-mvc3/cs/adding-validation-to-the-model
        
        [Required(ErrorMessage ="UserName cannot null")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot null")]
        public string Password { get; set; }

        //beni hatırlaya click olursa 30 dakika cookie de tut demez ise tutma
        public bool RememberMe { get; set; }

    }
}
