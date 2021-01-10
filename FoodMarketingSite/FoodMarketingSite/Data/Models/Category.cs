using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<FoodCategory> FoodCategories { get; set; }

    }
}