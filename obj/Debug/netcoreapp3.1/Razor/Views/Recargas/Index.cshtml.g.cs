#pragma checksum "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "162c47b96c85ec19547a175848787aa5020db3bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Recargas_Index), @"mvc.1.0.view", @"/Views/Recargas/Index.cshtml")]
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
#line 1 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/_ViewImports.cshtml"
using Octopus;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/_ViewImports.cshtml"
using Octopus.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/_ViewImports.cshtml"
using Octopus.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"162c47b96c85ec19547a175848787aa5020db3bb", @"/Views/Recargas/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d1f1972b413f3d58ddfa639af3814dc98b892d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Recargas_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Octopus.Helpers.PaginadorGenerico<Recarga>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
  
    ViewData["Title"] = "Index";
    var carteraId = ViewBag.carteraId != null ? ViewBag.carteraId : 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 9 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
 if (!User.IsInRole("Administrador"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\" style=\"max-height:30px\">\r\n        <button");
            BeginWriteAttribute("value", " value=\"", 274, "\"", 292, 1);
#nullable restore
#line 12 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 282, carteraId, 282, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-block btn-warning col-6 mx-auto\" id=\"1\" name=\"Index\" onclick=\"newSearch(this,1)\">Nueva búsqueda</button>\r\n    </div>\r\n");
#nullable restore
#line 14 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<h6>Total: <small>");
#nullable restore
#line 15 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
             Write(ViewBag.total);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small></h6>
<table class=""table table-dark table-striped"">
    <thead class=""thead-dark"">
        <tr>
            <th>
                Teléfono
            </th>
            <th>
                Fecha
            </th>

            <th>
                Acuse
            </th>
            <th>
                Estado
            </th>
            <th>
                Nombre
            </th>
            <th>
                Monto
            </th>
            <th>
                Compañía
            </th>
");
#nullable restore
#line 41 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
             if (SignInManager.IsSignedIn(User))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                 if (User.IsInRole("Administrador"))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th>\r\n                        WS\r\n                    </th>\r\n                    <th></th>\r\n");
#nullable restore
#line 49 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 55 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
         if (Model != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
             foreach (var item in Model.Resultado)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 61 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 64 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.StatusCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 71 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Status.StatusDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 74 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.User.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 77 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Monto.MontoCant));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 80 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Carrier.CarrierName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 82 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                     if (SignInManager.IsSignedIn(User))
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                         if (User.IsInRole("Administrador"))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                ");
#nullable restore
#line 87 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.WebServDesc.WebServiceName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                <a style=\"color:white\" class=\"btn btn-success\" name=\"Details\"");
            BeginWriteAttribute("id", " id=\"", 2828, "\"", 2841, 1);
#nullable restore
#line 90 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 2833, item.Id, 2833, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"showModal(this)\">Detalle</a>\r\n                            </td>\r\n");
#nullable restore
#line 92 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </tr>\r\n");
#nullable restore
#line 97 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 97 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n");
#nullable restore
#line 104 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
 if (Model != null)
{
    if (Model.RegistrosPorPagina != 0)
    {

        if (Model.Resultado.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span>\r\n                <strong>");
#nullable restore
#line 112 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                   Write(Model.TotalRegistros);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> registros encontrados\r\n            </span>\r\n            <span>&nbsp;|&nbsp;</span>\r\n            <span>\r\n                Página <strong>");
#nullable restore
#line 116 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                           Write(Model.PaginaActual);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> de\r\n                <strong>");
#nullable restore
#line 117 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                   Write(Model.TotalPaginas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n            </span>\r\n            <span>&nbsp;|&nbsp;</span>\r\n");
#nullable restore
#line 120 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span>No hay resultados para esta búsqueda</span>\r\n            <span>&nbsp;|&nbsp;</span>\r\n");
#nullable restore
#line 125 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
        }

        if (Model.PaginaActual > 1)
        {
            var pag = Model.PaginaActual - 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button onclick=\"showModal(this,1)\" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 3885, "\"", 3903, 1);
#nullable restore
#line 130 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 3893, carteraId, 3893, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Primera</button>\r\n            <span></span>\r\n            <button onclick=\"showModal(this,1)\" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 4042, "\"", 4060, 1);
#nullable restore
#line 132 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 4050, carteraId, 4050, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Anterior</button>\r\n");
#nullable restore
#line 133 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button disabled onclick=\"showModal(this,1)\" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 4218, "\"", 4236, 1);
#nullable restore
#line 136 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 4226, carteraId, 4226, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Primera</button>\r\n            <span></span>\r\n            <button disabled onclick=\"showModal(this,1)\" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 4384, "\"", 4402, 1);
#nullable restore
#line 138 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 4392, carteraId, 4392, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Anterior</button>\r\n");
#nullable restore
#line 139 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span></span>\r\n");
#nullable restore
#line 141 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
        if (Model.PaginaActual < Model.TotalPaginas)
        {
            var pag = Model.PaginaActual + 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button");
            BeginWriteAttribute("onclick", " onclick=\'", 4619, "\'", 4651, 3);
            WriteAttributeValue("", 4629, "showModal(this,\"", 4629, 16, true);
#nullable restore
#line 144 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 4645, pag, 4645, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4649, "\")", 4649, 2, true);
            EndWriteAttribute();
            WriteLiteral(" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 4666, "\"", 4684, 1);
#nullable restore
#line 144 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 4674, carteraId, 4674, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Siguiente</button>\r\n            <span></span>\r\n            <button");
            BeginWriteAttribute("onclick", " onclick=\'", 4783, "\'", 4830, 3);
            WriteAttributeValue("", 4793, "showModal(this,\"", 4793, 16, true);
#nullable restore
#line 146 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 4809, Model.TotalPaginas, 4809, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4828, "\")", 4828, 2, true);
            EndWriteAttribute();
            WriteLiteral(" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 4845, "\"", 4863, 1);
#nullable restore
#line 146 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 4853, carteraId, 4853, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Última</button>\r\n");
#nullable restore
#line 147 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
        }
        else
        {
            var pag = Model.TotalPaginas - 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button disabled");
            BeginWriteAttribute("onclick", " onclick=\'", 5024, "\'", 5056, 3);
            WriteAttributeValue("", 5034, "showModal(this,\"", 5034, 16, true);
#nullable restore
#line 151 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 5050, pag, 5050, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5054, "\")", 5054, 2, true);
            EndWriteAttribute();
            WriteLiteral(" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 5071, "\"", 5089, 1);
#nullable restore
#line 151 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 5079, carteraId, 5079, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Siguiente</button>\r\n            <span></span>\r\n            <button disabled");
            BeginWriteAttribute("onclick", " onclick=\'", 5197, "\'", 5244, 3);
            WriteAttributeValue("", 5207, "showModal(this,\"", 5207, 16, true);
#nullable restore
#line 153 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 5223, Model.TotalPaginas, 5223, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5242, "\")", 5242, 2, true);
            EndWriteAttribute();
            WriteLiteral(" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 5259, "\"", 5277, 1);
#nullable restore
#line 153 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 5267, carteraId, 5267, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Última</button>\r\n");
#nullable restore
#line 154 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
        }
    }

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Octopus.Data.ApplicationDbContext context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<User> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<User> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Octopus.Helpers.PaginadorGenerico<Recarga>> Html { get; private set; }
    }
}
#pragma warning restore 1591
