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
            //var watch = new System.Diagnostics.Stopwatch();
            //watch.Start();
            ViewBag.departments = departmentSqlMapperAsync.GetAllDepartments().ToList();
            //watch.Stop();
            //Console.WriteLine($"Execution time for Select in micro ORM(dapper): {watch.ElapsedMilliseconds}");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            //var watch = new System.Diagnostics.Stopwatch();
            //watch.Start();
            List<Department> listDepartment = new List<Department>();
            listDepartment = departmentSqlMapperAsync.GetAllDepartments().ToList();
            int d1 = listDepartment.Max(x => x.DeptId);
            department.DeptId = d1+1;
            //for(int i = 1; i < 110; i++)
            //{
            //    Department d = new Department();
            //    d.DeptId = d1+i;
            //    d.DepartmentName = "EmployeeMicroORM" + i.ToString();
            //    departmentSqlMapperAsync.AddDepartment(d);

            //}
            //watch.Stop();
            //Console.WriteLine($"Execution time for Insert in micro ORM(dapper): {watch.ElapsedMilliseconds}");

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
            //var watch = new System.Diagnostics.Stopwatch();
            //watch.Start();
            ViewBag.id = department.DeptId;
            //for (int i = 1; i < 215; i++)
            //{
            //    Department d = new Department();
            //    d.DeptId = department.DeptId + i;
            //    d.DepartmentName = "Depat" + i.ToString();
            //    departmentSqlMapperAsync.UpdateDepartment(d);

            //}
            departmentSqlMapperAsync.UpdateDepartment(department);
            //watch.Stop();
            //Console.WriteLine($"Execution time for Update in micro ORM(dapper): {watch.ElapsedMilliseconds}");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            //var watch = new System.Diagnostics.Stopwatch();
            //watch.Start();
            //for(int i = 1; i < 300; i++)
            //{
            //    departmentSqlMapperAsync.DeleteDepartment(i);
            //}
            departmentSqlMapperAsync.DeleteDepartment(Id);
            //watch.Stop();
            //Console.WriteLine($"Execution time for Delete in micro ORM(dapper): {watch.ElapsedMilliseconds}");

            return RedirectToAction("Index");
        }
    }
}