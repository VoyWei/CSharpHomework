﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(this.textBox1.Text.Trim());
            int j = Convert.ToInt32(this.textBox2.Text.Trim());
            int ji = i * j;
            this.label2.Text = ji.ToString();
        }
    }

}
