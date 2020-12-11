using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class ShoppingCartAdd
    {
        public int Quantity;

        public ShoppingCartAdd()
        {

        }



        public ShoppingCartAdd[] AddProductToCart(ShoppingCartAdd[] Cart, ShoppingCartAdd Cart1)
        {
            ShoppingCartAdd[] NewCart = new ShoppingCartAdd[Cart.Length + 1];
            for (int i = 0; i < Cart.Length; i++)
            {
                NewCart[i] = Cart[i];
            }
            NewCart[NewCart.Length - 1] = Cart1;
            return NewCart;
        }
    }
}
