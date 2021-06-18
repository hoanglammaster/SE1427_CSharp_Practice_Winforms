using OrderWinforms.DAL;
using OrderWinforms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OrderWinforms.BLL
{
    class ProductBLL
    {
        public List<Product> getListAllProduct()
        {
            List<Product> products = new List<Product>();
            ProductDAL productDAL = new ProductDAL();
            DataTable dataTable = productDAL.getDataTableAllProduct();
            foreach (DataRow row in dataTable.Rows)
            {
                products.Add(new Product(Int32.Parse(row["ProductID"].ToString()), row["ProductName"].ToString(), row["QuantityPerUnit"].ToString(), Decimal.Parse(row["UnitPrice"].ToString()), Int32.Parse(row["UnitsInStock"].ToString())));
            }
            return products;
        }
       
    }
}
