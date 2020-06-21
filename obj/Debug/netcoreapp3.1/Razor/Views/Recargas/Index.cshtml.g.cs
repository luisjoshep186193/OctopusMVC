#pragma checksum "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bec1be4213f32310ce7a3dbc80115c26a87187bd"
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
using Octopus;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/_ViewImports.cshtml"
using Octopus.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bec1be4213f32310ce7a3dbc80115c26a87187bd", @"/Views/Recargas/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8dc197defe10460f48a07a27c889821223e401bc", @"/Views/_ViewImports.cshtml")]
    public class Views_Recargas_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Octopus.Helpers.PaginadorGenerico<Recarga>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<input hidden id=\"pageType\" name=\"Recargas\" />\r\n<div class=\"col-12 mt-10 mb-10\">\r\n    <a class=\"btn btn-sm btn-block btn-outline-primary col-8 mx-auto\"");
            BeginWriteAttribute("id", " id=\"", 247, "\"", 252, 0);
            EndWriteAttribute();
            WriteLiteral(@" name=""getConsulta"" onclick=""showModal(this)"">Nueva Consulta</a>
</div>
<table class=""table table-striped"">
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
#line 36 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
             if (SignInManager.IsSignedIn(User))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                 if (User.IsInRole("Administrador"))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th>\r\n                        WS\r\n                    </th>\r\n                    <th></th>\r\n");
#nullable restore
#line 44 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 50 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
         foreach (var item in Model.Resultado)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.StatusCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 64 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Status.StatusDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 67 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 70 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Monto.MontoCant));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 73 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Carrier.CarrierName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 75 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                 if (SignInManager.IsSignedIn(User))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                     if (User.IsInRole("Administrador"))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            ");
#nullable restore
#line 80 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.WebServDesc.WebServiceName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <a style=\"color:white\" class=\"btn btn-success\" name=\"Details\"");
            BeginWriteAttribute("id", " id=\"", 2488, "\"", 2501, 1);
#nullable restore
#line 83 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 2493, item.Id, 2493, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"showModal(this)\">Detalle</a>\r\n                        </td>\r\n");
#nullable restore
#line 85 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </tr>\r\n");
#nullable restore
#line 90 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
#nullable restore
#line 95 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
 if (Model.Resultado.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span>\r\n        <strong>");
#nullable restore
#line 98 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
           Write(Model.TotalRegistros);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> registros encontrados\r\n    </span>\r\n    <span>&nbsp;|&nbsp;</span>\r\n    <span>\r\n        Página <strong>");
#nullable restore
#line 102 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                   Write(Model.PaginaActual);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> de\r\n        <strong>");
#nullable restore
#line 103 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
           Write(Model.TotalPaginas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </span>\r\n    <span>&nbsp;|&nbsp;</span>\r\n");
#nullable restore
#line 106 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span>No hay resultados para esta búsqueda</span>\r\n    <span>&nbsp;|&nbsp;</span>\r\n");
#nullable restore
#line 111 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 113 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
 if (Model.PaginaActual > 1)
{
    var pag = Model.PaginaActual - 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button onclick=\"getPage(this)\" name=\"Recargas\" value = \"1\" class=\"btn btn-sm btn-default\">Primera</button>\r\n");
            WriteLiteral("    <span></span>\r\n    <button onclick=\"getPage(this)\" name=\"Recargas\"");
            BeginWriteAttribute("value", " value = \"", 3514, "\"", 3528, 1);
#nullable restore
#line 120 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 3524, pag, 3524, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("  class=\"btn btn-sm btn-default\">Anterior</button>\r\n");
#nullable restore
#line 122 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                                                    
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button disabled onclick=\"getPage(this)\" name=\"Recargas\" value=\"1\" class=\"btn btn-sm btn-default\">Primera</button>\r\n");
            WriteLiteral("    <span></span>\r\n    <button disabled onclick=\"getPage(this)\" name=\"Recargas\" value=\"1\" class=\"btn btn-sm btn-default\">Anterior</button>\r\n");
#nullable restore
#line 132 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                                                             
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<span></span>\r\n");
#nullable restore
#line 135 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
 if (Model.PaginaActual < Model.TotalPaginas)
{
    var pag = Model.PaginaActual + 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button onclick=\"getPage(this)\" name=\"Recargas\"");
            BeginWriteAttribute("value", " value=\"", 4397, "\"", 4409, 1);
#nullable restore
#line 138 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 4405, pag, 4405, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Siguiente</button>\r\n");
            WriteLiteral("    <span></span>\r\n    <button onclick=\"getPage(this)\" name=\"Recargas\"");
            BeginWriteAttribute("value", " value=\"", 4672, "\"", 4699, 1);
#nullable restore
#line 142 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 4680, Model.TotalPaginas, 4680, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Última</button>\r\n");
#nullable restore
#line 144 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                                                    
}
else
{
    var pag = Model.TotalPaginas - 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button disabled onclick=\"getPage(this)\" name=\"Recargas\"");
            BeginWriteAttribute("value", " value=\"", 4988, "\"", 5000, 1);
#nullable restore
#line 149 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 4996, pag, 4996, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Siguiente</button>\r\n");
            WriteLiteral("    <span></span>\r\n    <button disabled onclick=\"getPage(this)\" name=\"Recargas\"");
            BeginWriteAttribute("value", " value=\"", 5281, "\"", 5308, 1);
#nullable restore
#line 153 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
WriteAttributeValue("", 5289, Model.TotalPaginas, 5289, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Última</button>\r\n");
#nullable restore
#line 155 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Index.cshtml"
                                                                                                                 
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
