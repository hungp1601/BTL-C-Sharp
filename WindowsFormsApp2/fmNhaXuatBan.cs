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
    public partial class fmNhaXuatBan : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        public fmNhaXuatBan()
        {
            InitializeComponent();
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtSDT.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != '.')
            {
                e.Handled = true;
            }
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
            SqlCommand cmd = new SqlCommand("select * from tblnxb " +
                "where sMaNXB= '" +txtMaNXB.Text + "'", sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            int i = ds1.Tables[0].Rows.Count;
            sqlConnection.Close();
            return i;
        }

        void Check_Empty_String(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                errorProvider1.SetError(textBox, "Không được để trống");
                btnDisabledAll();
            }
            else if (Check_unique() > 0)
            {
                errorProvider1.SetError(textBox, "");
                btnExisted();
            }
            else
            {
                errorProvider1.SetError(textBox, "");
                btnInitial();
            }
        }

        void loadData()
        {
            string sql = "select * from tblNXB";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            //dgvDSNhanVien.AutoGenerateColumns = false;

            dataadapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvDanhSachHDN.DataSource = ds.Tables[0];
            }
            connection.Close();

        }

        private void fmNhaXuatBan_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvDanhSachHDN_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachHDN.CurrentRow == null) return;
            btnChooseRow();

            txtMaNXB.Text = dgvDanhSachHDN.CurrentRow.Cells[0].Value.ToString();
            txtTenNXB.Text = dgvDanhSachHDN.CurrentRow.Cells[1].Value.ToString();
            txtSDT.Text = dgvDanhSachHDN.CurrentRow.Cells[2].Value.ToString();
            txtDC.Text = dgvDanhSachHDN.CurrentRow.Cells[3].Value.ToString();
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn thêm nhà xuất bản này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "them_NXB";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.AddWithValue("@MaNXB", txtMaNXB.Text);

            param = cmd.Parameters.AddWithValue("@TenNXB",txtTenNXB.Text);

            param = cmd.Parameters.AddWithValue("@SDT",txtSDT.Text);

            param = cmd.Parameters.AddWithValue("@DC", txtDC.Text);

            con.Open();



            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("thêm thành công", "thông báo");
                }
                else
                {
                    MessageBox.Show("thêm thất bại", "thông báo");
                }
            }
            catch
            {
                MessageBox.Show("không thể thêm", "thông báo");
            }

            con.Close();
            loadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn sửa nhà xuất bản này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "proc_sua_NXB";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.AddWithValue("@MaNXB", txtMaNXB.Text);

            param = cmd.Parameters.AddWithValue("@TenNXB", txtTenNXB.Text);

            param = cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);

            param = cmd.Parameters.AddWithValue("@DC", txtDC.Text);


            con.Open();
            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();


                if (rowsAffected > 0)
                {
                    MessageBox.Show("sửa thành công", "thông báo");
                }
                else
                {
                    MessageBox.Show("sửa thất bại", "thông báo");
                }
            }
            catch
            {
                MessageBox.Show("không thể sửa", "thông báo");
            }
            con.Close();

            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn xóa hóa đơn này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "xoa_NXB";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.AddWithValue("@MaNXB", txtMaNXB.Text);

            con.Open();


            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("xóa thành công", "thông báo");
                }
                else
                {
                    MessageBox.Show("xóa thất bại", "thông báo");
                }
            }
            catch
            {
                MessageBox.Show("không thể xóa", "thông báo");
            }

            con.Close();
            loadData();
        }

        private void txtMaNXB_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtMaNXB);
        }

        private void txtTenNXB_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtTenNXB);
        }

        private void txtSDT_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtSDT);
        }

        private void txtDC_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtDC);
        }
    }
}
