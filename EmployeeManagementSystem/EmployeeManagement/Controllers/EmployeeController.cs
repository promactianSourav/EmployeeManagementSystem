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

        DepartmentSqlMapperAsync departmentSqlMapperAsync = new DepartmentSqlMapperAsync();
        EmployeeSqlMapperAsync employeeSqlMapperAsync = new EmployeeSqlMapperAsync();

        //...and can access it in our actions.
        [HttpGet]
        public IActionResult Index()
        {
            
            ViewBag.employees = employeeSqlMapperAsync.GetAllEmployees().ToList();
            ViewBag.departments = departmentSqlMapperAsync.GetAllDepartments().ToList();
            var emp = new List<Employee>();
            emp = employeeSqlMapperAsync.GetAllEmployees().ToList();
            return View(emp);
        }

       [HttpGet]
        public IActionResult Add()
        {
            ViewBag.departments = departmentSqlMapperAsync.GetAllDepartments().ToList()
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
            listEmployee = employeeSqlMapperAsync.GetAllEmployees().ToList();
            int d = listEmployee.Max(x => x.Id);
            employee.Id = d + 1;

            employeeSqlMapperAsync.AddEmployee(employee);
            return RedirectToAction("Index");
        }

      

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewBag.departments = departmentSqlMapperAsync.GetAllDepartments().ToList()
              .Select(n => new SelectListItem
              {
                  Value = n.DeptId.ToString(),
                  Text = n.DepartmentName
              }).ToList();
            Employee employee = new Employee();

            List<Employee> listEmployee = new List<Employee>();
            listEmployee = employeeSqlMapperAsync.GetAllEmployees().ToList();
            foreach (var e in listEmployee)
            {
                if (e.Id == Id)
                {
                    ViewBag.name = e.Name;
                    employee.Id = Id;
                    employee.Name = e.Name;
                    employee.Surname = e.Surname;
                    employee.Address = e.Address;
                    employee.Qualification = e.Qualification;
                    employee.ContactNumber = e.ContactNumber;
                    employee.DepartmentId = e.DepartmentId;
                    break;
                }
            }
        
           
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
           
            ViewBag.id = employee.Id;
            employeeSqlMapperAsync.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
           
            employeeSqlMapperAsync.DeleteEmployee(Id);

            return RedirectToAction("Index");
        }
    }
}