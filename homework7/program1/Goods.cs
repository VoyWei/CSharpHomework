using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    public class Goods
    {
        public Goods(string goods)
        {
            if (goods.Equals("苹果"))
            {
                this.Id = "001";
                this.Price = 3.5f;
                this.Name = goods;
            }
            else if (goods.Equals("橙子"))
            {
                this.Id = "002";
                this.Price = 4.0f;
                this.Name = goods;
            }
            else if (goods.Equals("香蕉"))
            {
                this.Id = "003";
                this.Price = 2.0f;
                this.Name = goods;
            }
            else
            {
                throw new Exception("没有此商品");
            }            
        }

        public string Id
        {
            get;

        }
        public float Price
        {
            get;
        }
        public string Name
        {
            get;
        }
        public override string ToString()
        {
            return Price.ToString();
        }
    }
}
