using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class MainClass
    {
        static void Main(string[] args)
        {
            string Name;

            bool T = true;
            int index=0,Number=0;
            OrderService os = new OrderService();
            while (T)
            {
                try
                {
                    Console.WriteLine(" ++++++++++++++++++++++++++++++++橙序圆水果店++++++++++++++++++++++++++++++++ \n\n ------------------  本店产品：    苹果   橙子    香蕉   -------------------- \n\n ============== 请选择您要功能：\n ============= 1.添加订单  2.删除订单  3.查询  4.显示订单 5.退出 ============");
                    int select = Convert.ToInt32(Console.ReadLine());
                    if (select == 1)
                    {
                        index++;
                        //创建一个订单
                        Order order1 = new Order();
                        order1.OrderId = index;
                        Console.WriteLine("\n##################   客户名： ##################");
                        order1.Client= Console.ReadLine();
                        //添加明细
                        int index1 = 0;
                        bool T1 = true;
                        while (T1)
                        {
                            try
                            {   
                                Console.WriteLine("\n请选择：\n——————————1.添加明细 ——————————\n——————————2.完成 ——————————");
                                int select1 = Convert.ToInt32(Console.ReadLine());
                                if (select1 == 1)
                                {
                                    index1++;
                                    Console.WriteLine("商品名称：");
                                    Name = Console.ReadLine();
                                    Goods goods = new Goods(Name);
                                    Console.WriteLine("商品数量：");
                                    Number = Convert.ToInt32(Console.ReadLine());
                                    OrderDetails orderDetails = new OrderDetails(goods,Number);
                                    orderDetails.DetailsNumber = index1;
                                    order1.AddDetails(orderDetails);
                                    Console.WriteLine("\n-*-*-*-*- 完成 -*-*-*-*-\n");
                                }
                                else if (select1 == 2)
                                {
                                    T1 = false;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("\n   ******请正确输入！******");
                            }
                        }
                        //通过OrderService加入OrderList
                        os.AddOrder(order1);
                    }
                    else if (select == 2)
                    {
                        Console.WriteLine("\n\n  ################## 2.)删除订单: ##################\n——————1.按照客户名删除订单——————\n——————2.按照订单号删除订单——————\n——————3.返回\n");
                        int sd =Convert.ToInt32( Console.ReadLine());
                        if (sd == 1)
                        {
                            Console.WriteLine("\n2.按照客户名删除订单");
                            Console.WriteLine("需要删除掉订单的客户：");
                            string client = Console.ReadLine();
                            os.DeleteByCliend(client);
                            Console.WriteLine("-*-*-*-*- 完成 -*-*-*-*-\n");
                        }
                       else if (sd == 2)
                        {
                            Console.WriteLine("\n2.按照订单号删除订单");
                            Console.WriteLine("需要删除掉订单的订单号：");
                            int client =Convert.ToInt32( Console.ReadLine());
                            os.DeleteById(client);
                            Console.WriteLine("-*-*-*-*- 完成 -*-*-*-*-\n");
                        }
                        
                    }
                    else if (select == 3)
                    {
                        Console.WriteLine("\n\n    ################## 3.)查询订单:(请选择) ##################\n——————1.按照客户名查询订单——————\n——————2.按照订单号查询订单——————\n——————3.查询小于指定金额的订单——————\n——————4.按照商品名查询订单——————\n——————5.返回\n");
                        int sd = Convert.ToInt32(Console.ReadLine());
                        if (sd == 1)
                        {
                            Console.WriteLine("\n2.按照客户名查询订单");
                            Console.WriteLine("需要查询订单的客户：");
                            string client = Console.ReadLine();
                            os.FindByName(client);
                            Console.WriteLine("-*-*-*-*- 完成 -*-*-*-*-\n");
                        }
                        else if (sd == 2)
                        {
                            Console.WriteLine("\n2.按照订单号查询订单");
                            Console.WriteLine("需要查询订单的订单号：");
                            int client = Convert.ToInt32(Console.ReadLine());
                            os.FindByID(client);
                            Console.WriteLine("-*-*-*-*- 完成 -*-*-*-*-\n");
                        }
                        else if (sd == 3)
                        {
                            Console.WriteLine("\n3.查询小于指定金额的订单");
                            Console.WriteLine("输入您的金额：");
                            double client = Convert.ToDouble (Console.ReadLine());
                            os.FindByTotal(client);
                            Console.WriteLine("-*-*-*-*- 完成 -*-*-*-*-\n");
                        }
                        else if (sd == 4)
                        {
                            Console.WriteLine("\n2.按照商品名称查询订单");
                            Console.WriteLine("需要查询商品：");
                            string goodsName = Console.ReadLine();
                            os.FindByGN( goodsName);
                            Console.WriteLine("-*-*-*-*- 完成 -*-*-*-*-\n");
                        }
                        
                    }
                    else if (select == 4)
                    {
                        os.ShowForUser();
                        Console.WriteLine("\n***完成*** \n  ");                     
                    }
                    else if (select == 5)
                    {
                        Console.WriteLine("*****谢谢使用！*****");
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("\n   ******请正确输入！******");
                }
            }
        }
          
        
        
    }
}
