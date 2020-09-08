﻿using System;
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

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        //We inject the DBContext into the controller...
        private DataContextAll _context;
        private readonly RoleManager<Userroles> roleManager;

        public DepartmentController(DataContextAll context, RoleManager<Userroles> roleManager)
        {
            _context = context;
            this.roleManager = roleManager;
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
            //if (ModelState.IsValid)
            //{
            string s = (Convert.ToInt32(_context.Departments.Select(x => x.DeptId).Max())+1).ToString();
            Department dep = new Department
            {
                DeptId = s,
                DepartmentName = model.DepartmentName
            };

            //IdentityResult result = await roleManager.CreateAsync(dep);

            //if (result.Succeeded)
            //{
                    _context.Departments.Add(dep);
                    _context.SaveChanges();
            //        return RedirectToAction("Index");
            //    }

            //    foreach (IdentityError error in result.Errors)
            //    {
            //        ModelState.AddModelError("", error.Description);
            //    }
            //}

            
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
            //var dep = await roleManager.FindByIdAsync(model.Id);
            //dep.Name = model.Name;
            //var result = await roleManager.UpdateAsync(dep);

            //if (result.Succeeded)
            //{
            //    return RedirectToAction("Index");
            //}
            //foreach(var error in result.Errors)
            //{
            //    ModelState.AddModelError("", error.Description);
            //}

            return RedirectToAction("Index");

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string Id)
        {

            Department department = _context.Departments.FirstOrDefault(a => a.DeptId == Id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
            //var dep = await roleManager.FindByIdAsync(Id);
            //dep.Name = model.Name;
            //var result = await roleManager.DeleteAsync(dep);

            //if (result.Succeeded)
            //{
            //    return RedirectToAction("Index");
            //}
            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError("", error.Description);
            //}


            return RedirectToAction("Index");
        }
    }
}