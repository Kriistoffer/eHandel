using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class Visuals
    {
        ProductManager ManageProduct = new ProductManager();
        AdminPage Admin = new AdminPage();
        List<Product> listShoppingCart = new List<Product>();
        private string firstName;
        private string lastName;
        private string deliveryAdress;
        private double totalPrice;
        private int totalQuantity;

        string[] MenuOptions = {
            "Welcome to eCommerce Squads Online Shop.",
            "",
            "[1]Show all products.",
            "[2]Show your shopping cart.",
            //"[9]Login as admin",
            "[0]Exit the online shop.",
            "",
            "",
            "Please, pick an option:"};

        string[] AdminMenuOptions = {
        "-------Admin options-------",
        "",
        "[1]Add a new product.",
        "[2]Edit an existing product.",
        "[3]Remove a product.",
        "[0]Return to the main menu.",
        "",
        "Please, pick an option:"};

        public void DisplayMainMenu()
        {
            Console.Clear();
            for (int i = 0; i < MenuOptions.Length; i++)
            {
                Console.WriteLine(MenuOptions[i]);
            }

            string InputMainmenuOption = Console.ReadLine();

            if (InputMainmenuOption == "1")
            {
                //Visa alla produkter
                DisplayAllProducts();
            }
            else if (InputMainmenuOption == "2")
            {
                //Visa varukorgen
                DisplayShoppingCart();
            }
            /*else if (InputMainmenuOption == "9")
            {
                //Logga in som admin
                LoginAdmin();
            }*/
            else if (InputMainmenuOption == "0")
            {
                //Avsluta programmet
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\n\nPlease, enter a valid option (Number 1, 2, 9, or 0). Press a key to enter your option again.");
                Console.ReadKey();
                DisplayMainMenu();
            }
        }

        public void DisplayProductById(Product p)
        {
            Console.Clear();
            //Console.WriteLine("Product Name \t\tProduct Description \t\t\t\t\t\tPrice per item");
            Console.WriteLine("{0,0}{1,35}{2,40}", "Product name", "Price per item", "Product Description");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,0}{1,28} SEK{2,45}", p.GetProductName(), p.GetProductPrice(), p.GetProductInfo());
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("\n\n[1]Add item to your shopping cart. \n[2]Return to \"Show all products\". \n[0]Return to the main menu. \n\nPlease, pick an option:");

            string InputProductbyidOption = Console.ReadLine();

            if (InputProductbyidOption == "1")
            {
                //Lägg till vara i varukorg
                Console.WriteLine("\nHow many items of this product would you like to add to your shopping cart?");
                int wantedQuantity = Convert.ToInt32(Console.ReadLine());

                if (wantedQuantity > 0)
                {
                    ManageProduct.AddToShoppingCart(p);
                    p.SetProductQuantity(p, wantedQuantity);
                    Console.WriteLine("\n\n" + wantedQuantity + " items added to your shopping cart! Press a key to show all products again.");
                    Console.ReadKey();
                    DisplayAllProducts();
                }
                else
                {
                    Console.WriteLine("\n\nPlease, pick a quantity greater than zero. Press a key to pick an item again.");
                    Console.ReadKey();
                    DisplayProductById(p);
                }
            }
            else if (InputProductbyidOption == "2")
            {
                //Visa alla produkter
                DisplayAllProducts();
            }
            else if (InputProductbyidOption == "0")
            {
                //Visa huvudmenyn
                DisplayMainMenu();
            }
            else
            {
                Console.WriteLine("\n\nPlease, enter a valid option (Number 1, 2, or 0). Press a key to enter your option again.");
                Console.ReadKey();
                DisplayProductById(p);
            }
        }

        public void DisplayAllProducts()
        {
            Console.Clear();
            Product[] allProducts = ManageProduct.BasicProducts();
            Console.WriteLine("{0,10}{1,18}{2,20}", "Product ID", "Product name", "Price");
            Console.WriteLine("---------------------------------------------------------");

            foreach (var p in allProducts)
            {
                //Console.WriteLine(p.GetProductID() + "\t\t" + p.GetProductName() + "\t\t\t" + p.GetProductPrice() + " SEK");
                Console.WriteLine("{0,3}{1,25}{2,18} SEK", p.GetProductID(), p.GetProductName(), p.GetProductPrice());
            }

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\n\n[1]Pick an item to view. \n[2]View your shopping cart. \n[0]Return to main menu. \n\nPlease, pick an option:");

            string InputAllproductsOption = Console.ReadLine();

            if (InputAllproductsOption == "1")
            {
                //Visa produkt
                Console.WriteLine("\nWhich item would you like to view?");
                int InputItemchoice = Convert.ToInt32(Console.ReadLine());

                if (InputItemchoice > allProducts.Length)
                {
                    Console.WriteLine("\n\nPlease, enter a valid number. Press a key to enter your option again.");
                    Console.ReadKey();
                    DisplayAllProducts();
                }

                DisplayProductById(ManageProduct.GetProductById(InputItemchoice));
            }
            else if (InputAllproductsOption == "2")
            {
                //Visa varukorg
                DisplayShoppingCart();
            }
            else if (InputAllproductsOption == "0")
            {
                //Återvänd till huvudmeny
                DisplayMainMenu();
            }
            else
            {
                Console.WriteLine("\n\nPlease, enter a valid option (Number 1, 2, or 0). Press a key to enter your option again.");
                Console.ReadKey();
                DisplayAllProducts();
            }
        }

        public void DisplayShoppingCart()
        {
            Console.Clear();
            Console.WriteLine("Product Name \tProduct Quantity \t\tPrice");
            Console.WriteLine("---------------------------------------------------------");

            listShoppingCart = ManageProduct.GetShoppingCart();

            // Skapar en dictionary som har 'Tkey = int' och TValue = int
            Dictionary<int, int> productsCount = new Dictionary<int, int>();

            /* Skapar en loop som kollar varje produkt i listShoppingCart
               Om productsCount som är namnet på Dictionaryn har ett nyckelvärde
               som är ProduktID så ska produktkvantiteten tilldelas samma index.
               Om detta inte är fallet så läggs ProduktID och Kvantitet till som vanligt.*/
            foreach (var p in listShoppingCart)
            {
                if (productsCount.ContainsKey(p.GetProductID()))
                {
                    productsCount[p.GetProductID()] += p.GetProductQuantity();
                }
                else
                {
                    productsCount.Add(p.GetProductID(), p.GetProductQuantity());
                }
            }

            // Loop skapas som kollar Dictionaryns nycklar och tilldelar sedan nyckelns värde till produktens värde.
            // Skriver sedan ut nyckelns värde i dictionary som kvantitetens värde i utskriften.
            foreach (var value in productsCount.Keys)
            {
                Product p = ManageProduct.GetProductById(value);
                Console.WriteLine(p.GetProductName() + "\t\t" + productsCount[value] + "\t\t\t" + p.GetProductPrice() + " SEK");
            }

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\n\n[1]Order your products. \n[0]To return to the main menu.\n\nPlease, pick an option:");

            string InputDisplayshoppingcart = Console.ReadLine();

            if (InputDisplayshoppingcart == "1")
            {
                //Order
                AddInformation();
            }
            else if (InputDisplayshoppingcart == "0")
            {
                //Återvänd till huvudmeny
                DisplayMainMenu();
            }
            else
            {
                Console.WriteLine("\n\nPlease, enter a valid option (Number 1 or 0). Press a key to return to your shopping cart.");
                Console.ReadKey();
                DisplayShoppingCart();
            }
        }

        public void AskFirstName()
        {
            Console.WriteLine("What is your first name?");
            SetFirstName(Console.ReadLine());
            Console.WriteLine("");
        }

        public void AskLastName()
        {
            Console.WriteLine("What is your last name?");
            SetLastName(Console.ReadLine());
            Console.WriteLine("");
        }

        public void AskDeliveryAdress()
        {
            Console.WriteLine("What is the delivery adress?");
            SetDeliveryAdress(Console.ReadLine());
            Console.WriteLine("");
        }

        /*En metod för att dubbelkolla med användaren ifall den ifyllda informationen är korrekt, och om inte, vilket som ska korrigeras.*/
        public void DoubleCheck()
        {
            Console.Clear();
            Console.WriteLine("You have entered the following information: \n");
            Console.WriteLine("First name: " + GetFirstName());
            Console.WriteLine("Last name: " + GetLastName());
            Console.WriteLine("Delivery adress: " + GetDeliveryAdress() + "\n");
            Console.WriteLine("Is this information correct? (Yes or no)");

            string DoublecheckConfirmation = Console.ReadLine();

            if (DoublecheckConfirmation == "Yes" || DoublecheckConfirmation == "yes")
            {
                Console.Clear();
                MakeOrder();
            }
            else if (DoublecheckConfirmation == "No" || DoublecheckConfirmation == "no")
            {
                Console.Clear();
                Console.WriteLine("What information would you like to change? (First name, last name, delivery adress?");
                string InputDoublecheck = Console.ReadLine();

                if (InputDoublecheck == "First name" || InputDoublecheck == "first name")
                {
                    Console.Clear();
                    AskFirstName();
                    DoubleCheck();
                }
                else if (InputDoublecheck == "Last name" || InputDoublecheck == "last name")
                {
                    Console.Clear();
                    AskLastName();
                    DoubleCheck();
                }
                else if (InputDoublecheck == "Delivery adress" || InputDoublecheck == "delivery adress")
                {
                    Console.Clear();
                    AskDeliveryAdress();
                    DoubleCheck();
                }
                else
                {
                    Console.WriteLine("\n\nPlease, pick a valid option. Press a key to enter your option again.");
                    Console.ReadKey();
                    DoubleCheck();
                }
            }
            else
            {
                Console.WriteLine("Please, pick a valid option. Press a key to enter your option again.");
                Console.ReadKey();
                DoubleCheck();
            }
        }
        /*Metod som kan kallas på för att be användaren fylla i sin information.*/
        public void AddInformation()
        {
            Console.Clear();
            Console.WriteLine("Add information to your customer profile: \n");
            AskFirstName();
            AskLastName();
            AskDeliveryAdress();
            DoubleCheck();
        }

        public void MakeOrder()
        {
            Console.Clear();
            Console.WriteLine("\t\tRECEIPT AND ORDER CONFIRMATION");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("DELIVERY INFORMATION\n");
            Console.WriteLine("Name: " + this.GetFirstName() + " " + this.GetLastName());
            Console.WriteLine("Adress: " + this.GetDeliveryAdress());
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Product Name \t\tProduct Quantity \tPrice");
            Console.WriteLine("-------------------------------------------------------------");

            listShoppingCart = ManageProduct.GetShoppingCart();

            //Skapar en dictionary som har 'Tkey = int' och TValue = int
            Dictionary<int, int> ProductsCount = new Dictionary<int, int>();

            /* Skapar en loop som kollar varje produkt i listShoppingCart
               Om productsCount som är namnet på Dictionaryn har ett nyckelvärde
               som är ProduktID så ska produktkvantiteten tilldelas samma index
               Om detta inte är fallet så läggs ProduktID och Kvantitet till som vanligt.*/
            foreach (var p in listShoppingCart)
            {
                if (ProductsCount.ContainsKey(p.GetProductID()))
                {
                    ProductsCount[p.GetProductID()] += p.GetProductQuantity();
                }
                else
                {
                    ProductsCount.Add(p.GetProductID(), p.GetProductQuantity());
                }
            }

            //Loop skapas som kollar Dictionaryns nycklar och tilldelar sedan nyckelns värde till produktens värde.
            //Skriver sedan ut nyckelns värde i dictionary som kvantitetens värde i utskriften.
            foreach (var value in ProductsCount.Keys)
            {
                Product p = ManageProduct.GetProductById(value);

                Console.WriteLine(p.GetProductName() + "\t\t" + ProductsCount[value] + "\t\t\t" + ProductsCount[value] * p.GetProductPrice() + " SEK");

                totalPrice += ProductsCount[value] * p.GetProductPrice();
                totalQuantity += ProductsCount[value];
            }

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"\tTotal Quantity: {totalQuantity} \t Total price: {totalPrice} SEK");
            Console.WriteLine("\n\n\n[1]Finilize the order and exit the shop. \n[0]Something wrong? Empty the shopping cart and return to the main menu.");
            Console.WriteLine("\n\nPlease, pick an option:");

            string InputMakeorder = Console.ReadLine();

            if (InputMakeorder == "1")
            {
                Console.WriteLine("\n\nYour order has been sent! Thank you for your order.");
                Environment.Exit(0);
            }
            else if (InputMakeorder == "0")
            {
                totalPrice = 0;
                totalQuantity = 0;
                listShoppingCart.Clear();
                DisplayMainMenu();
            }
            else
            {
                Console.WriteLine("\n\nPlease, pick a valid option. Press a key to enter your option again.");
                Console.ReadKey();
                MakeOrder();
            }
        }

        public void LoginAdmin()
        {
            Console.Clear();
            Console.WriteLine("What's your username?");
            string inputUsername = Console.ReadLine();

            Console.WriteLine("\nWhat's your password?");
            string inputPassword = Console.ReadLine();

            if (inputUsername == Admin.GetUsername() && inputPassword == Admin.GetPassword())
            {
                //Visa adminsida
                AdminMenu();
            }
            else
            {
                Console.WriteLine("\n\nYou have entered incorrect information. Press a key to return to the main menu.");
                Console.ReadKey();
                DisplayMainMenu();
            }
        }

        public void AdminMenu()
        {
            Console.Clear();
            for (int i = 0; i < AdminMenuOptions.Length; i++)
            {
                Console.WriteLine(AdminMenuOptions[i]);
            }

            string InputAdminMenu = Console.ReadLine();

            if (InputAdminMenu == "1")
            {
                //Lägg till produkt
            }
            else if (InputAdminMenu == "2")
            {
                //Redigera produkt
            }
            else if (InputAdminMenu == "3")
            {
                //Ta bort produkt
            }
            else if (InputAdminMenu == "0")
            {
                //Återvänd till huvudmeny
                DisplayMainMenu();
            }
            else
            {
                Console.WriteLine("\n\nPlease, pick a valid option. Press a key to enter your option again.");
                Console.ReadKey();
                AdminMenu();
            }
        }

        /*Getters och setters för de olika privata variablerna som innehåller namn och adress.*/
        private void SetFirstName(string _firstName)
        {
            firstName = _firstName;
        }

        private void SetLastName(string _lastName)
        {
            lastName = _lastName;
        }

        private void SetDeliveryAdress(string _deliveryAdress)
        {
            deliveryAdress = _deliveryAdress;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public string GetDeliveryAdress()
        {
            return deliveryAdress;
        }
    }
}
