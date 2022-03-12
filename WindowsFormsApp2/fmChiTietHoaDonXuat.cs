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
    public partial class fmChiTietHoaDonXuat : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        public fmChiTietHoaDonXuat()
        {
            InitializeComponent();
        }

        

        void btnInitial()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        void btnChooseRow()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        void btnDisabledAll()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        }
        void btnExisted()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

        }
        int Check_unique()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from vDanhSachChiTietHoaDonNhap " +
                "where sMaHDN = '" + cbbMaHD.Text + "' and smasach='" + cbbSach.Text + "'", sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            int i = ds1.Tables[0].Rows.Count;
            sqlConnection.Close();
            return i;
        }

        private void fmChiTietHoaDonXuat_Load(object sender, EventArgs e)
        {

        }
    }
}
