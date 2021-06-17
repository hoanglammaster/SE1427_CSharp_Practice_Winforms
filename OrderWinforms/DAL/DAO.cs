using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;

namespace OrderWinforms.DAL
{
    class DAO
    { 
        public static SqlConnection getConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindDB"].ConnectionString);
        }
        public static DataTable getTableFromSql(SqlCommand command)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            dataAdapter.Fill(table);
            return table;
        }
    }
}
