using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Data.Models.AdminProcess
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Food CategoryName can't be empty")]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

    }
}
