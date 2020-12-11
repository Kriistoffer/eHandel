using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class ProductManager
    {
        ProductManager myProdManager = new ProductManager();
        AppManager instance = new AppManager();

        Product[] ArrayOfProducts = new Product[5];

        public Product[] BasicProducts()
        {
            // Inte plural products utan product.
            //Products Header = new Products();
            ArrayOfProducts[0] = new Product(1, "Canada Goose", "En varm vinterjacka.", 9999.00);
            ArrayOfProducts[1] = new Product(2, "Air Max Pro X", "Snabba skor för den som tränar!", 1299.00);
            ArrayOfProducts[2] = new Product(3, "G-Star Warp", "Stilrena byxor för den modemedvetna.", 1899.00);
            ArrayOfProducts[3] = new Product(4, "Hilfiger Star", "Snyggare T-Shirt är svårare att hitta.", 1099.00);
            ArrayOfProducts[4] = new Product(5, "Gant Hoodie", "För värme och komfort.", 1400.00);

            return ArrayOfProducts;
        }

        public void PrintProducts()
        {
            Product[] OurProducts = new Product[5];

            OurProducts = BasicProducts();

            for (int i = 0; i < OurProducts.Length; i++)
            {
                // Gör på detta sätt.
                Console.WriteLine(OurProducts[i].GetProductID());

                PrintObjects(OurProducts[i]);
            }

        }

        public void PrintProductLayout()
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("| Product ID     |   Product Name                     |   Unit Price         |");
            Console.WriteLine("------------------------------------------------------------------------------");
        }

        public void PrintObjects(Product p)
        {
            Console.WriteLine($"| {p.GetProductID()}              |   {p.GetProductName()}                    |  {p.GetProductPrice()}                |");
            Console.WriteLine("------------------------------------------------------------------------------");
        }

        public void GetAllProducts()
        {
            Console.Clear();
            Product[] allProducts = BasicProducts();
            Console.WriteLine("Product ID \tProduct Name \t\t\tPrice");
            Console.WriteLine("---------------------------------------------------------");

            foreach (var p in allProducts)
            {
                Console.WriteLine(p.GetProductID() + "\t\t" + p.GetProductName() + "\t\t\t" + p.GetProductPrice() + " SEK");
            }
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\n\n[1]Pick an item to view. \n[2]Add an item to your shopping cart. \n[3]View your shopping cart. \n[0]Return to main menu. \n\nPlease, pick an option.");

            string UserInput = Console.ReadLine();

            switch (UserInput)
            {
                case "1":
                    //Visa produkt
                    Console.WriteLine("\nWhich item would you like to view?");
                    string UserItem = Console.ReadLine();
                    int UserItemInt = Int32.Parse(UserItem);
                    Console.Clear();
                    GetProductById(UserItemInt);
                    break;
                case "2":
                   

                    break;
                case "3":
                    //Visa varukorg
                    break;
                case "0":
                    //Återvänd till huvudmeny
                    instance.RunProgram();
                    break;
            }
        }

        public void GetProductById(int id)
        {
            Product[] ProductById = BasicProducts();
            int i = id;

            Console.WriteLine("Product Name \t\tProduct Description \t\t\t\tPrice");
            Console.WriteLine("-----------------------------------------------------------------------------------");

            Console.WriteLine(ProductById[i - 1].GetProductName() + "\t\t" + ProductById[i - 1].GetProductInfo() + "\t\t" + ProductById[i - 1].GetProductPrice());
            Console.WriteLine("-----------------------------------------------------------------------------------");

            Console.WriteLine("\n\n[1]Add item to your shopping cart. \n[2]Return to \"Show all items\". \n[0]Return to main menu. \n\nPlease, pick an option.");

            string UserInput = Console.ReadLine();

            switch (UserInput)
            {
                case "1":
                    //Lägg till vara i varukorg
                    break;
                case "2":
                    //Återvänd till visa alla produkter
                    Console.Clear();
                    GetAllProducts();
                    break;
                case "0":
                    //Återvänd till huvudmenyn
                    instance.RunProgram();
                    break;
            }

        }

        public void AddToShoppingCart() 
        {
            //Lägg till produkt i varukorg
            Console.WriteLine("[1] Choose wich item you would like to add by entering ProduktID.");
            int UserAdd = Convert.ToInt32(Console.ReadLine());
            GetProductById(UserAdd);

            Console.WriteLine("Enter a number of quantity for exampel:\n If you want Onehundred of this item write '100'");
            int Quantity = Convert.ToInt32(Console.ReadLine());
            Product[] Cart = new Product[1];

            Product[] NewCart = new Product[Cart.Length + Quantity];
            for (int i = 0; i < Cart.Length; i++)
            {
                if (GetProductById(UserAdd) == )
                {

                }
                NewCart[i] = Cart[i];
            }

            NewCart[NewCart.Length - 1] = GetProductById(UserAdd);
            return NewCart;
        }
    }
}
