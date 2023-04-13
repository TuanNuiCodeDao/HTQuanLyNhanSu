using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HTQuanLyNhanSu.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }
        private string connectionStr = "Data Source=DESKTOP-LRLPN55;Initial Catalog=DataQLNS;Integrated Security=True";
        private DataProvider()
        {

        }
        public string getDateSql(DateTime d)
        {
            string dSql = d.Year + "-" + d.Month + "-" + d.Day;
            return dSql;
        }
        public string getDinhDanhHangNghin(int i)
        {
            return String.Format("{0:###,###,##0}", i);
        }
        public DataTable RunQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi");
            }
            return data;
        }
    }
}

