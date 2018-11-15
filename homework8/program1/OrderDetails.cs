using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace program1
{
    public class OrderDetails//订单明细/条目
    {
        public OrderDetails()
        {

        }
        public OrderDetails(Goods goods,int number)
        {
            this.CommodityNumber = number;
            this.good = goods;
            this.goodName = goods.Name;       
            this.TotalPrice = this.good.Price * this.CommodityNumber;
        }
        public Goods good { set; get; }
        
        public string goodName { set; get; }

        public int DetailsNumber { set; get; }  
        
        public float TotalPrice { set; get; }

        public int CommodityNumber { set; get; }            
    }
}
