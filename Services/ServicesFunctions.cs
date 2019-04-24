using Entities;
using Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServicesFunction
    {
        // When user enter the app and choose first options:
        public int CooseOption()
        {

            int result;
            while (true)
            {

                Console.Clear();
                Console.WriteLine($"1)Parts\n2)Modules\n3)Configurations");
                bool check = int.TryParse(Console.ReadLine(), out result);
                if (result >= 1 && result <= 3)
                {
                    break;
                }
                Console.WriteLine("please enter correct integer from 1 to 3");
                Console.ReadLine();

            }
            return result;
        }

        // reuse first func.
        public int CooseOptionFilterParts()
        {

            int result;
            while (true)
            {

                Console.Clear();
                Console.WriteLine("how do u want to filter our Product:\n1)All Products\n2)By Price\n3)Type");
                bool check = int.TryParse(Console.ReadLine(), out result);
                if (result >= 1 && result <= 3)
                {
                    break;
                }
                Console.WriteLine("please enter correct integer from 1 to 3");
                Console.ReadLine();

            }
            return result;
        }


        // Print all products
        public void PrintAllProducts<T>(List<T> products) where T : Item
        {
            foreach (T part in products)
            {
                part.PrintInfo();
            }
            GetProductById(products);

        }

        public void GetProductById<T>(List<T> products) where T : Item
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("please choose the number of product u want to buy:");
                Console.ResetColor();
                int result;
                bool check = int.TryParse(Console.ReadLine(), out result);

                bool findById = products.Where(product => product.Id == result).Count() != 0;
             
                if (check && findById)
                {
                    Console.Clear();

                    var obj = products.Where(product => product.Id == result).ToList()[0];
                        Cart.AddProduct(obj);
                 
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"this item has been succsessfully added to you cart!");
                        Console.ResetColor();
                        obj.PrintInfo();
                 
                    


                    Console.WriteLine("Press enter to continue");

                    Console.ReadLine();
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("you have entered invalid intiger please try again with correct input");
                Console.ResetColor();
               
            }
        }
        // Print products by Price range.

        public void PrintPriceProducts<T>(List<T> products) where T: Item
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Please enter the price range u want to sort from 0 to 2000");
                Console.WriteLine($"enter minimum price");
                int min;
                bool checkMin = int.TryParse(Console.ReadLine(), out min);
                 if(!checkMin || min < 0) Console.WriteLine("please enter correct input or integer minimum 0");

                Console.WriteLine($"enter maximum price");
                int max;
                bool checkMax = int.TryParse(Console.ReadLine(), out max);
                if(!checkMax || max > 2000) Console.WriteLine("please enter correct input or integer less than 2000");
                if(min > 0 && max < 2000)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    var filterByPrice = products.Where(product => product.Price > min && product.Price < max)
                        
                    .OrderBy(product => product.Price).ToList();
                    PrintAllProducts(filterByPrice);

                    Console.ResetColor();
                    return;
                }
       
            }
        }


        public void PrintTypeProductsForParts(List<Part> products)
        {

            while(true)
            {
                Console.Clear();
                Console.WriteLine($"we offer this types of parts");
                foreach (string value in Enum.GetNames(typeof(PartType)))
                {
                    Console.WriteLine(value);
                }
                Console.WriteLine("what would u like to choose?");
                var input = Console.ReadLine();

                var filteredProducts = products.Where(product => product.Type.ToString().ToLower() == input.ToLower()).ToList();
                if(filteredProducts.Count() != 0)
                {
                    foreach (var item in filteredProducts)
                    {
                        item.PrintInfo();
                    }
                    Console.Clear();
                    PrintAllProducts(filteredProducts);
                    break;
                }
            }


        }


        public void PrintTypeProductsForModules(List<Module> products)
        {
          while(true)
            {
                Console.Clear();
                Console.WriteLine($"we offer this types of parts");
                foreach (string value in Enum.GetNames(typeof(ModuleType)))
                {
                    Console.WriteLine(value);
                }
                Console.WriteLine("what would u like to choose?");
                var input = Console.ReadLine();

                var filteredProducts = products.Where(product => product.Type.ToString().ToLower() == input.ToLower()).ToList();
                if (filteredProducts.Count() != 0)
                {
                    foreach (var item in filteredProducts)
                    {
                        item.PrintInfo();
                    }
                    Console.Clear();
                    PrintAllProducts(filteredProducts);
                    break;
                }
            }

        }


        public void PrintTypeProductsForConfiguration(List<Configuration> products)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine($"we offer this types of parts");
                foreach (string value in Enum.GetNames(typeof(ConfigurationType)))
                {
                    Console.WriteLine(value);
                }
                Console.WriteLine("what would u like to choose?");
                var input = Console.ReadLine();

                var filteredProducts = products.Where(product => product.Type.ToString().ToLower() == input.ToLower()).ToList();
                if (filteredProducts.Count() != 0)
                {
                    foreach (var item in filteredProducts)
                    {
                        item.PrintInfo();
                    }
                    Console.Clear();
                    PrintAllProducts(filteredProducts);
                    break;
                }
            }
        }

        int result;

        public int Navigation()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("please choose an option:\n1)Continue Shopping\n2)Check the products again\n3)Check your shopping cart\n4)Check out");
                bool check = int.TryParse(Console.ReadLine(), out result);
                if (result >= 1 && result <= 3)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("please enter correct integer from 1 to 3");
                Console.ResetColor();
                Console.ReadLine();

            }
            return result;
        }


    }
}
