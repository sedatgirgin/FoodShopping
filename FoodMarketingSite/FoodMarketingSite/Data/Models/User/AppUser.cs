using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Data.Models.User
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }


    }
}
