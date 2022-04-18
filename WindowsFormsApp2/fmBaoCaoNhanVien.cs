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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;

namespace WindowsFormsApp2
{
    public partial class fmBaoCaoNhanVien : Form
    {

        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString").ToString();
        public fmBaoCaoNhanVien()
        {
            InitializeComponent();
        }

        private void fmBaoCaoNhanVien_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand("select * from vDanhSachNhanVien", connection);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "vDanhSachNhanVien");
            rpNhanVien rpt = new rpNhanVien();
            rpt.SetDataSource(ds);
            Crystalreportviewer.ReportSource = rpt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from vDanhSachNhanVien where sTenNV like N'%"
                + txtTen.Text + "%' and [Giới tính] like N'%"+
                cbbGT.Text + "%' and [Địa chỉ] like '%"+txtDC.Text + "%'";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand(sql, connection);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "vDanhSachNhanVien");
            rpNhanVien rpt = new rpNhanVien();
            rpt.SetDataSource(ds);
            Crystalreportviewer.ReportSource = rpt;

        }
    }
}
