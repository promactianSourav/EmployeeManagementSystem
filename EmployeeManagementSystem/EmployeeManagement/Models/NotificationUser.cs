using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Models
{
    public class NotificationUser
    {
        public string NotificationId { get; set; }
        public Notification Notification { get; set; }
        public string EmployeeUserId { get; set; }
        public Employee EmployeeUser { get; set; }
    }
}
