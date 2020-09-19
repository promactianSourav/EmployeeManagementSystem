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
        List<NotificationUser> GetNotificationUsersSecond(string userId);
         List<Notification> GetNotificationUsers(string userId);
        void Create(Notification notification, string changer, string changeObjectId);
        void ReadNotification(string Id);
        

    }
}
