using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new fmQuanLyNhanVien();
            form.MdiParent = this;
            form.Show();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                if (MessageBox.Show("bạn có muốn thoát ?", "Thoát", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                   
                    e.Cancel = false;
                    dangnhap obj = (dangnhap)Application.OpenForms["dangnhap"];
                    obj.Close();
                }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void quảnLýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fmQuanLyHoaDonNhap form = new fmQuanLyHoaDonNhap();
            form.MdiParent = this;
            form.Show();
        }

        private void quảnLýChiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmChiTietHoaDonNhap form = new fmChiTietHoaDonNhap();
            form.MdiParent = this;
            form.Show();
        }

       

        private void quảnLýHóaĐơnXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fmQuanLyHoaDonXuat form = new fmQuanLyHoaDonXuat();
            form.MdiParent = this;
            form.Show();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmChiTietHoaDonXuat form = new fmChiTietHoaDonXuat();
            form.MdiParent = this;
            form.Show();
        }

        private void quảnLýNhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmNhaXuatBan form = new fmNhaXuatBan();
            form.MdiParent = this;
            form.Show();
        }

        private void quảnLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmSach form = new fmSach();
            form.MdiParent = this;
            form.Show();
        }

        private void thốngKêNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmBaoCaoNhanVien form = new fmBaoCaoNhanVien();
            form.MdiParent = this;
            form.Show();
        }
    }
}
