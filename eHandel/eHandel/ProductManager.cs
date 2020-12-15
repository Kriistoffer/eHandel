using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class ProductManager
    {
        Product[] ArrayOfProducts = new Product[5];
        private List<Product> shoppingCartList = new List<Product>();

        public Product[] BasicProducts()
        {
            //Products Header = new Products();
            ArrayOfProducts[0] = new Product(1, "Canada Goose", "En varm vinterjacka.", 9999.00, 0);
            ArrayOfProducts[1] = new Product(2, "Air Max Pro X", "Snabba skor för den som tränar!", 1299.00, 0);
            ArrayOfProducts[2] = new Product(3, "G-Star Warp", "Stilrena byxor för den modemedvetna.", 1899.00, 0);
            ArrayOfProducts[3] = new Product(4, "Hilfiger Star", "Snyggare T-Shirt är svårare att hitta.", 1099.00, 0);
            ArrayOfProducts[4] = new Product(5, "Gant Hoodie", "För värme och komfort.", 1400.00, 0);

            return ArrayOfProducts;
        }

        public Product GetProductById(int id)
        {
            Product[] ProductById = BasicProducts();
            return ProductById[id - 1];
        }

        public void AddToShoppingCart(Product item)
        {
            shoppingCartList.Add(item);
        }

        public List<Product> GetShoppingCart()
        {
            return this.shoppingCartList;
        }
    }
}
