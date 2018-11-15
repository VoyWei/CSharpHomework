using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using program1;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;

namespace WinForm
{
    public partial class Form1 : Form
    {
        //判断输入的为数字
        public  static bool IsNumber(string number)
        {
            return Regex.IsMatch(number, @"^[0-9]*$");
        }
        public List<Order> GetOrders = new List<Order>();
        public static OrderService  os = new OrderService();
        public List<OrderDetails> details = new List<OrderDetails>();
        public string  C
        {
            get;
            set;
        }
        public Form1()
        {
           
            GetOrders = os.orders;
            InitializeComponent();
            this.dataGridView1.DataError += delegate (object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e) { };//加上否则报错
        }
        //查询
        private void button2_Click(object sender, EventArgs e)
        {
            GetOrders = os.orders;
            List<Order> B = new List<Order>();
            if(GetOrders.Count()==0)
            {
                MessageBox.Show("当前没有订单！");
                return;
            }
               
            if (comboBox1.Text.Equals("客户名"))
            {
                var A = GetOrders.Where(a => a.Client.Equals(textBox1.Text));       
                if(A.Count()==0)
                {
                    MessageBox.Show("没有相关订单！");
                    return;
                }
                    orderBindingSource.DataSource = A;
                foreach (Order a in A)
                    B.Add(a);
                orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(B[0].MyOrder);

            }
            else if (comboBox1.Text.Equals("订单号"))
            {
                var A = GetOrders.Where(a => a.OrderId.Equals(textBox1.Text));
                if (A.Count() == 0)
                {
                    MessageBox.Show("没有相关订单！");
                    return;
                }
                orderBindingSource.DataSource = A;
                foreach (Order a in A)
                    B.Add(a);
                orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(B[0].MyOrder);

            }
            else if (comboBox1.Text.Equals("金额（小于指定￥）"))
            {
                var A = GetOrders.Where(a => a.sum<(Convert.ToInt32(textBox1.Text)));
                if (A.Count() == 0)
                {
                    MessageBox.Show("没有相关订单！");
                    return;
                }
                orderBindingSource.DataSource = A;
                foreach (Order a in A)
                    B.Add(a);
                orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(B[0].MyOrder);
            }       
            else if(comboBox1.Text.Equals("金额（大于指定￥）"))
            {
                var A = GetOrders.Where(a => a.sum > (Convert.ToInt32(textBox1.Text)));
                if (A.Count() == 0)
                {
                    MessageBox.Show("没有相关订单！");
                    return;
                }
                orderBindingSource.DataSource = A;
                foreach (Order a in A)
                    B.Add(a);
                orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(B[0].MyOrder);
            }
            else
            {
                MessageBox.Show("没有相关订单！");
            }
            
         }

        
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (os.orders.Count() == 0)
                return;
            
            int A = os.orders.FindIndex(a => a.OrderId.Equals(OrderId.Text));
          
            orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(os.orders[A].MyOrder);
            
        }

        private void Add_Click_1(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void Delete_Click_1(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void Show_Click_1(object sender, EventArgs e)
        {

            if (os.orders.Count() != 0)
            {
                orderBindingSource.DataSource = new BindingList<Order>(os.orders);
            }

            else
                MessageBox.Show("没有订单！");
        }

        private void Export_Click(object sender, EventArgs e)
        {
            try
            {
                os.Export();             
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Order.xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(@"./Order.xslt");

                FileStream outFileStream = File.OpenWrite(@"./Order.html");
                XmlTextWriter writer =
                    new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, writer);
                MessageBox.Show("成功！");               
            }
            catch (XmlException ea)
            {
                Console.WriteLine("XML Exception:" + ea.ToString());
            }
            catch (XsltException ea)
            {
                Console.WriteLine("XSLT Exception:" + ea.ToString());
            }
          
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
