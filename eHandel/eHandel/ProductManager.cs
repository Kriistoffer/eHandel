using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class ProductManager
    {
       
        public ProductManager() { }

        public static void CreateObjekt()
        {
            // Gör så att användare kan visa en specifik produkt genom
            // Payams metod GetProductById.
            // Inte helt färdig än utan tänkte att när man har visat en viss produkt
            // Skall man även kunna välja att lägga till den i varukorgen 
            // Där man även ska kunna välja antal varor
            // Om man är rik och vill lägga till 2000 st jackor skall man kunna göra det.
            //********** Inte helt färdig än ***********

                Console.Write("Input a productID by number to\n" +
                                  "view a specific product: ");
            
            int input = Convert.ToInt32(Console.ReadLine());
            Product1 anProdukt = new Product1();
            Console.WriteLine("");
            Console.WriteLine("");
            anProdukt.GetProductById(input);

            Console.WriteLine("");
            string input2 = Console.ReadLine();

            Console.Clear();
            AppManager.DisplayMenu();
        }
        

        


        public void CreateObjects() 
        {
            Product Header = new Product();

            Product Jacka = new Product(1, "Canada Goose ", "En varm vinterjacka", 9999.00);

            Product Skor = new Product(2, "Air Max Pro X", "Snabba skor perfekt för den som tränar", 1299.00);

            Product Byxor = new Product(3, "G-star warp  ", "Stilrena byxor för den mode-medvetna", 1899.00);

            Product Tshirt = new Product(4, "Hilfiger Star", "Snyggare T-shirt är svår att hitta", 1099.00);

            Product Hoodie = new Product(5, "Gant Hoodie  ", "För värme och komfort", 1400.00);

            Console.Clear();
            Header.PrintProductLayout();

            Jacka.PrintObjects();
            Skor.PrintObjects();
            Byxor.PrintObjects();
            Tshirt.PrintObjects();
            Hoodie.PrintObjects();

            Console.WriteLine("");
        }
    }
}
