#pragma checksum "C:\Users\Lyami\Tasks\Lanit\InternetShop\InternetShop\Views\Home\GetOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "274d6f759928b27c5b0b475e4cb99de28a07f09a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(InternetShop.Pages.Home.Views_Home_GetOrder), @"mvc.1.0.view", @"/Views/Home/GetOrder.cshtml")]
namespace InternetShop.Pages.Home
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
#line 1 "C:\Users\Lyami\Tasks\Lanit\InternetShop\InternetShop\Views\_ViewImports.cshtml"
using InternetShop.ViewsModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"274d6f759928b27c5b0b475e4cb99de28a07f09a", @"/Views/Home/GetOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"544ba1d504927bbf4509e2d1ff38c63ca6bdff45", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GetOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductsListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Ваша покупка</h1>\r\n\r\n    <table class=\"table\">\r\n        <tr><td>Название</td><td>Количество</td></tr>\r\n");
#nullable restore
#line 8 "C:\Users\Lyami\Tasks\Lanit\InternetShop\InternetShop\Views\Home\GetOrder.cshtml"
         foreach (var item in Model.MainModel.OrdersModel)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 11 "C:\Users\Lyami\Tasks\Lanit\InternetShop\InternetShop\Views\Home\GetOrder.cshtml"
               Write(Model.MainModel.GetNameById(item.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 12 "C:\Users\Lyami\Tasks\Lanit\InternetShop\InternetShop\Views\Home\GetOrder.cshtml"
               Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 14 "C:\Users\Lyami\Tasks\Lanit\InternetShop\InternetShop\Views\Home\GetOrder.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductsListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
