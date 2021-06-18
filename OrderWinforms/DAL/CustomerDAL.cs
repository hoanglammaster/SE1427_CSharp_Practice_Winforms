using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace OrderWinforms.DAL
{
    class CustomerDAL
    {
        public DataTable getDataTabelAllCustomer()
        {
            string query = "SELECT CustomerID, CompanyName FROM Customers";
            SqlCommand command = new SqlCommand(query,DAO.getConnection());
            return DAO.getTableFromSql(command);
        }
    }
}
