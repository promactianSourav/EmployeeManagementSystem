using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Controllers
{
    
    public class EmployeeController : Controller
    {
        //We inject the DBContext into the controller...
         DataContextAll _context;
        private readonly UserManager<Employee> userManager;
        private readonly SignInManager<Employee> signInManager;

        public EmployeeController(DataContextAll context, UserManager<Employee> userManager,
            SignInManager<Employee> signInManager)
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

       
        //...and can access it in our actions.
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
             Employee currentEmp = await userManager.GetUserAsync(HttpContext.User);
            ViewBag.currentEmp = currentEmp;
            ViewBag.employees = _context.Employees.ToList();
            ViewBag.departments = _context.Departments.ToList();
            var emp = new List<Employee>();
            emp = _context.Employees.ToList();
            return View();
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin,HR")]
        public IActionResult Add()
        {
            ViewBag.departments = _context.Departments.ToList()
               .Select(n => new SelectListItem
               {
                   Value = n.DeptId,
                   Text = n.DepartmentName
               }).ToList();
            return View();
        }

        
        [HttpPost]
        [Authorize(Roles ="Admin,HR")]
        public async Task<IActionResult> Add(Employee model)
        {
            //_context.Employees.Add(employee);
            //_context.SaveChanges();
            if (ModelState.IsValid)
            {
                Employee emp1 = new Employee
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    Name = model.Name,
                    Surname = model.Surname,
                    Address = model.Address,
                    Qualification = model.Qualification,
                    ContactNumber = model.ContactNumber,
                    DepartmentId = model.DepartmentId
                };

                //Employee emp2 = new Employee
                //{
                //    UserName = "Admin",
                //    Email = "admin@gmail.com",
                //    Password = "Admin@123",
                //    ConfirmPassword = "Admin@123",
                //    Name = "Admin",
                //    Surname = "Admin",
                //    Address = "abcdAdmin",
                //    Qualification = "B.TechAdmin",
                //    ContactNumber = "1234567890",
                //    DepartmentId = null
                //};



                //Employee emp3 = new Employee
                //{
                //    UserName = "HR",
                //    Email = "hr@gmail.com",
                //    Password = "Hr@123",
                //    ConfirmPassword = "Hr@123",
                //    Name = "Hr",
                //    Surname = "Hr",
                //    Address = "abcdHr",
                //    Qualification = "B.TechHr",
                //    ContactNumber = "1234567890",
                //    DepartmentId = null
                //};
                IdentityResult result = await userManager.CreateAsync(emp1,model.Password);
                //IdentityResult result2 = await userManager.CreateAsync(emp2,model.Password);
                //IdentityResult result3 = await userManager.CreateAsync(emp3,model.Password);

                if (result.Succeeded)
                {
                    //_context.Departments.Add(dep);
                    //_context.SaveChanges();
                    //foreach (var e in userManager.Users)
                    //{
                    //    EmpDepart ed = new EmpDepart();
                    //    ed.UserId = e.Id;
                    //    ed.RoleId = e.DepartmentId;
                    //    _context.UserRoles.Add(ed);
                    //    _context.SaveChanges();
                    //}
                    Console.WriteLine(_context.UserRoles.ToList().Count());
                    return RedirectToAction("Index");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            return RedirectToAction("Index");
        }


        [HttpGet]
        [Authorize(Roles = "Admin,HR")]
        public IActionResult Edit(string Id)
        {
            ViewBag.departments = _context.Departments.ToList()
              .Select(n => new SelectListItem
              {
                  Value = n.DeptId,
                  Text = n.DepartmentName
              }).ToList();
            Employee employee = new Employee();
            employee = _context.Employees.FirstOrDefault(a => a.Id == Id);

            return View(employee);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,HR")]
        public async Task<IActionResult> Edit(Employee model)
        {
           
            ViewBag.id = model.Id;
            //_context.Employees.Update(employee);
            //_context.SaveChanges();
            //return RedirectToAction("Index");
            var emp = await userManager.FindByIdAsync(model.Id);
            emp.UserName = model.UserName;
            emp.Email = model.Email;
            emp.Password = model.Password;
            emp.ConfirmPassword = model.ConfirmPassword;
            emp.Name = model.Name;
            emp.Surname = model.Surname;
            emp.Address = model.Address;
            emp.Qualification = model.Qualification;
            emp.ContactNumber = model.ContactNumber;
            emp.DepartmentId = model.DepartmentId;
            var result = await userManager.UpdateAsync(emp);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);

        }

        [HttpPost]
        [Authorize(Roles = "Admin,HR")]
        public async Task<IActionResult> Delete(string Id)
        {

            //Employee employee = _context.Employees.FirstOrDefault(a => a.Id == Id);
            //_context.Employees.Remove(employee);
            //_context.SaveChanges();
            //return RedirectToAction("Index");
            var emp = await userManager.FindByIdAsync(Id);
            //dep.Name = model.Name;
            var result = await userManager.DeleteAsync(emp);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return RedirectToAction("Index");
        }
    }
}