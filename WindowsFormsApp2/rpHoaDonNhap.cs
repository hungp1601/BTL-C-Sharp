using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class rpHoaDonNhap : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        public rpHoaDonNhap()
        {
            InitializeComponent();
        }

        private void rpHoaDonNhap_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from vDanhSachNhanVien", sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable  ds1 = new DataTable();
            da.Fill(ds1);
            CrystalReport1 rp = new CrystalReport1();
            rp.SetDataSource(ds1);
            crystalReportViewer1.ReportSource = rp;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from vDanhSachNhanVien where [Giới Tính] like'"+comboBox1.Text+"'", sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds1 = new DataTable();
            da.Fill(ds1);
            CrystalReport1 rp = new CrystalReport1();
            rp.SetDataSource(ds1);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
