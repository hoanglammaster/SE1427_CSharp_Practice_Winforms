using OrderWinforms.DAL;
using OrderWinforms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OrderWinforms.BLL
{
    class ShipperBLL
    {
        public List<Shipper> getListAllShipper()
        {
            List<Shipper> shippers = new List<Shipper>();
            ShipperDAL shipperDAL = new ShipperDAL();
            DataTable dataTable = shipperDAL.getDataTableAllShipper();
            foreach(DataRow row in dataTable.Rows)
            {
                shippers.Add(new Shipper(Int32.Parse(row["ShipperID"].ToString()),row["CompanyName"].ToString()));
            }
            return shippers;
        }
    }
}
