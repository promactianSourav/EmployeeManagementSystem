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
            ViewBag.departments = _context.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            List<Department> listDepartment = new List<Department>();
            listDepartment = _context.Departments.ToList();
            int d = listDepartment.Max(x => x.DeptId);
            department.DeptId = d + 1;

            _context.Departments.Add(department);
            _context.SaveChanges();
            
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
            ViewBag.id = department.DeptId;

            _context.Departments.Update(department);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {

            Department department = _context.Departments.FirstOrDefault(a => a.DeptId == Id);
            _context.Departments.Remove(department);

            return RedirectToAction("Index");
        }
    }
}