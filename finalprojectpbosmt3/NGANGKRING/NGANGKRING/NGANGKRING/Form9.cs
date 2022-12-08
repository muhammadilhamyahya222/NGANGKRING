using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NGANGKRING
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        
        private string? datapesanan_update;
        private string[][] datapesanan;

        private void loaddata()
        {
            project project = new project();
            datapesanan = project.getdatapesanan("select * from datapesananmakanan");

            foreach (string[] i in datapesanan)
            {
                int indeks = dataGridView1.Rows.Add();
                DataGridViewRow dataGridViewRow0 = dataGridView1.Rows[indeks];

                dataGridViewRow0.Cells["Column1"].Value = i[0];
                dataGridViewRow0.Cells["Column2"].Value = i[1];
                dataGridViewRow0.Cells["Column3"].Value = i[2];
                dataGridViewRow0.Cells["Column4"].Value = i[3];
                dataGridViewRow0.Cells["Column5"].Value = i[4];
                dataGridViewRow0.Cells["Column6"].Value = i[5];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            this.Hide();
            form7.Show();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i=0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) == textBox1.Text)
                {
                    datapesanan_update = $"update datapesananmakanan set status='selesai' where id={textBox1.Text}";
                    project project = new project();
                    project.getdata(datapesanan_update);
                }
            }
            dataGridView1.Rows.Clear();
            textBox1.Clear();
            loaddata();
        }
    }
}
