using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using program1;

namespace WinForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
 
            InitializeComponent();
        }
        private static int m = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Goods goods1=null,goods2=null,goods3=null;
            m++;
            Order order = new Order();
            int B = 0;
            if(checkBox1.Checked&&textBox2.Text!="")
            {
               goods1 = new Goods("苹果");
                OrderDetails orderDetails = new OrderDetails(goods1, Convert.ToInt32(textBox2.Text));
                B++;
                orderDetails.DetailsNumber = B;
                order.MyOrder.Add(orderDetails);
            }
            if (checkBox2.Checked && textBox3.Text != "")
            {
                goods2 = new Goods("橙子");
                OrderDetails orderDetails = new OrderDetails(goods2, Convert.ToInt32(textBox3.Text));
                B++;
                orderDetails.DetailsNumber = B;
                order.MyOrder.Add(orderDetails);
            }
            if (checkBox3.Checked && textBox4.Text != "")
            {
                goods3 = new Goods("香蕉");
                OrderDetails orderDetails = new OrderDetails(goods3, Convert.ToInt32(textBox4.Text));
                B++;
                orderDetails.DetailsNumber = B;
                order.MyOrder.Add(orderDetails);
            }

            if (!textBox1.Text.Equals(""))
                order.Client = textBox1.Text;
            else
            {
                MessageBox.Show("请输入客户名！");
                return;
            }

            if (B == 0)
            {
                MessageBox.Show("抱歉！您添加的订单为空！");
                return;
            }
            else
                MessageBox.Show("添加成功！");
           
               
            order.OrderId = m +DateTime.Now.Month*10000+DateTime.Now.Day*100;
            order.Sum();
            Form1.os.AddOrder(order);
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
