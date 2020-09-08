#pragma checksum "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "189eb735d7821b9b77eb8142813845f2a096857d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Department_Index), @"mvc.1.0.view", @"/Views/Department/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"189eb735d7821b9b77eb8142813845f2a096857d", @"/Views/Department/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a438abb455ce872e5fe241c70018e289f3369ba7", @"/Views/_ViewImports.cshtml")]
    public class Views_Department_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeeManagement.Models.Department>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"
  
    ViewData["Title"] = "Department Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome to the Department section</h1>\r\n");
#nullable restore
#line 9 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"
       int i = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <table class=""table"">
        <thead class=""thead-dark"">
            <tr>
                <th scope=""col"">Serial No.</th>
                <th scope=""col"">Name</th>
                <th scope=""col"">Edit</th>
                <th scope=""col"">Delete</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 21 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"
             foreach (var dep in ViewBag.departments)
            {
                i++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 25 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"
                               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 26 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"
                   Write(dep.DepartmentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 28 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"
                   Write(Html.ActionLink("Edit","Edit", "Department",new { Id = dep.DeptId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 32 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"
                         using (Html.BeginForm("Delete", "Department", new { Id = dep.DeptId }, FormMethod.Post))
                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <button type=\"submit\" class=\"btn btn-link\">Delete</button>\r\n");
#nullable restore
#line 36 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 40 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <hr/>\r\n");
#nullable restore
#line 44 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"
     using (Html.BeginForm("Add", "Department", FormMethod.Post))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"
   Write(Html.HiddenFor(s=>s.DeptId));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <label style=\"font-size:26px\"> Enter the new Department Name</label>\r\n");
#nullable restore
#line 48 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"
   Write(Html.EditorFor(s => s.DepartmentName, new { htmlAttributes = new { @class = "form-control" ,@maxlength="20", @placeholder = "Department Name", @required="true" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("      <br />\r\n        <button type=\"submit\" class=\"btn btn-secondary btn-lg btn-block\">Add new department</button>\r\n");
#nullable restore
#line 50 "F:\promact\WorkingONBoard\EmpManageSys\EmployeeManagementSystem\EmployeeManagement\Views\Department\Index.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
