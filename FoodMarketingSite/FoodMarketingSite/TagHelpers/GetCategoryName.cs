using FoodMarketingSite.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMarketingSite.TagHelpers
{
    [HtmlTargetElement("TagCategoryName")]
    public class GetCategoryName:TagHelper
    {
        private readonly IFoodRepository _foodRepository;

        public GetCategoryName(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public int FoodId { get; set; }

        /// <summary>
        /// istedigimiz html oluşturulup geriye döndürülür
        /// </summary>
        /// <param name="context"> cshtml sayfasından gelen değer</param>
        /// <param name="output"> cshtml sayfasından giden değer</param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //bunlarda kullanılabilir
            //TagBuilder tagBuilder = new TagBuilder("ul");
            // tagBuilder.InnerHtml.Append("li");
            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append("a");

            string data = "";

            //sadece isimlerini bana döndür
            //istersen bütün datatyı alabilirsin
            var getCategories = _foodRepository.GetCategoryList(FoodId).Select(I => I.CategoryName).ToList();

            foreach (var item in getCategories)
            {
                data += item + " ";
            }
            output.Content.SetContent(data);
        }
    }
}
