using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Models
{
    public class Notification
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool IsRead { get; set; } = false;

        public List<NotificationUser> NotificationUsers { get; set; }
    }
}
