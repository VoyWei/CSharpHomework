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
using System.Text.RegularExpressions;

namespace WinForm
{
    public partial class Form2 : Form
    {
        //判断电话号码
        public bool IsPhoneNumber(string phone)
        {
            return  Regex.IsMatch(phone, @"[1]+\d{10}");
        }     
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
            if(Form1.IsNumber(textBox2.Text)&& textBox2.Text!=null&&checkBox1.Checked)
            {
               goods1 = new Goods("苹果");
                OrderDetails orderDetails = new OrderDetails(goods1, Convert.ToInt32(textBox2.Text));
                B++;
                orderDetails.DetailsNumber = B;
                order.MyOrder.Add(orderDetails);
            }
            if (Form1.IsNumber(textBox3.Text) && textBox2.Text != null && checkBox2.Checked)
            {
                goods2 = new Goods("橙子");
                OrderDetails orderDetails = new OrderDetails(goods2, Convert.ToInt32(textBox3.Text));
                B++;
                orderDetails.DetailsNumber = B;
                order.MyOrder.Add(orderDetails);
            }
            if (Form1.IsNumber(textBox4.Text) && textBox2.Text != null && checkBox3.Checked)
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
            //判断电话
            if (!IsPhoneNumber(phoneBox.Text))
            {
                MessageBox.Show("抱歉！请正确输入电话号码！");
                return;
            }
            else
            {
                order.Phone= phoneBox.Text;
            }
               
            if (B == 0)
            {
                MessageBox.Show("抱歉！您添加的订单数量为空！请检查您输入的数字！");
                return;
            }
            else
                MessageBox.Show("添加成功！");
           
            order.OrderId = DateTime.Now.Year + "" + DateTime.Now.Month + DateTime.Now.Day + m.ToString().PadLeft(3, '0');
            order.Sum();
            Form1.os.AddOrder(order);
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
