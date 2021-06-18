using OrderWinforms.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace OrderWinforms.DAL
{
    public class OrderDAL
    {
        public DataTable getDataTabelAllOrder()
        {
            SqlCommand command = new SqlCommand("SELECT od.OrderID, " +
            "ct.CompanyName AS Customer, " +
            "CONCAT(ep.FirstName, ' '," +
            "ep.LastName) AS Employee, " +
            "od.OrderDate, " +
            "od.RequiredDate, " +
            "od.ShippedDate, " +
            "od.Freight " +
            "FROM Orders od JOIN Customers ct " +
            "ON od.CustomerID = ct.CustomerID " +
            "JOIN Employees ep " +
            "ON od.EmployeeID = ep.EmployeeID "
            , DAO.getConnection());


            return DAO.getTableFromSql(command);
        }
        public DataTable getDataTableOrderWithConditions(string customer, string employee, DateTime from, DateTime to, bool lateOrder)
        {
            string query = "SELECT * FROM " +
                "(" +
                "SELECT od.OrderID,ct.CompanyName AS Customer, " +
                "CONCAT(ep.FirstName, ' ', ep.LastName) AS Employee, " +
                "od.OrderDate, " +
                "od.RequiredDate, " +
                "od.ShippedDate, " +
                "od.Freight " +
                "FROM Orders od JOIN Customers ct " +
                "ON od.CustomerID = ct.CustomerID " +
                "JOIN Employees ep " +
                "ON od.EmployeeID = ep.EmployeeID " +
                ") AS lo " +
                "WHERE lo.Customer LIKE @Cus AND lo.Employee LIKE @Emp AND lo.OrderDate > @From AND lo.OrderDate < @To ";
            if (!lateOrder)
            {
                query += " AND lo.ShippedDate < lo.RequiredDate";
            }
            SqlCommand command = new SqlCommand(query, DAO.getConnection());
            //add parameter to conditions
            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Cus", customer));
            parameter.Add(new SqlParameter("@Emp", employee));
            parameter.Add(new SqlParameter("@From", from));
            parameter.Add(new SqlParameter("@To", to));
            command.Parameters.AddRange(parameter.ToArray());
            return DAO.getTableFromSql(command);
        }

        public int insertOrderToDB(string customerID, int empID, DateTime orderDate, DateTime reqDate, int shipVia, double freight)
        {
            string query = "INSERT INTO Orders(CustomerID,EmployeeID,OrderDate,RequiredDate,ShipVia,Freight)" +
                " VALUES(@CusID, @EmpID,@Order, @Req, @Via, @Freight) SELECT @@IDENTITY AS ID";
            SqlConnection sqlConnection = DAO.getConnection();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CusID", customerID));
            parameters.Add(new SqlParameter("@EmpID", empID));
            parameters.Add(new SqlParameter("@Order", orderDate));
            parameters.Add(new SqlParameter("@Req", reqDate));
            parameters.Add(new SqlParameter("@Via", shipVia));
            parameters.Add(new SqlParameter("@Freight", freight));
            command.Parameters.AddRange(parameters.ToArray());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            DataRow row = dataTable.Rows[0];
            int result = Int32.Parse(row["ID"].ToString());

            return result;         
        }
        public void insertOrderDetailsToDB(List<Product> products, int orderId)
        {
            List<string> dbOperations = new List<string>();
            foreach (Product product in products)
            {
                dbOperations.Add("INSERT INTO [Order Details] VALUES ( "+orderId+" , "+product.ProductID+" , "+product.UnitPrice+" , "+product.Quantity+" ,"+product.Discound/100+")");
            }
            DAO.runBatchSql(dbOperations);
        }  
    }
}
