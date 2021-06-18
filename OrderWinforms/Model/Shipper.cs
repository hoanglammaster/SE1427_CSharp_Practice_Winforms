using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderWinforms.Model
{
    class Shipper
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public Shipper()
        {
        }
        public Shipper(int shipperID, string companyName)
        {
            ShipperID = shipperID;
            CompanyName = companyName;
        }
    }
}
