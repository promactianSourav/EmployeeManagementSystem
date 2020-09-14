using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Models
{
    [Table("Users")]
    public class Employee : IdentityUser
    {

        //public int Id { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="The {0} must be at least {2} character long.",MinimumLength =6)]
        [RegularExpression(@"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Please the Password validation. Include upper and lower case letter. Also include special character and one number.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Confrim Password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Address { get; set; }
        public string Qualification { get; set; }

        [Required(ErrorMessage ="Please fill the contact number.")]
        [RegularExpression(@"^([0-9]{10})$",ErrorMessage ="Not a valid Phone number")]
        public string ContactNumber { get; set; }

        
        [ForeignKey("DeptId")]
        public string DepartmentId { get; set; }

        public List<NotificationUser> NotificationUsers { get; set; }


    }
}