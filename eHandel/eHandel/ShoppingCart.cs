using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class ShoppingCart
    {
        public static string ProductID1 { get; private set; }
        public static string ProductID2 { get; private set; }
        public static string ProductID3 { get; private set; }
        public static string ProductID4 { get; private set; }
        public static string ProductID5 { get; private set; }

        public void GetProdID1() 
        {
            ShoppingCart Jacka = new ShoppingCart();
            Console.WriteLine(Jacka);
        }
            

        public static void GetProductID1(string _ProductID1)
        {
            ProductID1 = _ProductID1;
            
        }

        private static void GetProductID2(string _ProductID2)
        {
            ProductID2 = _ProductID2;
        }

        private static void GetProductID3(string _ProductID3)
        {
            ProductID3 = _ProductID3;
        }

        private static void GetProductID4(string _ProductID4)
        {
            ProductID4 = _ProductID4;
        }

        public static void GetProductID5(string _ProductID5)
        {
            ProductID5 = _ProductID5;
        }
    }
}