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
    public class EmployeeDataAccessLayer
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> lstEmployee = new List<Employee>();
            SqlConnection _Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True");


            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("select * from Employee", con);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Employee employee = new Employee();

                    employee.Id = Convert.ToInt32(sdr["Id"]);
                    employee.Name = sdr["Name"].ToString();
                    employee.Surname = sdr["Surname"].ToString();
                    employee.Address = sdr["Address"].ToString();
                    employee.Qualification = sdr["Qualification"].ToString();
                    employee.ContactNumber = sdr["ContactNumber"].ToString();
                    employee.DepartmentId = Convert.ToInt32(sdr["DepartmentId"]);

                    lstEmployee.Add(employee);
                }
                con.Close();
            }
            return lstEmployee;
        }

        //To Add new Employee record      
        public void AddEmployee(Employee employee)
        {

            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True"))
            {

                SqlCommand cmd = new SqlCommand("Insert Into Employee(Id,Name,Surname,Address,Qualification,ContactNumber,DepartmentId) values('" + employee.Id + "','" + employee.Name + "','" + employee.Surname + "','" + employee.Address + "','" + employee.Qualification + "','" + employee.ContactNumber + "','" + employee.DepartmentId + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar Employee    
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Update Employee Set Name='" + employee.Name + "',Surname='"+employee.Surname+ "',Address='" + employee.Address + "',Qualification='" + employee.Qualification + "',ContactNumber='" + employee.ContactNumber + "',DepartmentId='" + employee.DepartmentId + "' Where Id='" + employee.Id + "'", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



        //To Delete the record on a particular Employee    
        public void DeleteEmployee(int? id)
        {

            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employeeManagement;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Delete From Employee Where Id=" + id, con);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}