using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace OrderWinforms.DAL
{
    class ShipperDAL
    {
        public DataTable getDataTableAllShipper()
        {
            string query = "SELECT ShipperID, CompanyName FROM Shippers";
            SqlCommand command = new SqlCommand(query, DAO.getConnection());
            return DAO.getTableFromSql(command);
        }
    }
}
