using System;
using System.Collections.Generic;

namespace Program2
{

    class OrderDetails
    {
        public String ProductName { get; set; }    
        public String CustomerName { get; set; }     
    }

    class Order : OrderDetails
    {
        public String OrderID { get; set; }              
    }

    public class OrderException : Exception
    {
        public OrderException(string message) : base(message)
        { }

        public OrderException() : base()
        { }
    }

    class OrderService
    {
        List<Order> orders = new List<Order>();

        public void DisplayOrder(Order order)       
        {
            Console.WriteLine($"订单号：{order.OrderID}");
            Console.WriteLine($"商品名：{order.ProductName}");
            Console.WriteLine($"客户名：{order.CustomerName}\n");
        }

        public void DisplayOrderList()            
        {
            foreach (Order order in orders)
                DisplayOrder(order);
        }

        public void IsUnique(String orderID)            
        {
            foreach (Order order in orders)
            {
                if (order.OrderID == orderID)
                {
                    throw new OrderException("订单号已存在，请重新输入！");
                }
            }
        }

        public void AddOrder()
        {
            Order order = new Order();
            Console.WriteLine("请输入订单号：");
            String orderID = Console.ReadLine();
            try
            {
                IsUnique(orderID);
                order.OrderID = orderID;
                Console.WriteLine("请输入商品名：");
                order.ProductName = Console.ReadLine();
                Console.WriteLine("请输入客户名：");
                order.CustomerName = Console.ReadLine();
                orders.Add(order);
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteOrder()
        {
            bool DeleteOrNot = false;
            Console.WriteLine("请输入要删除的订单的订单号：");
            String orderID = Console.ReadLine();
            try
            {
                foreach (Order order in orders)
                {
                    if (order.OrderID == orderID)
                    {
                        orders.Remove(order);
                        DeleteOrNot = true;
                        break;
                    }
                }
                if (!DeleteOrNot)
                    throw new OrderException("找不到订单!");
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Search()
        {
            int flag = 0;
            Console.WriteLine("请选择查询方式（输入数字）：");
            Console.WriteLine("1.订单号");
            Console.WriteLine("2.商品名");
            Console.WriteLine("3.客户名");
            try
            {
                flag = Int32.Parse(Console.ReadLine());
                switch (flag)
                {
                    case 1:
                        SearchByOrderID();
                        break;
                    case 2:
                        SearchByProductName();
                        break;
                    case 3:
                        SearchByCustomerName();
                        break;
                    default:
                        throw new OrderException();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("输入有误！");
            }
        }

        public void SearchByOrderID()             
        {
            bool FoundOrNot = false; 
            Console.WriteLine("请输入订单号：");
            String orderID = Console.ReadLine();
            try                        
            {
                foreach (Order order in orders)
                {
                    if (order.OrderID == orderID)
                    {
                        Console.WriteLine("查询结果：");
                        DisplayOrder(order);
                        FoundOrNot = true;
                        break;    
                    }
                }
                if (!FoundOrNot)
                    throw new OrderException("未找到该订单");
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SearchByProductName()    
        {
            bool FoundOrNot = false;       
            Console.WriteLine("请输入商品名：");
            String productName = Console.ReadLine();
            Console.WriteLine("查询结果：");
            try
            {
                foreach (Order order in orders)
                {
                    if (order.ProductName == productName)
                    {
                        DisplayOrder(order);
                        FoundOrNot = true;
                    }
                }
                if (!FoundOrNot)
                    throw new OrderException("找不到订单");
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SearchByCustomerName()  
        {
            bool FoundOrNot = false;   
            Console.WriteLine("请输入客户名：");
            String customerName = Console.ReadLine();
            Console.WriteLine("查询结果：");
            try
            {
                foreach (Order order in orders)
                {
                    if (order.CustomerName == customerName)
                    {
                        DisplayOrder(order);
                        FoundOrNot = true;
                    }
                }
                if (!FoundOrNot)
                    throw new OrderException("找不到订单");
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void EditOrder()                
        {
            bool FoundOrNot = false;                   
            Console.WriteLine("请输入订单号：");
            String orderID = Console.ReadLine();
            try
            {                 
                Order temp = null;
                foreach (Order order in orders)
                {
                    if (order.OrderID == orderID)
                    {
                        temp = order;
                        FoundOrNot = true;
                        break;
                    }
                }
                if (FoundOrNot)
                {
                    Console.WriteLine("请输入新的订单号：");
                    String newID = Console.ReadLine();
                    IsUnique(newID);  
                    temp.OrderID = newID;
                    Console.WriteLine("请输入新的商品名：");
                    temp.ProductName = Console.ReadLine();
                    Console.WriteLine("请输入新的客户名：");
                    temp.CustomerName = Console.ReadLine();
                    Console.WriteLine("新的订单：");
                    DisplayOrder(temp);
                }
                else
                    throw new OrderException("找不到订单");
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            int flag = 0;
            while (true)
            {
                Console.WriteLine("请选择需要执行的操作（输入数字）：");
                Console.WriteLine("1.添加新订单");
                Console.WriteLine("2.删除订单");
                Console.WriteLine("3.查询订单");
                Console.WriteLine("4.修改订单");
                Console.WriteLine("5.查看订单列表");
                Console.WriteLine("6.退出");
                try
                {
                    flag = Int32.Parse(Console.ReadLine());
                    if (flag < 1 || flag > 6)
                        throw new OrderException();
                    else
                    {
                        switch (flag)
                        {
                            case 1:
                                orderService.AddOrder();
                                break;
                            case 2:
                                orderService.DeleteOrder();
                                break;
                            case 3:
                                orderService.Search();
                                break;
                            case 4:
                                orderService.EditOrder();
                                break;
                            case 5:
                                orderService.DisplayOrderList();
                                break;
                            case 6:
                                return;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("输入有误！");
                }
            }
        }
    }
}
