using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Data
{
    public class EmployeeSqlMapperAsync
    {
        //To View all Employee details      
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> lstEmployee = new List<Employee>();
            IDbConnection db = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True");
            String query = "select * from Employee";
            lstEmployee = (List<Employee>)db.Query<Employee>(query);

            
            return lstEmployee;
        }

        //To Add new Employee record      
        public void AddEmployee(Employee employee)
        {
            IDbConnection db = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True");
            String query = "Insert Into Employee(Id,Name,Surname,Address,Qualification,ContactNumber,DepartmentId) values('" + employee.Id + "','" + employee.Name + "','" + employee.Surname + "','" + employee.Address + "','" + employee.Qualification + "','" + employee.ContactNumber + "','" + employee.DepartmentId + "')";
            db.Query<Employee>(query);
           
        }

        //To Update the records of a particluar Employee    
        public void UpdateEmployee(Employee employee)
        {
            IDbConnection db = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True");
            String query = "Update Employee Set Name='" + employee.Name + "',Surname='" + employee.Surname + "',Address='" + employee.Address + "',Qualification='" + employee.Qualification + "',ContactNumber='" + employee.ContactNumber + "',DepartmentId='" + employee.DepartmentId + "' Where Id='" + employee.Id + "'";
            db.Query<Employee>(query);
           
        }

        

        //To Delete the record on a particular Employee    
        public void DeleteEmployee(int? id)
        {
            IDbConnection db = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True");
            String query = "Delete From Employee Where Id=" + id;
            db.Query<Employee>(query);
            
        }
    }
}