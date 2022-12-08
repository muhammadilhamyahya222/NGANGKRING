using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private string[][] data_makanan;
        private string[][] data_minuman;

        private void Form3_Load(object sender, EventArgs e)
        {
            project project = new project();

            data_makanan = project.getdata("select * from menumakanan");
            data_minuman = project.getdata("select * from menuminuman");

            foreach (string[] i in data_makanan)
            {
                int indeks = dataGridView1.Rows.Add();
                DataGridViewRow dataGridViewRow0 = dataGridView1.Rows[indeks];

                dataGridViewRow0.Cells["Column1"].Value = i[1];
                comboBox1.Items.Add(i[1]);
                dataGridViewRow0.Cells["Column2"].Value = i[2];

            }
            foreach (string[] i in data_minuman)
            {
                int indeks = dataGridView2.Rows.Add();
                DataGridViewRow dataGridViewRow0 = dataGridView2.Rows[indeks];

                dataGridViewRow0.Cells["Column3"].Value = i[1];
                comboBox2.Items.Add(i[1]);
                dataGridViewRow0.Cells["Column4"].Value = i[2];
            }
        }


        private void tabel_pesanan(string kolommenu, string kolomqty, string klmharga, string box, string qty, string harga)
        {
            int indeks = dataGridView3.Rows.Add();
            DataGridViewRow dataGridViewRow0 = dataGridView3.Rows[indeks];

            dataGridViewRow0.Cells[kolommenu].Value = box;
            dataGridViewRow0.Cells[kolomqty].Value = qty;
            dataGridViewRow0.Cells[klmharga].Value = harga;
        }

        private void update_value(string? pilihan, string jenis_pesanan, string quantity, int total_harga_pilihan)
        {
            bool cek = true;

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (pilihan == Convert.ToString(dataGridView3.Rows[i].Cells[0].Value))
                {
                    total_harga_pilihan += Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);
                    int jumlah = Convert.ToInt32(quantity) + Convert.ToInt32(dataGridView3.Rows[i].Cells[1].Value);

                    dataGridView3.Rows[i].Cells[2].Value = total_harga_pilihan;
                    dataGridView3.Rows[i].Cells[1].Value = jumlah;
                    cek = true;
                    break;
                }
                else
                {
                    cek = false;
                }
            }
            if (cek == false)
            {
                tabel_pesanan("Column5", "Column6", "Column7", jenis_pesanan, quantity, Convert.ToString(total_harga_pilihan));
            }
            
        }

        private int total_harga;
        private int total_harga_makanan;
        private int total_harga_minuman;
        private int banyak_makanan;
        private int banyak_minuman;
        private void button2_Click(object sender, EventArgs e)
        {

            string? pilihan_makanan = Convert.ToString(comboBox1.SelectedItem);
            string? pilihan_minuman = Convert.ToString(comboBox2.SelectedItem);

            total_harga = 0;
            total_harga_makanan = 0;
            total_harga_minuman = 0;
            banyak_makanan = 0;
            banyak_minuman = 0;

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                banyak_makanan = Convert.ToInt32(textBox1.Text);
                banyak_minuman = Convert.ToInt32(textBox2.Text);
            }
            else if (textBox1.Text != "")
            {
                banyak_makanan = Convert.ToInt32(textBox1.Text);
            }
            else if (textBox2.Text != "")
            {
                banyak_minuman = Convert.ToInt32(textBox2.Text);
            }

            if (pilihan_makanan != "" && pilihan_minuman != "" && banyak_makanan > 0 && banyak_minuman > 0)
            {

                foreach (string[] i in data_makanan)
                {
                    if (i[1] == pilihan_makanan)
                    {
                        total_harga_makanan += Convert.ToInt32(i[2]) * banyak_makanan;
                    }
                }
                foreach (string[] i in data_minuman)
                {
                    if (i[1] == pilihan_minuman)
                    {
                        total_harga_minuman += Convert.ToInt32(i[2]) * banyak_minuman;
                    }
                }


                if (dataGridView3.Rows.Count > 1)
                {
                    update_value(pilihan_makanan, comboBox1.Text, textBox1.Text, total_harga_makanan);
                    update_value(pilihan_minuman, comboBox2.Text, textBox2.Text, total_harga_minuman);
                }
                else
                {
                    tabel_pesanan("Column5", "Column6", "Column7", comboBox1.Text, textBox1.Text, Convert.ToString(total_harga_makanan));
                    tabel_pesanan("Column5", "Column6", "Column7", comboBox2.Text, textBox2.Text, Convert.ToString(total_harga_minuman));
                }
            }

            else if (pilihan_makanan != "" && banyak_makanan > 0)
            {
                foreach (string[] i in data_makanan)
                {
                    if (i[1] == pilihan_makanan)
                    {
                        total_harga_makanan += Convert.ToInt32(i[2]) * banyak_makanan;
                    }
                }

                if (dataGridView3.Rows.Count > 1)
                {
                    update_value(pilihan_makanan, comboBox1.Text, textBox1.Text, total_harga_makanan);
                }
                else
                {
                    tabel_pesanan("Column5", "Column6", "Column7", comboBox1.Text, textBox1.Text, Convert.ToString(total_harga_makanan));
                }

            }
            else if (pilihan_minuman != "" && banyak_minuman > 0)
            {
                foreach (string[] i in data_minuman)
                {
                    if (i[1] == pilihan_minuman)
                    {
                        total_harga_minuman += Convert.ToInt32(i[2]) * banyak_minuman;
                    }
                }

                if (dataGridView3.Rows.Count > 1)
                {
                    update_value(pilihan_minuman, comboBox2.Text, textBox2.Text, total_harga_minuman);
                }
                else
                {
                    tabel_pesanan("Column5", "Column6", "Column7", comboBox2.Text, textBox2.Text, Convert.ToString(total_harga_minuman));
                }
                
            }
            else
            {
                MessageBox.Show("Masukkan pesanan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            comboBox1.ResetText();
            comboBox2.ResetText();
            pilihan_makanan = "";
            pilihan_minuman = "";
            textBox1.Clear();
            textBox2.Clear();
            
            for (int i=0; i < dataGridView3.Rows.Count; i++)
            {
                total_harga += Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);
            }
            listBox1.Items.Clear();
            listBox1.Items.Add(total_harga);
        }
        private void setdatapesanan(string nama, string? pesanan, int jumlah, int total, string status)
        {
            string query = $"insert into datapesananmakanan(nama_pelanggan, pesanan, jumlah, total_harga, status) values('{nama}', '{pesanan}', {jumlah}, {total}, 'proses')";

            project project = new project();
            project.getdata(query);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count != 0)
            {
                DialogResult dr = MessageBox.Show($"Jumlah yang harus dibayar sebanyak {listBox1.Items[0]}", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string nama = Form2.f2.tb1.Text;
                string status = "proses";


                for (int i = 0; i < dataGridView3.Rows.Count-1; i++)
                {
                    setdatapesanan(nama, Convert.ToString(dataGridView3.Rows[i].Cells[0].Value), Convert.ToInt32(dataGridView3.Rows[i].Cells[1].Value), Convert.ToInt32(listBox1.Items[0]), status);
                }

                if (dr == DialogResult.OK)
                {
                    Form4 endform = new Form4();
                    this.Hide();
                    endform.Show();
                }
            }
            else
            {
                MessageBox.Show("Masukkan pesanan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }
    }
}
