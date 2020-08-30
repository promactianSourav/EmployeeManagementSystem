using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        //We inject the DBContext into the controller...
        private DataContextTwo _context;
        private DataContext _contextDepartment;

        public EmployeeController(DataContextTwo context,DataContext contextDepartment)
        {
            _context = context;
            _contextDepartment = contextDepartment;
        }

        //...and can access it in our actions.
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.employees = _context.Employees.ToList();
            ViewBag.departments = _contextDepartment.Departments.ToList();
            var emp = new List<Employee>();
            emp = _context.Employees.ToList();
            return View(emp);
        }

       [HttpGet]
        public IActionResult Add()
        {
            ViewBag.departments = _contextDepartment.Departments
               .Select(n => new SelectListItem
               {
                   Value = n.DeptId.ToString(),
                   Text = n.DepartmentName
               }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {

            var newID = _context.Employees.Select(x => x.Id).Max() + 1;
            employee.Id = newID;

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

      

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewBag.departments = _contextDepartment.Departments
                .Select(n => new SelectListItem
                {
                    Value = n.DeptId.ToString(),
                    Text = n.DepartmentName
                }).ToList();
            Employee employee = new Employee();
            employee = ((Employee)_context.Employees.Where(s => s.Id == Id).FirstOrDefault());
            ViewBag.name = employee.Name;
           
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var emp = (Employee)_context.Employees.Where(s => s.Id == employee.Id).FirstOrDefault();
            _context.Employees.Remove(emp);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var emp = (Employee)_context.Employees.Find(Id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}