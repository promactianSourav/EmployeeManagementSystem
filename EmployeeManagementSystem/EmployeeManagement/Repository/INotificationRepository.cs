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


        public void Create(Notification notification);

        public List<NotificationUser> GetNotificationUsers(string userId);

        public void ReadNotification(string Id);
        

    }
}
