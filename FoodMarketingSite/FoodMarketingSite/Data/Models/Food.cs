using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Data.Models
{
    public class Food
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public  string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public int Stock { get; set; }
        public List<FoodCategory> FoodCategories { get; set; }

        //one to many ilişki durumunda
        //public int CategoryID { get; set; }
        //public virtual Category Category { get; set; } 

    }
}
