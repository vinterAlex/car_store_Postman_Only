#pragma checksum "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1a9369318099b850386332be46c37a882f127ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_VehiclesList_Vehicles), @"mvc.1.0.view", @"/Views/VehiclesList/Vehicles.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/VehiclesList/Vehicles.cshtml", typeof(AspNetCore.Views_VehiclesList_Vehicles))]
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
#line 1 "Y:\CarStore\CarStoreApplication.UI\Views\_ViewImports.cshtml"
using CarStoreApplication.UI;

#line default
#line hidden
#line 2 "Y:\CarStore\CarStoreApplication.UI\Views\_ViewImports.cshtml"
using CarStoreApplication.UI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1a9369318099b850386332be46c37a882f127ba", @"/Views/VehiclesList/Vehicles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff64e397a147b44e208687da3c9a0e1d84c593c5", @"/Views/_ViewImports.cshtml")]
    public class Views_VehiclesList_Vehicles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VehicleUtils.Vehicles>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
  
    ViewData["Title"] = "Vehicles";

#line default
#line hidden
            BeginContext(89, 32, true);
            WriteLiteral("\r\n<h2>Vehicles</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(121, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b28da7a547a4a4a9230c465219ed8fa", async() => {
                BeginContext(144, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(158, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(251, 45, false);
#line 16 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayNameFor(model => model.VehicleID));

#line default
#line hidden
            EndContext();
            BeginContext(296, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(352, 47, false);
#line 19 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayNameFor(model => model.DriveTypeID));

#line default
#line hidden
            EndContext();
            BeginContext(399, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(455, 55, false);
#line 22 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayNameFor(model => model.EngineDescriptionID));

#line default
#line hidden
            EndContext();
            BeginContext(510, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(566, 42, false);
#line 25 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayNameFor(model => model.MakeID));

#line default
#line hidden
            EndContext();
            BeginContext(608, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(664, 43, false);
#line 28 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayNameFor(model => model.ModelID));

#line default
#line hidden
            EndContext();
            BeginContext(707, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(763, 54, false);
#line 31 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayNameFor(model => model.ConstructionYearID));

#line default
#line hidden
            EndContext();
            BeginContext(817, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(873, 46, false);
#line 34 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayNameFor(model => model.ModifyDate));

#line default
#line hidden
            EndContext();
            BeginContext(919, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(975, 48, false);
#line 37 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayNameFor(model => model.VehiclePrice));

#line default
#line hidden
            EndContext();
            BeginContext(1023, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 43 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(1141, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1190, 44, false);
#line 46 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayFor(modelItem => item.VehicleID));

#line default
#line hidden
            EndContext();
            BeginContext(1234, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1290, 46, false);
#line 49 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayFor(modelItem => item.DriveTypeID));

#line default
#line hidden
            EndContext();
            BeginContext(1336, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1392, 54, false);
#line 52 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayFor(modelItem => item.EngineDescriptionID));

#line default
#line hidden
            EndContext();
            BeginContext(1446, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1502, 41, false);
#line 55 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayFor(modelItem => item.MakeID));

#line default
#line hidden
            EndContext();
            BeginContext(1543, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1599, 42, false);
#line 58 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayFor(modelItem => item.ModelID));

#line default
#line hidden
            EndContext();
            BeginContext(1641, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1697, 53, false);
#line 61 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayFor(modelItem => item.ConstructionYearID));

#line default
#line hidden
            EndContext();
            BeginContext(1750, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1806, 45, false);
#line 64 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayFor(modelItem => item.ModifyDate));

#line default
#line hidden
            EndContext();
            BeginContext(1851, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1907, 47, false);
#line 67 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.DisplayFor(modelItem => item.VehiclePrice));

#line default
#line hidden
            EndContext();
            BeginContext(1954, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2010, 65, false);
#line 70 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(2075, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(2096, 71, false);
#line 71 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(2167, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(2188, 69, false);
#line 72 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(2257, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 75 "Y:\CarStore\CarStoreApplication.UI\Views\VehiclesList\Vehicles.cshtml"
}

#line default
#line hidden
            BeginContext(2296, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VehicleUtils.Vehicles>> Html { get; private set; }
    }
}
#pragma warning restore 1591
