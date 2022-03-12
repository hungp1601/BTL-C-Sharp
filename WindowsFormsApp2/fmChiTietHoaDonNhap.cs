using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class fmChiTietHoaDonNhap : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        public fmChiTietHoaDonNhap()
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
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtSL.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void txtDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtDG.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        void loadData()
        {
            string sql = "select * from vDanhSachChiTietHoaDonNhap";
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
            string SQL = "SELECT * FROM tblSach";
            SqlDataAdapter sda = new SqlDataAdapter(SQL, conn);
            conn.Open();
            sda.Fill(ds);
            cbbSach.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSach.DataSource = ds.Tables[0];
            cbbSach.DisplayMember = ds.Tables[0].Columns[0].ToString();

            ds = new DataSet();
            SQL = "SELECT * FROM tblHoaDonNhap";
            sda = new SqlDataAdapter(SQL, conn);

            sda.Fill(ds);
            cbbMaHD.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbMaHD.DataSource = ds.Tables[0];
            cbbMaHD.DisplayMember = ds.Tables[0].Columns[0].ToString();
            conn.Close();

        }
        private void fmChiTietHoaDonNhap_Load(object sender, EventArgs e)
        {
            loadData();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn thêm hóa đơn này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "proc_ThemChiTietHDN";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.AddWithValue("@MaHDN", cbbMaHD.Text);

            param = cmd.Parameters.AddWithValue("@Masach", cbbSach.Text);

            param = cmd.Parameters.AddWithValue("@SL", int.Parse(txtSL.Text));

            param = cmd.Parameters.AddWithValue("@DGmua", float.Parse(txtDG.Text));

            con.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("thêm thành công", "thông báo");
            }
            else
            {
                MessageBox.Show("thêm thất bại", "thông báo");
            }
            loadData();
        }

        private void dgvDanhSachHDN_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDanhSachHDN.CurrentRow == null) return;
            btnChooseRow();

            cbbMaHD.Text = dgvDanhSachHDN.CurrentRow.Cells[0].Value.ToString();
            cbbSach.Text = dgvDanhSachHDN.CurrentRow.Cells[1].Value.ToString();
            txtSach.Text = dgvDanhSachHDN.CurrentRow.Cells[2].Value.ToString();
            txtSL.Text = dgvDanhSachHDN.CurrentRow.Cells[3].Value.ToString();
            txtDG.Text = dgvDanhSachHDN.CurrentRow.Cells[4].Value.ToString();
        }

        private void cbbSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Check_unique() > 0)
            {
                btnExisted();
            }
            else
            {
                btnInitial();
            }
            string manv = cbbSach.Text;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select sTensach from tblSach where sTenSach = '" + manv + "'", sqlConnection);

            string i = (string)cmd.ExecuteScalar();
            txtSach.Text = i;
        }

        private void cbbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Check_unique() > 0)
            {
                btnExisted();
            }
            else
            {
                btnInitial();
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn sửa hóa đơn này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "proc_SuaChiTietHDN";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.AddWithValue("@MaHDN", cbbMaHD.Text);

            param = cmd.Parameters.AddWithValue("@Masach", cbbSach.Text);

            param = cmd.Parameters.AddWithValue("@SL", int.Parse(txtSL.Text));

            param = cmd.Parameters.AddWithValue("@DGmua", float.Parse(txtDG.Text));

            con.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("sửa thành công", "thông báo");
            }
            else
            {
                MessageBox.Show("sửa thất bại", "thông báo");
            }
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn xóa hóa đơn này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "proc_XoaChiTietHDN";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.AddWithValue("@MaHDN", cbbMaHD.Text);

            param = cmd.Parameters.AddWithValue("@Masach", cbbSach.Text);

            con.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("xóa thành công", "thông báo");
            }
            else
            {
                MessageBox.Show("xóa thất bại", "thông báo");
            }
            loadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from vDanhSachChiTietHoaDonNhap where sMaHDN like '%" + textBox1.Text
                + "%' or sMaSach like '%" + textBox1.Text + "%' or [Ten sach] like N'%" + textBox1.Text + "%'";
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
            btnInitial();
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

        private void txtSL_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtSL);
        }

        private void txtDG_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtDG);
        }
    }
}
