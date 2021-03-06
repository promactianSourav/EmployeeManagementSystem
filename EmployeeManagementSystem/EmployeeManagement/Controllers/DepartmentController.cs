﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        //We inject the DBContext into the controller...
        private DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        //...and can access it in our actions.
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.departments = _context.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            var newID = _context.Departments.Select(x => x.DeptId).Max() + 1;
            department.DeptId = newID;

            _context.Departments.Add(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {

            Department department = new Department();
            department.DepartmentName = ((Department)_context.Departments.Where(s => s.DeptId == Id).FirstOrDefault()).DepartmentName;
            department.DeptId = Id;
            ViewBag.name = department.DepartmentName;
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            ViewBag.id = department.DeptId;
            var dep = (Department)_context.Departments.Where(s => s.DeptId == department.DeptId).FirstOrDefault();
            _context.Departments.Remove(dep);
            _context.Departments.Add(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var dep = (Department)_context.Departments.Find(Id);
            _context.Departments.Remove(dep);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}