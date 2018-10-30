using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace program1
{
     public class OrderService
    {
       
        public List<Order> orders = new List<Order>();

       //添加订单
       public void AddOrder(Order order)
        {
            this.orders.Add(order);
        }

        //按订单号删除订单
        public void DeleteById(int id)
        {
            if(this.orders.Count==0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }
            var A = orders.Where(a => a.OrderId == id).Select(a => a);
            //判断是否有相关订单
            if (A.Count() == 0)
            {
                Console.WriteLine("========== 没有符合条件的订单 ==========");
                return;
            }
            this.orders.RemoveAll(a => a.OrderId == id);
        }
        //按客户删除订单
        public void DeleteByCliend(string client)
        {
            if (this.orders.Count == 0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }
            var A = orders.Where(a => a.Client.Equals(client)).Select(a => a);
            //判断是否有相关订单
            if (A.Count() == 0)
            {
                Console.WriteLine("========== 没有符合条件的订单 ==========");
                return;
            }
            this.orders.RemoveAll(a => a.Client.Equals(client));
        }     

        //按照客户查询订单
        public void FindByName(string client)
        {
            if (this.orders.Count == 0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }
            //筛选订单
            var A = orders.Where(a => a.Client == client).Select(a => a);
            if (A.Count() == 0)
            {
                Console.WriteLine("========== 没有符合条件的订单 ==========");
                return;
            }
            //输出所得订单
            foreach (var B in A)
            {
                Console.WriteLine($"\n=========订单号：{B.OrderId}    客户：{B.Client}=========");
                foreach (var C in B.MyOrder)
                {
                    Console.WriteLine($"++++++++ {C.DetailsNumber}.  商品编号：{C.good.Id}\t名称：{C.good.Name}\t单价：{C.good.Price}\t数量：{C.CommodityNumber}\t价格：{C.TotalPrice}++++++++");
                }
                Console.WriteLine($"++++++++总金额：{B.Sum()}");
                Console.WriteLine($"\n*****{DateTime.Now.Year.ToString()}/{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}*****");
            }
        }

        //按照订单号查询订单
        public void FindByID(int id)
        {
            if (this.orders.Count == 0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }

            //筛选订单
            var A = orders.Where(a => a.OrderId == id).Select(a => a);
            if (A.Count() == 0)
            {
                Console.WriteLine("========== 没有符合条件的订单 ==========");
                return;
            }
            //输出所得订单
            
            foreach (var B in A)
            {
                Console.WriteLine($"\n=========订单号：{B.OrderId}    客户：{B.Client}=========");
                foreach (var C in B.MyOrder)
                {
                    Console.WriteLine($"++++++++ {C.DetailsNumber}.  商品编号：{C.good.Id}\t名称：{C.good.Name}\t单价：{C.good.Price}\t数量：{C.CommodityNumber}\t价格：{C.TotalPrice}++++++++");
                }
                Console.WriteLine($"++++++++总金额：{B.Sum()}");
                Console.WriteLine($"\n*****{DateTime.Now.Year.ToString()}/{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}*****");
            }
        }

        //按照商品名称查询
        public void FindByGN(string name)
        {
            if (this.orders.Count == 0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }
            var A =  orders.Where(a => a.MyOrder.Exists(b => b.good.Name == name)).Select(a => a);
            
            foreach (var B in A)
            {
                Console.WriteLine($"\n=========订单号：{B.OrderId}    客户：{B.Client}=========");
                foreach (var C in B.MyOrder)
                {
                    Console.WriteLine($"++++++++ {C.DetailsNumber}.  商品编号：{C.good.Id}\t名称：{C.good.Name}\t单价：{C.good.Price}\t数量：{C.CommodityNumber}\t价格：{C.TotalPrice}++++++++");
                }
                Console.WriteLine($"++++++++总金额：{B.Sum()}");
                Console.WriteLine($"\n*****{DateTime.Now.Year.ToString()}/{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}*****");
            }
        }


        //按照指定金额查询订单
        public void FindByTotal(double total)
        {
            if (this.orders.Count == 0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }
            if (total < 0)
            {
                Console.WriteLine("++++++ 正确输入！ ++++++");
                return;
            }
            
            //筛选订单
            var A = orders.Where(a => a.Sum()<total).Select(a => a);
            if (A.Count() == 0)
            {
                Console.WriteLine("========== 没有符合条件的订单 ==========");
                return;
            }
            //循环输出所得订单
            foreach (var B in A)
            {
                Console.WriteLine($"\n=========订单号：{B.OrderId}    客户：{B.Client}=========");
                foreach (var C in B.MyOrder)
                {
                    Console.WriteLine($"++++++++ {C.DetailsNumber}.  商品编号：{C.good.Id}\t名称：{C.good.Name}\t单价：{C.good.Price}\t数量：{C.CommodityNumber}\t价格：{C.TotalPrice}++++++++");
                }
                Console.WriteLine($"++++++++总金额：{B.Sum()}");
                Console.WriteLine($"\n*****{DateTime.Now.Year.ToString()}//{DateTime.Now.Month.ToString()}//{DateTime.Now.Day.ToString()}*****");

            }

        }
        //显示所有订单
        public void ShowForUser()
        {
            if (this.orders.Count == 0)
            {
                Console.WriteLine("++++++ 没有订单 ++++++");
                return;
            }
            foreach(var B in this.orders)
            {
                Console.WriteLine($"\n=========订单号：{B.OrderId}    客户：{B.Client}=========");
                foreach (var C in B.MyOrder)
                {
                    Console.WriteLine($"++++++++ {C.DetailsNumber}.  商品编号：{C.good.Id}\t名称：{C.good.Name}\t单价：{C.good.Price}\t数量：{C.CommodityNumber}\t价格：{C.TotalPrice}++++++++");
                }
                Console.WriteLine($"++++++++总金额：{B.Sum()}");
                Console.WriteLine($"\n*****{DateTime.Now.Year.ToString()}//{DateTime.Now.Month.ToString()}//{DateTime.Now.Day.ToString()}*****");
            }
            
            
        }
        
    }
}
