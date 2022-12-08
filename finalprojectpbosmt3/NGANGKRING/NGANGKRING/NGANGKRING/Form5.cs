using System;
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Form7 form7 = new Form7();
                this.Hide();
                form7.Show();
            }
            else
            {
                if (textBox2.Text != "")
                {
                    MessageBox.Show("Masukkan username", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(textBox1.Text != "")
                {
                    MessageBox.Show("Masukkan password", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Masukkan username dan password", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
