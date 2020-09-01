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
    public class DepartmentSqlMapperAsync
    {
        //To View all Department details      
        public IEnumerable<Department> GetAllDepartments()
        {
            List<Department> lstDepartment = new List<Department>();
            IDbConnection db = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True");
            String query = "select * from Department";
            lstDepartment = (List<Department>)db.Query<Department>(query);

            
            return lstDepartment;
        }

        //To Add new Department record      
        public void AddDepartment(Department department)
        {
            IDbConnection db = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True");
            String query = "Insert Into Department(DeptId,DepartmentName) values('" + department.DeptId + "','" + department.DepartmentName + "')";
            db.Query<Department>(query);
           
        }

        //To Update the records of a particluar Department    
        public void UpdateDepartment(Department department)
        {
            IDbConnection db = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True");
            String query = "Update Department Set DepartmentName='" + department.DepartmentName + "' Where DeptId='" + department.DeptId + "'";
            db.Query<Department>(query);
           
        }

        

        //To Delete the record on a particular Department    
        public void DeleteDepartment(int? id)
        {
            IDbConnection db = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True");
            String query = "Delete From Department Where DeptId=" + id;
            db.Query<Department>(query);
          
        }
    }
}