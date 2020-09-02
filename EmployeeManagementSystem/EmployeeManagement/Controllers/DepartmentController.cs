using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        //We inject the DBContext into the controller...
        private DataContextAll _context;

        public DepartmentController(DataContextAll context)
        {
            _context = context;
        }
        

        //...and can access it in our actions.
        [HttpGet]
        public IActionResult Index()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            ViewBag.departments = _context.Departments.ToList();
            watch.Stop();
            Console.WriteLine($"Execution time for select : {watch.ElapsedMilliseconds} ms");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            List<Department> listDepartment = new List<Department>();
            listDepartment = _context.Departments.ToList();
            int d = listDepartment.Max(x => x.DeptId);
            department.DeptId = d + 1;
            for (int i = 1; i < 100; i++)
            {
                Department de = new Department();
                de.DeptId = d + i;
                de.DepartmentName = "DepEF" + i.ToString();
                _context.Departments.Add(de);
            }

            //_context.Departments.Add(department);
            _context.SaveChanges();
            watch.Stop();
            Console.WriteLine($"Execution time for Insert : {watch.ElapsedMilliseconds} ms");

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {

            Department department = new Department();
            department = _context.Departments.FirstOrDefault(a => a.DeptId == Id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            //ViewBag.id = department.DeptId;
            for(int i = 1; i < 100; i++)
            {
                Department d = new Department();
                d.DeptId = i;
                d.DepartmentName = "DeEFup" + i.ToString();
                _context.Departments.Update(d);
                _context.SaveChanges();
            }
            //_context.Departments.Update(department);
            
            watch.Stop();
            Console.WriteLine($"Execution time for update : {watch.ElapsedMilliseconds} ms");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            for(int i = 1; i < 100; i++)
            {
                Department department = _context.Departments.First();
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
            //Department department = _context.Departments.FirstOrDefault(a => a.DeptId == Id);
            //_context.Departments.Remove(department);
           
            watch.Stop();
            Console.WriteLine($"Execution time for delete : {watch.ElapsedMilliseconds} ms");

            return RedirectToAction("Index");
        }
    }
}