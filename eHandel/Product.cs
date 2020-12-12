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
        private int productQuantity;


        public Product() { }

        public Product(int id, string name, string info, double price, int quantity)
        {
            this.productID = id;
            this.productName = name;
            this.productInfo = info;
            this.productPrice = price;
            this.productQuantity = quantity;
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

        public int GetProductQuantity()
        {
            return this.productQuantity;
        }

        public void SetProductQuantity(Product p, int a)
        {
            p.productQuantity = p.productQuantity + a;
        }
    }
}
