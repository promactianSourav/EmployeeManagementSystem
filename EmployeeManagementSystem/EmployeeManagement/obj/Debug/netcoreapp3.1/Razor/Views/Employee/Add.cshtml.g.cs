#pragma checksum "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10b7842c8c08e38290a3b16b06cbda3659153430"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Add), @"mvc.1.0.view", @"/Views/Employee/Add.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10b7842c8c08e38290a3b16b06cbda3659153430", @"/Views/Employee/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3af35a328bfe0c906f75d04efeba14f80e1f583b", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeeManagement.Models.Employee>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
  
    ViewData["Title"] = "Add New Employee";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Add New Employee</h2>\r\n\r\n");
#nullable restore
#line 9 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-horizontal\">\r\n    <hr />\r\n\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-10\">\r\n            <label>Name</label>\r\n            ");
#nullable restore
#line 20 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
       Write(Html.EditorFor(m => m.Name, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 21 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
       Write(Html.ValidationMessageFor(m => m.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-10\">\r\n            <label>Surname</label>\r\n            ");
#nullable restore
#line 27 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
       Write(Html.EditorFor(m => m.Surname, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 28 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
       Write(Html.ValidationMessageFor(m => m.Surname, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-10\">\r\n            <label>Address</label>\r\n            ");
#nullable restore
#line 34 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
       Write(Html.EditorFor(m => m.Address, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 35 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
       Write(Html.ValidationMessageFor(m => m.Address, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-10\">\r\n            <label>Qualification</label>\r\n            ");
#nullable restore
#line 41 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
       Write(Html.EditorFor(m => m.Qualification, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 42 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
       Write(Html.ValidationMessageFor(m => m.Qualification, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-10\">\r\n            <label>Contact Number</label>\r\n            ");
#nullable restore
#line 48 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
       Write(Html.EditorFor(m => m.ContactNumber, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 49 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
       Write(Html.ValidationMessageFor(m => m.ContactNumber, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-10\">\r\n            <label>Department</label>\r\n            ");
#nullable restore
#line 55 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
       Write(Html.EditorFor(m => m.Department, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 56 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
       Write(Html.ValidationMessageFor(m => m.Department, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-10\">\r\n            <button type=\"submit\" class=\"btn btn-secondary btn-sm btn-block\">Save</button>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 66 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    ");
#nullable restore
#line 69 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Employee\Add.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EmployeeManagement.Models.Employee> Html { get; private set; }
    }
}
#pragma warning restore 1591
