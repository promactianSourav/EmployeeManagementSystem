#pragma checksum "F:\promact\WorkingONBoard\EmployeeManagementSystem\EmployeeManagement\Views\Department\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f131bce60775da28c0dac03105fc3b4bc23497f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Department_Edit), @"mvc.1.0.view", @"/Views/Department/Edit.cshtml")]
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
#line 1 "F:\promact\WorkingONBoard\EmployeeManagementSystem\EmployeeManagement\Views\_ViewImports.cshtml"
using EmployeeManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\promact\WorkingONBoard\EmployeeManagementSystem\EmployeeManagement\Views\_ViewImports.cshtml"
using EmployeeManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f131bce60775da28c0dac03105fc3b4bc23497f5", @"/Views/Department/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3af35a328bfe0c906f75d04efeba14f80e1f583b", @"/Views/_ViewImports.cshtml")]
    public class Views_Department_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeeManagement.Models.Department>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\promact\WorkingONBoard\EmployeeManagementSystem\EmployeeManagement\Views\Department\Edit.cshtml"
  
    ViewData["Title"] = "Edit Page for Department";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Edit</h2>\r\n\r\n");
#nullable restore
#line 9 "F:\promact\WorkingONBoard\EmployeeManagementSystem\EmployeeManagement\Views\Department\Edit.cshtml"
 using (Html.BeginForm("Edit","Department",FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\promact\WorkingONBoard\EmployeeManagementSystem\EmployeeManagement\Views\Department\Edit.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <h4>Student</h4>\r\n        <hr />\r\n        \r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 20 "F:\promact\WorkingONBoard\EmployeeManagementSystem\EmployeeManagement\Views\Department\Edit.cshtml"
           Write(ViewBag.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 21 "F:\promact\WorkingONBoard\EmployeeManagementSystem\EmployeeManagement\Views\Department\Edit.cshtml"
           Write(Html.EditorFor(m => m.DepartmentName, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 22 "F:\promact\WorkingONBoard\EmployeeManagementSystem\EmployeeManagement\Views\Department\Edit.cshtml"
           Write(Html.ValidationMessageFor(m => m.DepartmentName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-offset-2 col-md-10\">\r\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-default\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 32 "F:\promact\WorkingONBoard\EmployeeManagementSystem\EmployeeManagement\Views\Department\Edit.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    ");
#nullable restore
#line 35 "F:\promact\WorkingONBoard\EmployeeManagementSystem\EmployeeManagement\Views\Department\Edit.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EmployeeManagement.Models.Department> Html { get; private set; }
    }
}
#pragma warning restore 1591