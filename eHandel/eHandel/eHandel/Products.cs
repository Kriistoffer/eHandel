using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class Product
    {
        private int productID;
        private string productName;
        private string productInfo;
        private double productPrice;
        
        // Dessa ska inte vara här
       

        public Product() { }

        public Product(int id, string name, string info, double price)
        {
            this.productID = id;
            this.productName = name;
            this.productInfo = info;
            this.productPrice = price;
        }


        public int GetProductID()
        {
            return this.productID;
        }

        public string GetProductName()
        {
            return this.productName;
        }

        public string GetProductInfo()
        {
            return this.productInfo;
        }

        public double GetProductPrice()
        {
            return this.productPrice;
        }

    }
}
