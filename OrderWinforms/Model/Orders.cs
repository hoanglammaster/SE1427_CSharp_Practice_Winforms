using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderWinforms
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Customer { get; set; }
        public string Employee { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequireDate { get; set; }
        public Nullable<DateTime> ShippedDate { get; set; }
        public Decimal Freight { get; set; }

        public Order()
        {
        }

        public Order(int orderID, string customer, string employee, DateTime orderDate, DateTime requireDate, DateTime shippedDate, decimal freight)
        {
            OrderID = orderID;
            Customer = customer;
            Employee = employee;
            OrderDate = orderDate;
            RequireDate = requireDate;
            ShippedDate = shippedDate;
            Freight = freight;
        }
    }
}
