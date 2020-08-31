using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Data
{
    public class DepartmentDataAccessLayer
    {
        //To View all Department details      
        public IEnumerable<Department> GetAllDepartments()
        {
            List<Department> lstDepartment = new List<Department>();
            SqlConnection _Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True");


            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("select * from Department", con);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Department department = new Department();

                    department.DeptId = Convert.ToInt32(sdr["DeptId"]);
                    department.DepartmentName = sdr["DepartmentName"].ToString();
                   
                    lstDepartment.Add(department);
                }
                con.Close();
            }
            return lstDepartment;
        }

        //To Add new Department record      
        public void AddDepartment(Department department)
        {

            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True"))
            {
                
                SqlCommand cmd = new SqlCommand("Insert Into Department(DeptId,DepartmentName) values('"+department.DeptId+"','"+department.DepartmentName+"')", con);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar Department    
        public void UpdateDepartment(Department department)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Update Department Set DepartmentName='"+department.DepartmentName+"' Where DeptId='"+department.DeptId+"'" , con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        

        //To Delete the record on a particular Department    
        public void DeleteDepartment(int? id)
        {

            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Delete From Department Where DeptId="+id, con);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}