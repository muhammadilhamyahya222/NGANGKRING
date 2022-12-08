﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANGKRING
{
    public partial class Form2 : Form
    {
        public static Form2 f2;
        public TextBox tb1;
        public Form2()
        {
            InitializeComponent();
            f2 = this;
            tb1 = textBox1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Form3 form3 = new Form3();
                this.Hide();
                form3.Show();
            }
            else
            {
                MessageBox.Show("Masukkan nama pelanggan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
