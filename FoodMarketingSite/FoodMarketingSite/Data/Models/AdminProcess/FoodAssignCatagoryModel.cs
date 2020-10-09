using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Data.Models.AdminProcess
{
    public class FoodAssignCatagoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        //ilgili üründe bu kategori var mı yok  mu?
        public bool IsThere { get; set; }


    }
}
