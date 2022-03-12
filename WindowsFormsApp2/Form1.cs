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
                else e.Cancel = false;
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

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpHoaDonNhap form = new rpHoaDonNhap();
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
    }
}
