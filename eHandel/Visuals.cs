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
        //AdminPage Admin = new AdminPage();
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
            //"[9]Login as admin.",
            "[0]Exit the online shop.",
            "",
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
            //else if (InputMainmenuOption == "9")
            //{
            //    //Logga in som admin
            //    LoginAdmin();
            //}
            else if (InputMainmenuOption == "0")
            {
                //Avsluta programmet
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\nPlease, enter a valid option (Number 1, 2, or 0). Press a key to enter your option again.");
                //System.Threading.Thread.Sleep(2500);
                Console.ReadKey();
                DisplayMainMenu();
            }
        }

        public void DisplayProductById(Product p)
        {
            Console.Clear();
            Console.WriteLine("Product Name \t\tProduct Description \t\t\t\tPrice");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine(p.GetProductName() + "\t\t" + p.GetProductInfo() + "\t\t\t\t" + p.GetProductPrice());
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("\n\n[1]Add item to your shopping cart. \n[2]Return to \"Show all products\". \n[0]Return to the main menu. \n\nPlease, pick an option:");

            string InputProductbyidOption = Console.ReadLine();

            if (InputProductbyidOption == "1")
            {
                //Lägg till vara i varukorg
                ManageProduct.AddToShoppingCart(p);
                Console.WriteLine("\nHow many items of this product would you like to add to your shopping cart?");
                int wantedQuantity = Convert.ToInt32(Console.ReadLine());
                p.SetProductQuantity(p, wantedQuantity);
                Console.WriteLine("\n\n" + wantedQuantity + " items added to your shopping cart! Press a key to show all products again.");
                //System.Threading.Thread.Sleep(2500);
                Console.ReadKey();
                DisplayAllProducts();
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
                Console.WriteLine("\nPlease, enter a valid option (Number 1, 2, or 0). Press a key to enter your option again.");
                //System.Threading.Thread.Sleep(2500);
                Console.ReadKey();
                DisplayProductById(p);
            }
        }

        public void DisplayAllProducts()
        {
            Console.Clear();
            //Product[] allProducts = ManageProduct.BasicProducts();
            Console.WriteLine("Product ID \tProduct Name \t\t\tPrice");
            Console.WriteLine("---------------------------------------------------------");
            // bytte ut allProducts mot ManageProducts.BasicProducts()
            foreach (var p in ManageProduct.BasicProducts())
            {
                Console.WriteLine(p.GetProductID() + "\t\t" + p.GetProductName() + "\t\t\t" + p.GetProductPrice() + " SEK");
            }

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\n\n[1]Pick an item to view. \n[2]View your shopping cart. \n[0]Return to main menu. \n\nPlease, pick an option:");

            string InputAllproductsOption = Console.ReadLine();

            if (InputAllproductsOption == "1")
            {
                //Visa produkt
                Console.WriteLine("\nWhich item would you like to view?, Choose på entering the desired product by ID.");
                int InputItemchoice = Convert.ToInt32(Console.ReadLine());

                if (InputItemchoice > ManageProduct.BasicProducts().Length)
                {
                    Console.WriteLine("\nPlease, enter a valid number. Press a key to enter your option again.");
                    //System.Threading.Thread.Sleep(2500);
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
                Console.WriteLine("\nPlease, enter a valid option (Number 1, 2, or 0). Press a key to enter your option again.");
                //System.Threading.Thread.Sleep(2500);
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
               som är ProduktID så ska produktkvantiteten tilldelas samma index
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

            string UserInput5 = Console.ReadLine();

            if (UserInput5 == "1")
            {
                //Order
                AddInformation();
            }
            else if (UserInput5 == "0")
            {
                //Återvänd till huvudmeny
                DisplayMainMenu();
            }
            else
            {
                Console.WriteLine("\nPlease, enter a valid option (Number 1 or 0).");
                System.Threading.Thread.Sleep(2500);
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
                    Console.WriteLine("Please, pick a valid option. Press a key to enter your option again.");
                    //System.Threading.Thread.Sleep(2500);
                    Console.ReadKey();
                    DoubleCheck();
                }
            }
            else
            {
                Console.WriteLine("Please, pick a valid option. Press a key to enter your option again.");
                //System.Threading.Thread.Sleep(2500);
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

            // Skapar en dictionary som har 'Tkey = int' och TValue = int
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

            // Loop skapas som kollar Dictionaryns nycklar och tilldelar sedan nyckelns värde till produktens värde.
            // Skriver sedan ut nyckelns värde i dictionary som kvantitetens värde i utskriften.
            foreach (var value in ProductsCount.Keys)
            {
                Product p = ManageProduct.GetProductById(value);

                Console.WriteLine(p.GetProductName() + "\t\t" + ProductsCount[value] + "\t\t\t" + ProductsCount[value] * p.GetProductPrice() + " SEK");

                totalPrice += ProductsCount[value] * p.GetProductPrice();
                totalQuantity += ProductsCount[value];
            }

            // Skapar en variabel som formaterar totalPrice så att utskkriften skrivs ut i thousands seperator.
            string fTotalPrice = string.Format("{0:0,0}", totalPrice);
            
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"\tTotal Quantity: {totalQuantity} \t Total price:   {fTotalPrice} SEK");
            
            Console.WriteLine("\n\n\n[1]Finilize the order and exit the shop. \n[0]Something wrong? Empty the shopping cart and return to the main menu.");
            Console.WriteLine("\n\nPlease, pick an option:");
            
            
            string UserInput = Console.ReadLine();

            if (UserInput == "1")
            {
                Console.WriteLine("\n\nYour order has been sent! Thank you for your order.\n");
                Environment.Exit(0);
            }
            else if (UserInput == "0")
            {
                totalQuantity = 0;
                totalPrice = 0;
                listShoppingCart.Clear();
                DisplayMainMenu();
            }

        }
        
        //public void LoginAdmin()
        //{
        //    Console.Clear();
        //    Console.WriteLine("What's your username?");
        //    string inputUsername = Console.ReadLine();

        //    Console.WriteLine("\nWhat's your password?");
        //    string inputPassword = Console.ReadLine();

        //    if (inputUsername == Admin.GetUsername() && inputPassword == Admin.GetPassword())
        //    {
        //        Console.WriteLine("[1] Add new item to store. \n [0]To return to the main menu.\n\nPlease, pick an option: ");
        //        string AddItemInput = Console.ReadLine();
        //        if (AddItemInput == "1")
        //        {
        //            //Visa adminsida
        //            foreach (var product in ManageProduct.BasicProducts())
        //            {
        //                ManageProduct.AddToArray(ManageProduct.NewProductInformation(product));
        //                DisplayAllProducts();
        //            }
        //        }
        //        else if (AddItemInput == "0")
        //        {
        //            DisplayMainMenu();
        //        }

        //    }
        //    else
        //    {
        //        Console.WriteLine("\nYou have entered incorrect information. Press a key to return to the main menu.");
        //        //System.Threading.Thread.Sleep(2500);
        //        Console.ReadKey();
        //        DisplayMainMenu();
        //    }
        //}

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
