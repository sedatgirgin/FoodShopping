using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Data.Models
{
    public class FoodCategory
    {
        public int Id { get; set; }
        public int FoodID { get; set; }
        public Food Food { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
