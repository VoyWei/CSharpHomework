﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

    class MainClass {
        public static void Main() {
            try {
                Customer customer1 = new Customer(1, "Customer1");
                Customer customer2 = new Customer(2, "Customer2");

                Goods milk = new Goods(1, "Milk", 69.9);
                Goods eggs = new Goods(2, "eggs", 4.99);
                Goods apple = new Goods(3, "apple", 5.59);

                OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
                OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
                OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

                Order order1 = new Order(1, customer1);
                Order order2 = new Order(2, customer2);
                Order order3 = new Order(3, customer2);
                order1.AddDetails(orderDetails1);
                order1.AddDetails(orderDetails2);
                order1.AddDetails(orderDetails3);
                //order1.AddOrderDetails(orderDetails3);
                order2.AddDetails(orderDetails2);
                order2.AddDetails(orderDetails3);
                order3.AddDetails(orderDetails3);

                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);

                Console.WriteLine("GetAllOrders");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByCustomerName:'Customer2'");
                var m = from order in orders where order.Customer.Name == "Customer2" select order;
                foreach (var n in m)
                    Console.WriteLine(n.ToString());

                Console.WriteLine("GetOrdersByGoodsName:'apple'");
                foreach (Order order in orders)
                {
                    var mm = from orderDetail in order.Details
                             where orderDetail.Goods.Name == "apple"
                             select orderDetail;
                    foreach (var n in mm)
                    {
                        if (n != null)
                            Console.WriteLine(order.ToString());
                    }
                }

                //查询订单金额大于1万元的订单
                Console.WriteLine("GetOrdersWithPriceMoreThan'10000'");
                m = from order in orders where order.getPrice() >= 10000 select order;
                foreach (var n in m)
                    Console.WriteLine(n.ToString());

                Console.WriteLine("Remove order(id=2) and qurey all");
                os.RemoveOrder(2);
                os.QueryAllOrders().ForEach(
                    od => Console.WriteLine(od));

            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
