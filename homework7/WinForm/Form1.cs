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
    public partial class Form1 : Form
    {
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
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

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
                var A = GetOrders.Where(a => a.OrderId==(Convert.ToInt32(textBox1.Text)));
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (os.orders.Count() != 0)
            {                
                orderBindingSource.DataSource = new BindingList<Order>(os.orders);           
            }
            
            else
                MessageBox.Show("没有订单！");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (os.orders.Count() == 0)
                return;
            
            int A = os.orders.FindIndex(a => a.OrderId.ToString().Equals(label1.Text));
          
            orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(os.orders[A].MyOrder);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
