#pragma checksum "C:\Users\serka\WorkSpace\FoodMarketingSite\FoodMarketingSite\Views\Home\FoodDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7b7e2692a0af6854652ce0663fae4bdcb62d16e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FoodDetail), @"mvc.1.0.view", @"/Views/Home/FoodDetail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\serka\WorkSpace\FoodMarketingSite\FoodMarketingSite\Views\_ViewImports.cshtml"
using FoodMarketingSite.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\serka\WorkSpace\FoodMarketingSite\FoodMarketingSite\Views\_ViewImports.cshtml"
using FoodMarketingSite.Data.Models.Login;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7b7e2692a0af6854652ce0663fae4bdcb62d16e", @"/Views/Home/FoodDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd50015653188ea6549700783fcfa624ad95ab72", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FoodDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Food>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::FoodMarketingSite.TagHelpers.GetCategoryName __FoodMarketingSite_TagHelpers_GetCategoryName;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 111, "\"", 137, 2);
            WriteAttributeValue("", 117, "/img/", 117, 5, true);
#nullable restore
#line 6 "C:\Users\serka\WorkSpace\FoodMarketingSite\FoodMarketingSite\Views\Home\FoodDetail.cshtml"
WriteAttributeValue("", 122, Model.ImageURL, 122, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"w-100 img-thumbnail img-fluid\"");
            BeginWriteAttribute("alt", "\r\n                 alt=\"", 176, "\"", 211, 1);
#nullable restore
#line 7 "C:\Users\serka\WorkSpace\FoodMarketingSite\FoodMarketingSite\Views\Home\FoodDetail.cshtml"
WriteAttributeValue("", 200, Model.Name, 200, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        </div>\r\n        ");
#nullable restore
#line 9 "C:\Users\serka\WorkSpace\FoodMarketingSite\FoodMarketingSite\Views\Home\FoodDetail.cshtml"
   Write(ViewBag.Cook);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 10 "C:\Users\serka\WorkSpace\FoodMarketingSite\FoodMarketingSite\Views\Home\FoodDetail.cshtml"
   Write(ViewBag.Ses);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-9\">\r\n            <div class=\"card\">\r\n                <h5 class=\"card-header\">\r\n                    ");
#nullable restore
#line 14 "C:\Users\serka\WorkSpace\FoodMarketingSite\FoodMarketingSite\Views\Home\FoodDetail.cshtml"
               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </h5>\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 17 "C:\Users\serka\WorkSpace\FoodMarketingSite\FoodMarketingSite\Views\Home\FoodDetail.cshtml"
                                      Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-text\">\r\n\r\n                        <strong>Category :</strong>\r\n");
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("TagCategoryName", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c7b7e2692a0af6854652ce0663fae4bdcb62d16e6629", async() => {
            }
            );
            __FoodMarketingSite_TagHelpers_GetCategoryName = CreateTagHelper<global::FoodMarketingSite.TagHelpers.GetCategoryName>();
            __tagHelperExecutionContext.Add(__FoodMarketingSite_TagHelpers_GetCategoryName);
#nullable restore
#line 22 "C:\Users\serka\WorkSpace\FoodMarketingSite\FoodMarketingSite\Views\Home\FoodDetail.cshtml"
__FoodMarketingSite_TagHelpers_GetCategoryName.FoodId = Model.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("food-id", __FoodMarketingSite_TagHelpers_GetCategoryName.FoodId, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <br />\r\n                        ");
#nullable restore
#line 24 "C:\Users\serka\WorkSpace\FoodMarketingSite\FoodMarketingSite\Views\Home\FoodDetail.cshtml"
                   Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                    <a href=\"#\" class=\"btn btn-danger float-right ml-1\">\r\n                        add to Basket\r\n                    </a>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c7b7e2692a0af6854652ce0663fae4bdcb62d16e8487", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Food> Html { get; private set; }
    }
}
#pragma warning restore 1591
