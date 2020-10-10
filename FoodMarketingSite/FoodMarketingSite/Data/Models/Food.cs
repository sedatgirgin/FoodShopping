using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Data.Models
{
    public class Food:IEquatable<Food>
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public  string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public int Stock { get; set; }
        public List<FoodCategory> FoodCategories { get; set; }

        public bool Equals([AllowNull] Food other)
        {
            return Id == other.Id && Name == other.Name && Description == other.Description && Price == other.Price && ImageURL == other.ImageURL && Stock == other.Stock;
        }

        //one to many ilişki durumunda
        //public int CategoryID { get; set; }
        //public virtual Category Category { get; set; } 

    }
}
