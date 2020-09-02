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
        

        //...and can access it in our actions.
        [HttpGet]
        public IActionResult Index()
        {
            //var watch = new System.Diagnostics.Stopwatch();
            //watch.Start();
            ViewBag.departments = departmentDataAccessLayer.GetAllDepartments().ToList();
            //watch.Stop();
            //Console.WriteLine($"Execution time for Select using ado.net : {watch.ElapsedMilliseconds} ms");

            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            //var watch = new System.Diagnostics.Stopwatch();
            //watch.Start();
            List<Department> listDepartment = new List<Department>();
            listDepartment = departmentDataAccessLayer.GetAllDepartments().ToList();
            int d = listDepartment.Max(x => x.DeptId);
            department.DeptId = d + 1;
            //for (int i = 1; i < 100; i++)
            //{
            //    department.DeptId = d + i;
            //    department.DepartmentName = "EmployeeNew" + i.ToString();
            //    departmentDataAccessLayer.AddDepartment(department);

            //}

            //watch.Stop();
            //Console.WriteLine($"Execution time for Insert using ado.net : {watch.ElapsedMilliseconds} ms");
            departmentDataAccessLayer.AddDepartment(department);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {

            Department department = new Department();
            List<Department> listDepartment = new List<Department>();
            listDepartment = departmentDataAccessLayer.GetAllDepartments().ToList();
            foreach(var d in listDepartment)
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
            //var watch = new System.Diagnostics.Stopwatch();
            //watch.Start();
            //for (int i = 1; i < 101; i++)
            //{
            //    Department d = new Department();
            //    d.DeptId = i;
            //    d.DepartmentName = "Hello" + i.ToString();
            //    departmentDataAccessLayer.UpdateDepartment(d);

            //}
            //watch.Stop();
            //Console.WriteLine($"Execution time for Update using ado.net : {watch.ElapsedMilliseconds} ms");

            departmentDataAccessLayer.UpdateDepartment(department);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            //var watch = new System.Diagnostics.Stopwatch();
            //watch.Start();
            //for (int i = 1; i < 101; i++)
            //{
            //    Department d = new Department();
            //    d.DeptId = i;
            //    d.DepartmentName = "EmployeeUpdate" + i.ToString();
            //    departmentDataAccessLayer.DeleteDepartment(i);

            //}
            //watch.Stop();
            //Console.WriteLine($"Execution time for Delete using ado.net : {watch.ElapsedMilliseconds} ms");

            departmentDataAccessLayer.DeleteDepartment(Id);

            return RedirectToAction("Index");
        }
    }
}