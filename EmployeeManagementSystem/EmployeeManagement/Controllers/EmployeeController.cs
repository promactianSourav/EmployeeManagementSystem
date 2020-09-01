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
         DataContextAll _context;

        public EmployeeController(DataContextAll context)
        {
            _context = context;
        }

       
        //...and can access it in our actions.
        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.employees = _context.Employees.ToList();
            ViewBag.departments = _context.Departments.ToList();
            var emp = new List<Employee>();
            emp = _context.Employees.ToList();
            return View(emp);
        }

       [HttpGet]
        public IActionResult Add()
        {
            ViewBag.departments = _context.Departments.ToList()
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
            List<Employee> listEmployee = new List<Employee>();
            listEmployee = _context.Employees.ToList();
            int d = listEmployee.Max(x => x.Id);
            employee.Id = d + 1;

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

      

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewBag.departments = _context.Departments.ToList()
              .Select(n => new SelectListItem
              {
                  Value = n.DeptId.ToString(),
                  Text = n.DepartmentName
              }).ToList();
            Employee employee = new Employee();
            employee = _context.Employees.FirstOrDefault(a => a.Id == Id);

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
           
            ViewBag.id = employee.Id;
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {

            Employee employee = _context.Employees.FirstOrDefault(a => a.Id == Id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}