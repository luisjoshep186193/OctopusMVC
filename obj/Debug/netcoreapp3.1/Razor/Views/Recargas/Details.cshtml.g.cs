#pragma checksum "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dae7148186ca533aa7bc3900c8d454a66b1f2c49"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Recargas_Details), @"mvc.1.0.view", @"/Views/Recargas/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dae7148186ca533aa7bc3900c8d454a66b1f2c49", @"/Views/Recargas/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d1f1972b413f3d58ddfa639af3814dc98b892d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Recargas_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Octopus.Models.Recarga>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <div>\r\n        <a class=\"btn btn-danger\" style=\"color:white;\" name=\"Index\" onclick=\"showModal(this)\">Regresar</a>\r\n    </div>\n<h1>Detalles</h1>\n\n<div>\n    <h4>Recarga</h4>\n    <hr />\n    <dl class=\"row\">\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 17 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 20 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 23 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 26 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n      \n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 30 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.StatusCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 33 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayFor(model => model.StatusCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 36 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 39 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayFor(model => model.User.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 42 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Monto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 45 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayFor(model => model.Monto.MontoCant));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 48 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Carrier));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 51 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayFor(model => model.Carrier.CarrierName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 54 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.WebServDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 57 "/Users/flex/Documents/OctopusMVC-master/Octopus/Views/Recargas/Details.cshtml"
       Write(Html.DisplayFor(model => model.WebServDesc.WebServiceName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n    </dl>\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Octopus.Models.Recarga> Html { get; private set; }
    }
}
#pragma warning restore 1591
