using OrderWinforms.DAL;
using OrderWinforms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OrderWinforms.BLL
{
    class CustomerBLL
    {
        public List<Customer> getListAllCustomer()
        {
            List<Customer> customers = new List<Customer>();
            CustomerDAL customerDAL = new CustomerDAL();
            DataTable dataTable = customerDAL.getDataTabelAllCustomer();
            foreach(DataRow row in dataTable.Rows)
            {
                customers.Add(new Customer(row["CustomerID"].ToString(), row["CompanyName"].ToString()));
            }
            return customers;
        }
    }
}
