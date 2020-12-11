using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class MenuLayout
    {
        ProductManager instance = new ProductManager();

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
                    string UserItem = Console.ReadLine();
                    int UserItemInt = Int32.Parse(UserItem);
                    Console.Clear();
                    instance.GetProductById(UserItemInt);
                    
                    break;

                case "3":
                    //Visa varukorgen
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
