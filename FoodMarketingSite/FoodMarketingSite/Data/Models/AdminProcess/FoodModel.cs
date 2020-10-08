using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Data.Models.AdminProcess
{
    public class FoodModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Food Name can't be empty")]
        public string Name { get; set; }
        [Range(0,double.MaxValue,ErrorMessage ="Fiyat 0 dan büyük degeler olmalıdır.")]
        public double Price { get; set; }
        public string Description { get; set; }
        public IFormFile ImageURL { get; set; }

    }
}
