#pragma checksum "D:\system\APIRESTATUAL\APIREST\APIREST\Views\Procedimentos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7c4cf65c7a9e92d39b11e6e5064b326af846e57"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Procedimentos), @"mvc.1.0.view", @"/Views/Procedimentos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7c4cf65c7a9e92d39b11e6e5064b326af846e57", @"/Views/Procedimentos.cshtml")]
    #nullable restore
    public class Views_Procedimentos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<APIREST.Models.Procedimento>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\system\APIRESTATUAL\APIREST\APIREST\Views\Procedimentos.cshtml"
  
    ViewData["Title"] = "Procedimentos";
    Layout = "~/Views/Shared/_ValidationScriptsPartial.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Procedimentos</h1>

<h4>Procedimento</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Procedimentos"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Descricao"" class=""control-label""></label>
                <input asp-for=""Descricao"" class=""form-control"" />
                <span asp-validation-for=""Descricao"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Valor"" class=""control-label""></label>
                <input asp-for=""Valor"" class=""form-control"" />
                <span asp-validation-for=""Valor"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 38 "D:\system\APIRESTATUAL\APIREST\APIREST\Views\Procedimentos.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<APIREST.Models.Procedimento> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
