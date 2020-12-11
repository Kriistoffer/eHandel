using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class MenuLayout
    {
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

        public void DisplayMenuLayout() 
        {
            Console.WriteLine("Pick one option");
            for (int i = 0; i < MenuOptions.Length; i++) 
            {
                Console.WriteLine(MenuOptions[i]);
            }
        }

        
    }
}
