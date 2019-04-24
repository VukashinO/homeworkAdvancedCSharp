using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Classes
{
    public static class Cart
    {
        public static List<Item> Items = new List<Item>();

        //public Cart()
        //{
        //    Items = new List<Item>();
        //}

        public static void AddProduct(Item item)
        {
            Items.Add(item);
        }

        public static void PrintProductsInCard()
        {
            foreach (var item in Items)
            {
                item.PrintInfo();
            }
        }






        }
    }

