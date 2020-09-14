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
using System.Data.Entity;
using EmployeeManagement.Repository;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class NotificaitonController : Controller
    {
        //We inject the DBContext into the controller...
        private DataContextAll _context;
        private readonly RoleManager<Userroles> roleManager;
        private readonly UserManager<Employee> userManager;
        private readonly SignInManager<Employee> signInManager;

        public NotificationRepository NotificationRepository { get; }

        public NotificaitonController(DataContextAll context, RoleManager<Userroles> roleManager,UserManager<Employee> userManager,
            SignInManager<Employee> signInManager,NotificationRepository notificationRepository)
        {
            _context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            NotificationRepository = notificationRepository;
        }
        
        public IActionResult GetNotification()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            var notification = NotificationRepository.GetNotificationUsers(userId);
            return Ok( new { NotificationUser = notification, Count = notification.Count});
        }

        public IActionResult ReadNotification(string NotificationId)
        {
            NotificationRepository.ReadNotification(NotificationId);
            return Ok();
        }
    }
}