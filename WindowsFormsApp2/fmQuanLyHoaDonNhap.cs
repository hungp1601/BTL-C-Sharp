using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class fmQuanLyHoaDonNhap : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        public fmQuanLyHoaDonNhap()
        {
            InitializeComponent();
        }
        void btnInitial()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
        }
        void btnChooseRow()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnIn.Enabled = true;
        }

        void btnDisabledAll()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;

        }
        void btnExisted()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnIn.Enabled = true;

        }

        void loadData()
        {
            string sql = "select * from vDanhSachHoaDonNhap";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            //dgvDSNhanVien.AutoGenerateColumns = false;

            dataadapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvDSHoaDonNhap.DataSource = ds.Tables[0];
            }
            connection.Close();
            SqlConnection conn = new SqlConnection(ConnectionString);
            ds = new DataSet();
            string SQL = "SELECT * FROM vDanhSachNhanVien";
            SqlDataAdapter sda = new SqlDataAdapter(SQL, conn);
            conn.Open();
            sda.Fill(ds);
            cbbMaNV.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbMaNV.DataSource = ds.Tables[0];
            cbbMaNV.DisplayMember = ds.Tables[0].Columns[0].ToString();
            conn.Close();
            btnInitial();

        }

        int Check_MaHDN()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from tblHoaDonNhap where sMaHDN = '" + txtMaHDN.Text + "'", sqlConnection);
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
            else if (Check_MaHDN() > 0)
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn thêm hóa đơn này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procThemHDN";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaHDN", SqlDbType.NVarChar, 10);
            param.Value = txtMaHDN.Text;

            param = cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 25);
            param.Value = cbbMaNV.Text;

            param = cmd.Parameters.Add("@NgayLap", SqlDbType.Date);
            param.Value = dtpNL.Value.ToString();

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
                MessageBox.Show("đã có hóa đơn này", "thông báo");

            }
            loadData();
            con.Close();
        }

        private void fmQuanLyHoaDonNhap_Load(object sender, EventArgs e)
        {
            loadData();

        }

        private void fmQuanLyHoaDonNhap_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtMaHD_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtMaHDN);
        }

        private void dgvDSHoaDonNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSHoaDonNhap.CurrentRow == null) return;
            btnChooseRow();

            txtMaHDN.Text = dgvDSHoaDonNhap.CurrentRow.Cells[0].Value.ToString();
            cbbMaNV.Text = dgvDSHoaDonNhap.CurrentRow.Cells[1].Value.ToString();
            txtTenNV.Text = dgvDSHoaDonNhap.CurrentRow.Cells[2].Value.ToString();
            if (dgvDSHoaDonNhap.CurrentRow.Index >= dgvDSHoaDonNhap.Rows.Count - 1)
            {
                dtpNL.Value = DateTime.Parse("01/01/2000");
                btnDisabledAll();
            }
            else
                dtpNL.Value = DateTime.Parse(dgvDSHoaDonNhap.CurrentRow.Cells[3].Value.ToString());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn sửa hóa đơn này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procSuaHDN";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaHDN", SqlDbType.NVarChar, 10);
            param.Value = txtMaHDN.Text;

            param = cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 25);
            param.Value = cbbMaNV.Text;

            param = cmd.Parameters.Add("@NgayLap", SqlDbType.Date);
            param.Value = dtpNL.Value.ToString();

            con.Open();
            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("sửa thành công", "thông báo");
                    btnChooseRow();
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
            string SQL = "procXoaHDN";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaHDN", SqlDbType.NVarChar, 10);
            param.Value = txtMaHDN.Text;


            con.Open();
            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("xóa thành công", "thông báo");
                    btnChooseRow();
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

        private void cbbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Check_MaHDN() > 0)
            {
                btnExisted();
            }
            else
            {
                btnInitial();
            }
            string manv = cbbMaNV.Text;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select sTenNV from tblNhanVien where sMaNV = '" + manv + "'", sqlConnection);

            string i = (string)cmd.ExecuteScalar();
            txtTenNV.Text = i;

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            
            fmHoadonnhap form = new fmHoadonnhap(txtMaHDN.Text);
            form.Show();
        }
    }
}

