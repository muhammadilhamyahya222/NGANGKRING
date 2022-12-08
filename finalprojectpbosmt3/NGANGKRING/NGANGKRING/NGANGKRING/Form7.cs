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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        private string query_tambah;
        private string query_update;
        private string query_delete;
        private string tabel_menu;
        private void section_loaddata()
        {
            comboBox2.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
        }
        private void section_tambahdata()
        {
            comboBox2.Show();
            textBox1.Hide();
            button2.Hide();
            button3.Hide();
            textBox2.Show();
            textBox3.Show();
            button1.Show();
            label2.Show();
            label3.Hide();
            label4.Show();
            label5.Show();
        }

        private void section_updatedata()
        {
            comboBox2.Show();
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            button2.Show();
            button1.Hide();
            button3.Hide();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
        }
        private void section_deletedata()
        {
            comboBox2.Show();
            textBox1.Show();
            textBox2.Hide();
            textBox3.Hide();
            button1.Hide();
            button2.Hide();
            button3.Show();
            label2.Show();
            label3.Show();
            label4.Hide();
            label5.Hide();
        }
        private void reload()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            comboBox2.ResetText();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            loadata();
        }
        private void loadata()
        {
            project project = new project();

            string[][] data_makanan = project.getdata("select * from menumakanan");
            string[][] data_minuman = project.getdata("select * from menuminuman");

            foreach (string[] i in data_makanan)
            {
                int indeks = dataGridView1.Rows.Add();
                DataGridViewRow dataGridViewRow0 = dataGridView1.Rows[indeks];

                dataGridViewRow0.Cells["Column1"].Value = i[0];
                dataGridViewRow0.Cells["Column2"].Value = i[1];
                dataGridViewRow0.Cells["Column3"].Value = i[2];

            }
            foreach (string[] i in data_minuman)
            {
                int indeks = dataGridView2.Rows.Add();
                DataGridViewRow dataGridViewRow0 = dataGridView2.Rows[indeks];

                dataGridViewRow0.Cells["Column4"].Value = i[0];
                dataGridViewRow0.Cells["Column5"].Value = i[1];
                dataGridViewRow0.Cells["Column6"].Value = i[2];
            }
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            loadata();
            section_loaddata();

        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Tambah")
            {
                section_tambahdata();
            }
            else if (comboBox1.Text == "Update")
            {
                section_updatedata();
            }
            else if (comboBox1.Text == "Hapus")
            {
                section_deletedata();
            }
        }
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Makanan")
            {
                tabel_menu = "menumakanan";
            }
            else if (comboBox2.Text == "Minuman")
            {
                tabel_menu = "menuminuman";
            }
            else
            {
                tabel_menu = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "" || comboBox2.Text != "Pilih Jenis Menu")
                {
                    query_tambah = $"insert into {tabel_menu} (nama_{comboBox2.Text}, harga_{comboBox2.Text}) values('{textBox2.Text}','{Convert.ToInt32(textBox3.Text)}')";

                    project project = new project();
                    project.getdata(query_tambah);

                    MessageBox.Show("Data berhasil ditambahkan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reload();
                }
                else
                {
                    MessageBox.Show("Pilih jenis menu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Isi data menu dengan benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "" || comboBox2.Text != "Pilih Jenis Menu")
                {
                    query_update = $"update {tabel_menu} set nama_{comboBox2.Text}='{textBox2.Text}', harga_{comboBox2.Text}={textBox3.Text} where id={textBox1.Text}";

                    project project = new project();
                    project.getdata(query_update);

                    MessageBox.Show("Data berhasil diupdate", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reload();
                }
                else
                {
                    MessageBox.Show("Pilih jenis menu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Isi data menu dengan benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "" || comboBox2.Text != "Pilih Jenis Menu")
                {
                    query_delete = $"delete from {tabel_menu} where id={Convert.ToInt32(textBox1.Text)}";

                    project project = new project();
                    project.getdata(query_delete);

                    MessageBox.Show("Data berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reload();
                }
                else
                {
                    MessageBox.Show("Pilih jenis menu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Isi data menu dengan benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            this.Hide();
            form9.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Hide();
            form5.Show();
        }
    }
}
