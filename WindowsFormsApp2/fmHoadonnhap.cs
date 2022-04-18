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
    public partial class fmHoadonnhap : Form
    {
        string mahd;
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString").ToString();
        public fmHoadonnhap(string mahdn)
        {
            InitializeComponent();
            mahd = mahdn;
        }
        private void fmHoadonnhap_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand("select * from vHoadonnhap where sMaHDN='"+mahd+"'", connection);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "vHoadonnhap");
            rpHoadonnhap rpt = new rpHoadonnhap();
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
