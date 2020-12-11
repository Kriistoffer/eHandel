using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class Profile
    {

        private static string firstName;
        private static string lastName;
        private static string deliveryAdress;


        /*Tre metoder vars syfte endast är att fråga efter förnamn, efternamn, och leveransadress och sedan spara input-värdet
         i de korrekta variablerna.*/
        public static void AskFirstName()
        {
            Console.WriteLine("What is your first name?");
            SetFirstName(Console.ReadLine());
            Console.WriteLine("");
        }

        public static void AskLastName()
        {
            Console.WriteLine("What is your last name?");
            SetLastName(Console.ReadLine());
            Console.WriteLine("");
        }

        public static void AskDeliveryAdress()
        {
            Console.WriteLine("What is the delivery adress?");
            SetDeliveryAdress(Console.ReadLine());
            Console.WriteLine("");
        }


        /*En metod för att dubbelkolla ifall användaren är nöjd med sin ifyllda information. Om användaren är nöjd så återvänder man till
         huvudmenyn, ananrs får användaren en förfrågan om vilken information som ska ändras.*/
        public static void DoubleCheck()
        {
            Console.Clear();
            Console.WriteLine("You have entered the following information:");
            Console.WriteLine("");
            Console.WriteLine("First name: " + GetFirstName());
            Console.WriteLine("Last name: " + GetLastName());
            Console.WriteLine("Delivery Adress: " + GetDeliveryAdress());
            Console.WriteLine("");
            Console.WriteLine("Is this information correct? (Yes or no)");

            string input = Console.ReadLine();

            if (input == "Yes" || input == "yes")
            {
                Console.Clear();
                AppManager.DisplayMenu();
            }
            else if (input == "No" || input == "no")
            {
                Console.Clear();
                Console.WriteLine("What would you like to change? (First name, last name, delivery adress)");
                string input2 = Console.ReadLine();

                if (input2 == "First name" || input2 == "First Name")
                {
                    Console.Clear();
                    AskFirstName();
                    DoubleCheck();
                }
                else if (input2 == "Last name" || input2 == "Last Name")
                {
                    Console.Clear();
                    AskLastName();
                    DoubleCheck();
                }
                else if (input2 == "Delivery adress" || input2 == "Delivery Adress")
                {
                    Console.Clear();
                    AskDeliveryAdress();
                    DoubleCheck();
                }
                else
                {
                    Console.WriteLine("You need to pick a valid option.");
                    System.Threading.Thread.Sleep(5000);
                    DoubleCheck();
                }
            }
            else
            {
                Console.WriteLine("Please, enter a valid option.");
                System.Threading.Thread.Sleep(5000);
                DoubleCheck();
            }
        }


        /*Metod som kan kallas på för att be användaren fylla i förnamn, efternamn, och leveransadress. Innehåller även dubbelkollen
         av informationen.*/
        public static void AddInformation()
        {
            Console.Clear();
            Console.WriteLine("Add information to your customer profile.");
            Console.WriteLine("");

            AskFirstName();
            AskLastName();
            AskDeliveryAdress();
            DoubleCheck();
        }


        /*Getters och setters för de privata variablerna som innehåller namn och leveransadress.*/
        private static void SetFirstName(string _firstName)
        {
            firstName = _firstName;
        }

        private static void SetLastName(string _lastName)
        {
            lastName = _lastName;
        }

        private static void SetDeliveryAdress(string _deliveryAdress)
        {
            deliveryAdress = _deliveryAdress;
        }

        public static string GetFirstName()
        {
            return firstName;
        }

        public static string GetLastName()
        {
            return lastName;
        }

        public static string GetDeliveryAdress()
        {
            return deliveryAdress;
        }
    }
}
