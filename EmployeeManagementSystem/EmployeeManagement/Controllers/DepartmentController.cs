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
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
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
        [HttpGet("departmentlist")]
        [Authorize(Roles = "Admin,HR")]
        public IActionResult Index()
        {

            //_context.SaveChanges();
            //ViewBag.departments = _context.Departments.ToList();
            //return View();

            var departList = _context.Departments.ToList();
            return Ok(departList);
        }

        [HttpPost("add/{id}")]
        // [Authorize(Roles = "Admin")]
        public IActionResult Add([FromBody] Department model,string id)
        {
            string s = (Convert.ToInt32(_context.Departments.Select(x => x.DeptId).Max())+1).ToString();
            Department dep = new Department
            {
                DeptId = s,
                DepartmentName = model.DepartmentName
            };

          
                    _context.Departments.Add(dep);
                    _context.SaveChanges();

            //var userid = userManager.GetUserId(HttpContext.User);
            var userid = id;
            var role = _context.UserRoles.FirstOrDefault(a => a.UserId == userid);
            var changer = _context.Roles.FirstOrDefault(a => a.Id == role.RoleId);
            var changeObjectId = s;

            var notification = new Notification
            {
               Text = $" The {model.DepartmentName} is new Department."
            };
            NotificationRepository.CreateDepartNoti(notification, changer.Name, changeObjectId);

            //return RedirectToAction("Index");
            return Ok(model);
        }


        // [HttpPut("{Id}")]
        // // [Authorize(Roles = "Admin")]
        // public IActionResult Edit(string Id)
        // {

        //     Department department = new Department();
        //     department = _context.Departments.FirstOrDefault(a => a.DeptId == Id);
        //     //return View(department);
        //     return Ok(department);
        // }

        [HttpPut("{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string Id, [FromBody] Department model)
        {
           //ViewBag.id = model.DeptId;
        //    _context.Departments.Update(model);
                Department dep = new Department();
                dep = _context.Departments.FirstOrDefault(a => a.DeptId == Id);
                dep.DeptId = Id;
                dep.DepartmentName = model.DepartmentName;
                

           _context.SaveChanges();

           //return RedirectToAction("Index");
           return Ok(model);

        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(string Id)
        {

            Department department = _context.Departments.FirstOrDefault(a => a.DeptId == Id);
            _context.Departments.Remove(department);
            _context.SaveChanges();

            //return RedirectToAction("Index");
        }
    }
}