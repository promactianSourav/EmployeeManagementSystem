using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        //We inject the DBContext into the controller...
        private DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        //...and can access it in our actions.
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.employees = _context.Employees.ToList();
            return View();
        }

        //...

       [HttpGet]
        public IActionResult Add()
        {
            
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

        //...

        [HttpGet]
        public IActionResult Edit(int Id)
        {

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