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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using EmployeeManagement.Repository;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        //We inject the DBContext into the controller...
        private DataContextAll _context;
        private readonly RoleManager<Userroles> roleManager;

        public UserManager<Employee> userManager { get; }
        public INotificationRepository NotificationRepository { get; }

        public DepartmentController(DataContextAll context, UserManager<Employee> UserManager, RoleManager<Userroles> roleManager, INotificationRepository notificationRepository)
        {
            _context = context;
            userManager = UserManager;
            this.roleManager = roleManager;
            NotificationRepository = notificationRepository;
        }
        

        //...and can access it in our actions.
        [HttpGet]
        [Authorize(Roles ="Admin,HR")]
        public IActionResult Index()
        {

            //if (ModelState.IsValid)
            //{

            //    Userroles dep1 = new Userroles
            //    {
            //        Name = "Admin"
            //    };
            //    roleManager.CreateAsync(dep1);
            //    Userroles dep2 = new Userroles
            //    {
            //        Name = "HR"
            //    };
            //    roleManager.CreateAsync(dep2);
            //}

            //Userroles dep1 = new Userroles
            //{
            //    Id="1",
            //    Name="Admin"
            //};
            //_context.Roles.Add(dep1);
            //_context.SaveChanges();
            //Userroles dep2 = new Userroles
            //{
            //    Id = "2",
            //    Name = "HR"
            //};
            //_context.Roles.Add(dep2);

            //_context.SaveChanges();
            //Userroles dep3 = new Userroles
            //{
            //    Id = "3",
            //    Name = "HR"
            //};
            //_context.Roles.Add(dep3);

            //_context.SaveChanges();
            ViewBag.departments = _context.Departments.ToList();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(Department model)
        {
            string s = (Convert.ToInt32(_context.Departments.Select(x => x.DeptId).Max())+1).ToString();
            Department dep = new Department
            {
                DeptId = s,
                DepartmentName = model.DepartmentName
            };

          
                    _context.Departments.Add(dep);
                    _context.SaveChanges();

            var userid = userManager.GetUserId(HttpContext.User);
            var role = _context.UserRoles.FirstOrDefault(a => a.UserId == userid);
            var changer = _context.Roles.FirstOrDefault(a => a.Id == role.RoleId);
            var changeObjectId = s;

            var notification = new Notification
            {
                Text = $" The {model.DepartmentName} is new Department."
            };
            NotificationRepository.CreateDepartNoti(notification, changer.Name, changeObjectId);

            return RedirectToAction("Index");
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string Id)
        {

            Department department = new Department();
            department = _context.Departments.FirstOrDefault(a => a.DeptId == Id);
            return View(department);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Department model)
        {
            ViewBag.id = model.DeptId;
            _context.Departments.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string Id)
        {

            Department department = _context.Departments.FirstOrDefault(a => a.DeptId == Id);
            _context.Departments.Remove(department);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}