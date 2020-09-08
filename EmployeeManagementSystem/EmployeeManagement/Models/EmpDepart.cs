using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Models
{
    public class EmpDepart:IdentityUserRole<string>
    {
        //public string userId { get; set; }
        //public string roleId { get; set; }
    }
}