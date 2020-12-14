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

            string UserInput = Console.ReadLine();

            if (UserInput == "1")
            {
                //Visa alla produkter
                DisplayAllProducts();
            }
            else if (UserInput == "2")
            {
                //Visa varukorgen
                DisplayShoppingCart();
            }
            else if (UserInput == "0")
            {
                //Avsluta programmet
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\nPlease, enter a valid option (Number 1, 2, or 0).");
                System.Threading.Thread.Sleep(2500);
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

            string UserInput2 = Console.ReadLine();

            if (UserInput2 == "1")
            {
                //Lägg till vara i varukorg
                ManageProduct.AddToShoppingCart(p);
                Console.WriteLine("\nHow many items of this product would you like to add to your shopping cart?");
                int wantedQuantity = Convert.ToInt32(Console.ReadLine());
                p.SetProductQuantity(p, wantedQuantity);
                Console.WriteLine("\n\n" + wantedQuantity + " items added to your shopping cart!");
                System.Threading.Thread.Sleep(2500);
                DisplayAllProducts();
            }
            else if (UserInput2 == "2")
            {
                //Visa alla produkter
                DisplayAllProducts();
            }
            else if (UserInput2 == "0")
            {
                //Visa huvudmenyn
                DisplayMainMenu();
            }
            else
            {
                Console.WriteLine("\nPlease, enter a valid option (Number 1, 2, or 0).");
                System.Threading.Thread.Sleep(2500);
                DisplayProductById(p);
            }
        }

        public void DisplayAllProducts()
        {
            Console.Clear();
            Product[] allProducts = ManageProduct.BasicProducts();
            Console.WriteLine("Product ID \tProduct Name \t\t\tPrice");
            Console.WriteLine("---------------------------------------------------------");

            foreach (var p in allProducts)
            {
                Console.WriteLine(p.GetProductID() + "\t\t" + p.GetProductName() + "\t\t\t" + p.GetProductPrice() + " SEK");
            }

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\n\n[1]Pick an item to view. \n[2]View your shopping cart. \n[0]Return to main menu. \n\nPlease, pick an option:");

            string UserInput = Console.ReadLine();

            if (UserInput == "1")
            {
                //Visa produkt
                Console.WriteLine("\nWhich item would you like to view?");
                int UserInput4 = Convert.ToInt32(Console.ReadLine());

                if (UserInput4 > allProducts.Length)
                {
                    Console.WriteLine("\nPlease, enter a valid number.");
                    System.Threading.Thread.Sleep(2500);
                    DisplayAllProducts();
                }

                DisplayProductById(ManageProduct.GetProductById(UserInput4));
            }
            else if (UserInput == "2")
            {
                //Visa varukorg
                DisplayShoppingCart();
            }
            else if (UserInput == "0")
            {
                //Återvänd till huvucmeny
                DisplayMainMenu();
            }
            else
            {
                Console.WriteLine("\nPlease, enter a valid option (Number 1, 2, or 0).");
                System.Threading.Thread.Sleep(2500);
                DisplayAllProducts();
            }
        }

        public void DisplayShoppingCart()
        {
            Console.Clear();
            Console.WriteLine("Product Name \tProduct Quantity \t\tPrice");
            Console.WriteLine("---------------------------------------------------------");

            listShoppingCart = ManageProduct.GetShoppingCart();

            foreach (var p in listShoppingCart)
            {
                Console.WriteLine(p.GetProductName() + "\t\t" + p.GetProductQuantity() + "\t\t\t" + p.GetProductPrice() + " SEK");
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

            string UserInput = Console.ReadLine();

            if (UserInput == "Yes" || UserInput == "yes")
            {
                Console.Clear();
                MakeOrder();
            }
            else if (UserInput == "No" || UserInput == "no")
            {
                Console.Clear();
                Console.WriteLine("What information would you like to change? (First name, last name, delivery adress?");
                string UserInput2 = Console.ReadLine();

                if (UserInput2 == "First name" || UserInput2 == "first name")
                {
                    Console.Clear();
                    AskFirstName();
                    DoubleCheck();
                }
                else if (UserInput2 == "Last name" || UserInput2 == "last name")
                {
                    Console.Clear();
                    AskLastName();
                    DoubleCheck();
                }
                else if (UserInput2 == "Delivery adress" || UserInput2 == "delivery adress")
                {
                    Console.Clear();
                    AskDeliveryAdress();
                    DoubleCheck();
                }
                else
                {
                    Console.WriteLine("Please, pick a valid option.");
                    System.Threading.Thread.Sleep(2500);
                    DoubleCheck();
                }
            }
            else
            {
                Console.WriteLine("Please, pick a valid option");
                System.Threading.Thread.Sleep(2500);
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

            foreach (var p in listShoppingCart)
            {
                Console.WriteLine(p.GetProductName() + "\t\t" + p.GetProductQuantity() + "\t\t\t" + p.GetProductQuantity() * p.GetProductPrice() + " SEK");
                totalPrice += p.GetProductQuantity() * p.GetProductPrice();
                totalQuantity += p.GetProductQuantity();
            }

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"\tTotal Quantity: {totalQuantity} \t Total price: {totalPrice} SEK");
            Console.WriteLine("\n\n\n[1]Finilize the order and exit the shop. \n[0]Something wrong? Empty the shopping cart and return to the main menu.");
            Console.WriteLine("\n\nPlease, pick an option:");

            string UserInput = Console.ReadLine();

            if (UserInput == "1")
            {
                Console.WriteLine("\n\nYour order has been sent! Thank you for your order.");
                Environment.Exit(0);
            }
            else if (UserInput == "0")
            {
                listShoppingCart.Clear();
                DisplayMainMenu();
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
