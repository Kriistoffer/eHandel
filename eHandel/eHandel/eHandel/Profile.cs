using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class Profile : AppManager
    {
        private string firstName;
        private string lastName;
        private string deliveryAdress;


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
                RunProgram();
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
