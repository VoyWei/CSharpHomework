using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals(""))
            {
                MessageBox.Show("请输入您的删除目标！");
                return;
            }
            if (Form1.os.orders.Exists(a => a.Client.Equals(textBox1.Text))&&comboBox1.Text.Equals("客户名"))
            {
                Form1.os.DeleteByCliend(textBox1.Text);
                MessageBox.Show("删除成功！");
            }
            else if(Form1.os.orders.Exists(a => a.OrderId==(Convert.ToInt32(textBox1.Text))) && comboBox1.Text.Equals("订单号"))
            {
                Form1.os.DeleteById(Convert.ToInt32(textBox1.Text));
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("没有此订单！");
                return;
            }
            this.Close();
        }
    }
}
