using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Project1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
    }

    class OrdersDatabase
    {
        public static IEnumerable<Order> Orders
        {
            get
            {
                //Thread.Sleep(5000);

                return new List<Order>
                {
                    new Order() {Id = 1, Product = "Product 1", Customer = "Ivanov", Quantity = 1},
                    new Order() {Id = 2, Product = "Product 2", Customer = "Petrov", Quantity = 10},
                    new Order() {Id = 3, Product = "Product 2", Customer = "Fedorov", Quantity = 12},
                };
            }
        }

    }
}