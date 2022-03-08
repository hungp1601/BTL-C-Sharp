using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class fmQuanLyNhanVien : Form
    {
        string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

        public fmQuanLyNhanVien()
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

        void Check_Empty_String(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                errorProvider1.SetError(textBox, "Không được để trống");
                btnDisabledAll();
            }
            else if (Check_MaNV() > 0)
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
        int Check_MaNV()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from tblNhanVien where sMaNV = '" + txtMaNV.Text + "'", sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            int i = ds1.Tables[0].Rows.Count;
            sqlConnection.Close();
            return i;
        }

        void loadData()
        {
            string sql = "select * from vDanhSachNhanVien";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            //dgvDSNhanVien.AutoGenerateColumns = false;
            dgvDSNhanVien.ReadOnly = true;
            dataadapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvDSNhanVien.DataSource = ds.Tables[0];
            }
            connection.Close();
            btnInitial();

        }
        private void fmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void fmQuanLyNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvDSNhanVien_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDSNhanVien.CurrentRow == null) return;

            btnChooseRow();

            txtMaNV.Text = dgvDSNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dgvDSNhanVien.CurrentRow.Cells[1].Value.ToString();
            if (dgvDSNhanVien.CurrentRow.Cells[3].Value.ToString() == "Nam")
            {
                rtNam.Checked = true;
                rtNu.Checked = false;
            }
            else
            {
                rtNam.Checked = false;
                rtNu.Checked = true;
            }
            txtDC.Text = dgvDSNhanVien.CurrentRow.Cells[4].Value.ToString();
            txtSDT.Text = dgvDSNhanVien.CurrentRow.Cells[5].Value.ToString();
            txtHSL.Text = dgvDSNhanVien.CurrentRow.Cells[6].Value.ToString();
            txtPC.Text = dgvDSNhanVien.CurrentRow.Cells[7].Value.ToString();
            if (dgvDSNhanVien.CurrentRow == null ||
                dgvDSNhanVien.CurrentRow.Index >= dgvDSNhanVien.Rows.Count - 1)
            {
                txtMaNV.Focus();
                dtpNVL.Value = DateTime.Parse("01/01/2000");
                btnDisabledAll();
            }
            else
                dtpNVL.Value = DateTime.Parse(dgvDSNhanVien.CurrentRow.Cells[9].Value.ToString());
            if (dgvDSNhanVien.CurrentRow == null ||
                dgvDSNhanVien.CurrentRow.Index >= dgvDSNhanVien.Rows.Count - 1)
            {
                dtpNgaysinh.Value = DateTime.Parse("01/01/2000");
                btnDisabledAll();
            }
            else
                dtpNgaysinh.Value = DateTime.Parse(dgvDSNhanVien.CurrentRow.Cells[2].Value.ToString());


        }

        private void txtMaNV_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtMaNV);
        }

        private void txtTenNV_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtTenNV);
        }

        private void txtDC_Validating(object sender, CancelEventArgs e)
        {
            Check_Empty_String(txtDC);
        }

        private void txtSDT_Validating(object sender, CancelEventArgs e)
        {

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from tblNhanVien where sMaNV <> '" + txtMaNV.Text + "' and sSDT='" + txtSDT.Text
               + "'", sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            int i = ds1.Tables[0].Rows.Count;
            sqlConnection.Close();
            if (i > 0)
            {
                errorProvider1.SetError(txtSDT, "Không được trùng số điện thoại");
                btnDisabledAll();
                return;
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");

            }
            Check_Empty_String(txtDC);
        }

        private void txtHSL_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                float hsl = float.Parse(txtHSL.Text);
                if (hsl <= 0)
                {
                    errorProvider1.SetError(txtHSL, "Số phải lớn hơn không");
                    btnDisabledAll();
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtHSL, "");

                }
            }
            catch
            {
                errorProvider1.SetError(txtHSL, "Số không hợp lệ");
                btnDisabledAll();
                return;
            }
            Check_Empty_String(txtHSL);
        }

        private void txtPC_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                float hsl = float.Parse(txtPC.Text);
                if (hsl <= 0)
                {
                    errorProvider1.SetError(txtPC, "Số phải lớn hơn không");
                    btnDisabledAll();
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtPC, "");

                }
            }
            catch
            {
                errorProvider1.SetError(txtPC, "Số không hợp lệ");
                btnDisabledAll();
                return;
            }
            Check_Empty_String(txtPC);
        }

        private void dtpNVL_Validating(object sender, CancelEventArgs e)
        {
            if (dtpNVL.Value > DateTime.Today)
            {

                btnDisabledAll();
                errorProvider1.SetError(dtpNVL, "Ngày vào làm không hợp lệ");
            }
            else
            {
                if (Check_MaNV() > 0)
                {
                    errorProvider1.SetError(dtpNVL, "");
                    btnExisted();
                }
                else
                {
                    errorProvider1.SetError(dtpNVL, "");
                    btnInitial();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn thêm nhân viên này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procThemNhanVien";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 10);
            param.Value = txtMaNV.Text;

            param = cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar, 25);
            param.Value = txtTenNV.Text;


            param = cmd.Parameters.Add("@Ngaysinh", SqlDbType.Date);
            param.Value = dtpNgaysinh.Value.ToString();


            param = cmd.Parameters.Add("@Gioitinh", SqlDbType.Bit);
            if (rtNam.Checked == true)
            {

                param.Value = 1;
            }
            else param.Value = 0;

            param = cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar, 255);
            param.Value = txtDC.Text;

            param = cmd.Parameters.Add("@SDT", SqlDbType.NVarChar, 10);
            param.Value = txtSDT.Text;

            param = cmd.Parameters.Add("@HSL", SqlDbType.Float);
            param.Value = float.Parse(txtHSL.Text);

            param = cmd.Parameters.Add("@PC", SqlDbType.Float);
            param.Value = float.Parse(txtPC.Text);

            param = cmd.Parameters.Add("@Ngayvaolam", SqlDbType.Date);
            param.Value = dtpNVL.Value.ToString();

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn sửa thông tin của nhân viên này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procSuaNhanVien";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 10);
            param.Value = txtMaNV.Text;

            param = cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar, 25);
            param.Value = txtTenNV.Text;

            param = cmd.Parameters.Add("@Gioitinh", SqlDbType.Bit);
            if (rtNam.Checked == true)
            {

                param.Value = 1;
            }
            else param.Value = 0;

            param = cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar, 255);
            param.Value = txtDC.Text;

            param = cmd.Parameters.Add("@Ngaysinh", SqlDbType.Date);
            param.Value = dtpNgaysinh.Value.ToString();

            param = cmd.Parameters.Add("@SDT", SqlDbType.NVarChar, 10);
            param.Value = txtSDT.Text;

            param = cmd.Parameters.Add("@HSL", SqlDbType.Float);
            param.Value = float.Parse(txtHSL.Text);

            param = cmd.Parameters.Add("@PC", SqlDbType.Float);
            param.Value = float.Parse(txtPC.Text);

            param = cmd.Parameters.Add("@Ngayvaolam", SqlDbType.Date);
            param.Value = dtpNVL.Value.ToString();

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
            if (MessageBox.Show("bạn có muốn xóa nhân viên này ?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string SQL = "procXoaNhanVien";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 10);
            param.Value = txtMaNV.Text;


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

        private void txtTim_TextChanged(object sender, EventArgs e)
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

