using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        //We inject the DBContext into the controller...
        private DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }

       DepartmentDataAccessLayer departmentDataAccessLayer = new DepartmentDataAccessLayer();
        DepartmentSqlMapperAsync departmentSqlMapperAsync = new DepartmentSqlMapperAsync();

        //...and can access it in our actions.
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.departments = departmentSqlMapperAsync.GetAllDepartments().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            List<Department> listDepartment = new List<Department>();
            listDepartment = departmentSqlMapperAsync.GetAllDepartments().ToList();
            int d = listDepartment.Max(x => x.DeptId);
            department.DeptId = d+1;

            departmentSqlMapperAsync.AddDepartment(department);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {

            Department department = new Department();
            List<Department> listDepartment = new List<Department>();
            listDepartment = departmentSqlMapperAsync.GetAllDepartments().ToList();
            foreach (var d in listDepartment)
            {
                if(d.DeptId == Id)
                {
                    ViewBag.name = d.DepartmentName;
                    department.DeptId = Id;
                    department.DepartmentName = d.DepartmentName;
                    break;
                }
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            ViewBag.id = department.DeptId;
            departmentSqlMapperAsync.UpdateDepartment(department);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {

            departmentSqlMapperAsync.DeleteDepartment(Id);

            return RedirectToAction("Index");
        }
    }
}