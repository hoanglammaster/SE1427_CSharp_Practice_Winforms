using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderWinforms.Model
{
    class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }

        public Customer()
        {
        }

        public Customer(string customerID, string companyName)
        {
            CustomerID = customerID;
            CompanyName = companyName;
        }
    }
}
