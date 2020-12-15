using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class AppManager
    {
		public void RunProgram()
        {
            Console.Title = "eCommerce Online Shop";
            Visuals myMenu = new Visuals();
            myMenu.DisplayMainMenu();
        }
    }
}
