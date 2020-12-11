using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class Product1 : Product
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //en array av 5 element 
        Product1[] products = new Product1[5];
        //en metod för att fylla in products array med Dummy Data!
        public Product1[] InitializeArrayOfProducts()
        {
            // Har lagt in så att produkterna matchar med varandera.
            Product1 prod1 = new Product1();
            prod1.Id = 1;
            prod1.Name = "Canada Goose";
            prod1.Description = "En varm vinterjacka.";
            prod1.Price = 9999.00M;

            Product1 prod2 = new Product1();
            prod2.Id = 2;
            prod2.Name = "Air Max Pro X";
            prod2.Description = "Snabba skor.\t";
            prod2.Price = 1299.00M;

            Product1 prod3 = new Product1();
            prod3.Id = 3;
            prod3.Name = "G-star warp";
            prod3.Description = "Stilrena byxor.\t";
            prod3.Price = 1899.00M;

            Product1 prod4 = new Product1();
            prod4.Id = 4;
            prod4.Name = "Hilfiger Star";
            prod4.Description = "Snyggaste T-shirten.";
            prod4.Price = 1099.00M;

            Product1 prod5 = new Product1();
            prod5.Id = 5;
            prod5.Name = "Gant Hoodie";
            prod5.Description = "För värme och komfort.";
            prod5.Price = 1400.00M;

            products[0] = prod1;
            products[1] = prod2;
            products[2] = prod3;
            products[3] = prod4;
            products[4] = prod5;
            return products;
        }

        //metoden skapar en ny array enligt dummy data i InitializeArrayOfProducts och returnerar alla produkter genom foreach loop
        public void GetAllProducts()
        {
            Product1[] allProducts = InitializeArrayOfProducts();
            Console.WriteLine("\tName \tDescription \tPrice");

            foreach (var p in allProducts)
            {
                Console.WriteLine(p.Id + "\t" + p.Name + "\t" + p.Description + "\t" + p.Price + "SEK");
            }

        }
        //metoden skapar en ny array enligt dummy data i InitializeArrayOfProducts och returnerar en viss produkt 
        //Paramtren int id är userInput från Appmanager
        
        public void GetProductById(int id)
        {
            Product1[] productById = InitializeArrayOfProducts();
            int i = id;
            Console.WriteLine("Name \t\tDescription \t\tPrice");
            Console.WriteLine("*************************************************");



            Console.WriteLine(productById[i - 1].Name + "\t" + productById[i - 1].Description + "\t" + productById[i - 1].Price + " SEK");
            Console.WriteLine("");
            Console.WriteLine("Press [0] To return to Start menu..");




        }
    }
}
