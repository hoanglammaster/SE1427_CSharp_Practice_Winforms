using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderWinforms.Model
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public Employee()
        {
        }

        public Employee(int employeeID, string employeeName)
        {
            EmployeeID = employeeID;
            EmployeeName = employeeName;
        }
    }
}
