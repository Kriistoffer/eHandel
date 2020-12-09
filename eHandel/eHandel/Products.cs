﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHandel
{
    class Product
    {
        //Instansvariabler för klasen Produkter.
        private int ProductID;
        private string ProduktName;
        private string ProduktInfo;
        private double ProduktPrice;




        public Product() { }

        // Konstruktor som tar emot 4st parametrar.
        public Product(int ProdID, string ProdName, string ProdInfo, double ProdPrice)
        {
            ProductID = ProdID;
            ProduktName = ProdName;
            ProduktInfo = ProdInfo;
            ProduktPrice = ProdPrice;

        }

        public void PrintProducts()
        {
            ProductManager myProdManager = new ProductManager();
            myProdManager.CreateObjects();

            Console.WriteLine("Choose products to add to shoppingcart by pressing the following numbers 1 - 5. ");

            Console.WriteLine("Press 0 to return to eCommerce Squads start menu");
            string input = Console.ReadLine();

            if (input == "0")
            {
                Console.Clear();
                MenuLayout myMenu = new MenuLayout();
                myMenu.DisplayMenuLayout();
            }
        }

        
        
        // En produkt layout för produkterna.
        public void PrintProductLayout()
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("| Product ID     |   Product Name                     |   Unit Price         |");
            Console.WriteLine("------------------------------------------------------------------------------");
        }

        // Metod som skriver ut varje enskilt objekt.
        public void PrintObjects()
        {

            Console.WriteLine($"| {ProductID}              |   {ProduktName}                    |  {ProduktPrice}                |");
            Console.WriteLine("------------------------------------------------------------------------------");

        }

        // Getters för varje enskild parameter som finns i produkterna.
        public int GetProdID()
        {
            return ProductID;
        }

        public string GetProdName()
        {
            return ProduktName;
        }

        public string GetProdInfo()
        {
            return ProduktInfo;
        }

        public double GetProdPrice()
        {
            return ProduktPrice;
        }


    }
}