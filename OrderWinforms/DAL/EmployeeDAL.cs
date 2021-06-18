using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace OrderWinforms.DAL
{
    class EmployeeDAL
    {
        public DataTable getDataTableAllEmployee()
        {
            string query = "SELECT EmployeeID, CONCAT(FirstName,' ',LastName) AS EmployeeName FROM Employees";
            SqlCommand command = new SqlCommand(query, DAO.getConnection());
            return DAO.getTableFromSql(command);
        }
    }
}
