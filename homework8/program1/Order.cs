using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    public class Order
    {
        private List<OrderDetails> myOrder = new List<OrderDetails>();      
        
        public List<OrderDetails> MyOrder { get => this.myOrder; }
        //订单的编号
        public string OrderId { set; get; }
        //该订单的客户
        public string Client { set; get; }
        //客户电话
        public string Phone { set; get; }
        //订单金额
        public float sum { set; get; }
       
        public float Sum()
        {
            foreach(var A in MyOrder)
            {
                sum += A.TotalPrice;
            }
            return sum;
        }
        //添加明细
        public void AddDetails(OrderDetails od) 
        {
            this.MyOrder.Add(od);
        }

        //按商品的编号删除该明细
        public void DelectByName(string name)
        {
            var A = MyOrder.Where(a => a.good.Id == name).Select(a => a);
            foreach(var B in A)
            {
                MyOrder.Remove(B);
            }
        }

        //按商品的名称查询该明细
        public void FindByName(string name)
        {
            var A = MyOrder.Where(a => a.good.Id == name).Select(a => a);
            foreach(var B in A)
            {
                Console.WriteLine($"++++++++ {B.DetailsNumber}.  商品编号：{B.good.Id}  名称：{B.good.Name}  单价：{B.good.Price}  数量：{B.CommodityNumber}  价格：{B.TotalPrice}++++++++");
            }
        }
        
        
    }
}
