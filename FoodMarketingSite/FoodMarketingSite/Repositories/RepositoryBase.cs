using FoodMarketingSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMarketingSite.Repositories
{
    /// <summary>
    /// multi thread işlemleri kontrol etmek için
    /// </summary>
    public class RepositoryBase
    {
        protected static  Context context;
        private static object obj = new object();
        public RepositoryBase()
        {
            CreateContext();
        }
        private static  void CreateContext()
        {
            if(context == null)
            {
                //lock = eger 2 request geldiyse biri bitmeden diğerine devam etmiyor.
                lock(obj){
                    context = new Context();
                }
            }
        }

    }
}
