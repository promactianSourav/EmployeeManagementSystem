#pragma checksum "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db501654eb64cdcea4f19a85e06dfb78ac0b30e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Update), @"mvc.1.0.view", @"/Views/Employee/Update.cshtml")]
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
#line 1 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\_ViewImports.cshtml"
using EmployeeManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\_ViewImports.cshtml"
using EmployeeManagement.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.SignalR;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db501654eb64cdcea4f19a85e06dfb78ac0b30e9", @"/Views/Employee/Update.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ce77afcee146b6dec92052c0d7df3e3b92b6d3b", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Update : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeeManagement.Models.Employee>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
  
    ViewData["Title"] = "Edit Page for Employee";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Edit</h2>\r\n\r\n");
#nullable restore
#line 9 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
 using (Html.BeginForm("Update", "Employee", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <hr />\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <label>UserName</label>\r\n                ");
#nullable restore
#line 18 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.EditorFor(m => m.UserName, new { htmlAttributes = new { @class = "form-control", @maxlength = "20", @required = "true" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 19 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.ValidationMessageFor(m => m.UserName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <label>Email</label>\r\n                ");
#nullable restore
#line 25 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.EditorFor(m => m.Email, new { htmlAttributes = new { @class = "form-control", @maxlength = "20", @required = "true" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 26 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.ValidationMessageFor(m => m.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <label>Password</label>\r\n                ");
#nullable restore
#line 33 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.EditorFor(m => m.Password, new { htmlAttributes = new { @class = "form-control", @maxlength = "20", @required = "true", @type = "password" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 34 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.ValidationMessageFor(m => m.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <label>Confirm Password</label>\r\n                ");
#nullable restore
#line 40 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.EditorFor(m => m.ConfirmPassword, new { htmlAttributes = new { @class = "form-control", @maxlength = "20", @required = "true" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 41 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.ValidationMessageFor(m => m.ConfirmPassword, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <label>Name</label>\r\n                ");
#nullable restore
#line 47 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.EditorFor(m => m.Name, new { htmlAttributes = new { @class = "form-control", @maxlength = "20", @required = "true" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 48 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.ValidationMessageFor(m => m.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <label>Surname</label>\r\n                ");
#nullable restore
#line 54 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.EditorFor(m => m.Surname, new { htmlAttributes = new { @class = "form-control", @maxlength = "20", @required = "true" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 55 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.ValidationMessageFor(m => m.Surname, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <label>Address</label>\r\n                ");
#nullable restore
#line 62 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.EditorFor(m => m.Address, new { htmlAttributes = new { @class = "form-control", @maxlength = "100", @required = "true" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 63 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.ValidationMessageFor(m => m.Address, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <label>Qualification</label>\r\n                ");
#nullable restore
#line 69 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.EditorFor(m => m.Qualification, new { htmlAttributes = new { @class = "form-control", @required = "true" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 70 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.ValidationMessageFor(m => m.Qualification, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <label>Contact Number<i style=\"font-size: 12px\">(Numbers only, Avoid any other characters)</i></label>\r\n                ");
#nullable restore
#line 77 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.EditorFor(m => m.ContactNumber, new { htmlAttributes = new { @class = "form-control", @required = "true", @pattern = "^[0-9]+", @maxlength = "10", @minlength = "10", @type = "text" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 78 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.ValidationMessageFor(m => m.ContactNumber, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <label>Department : </label>\r\n                ");
#nullable restore
#line 84 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.DropDownListFor(m => m.DepartmentId, new SelectList(ViewBag.departments, "Value", "Text"), new { htmlAttributes = new { @class = "form-control", @maxlength = "20", @required = "true" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 85 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
           Write(Html.ValidationMessageFor(m => m.DepartmentId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>

        <div class=""form-group"">
            <div class=""col-md-offset-2 col-md-10"">
                <button type=""submit"" class=""btn btn-secondary btn-sm btn-block"">Save</button>
            </div>
        </div>
    </div>
");
#nullable restore
#line 95 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"


}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    ");
#nullable restore
#line 100 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Update.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EmployeeManagement.Models.Employee> Html { get; private set; }
    }
}
#pragma warning restore 1591
