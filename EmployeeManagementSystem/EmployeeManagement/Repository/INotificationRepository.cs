using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Repository
{
    public interface INotificationRepository
    {
        List<NotificationUser> GetNotificationUsers(string userId);
        void Create(Notification notification);
        void ReadNotification(string Id);
        

    }
}
