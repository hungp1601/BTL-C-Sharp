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
    public partial class fmSach : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString").ToString();

        public fmSach()
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
            SqlCommand cmd = new SqlCommand("select * from vDanhSachSach " +
                "where sMaSach = '" + txtMaSach.Text+ "'" , sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            int i = ds1.Tables[0].Rows.Count;
            sqlConnection.Close();
            return i;
        }

        void loadData()
        {
            string sql = "select * from vDanhSachSach";
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
            SqlConnection conn = new SqlConnection(ConnectionString);
            ds = new DataSet();
            string SQL = "SELECT * FROM tblNXB";
            SqlDataAdapter sda = new SqlDataAdapter(SQL, conn);
            conn.Open();

            sda.Fill(ds);
            cbbNXB.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbNXB.DataSource = ds.Tables[0];
            cbbNXB.DisplayMember = ds.Tables[0].Columns[1].ToString();

            conn.Close();

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



        private void fmSach_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvDanhSachHDN_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachHDN.CurrentRow == null) return;
            btnChooseRow();

            txtMaSach.Text = dgvDanhSachHDN.CurrentRow.Cells[0].Value.ToString();
            txtTenSach.Text = dgvDanhSachHDN.CurrentRow.Cells[1].Value.ToString();
            cbbNXB.Text = dgvDanhSachHDN.CurrentRow.Cells[3].Value.ToString();
            txtTheLoai.Text = dgvDanhSachHDN.CurrentRow.Cells[5].Value.ToString();
            txtTG.Text = dgvDanhSachHDN.CurrentRow.Cells[4].Value.ToString();
        }

        private void cbbNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Check_unique() > 0)
            {
                btnExisted();
            }
            else
            {
                btnInitial();
            }
            /**/
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn thêm cuốn sách này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "them_sach";

            string tennxb = cbbNXB.Text;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd1 = new SqlCommand("select sMaNXB from tblNXB where sTenNXB = N'" + tennxb + "'", sqlConnection);

            string manxb = (string)cmd1.ExecuteScalar();
            sqlConnection.Close();

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.AddWithValue("@Masach", txtMaSach.Text);

            param = cmd.Parameters.AddWithValue("@Tensach", txtTenSach.Text);

            param = cmd.Parameters.AddWithValue("@MaNXB", manxb);

            param = cmd.Parameters.AddWithValue("@Tacgia", txtTG.Text);

            param = cmd.Parameters.AddWithValue("@TheLoai", txtTheLoai.Text);

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
                MessageBox.Show("thêm thất bại", "thông báo");
            }
            con.Close();
            loadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn sửa cuốn sách này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "sua_sach";

            string tennxb = cbbNXB.Text;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd1 = new SqlCommand("select sMaNXB from tblNXB where sTenNXB = N'" + tennxb + "'", sqlConnection);

            string manxb = (string)cmd1.ExecuteScalar();
            sqlConnection.Close();

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.AddWithValue("@Masach", txtMaSach.Text);

            param = cmd.Parameters.AddWithValue("@Tensach", txtTenSach.Text);

            param = cmd.Parameters.AddWithValue("@MaNXB", manxb);

            param = cmd.Parameters.AddWithValue("@Tacgia", txtTG.Text);

            param = cmd.Parameters.AddWithValue("@TheLoai", txtTheLoai.Text);

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
                MessageBox.Show("sửa thất bại", "thông báo");
            }
            con.Close();
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn xóa cuốn sách này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "xoa_sach";


            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.AddWithValue("@Masach", txtMaSach.Text);


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
                MessageBox.Show("xóa thất bại", "thông báo");
            }
            con.Close();
            loadData();
        }

        private void txtMaSach_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtMaSach);
        }

        private void txtTenSach_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtTenSach);
        }

        private void txtTG_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtTG);
        }

        private void txtTheLoai_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtTheLoai);
        }

        private void fmSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("bạn có muốn thoát ?", "Thoát", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else e.Cancel = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from vDanhSachNhanVien where sTenNV like N'%" + txtTim.Text
                + "%' or [Mã Nhân Viên] like '%" + txtTim.Text + "%' or [số điện thoại] like '%" + txtTim.Text + "%'";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            //dgvDSNhanVien.AutoGenerateColumns = false;

            dataadapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvDSNhanVien.DataSource = ds.Tables[0];
            }
            connection.Close();
            btnInitial();
        }
    }
}
