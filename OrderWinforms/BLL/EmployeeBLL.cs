using OrderWinforms.DAL;
using OrderWinforms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OrderWinforms.BLL
{
    class EmployeeBLL
    {
        public List<Employee> getListAllEmployee()
        {
            List<Employee> employees = new List<Employee>();
            EmployeeDAL employeeDAL = new EmployeeDAL();
            DataTable dataTable = employeeDAL.getDataTableAllEmployee();
            foreach (DataRow row in dataTable.Rows)
            {
                employees.Add(new Employee(Int32.Parse(row["EmployeeID"].ToString()), row["EmployeeName"].ToString()));
            }
            return employees;
        }
    }
}
