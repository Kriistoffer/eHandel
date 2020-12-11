using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace eHandel
{
    class MenuLayout
    {
        ProductManager instance = new ProductManager();
        //AppManager instance2 = new AppManager();

        string[] MenuOptions = {
        "Welcome to eCommerce Squads Online Shop.",
        "",
        "[1]Show all the products.",
        "[2]Show one specific product.",
        "[3]Show the shopping cart.",
        "[4]Add your name and adress to your profile.",
        "[5]Make the order.",
        "[0]Exit the online shop.",
        "",
        "",
        "Pick one option:"};

        public void DisplayMainMenu()
        {
            Console.Clear();
            for (int i = 0; i < MenuOptions.Length; i++)
            {
                Console.WriteLine(MenuOptions[i]);
            }
            MainMenuOptions();
        }

        public void GetProductByIdMenu(Product p)
        {
            Console.WriteLine("Product Name \t\tProduct Description \t\t\t\tPrice");
            Console.WriteLine("-----------------------------------------------------------------------------------");

            Console.WriteLine(p.GetProductName() + "\t\t" + p.GetProductInfo() + "\t\t" + p.GetProductPrice());
            Console.WriteLine("-----------------------------------------------------------------------------------");

            Console.WriteLine("\n\n[1]Add item to your shopping cart. \n[2]Return to \"Show all items\". \n[0]Return to main menu. \n\nPlease, pick an option.");

            string UserInput = Console.ReadLine();

            switch (UserInput)
            {
                case "1":
                    //Lägg till vara i varukorg
                    instance.AddToShoppingCart(p);
                    break;
                case "2":
                    //Återvänd till visa alla produkter
                    Console.Clear();
                    instance.GetAllProducts();
                    break;
                case "0":
                    //Återvänd till huvudmenyn
                    DisplayMainMenu();
                    break;
            }

        }

        public void MainMenuOptions()
        {
            string UserInput = Console.ReadLine();

            switch(UserInput)
            {
                case "1":
                    //Visa alla 
                    instance.GetAllProducts();
                    break;

                case "2":
                    //Visa en specifik produkt
                    Console.WriteLine("\nWhich item would you like to view?");
                    int UserItemInt = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    //instance.GetProductById(UserItemInt);
                    GetProductByIdMenu(instance.GetProductById(UserItemInt));
                    
                    break;

                case "3":
                    //Visa varukorgen
                    List<Product> listShoppingCart = instance.GetShoppingCart();
                    //Product[] arrayShoppingCart = new Product[listShoppingCart.Count()];
                    //arrayShoppingCart = listShoppingCart.ToArray();

                    Console.WriteLine("Product Name \tProduct Quantity \t\t\tPrice");
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine(listShoppingCart.Count());
                    
                    foreach (var p in listShoppingCart)
                    {
                        Console.WriteLine(p.GetProductName() + "\t\t" + instance.GetQuantity() + "\t\t\t" + p.GetProductPrice() + " SEK");
                    }
                    
                    Console.WriteLine("---------------------------------------------------------");
                    break;

                case "4":
                    //Lägg till namn och adress till profil
                    Profile UserProfile = new Profile();
                    UserProfile.AddInformation();
                    break;

                case "5":
                    //Gör beställning
                    break;

                case "0":
                    //Stäng av programmet
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
