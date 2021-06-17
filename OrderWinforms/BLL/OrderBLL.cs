using OrderWinforms.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OrderWinforms.BLL
{
    public class OrderBLL
    {
        public List<Order> getListAllOrder()
        {
            OrderDAL orderDAL = new OrderDAL();
            return convertDataTabelToList(orderDAL.getDataTabelAllOrder());
        }
        public List<Order> getListOrderWithConditions(string customer, string employee, DateTime from, DateTime to, bool lateOrder)
        {
            OrderDAL orderDAL = new OrderDAL();
            //Convert "All Customer" to "%" because "%" mean non-condition in sql
            if(customer.Equals("All Customer"))
            {
                customer = "%";
            }
            if(employee.Equals("All Employee"))
            {
                employee = "%";
            }
            
            return convertDataTabelToList(orderDAL.getDataTableOrderWithConditions(customer,employee,from,to,lateOrder));
        }
        //convert DataTable to List<Order>
        private List<Order> convertDataTabelToList(DataTable orderTabel)
        {
            List<Order> listOrder = new List<Order>();
            foreach (DataRow dataRow in orderTabel.Rows)
            {
                DateTime shippedDate;
                DateTime.TryParse(dataRow["ShippedDate"].ToString(), out shippedDate);
                listOrder.Add(new Order(Int32.Parse(dataRow["OrderID"].ToString()),
                dataRow["Customer"].ToString(),
                dataRow["Employee"].ToString(),
                DateTime.Parse(dataRow["OrderDate"].ToString()),
                DateTime.Parse(dataRow["RequiredDate"].ToString()),
                shippedDate,
                Decimal.Parse(dataRow["Freight"].ToString())));
            }
            return listOrder;
        }
    }
}
