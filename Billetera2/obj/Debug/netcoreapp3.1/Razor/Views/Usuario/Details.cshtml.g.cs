#pragma checksum "C:\Users\Laburo\wa\PNT1-Grupo1-Billetera\Billetera2\Views\Usuario\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60fa2d15f23e9c4f92af2a8741028c32d8738c2e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Details), @"mvc.1.0.view", @"/Views/Usuario/Details.cshtml")]
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
#line 1 "C:\Users\Laburo\wa\PNT1-Grupo1-Billetera\Billetera2\Views\_ViewImports.cshtml"
using Billetera2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Laburo\wa\PNT1-Grupo1-Billetera\Billetera2\Views\_ViewImports.cshtml"
using Billetera2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60fa2d15f23e9c4f92af2a8741028c32d8738c2e", @"/Views/Usuario/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"974dd2c8f883bdf66ebd811ef5bd1d90a9549559", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Billetera2.Models.Usuario>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Movimiento", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Laburo\wa\PNT1-Grupo1-Billetera\Billetera2\Views\Usuario\Details.cshtml"
   ViewData["Title"] = "Resumen"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"justify-content-center\">\r\n");
            WriteLiteral("\r\n    <div class=\"card flex\">\r\n        <h5 class=\"card-header\">Hola, ");
#nullable restore
#line 10 "C:\Users\Laburo\wa\PNT1-Grupo1-Billetera\Billetera2\Views\Usuario\Details.cshtml"
                                 Write(Model.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</h5>\r\n        <div class=\"card-body\">\r\n            <h1 class=\"display-5 card-title text-center\">Tu balance actual es de</h1>\r\n            <h1 class=\"display-3 text-center\">$");
#nullable restore
#line 13 "C:\Users\Laburo\wa\PNT1-Grupo1-Billetera\Billetera2\Views\Usuario\Details.cshtml"
                                          Write(ViewData["total"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60fa2d15f23e9c4f92af2a8741028c32d8738c2e5177", async() => {
                WriteLiteral("Ver todos mis movimientos");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
    <div id=""accordion"">
        <div class=""card"">
            <div class=""card-header"" id=""headingOne"">
                <h5 class=""mb-0"">
                    <button class=""btn btn-link"" data-toggle=""collapse"" data-target=""#collapseOne"" aria-expanded=""true"" aria-controls=""collapseOne"">
                        Ultimos Movimientos
                    </button>
                </h5>
            </div>
            <div id=""collapseOne"" class=""collapse show"" aria-labelledby=""headingOne"" data-parent=""#accordion"">
                <div class=""card-body"">
                    <table class=""table table-hover"">
                        <thead>
                            <tr>
                                <th scope=""col"">Monto</th>
                                <th scope=""col"">Descripcion</th>
                                <th scope=""col"">Tipo</th>
                                <th scope=""col"">Fecha</th>
                            </tr>
                        </");
            WriteLiteral("thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 38 "C:\Users\Laburo\wa\PNT1-Grupo1-Billetera\Billetera2\Views\Usuario\Details.cshtml"
                             foreach(var mov in @ViewData["movimientos"] as IEnumerable<Billetera2.Models.Movimiento>)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    $");
#nullable restore
#line 42 "C:\Users\Laburo\wa\PNT1-Grupo1-Billetera\Billetera2\Views\Usuario\Details.cshtml"
                                Write(mov.Monto);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 45 "C:\Users\Laburo\wa\PNT1-Grupo1-Billetera\Billetera2\Views\Usuario\Details.cshtml"
                               Write(mov.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 48 "C:\Users\Laburo\wa\PNT1-Grupo1-Billetera\Billetera2\Views\Usuario\Details.cshtml"
                               Write(mov.TipoMovimiento);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 51 "C:\Users\Laburo\wa\PNT1-Grupo1-Billetera\Billetera2\Views\Usuario\Details.cshtml"
                               Write(mov.Fecha);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 54 "C:\Users\Laburo\wa\PNT1-Grupo1-Billetera\Billetera2\Views\Usuario\Details.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>



<!--<div>
    <a class=""btn btn-primary"" asp-controller=""Movimiento"" asp-action=""Index"">Ver Movimientos</a> 
    <a class=""btn btn-primary"" asp-action=""Edit"">Editar credenciales</a>--> 

    <!--<a asp-action=""Index"">Back to List</a>-->
<!--</div>-->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Billetera2.Models.Usuario> Html { get; private set; }
    }
}
#pragma warning restore 1591
