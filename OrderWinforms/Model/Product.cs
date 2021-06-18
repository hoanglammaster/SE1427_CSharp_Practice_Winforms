using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderWinforms.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public Decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int Quantity { get; set; }
        public double Discound { get; set; }

        public Product()
        {
        }

        public Product(int productID, string productName, string quantityPerUnit, decimal unitPrice, int unitsInStock)
        {
            ProductID = productID;
            ProductName = productName;
            QuantityPerUnit = quantityPerUnit;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
        }

        public Product(int productID, decimal unitPrice, int quantity, double discound)
        {
            ProductID = productID;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discound = discound;
        }

        public override string ToString()
        {
            return ProductName + "("+ UnitPrice+")";
        }
    }
}
