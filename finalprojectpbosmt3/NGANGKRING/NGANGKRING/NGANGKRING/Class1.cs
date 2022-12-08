using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGANGKRING
{
    internal abstract class sql
    {
        protected NpgsqlConnection connect;

        internal sql()
        {
            string dbconnect = "Host=localhost;Database=menu;username=postgres;password=y_271002";
            connect = new NpgsqlConnection(dbconnect);
        }
    }

    internal class project : sql
    {
        internal string[][] getdata(string query)
        {
            List<string[]> list = new List<string[]>();

            connect.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nama = reader.GetString(1);
                int harga = reader.GetInt32(2);

                list.Add(new string[]{Convert.ToString(id), nama, Convert.ToString(harga)});
            }
            connect.Close();
            return list.ToArray();
        }

        internal string[][] getdatapesanan(string query)
        {
            List<string[]> list = new List<string[]>();

            connect.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nama = reader.GetString(1);
                string pesanan = reader.GetString(2);
                int jumlah = reader.GetInt32(3);
                int pesanan0 = reader.GetInt32(4);
                string status = reader.GetString(5);


                list.Add(new string[] { Convert.ToString(id), nama, pesanan, Convert.ToString(jumlah), Convert.ToString(pesanan0), status});
            }
            connect.Close();
            return list.ToArray();
        }
    }
}
