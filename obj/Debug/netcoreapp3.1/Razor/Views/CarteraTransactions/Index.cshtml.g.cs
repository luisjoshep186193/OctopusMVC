#pragma checksum "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a962d1078620fb0bf0e9ba0ae4a8c61bb6cc70e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CarteraTransactions_Index), @"mvc.1.0.view", @"/Views/CarteraTransactions/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a962d1078620fb0bf0e9ba0ae4a8c61bb6cc70e", @"/Views/CarteraTransactions/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d1f1972b413f3d58ddfa639af3814dc98b892d9", @"/Views/_ViewImports.cshtml")]
    public class Views_CarteraTransactions_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Octopus.Helpers.PaginadorGenerico<CarteraTransaction>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
  
    ViewData["Title"] = "Mis Transacciones";
    var pageName = "Recargas";
    var carteraId = ViewBag.carteraId != null ? ViewBag.carteraId : 0;
    var rowClass = User.IsInRole("Administrador") ?"col-4": "col-8";
    var userId = UserManager.GetUserId(User);


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 12 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
 if (Model.RegistrosPorPagina != 3)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\" style=\"max-height:30px\">\r\n        <button");
            BeginWriteAttribute("value", " value=\"", 444, "\"", 462, 1);
#nullable restore
#line 15 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 452, carteraId, 452, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-block btn-warning col-6 mx-auto\" id=\"1\" name=\"Index\" onclick=\"newSearch(this,1)\">Nueva búsqueda</button>\r\n    </div>\r\n");
#nullable restore
#line 17 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row rowTitle\">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 645, "\"", 662, 1);
#nullable restore
#line 20 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 653, rowClass, 653, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <h7>Operación</h7>\r\n    </div>\r\n    <div class=\"col-2\">\r\n        <h7>Cantidad </h7>\r\n    </div>\r\n    <div class=\"col-2\">\r\n        <h7>Fecha</h7>\r\n\r\n    </div>\r\n");
#nullable restore
#line 30 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
     if (User.IsInRole("Administrador"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div");
            BeginWriteAttribute("class", " class=\"", 895, "\"", 912, 1);
#nullable restore
#line 32 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 903, rowClass, 903, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <h7>Desc</h7>\r\n\r\n        </div>\r\n");
#nullable restore
#line 36 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
#nullable restore
#line 40 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
 foreach (var item in Model.Resultado)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 1050, "\"", 1067, 1);
#nullable restore
#line 43 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 1058, rowClass, 1058, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <small>");
#nullable restore
#line 44 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
          Write(Html.DisplayFor(modelItem => item.OperacionDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n    </div>\r\n    <div class=\"col-2\">\r\n        <small>");
#nullable restore
#line 47 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
          Write(Html.DisplayFor(modelItem => item.Monto));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n    </div>\r\n    <div class=\"col-2\">\r\n        <small>");
#nullable restore
#line 50 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
          Write(Html.DisplayFor(modelItem => item.FechaOperation));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n\r\n    </div>\r\n");
#nullable restore
#line 53 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
     if (User.IsInRole("Administrador"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div");
            BeginWriteAttribute("class", " class=\"", 1427, "\"", 1444, 1);
#nullable restore
#line 55 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 1435, rowClass, 1435, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    <small class=\"max-lines\">");
#nullable restore
#line 56 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
                        Write(Html.DisplayFor(modelItem => item.CarrierResponse));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n\r\n</div>\r\n");
#nullable restore
#line 59 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 61 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"

}

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
 if (Model != null)
{
    if (Model.RegistrosPorPagina != 3)
    {

        if (Model.Resultado.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span>\r\n                <strong>");
#nullable restore
#line 72 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
                   Write(Model.TotalRegistros);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> registros encontrados\r\n            </span>\r\n            <span>&nbsp;|&nbsp;</span>\r\n            <span>\r\n                Página <strong>");
#nullable restore
#line 76 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
                           Write(Model.PaginaActual);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> de\r\n                <strong>");
#nullable restore
#line 77 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
                   Write(Model.TotalPaginas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n            </span>\r\n            <span>&nbsp;|&nbsp;</span>\r\n");
#nullable restore
#line 80 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span>No hay resultados para esta búsqueda</span>\r\n            <span>&nbsp;|&nbsp;</span>\r\n");
#nullable restore
#line 85 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
        }

        if (Model.PaginaActual > 1)
        {
            var pag = Model.PaginaActual - 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button onclick=\"showModal(this,1)\" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 2405, "\"", 2423, 1);
#nullable restore
#line 90 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 2413, carteraId, 2413, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Primera</button>\r\n            <span></span>\r\n            <button onclick=\"showModal(this,1)\" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 2562, "\"", 2580, 1);
#nullable restore
#line 92 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 2570, carteraId, 2570, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Anterior</button>\r\n");
#nullable restore
#line 93 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button disabled onclick=\"showModal(this,1)\" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 2738, "\"", 2756, 1);
#nullable restore
#line 96 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 2746, carteraId, 2746, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Primera</button>\r\n            <span></span>\r\n            <button disabled onclick=\"showModal(this,1)\" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 2904, "\"", 2922, 1);
#nullable restore
#line 98 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 2912, carteraId, 2912, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Anterior</button>\r\n");
#nullable restore
#line 99 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span></span>\r\n");
#nullable restore
#line 101 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
        if (Model.PaginaActual < Model.TotalPaginas)
        {
            var pag = Model.PaginaActual + 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button");
            BeginWriteAttribute("onclick", " onclick=\'", 3139, "\'", 3171, 3);
            WriteAttributeValue("", 3149, "showModal(this,\"", 3149, 16, true);
#nullable restore
#line 104 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 3165, pag, 3165, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3169, "\")", 3169, 2, true);
            EndWriteAttribute();
            WriteLiteral(" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 3186, "\"", 3204, 1);
#nullable restore
#line 104 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 3194, carteraId, 3194, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Siguiente</button>\r\n            <span></span>\r\n            <button");
            BeginWriteAttribute("onclick", " onclick=\'", 3303, "\'", 3350, 3);
            WriteAttributeValue("", 3313, "showModal(this,\"", 3313, 16, true);
#nullable restore
#line 106 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 3329, Model.TotalPaginas, 3329, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3348, "\")", 3348, 2, true);
            EndWriteAttribute();
            WriteLiteral(" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 3365, "\"", 3383, 1);
#nullable restore
#line 106 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 3373, carteraId, 3373, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Última</button>\r\n");
#nullable restore
#line 107 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
        }
        else
        {
            var pag = Model.TotalPaginas - 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button disabled");
            BeginWriteAttribute("onclick", " onclick=\'", 3544, "\'", 3576, 3);
            WriteAttributeValue("", 3554, "showModal(this,\"", 3554, 16, true);
#nullable restore
#line 111 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 3570, pag, 3570, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3574, "\")", 3574, 2, true);
            EndWriteAttribute();
            WriteLiteral(" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 3591, "\"", 3609, 1);
#nullable restore
#line 111 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 3599, carteraId, 3599, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Siguiente</button>\r\n            <span></span>\r\n            <button disabled");
            BeginWriteAttribute("onclick", " onclick=\'", 3717, "\'", 3764, 3);
            WriteAttributeValue("", 3727, "showModal(this,\"", 3727, 16, true);
#nullable restore
#line 113 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 3743, Model.TotalPaginas, 3743, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3762, "\")", 3762, 2, true);
            EndWriteAttribute();
            WriteLiteral(" name=\"IndexP\"");
            BeginWriteAttribute("value", " value=\"", 3779, "\"", 3797, 1);
#nullable restore
#line 113 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 3787, carteraId, 3787, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-default\">Última</button>\r\n");
#nullable restore
#line 114 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
        }
    }

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 119 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
 if (Model.RegistrosPorPagina == 3)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\" style=\"max-height:30px\">\r\n    <button");
            BeginWriteAttribute("value", " value=\"", 3966, "\"", 3984, 1);
#nullable restore
#line 122 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 3974, carteraId, 3974, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-primary col-4 mx-auto\" id=\"1\" name=\"Index\"");
            BeginWriteAttribute("onclick", " onclick=\'", 4050, "\'", 4089, 3);
            WriteAttributeValue("", 4060, "setPageType(this,\"", 4060, 18, true);
#nullable restore
#line 122 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 4078, pageName, 4078, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4087, "\")", 4087, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Recargas</button>\r\n    <button");
            BeginWriteAttribute("value", " value=\"", 4121, "\"", 4139, 1);
#nullable restore
#line 123 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
WriteAttributeValue("", 4129, carteraId, 4129, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm  btn-warning col-4 mx-auto\" id=\"1\" name=\"Index\" onclick=\'setPageType(this,\"CarteraTransactions\")\'>Detalles</button>\r\n");
            WriteLiteral("</div>\r\n");
#nullable restore
#line 126 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/CarteraTransactions/Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Octopus.Helpers.PaginadorGenerico<CarteraTransaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591
