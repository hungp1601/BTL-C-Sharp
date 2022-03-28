using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text=="admin" && txtPassword.Text == "hung12")
            {
                //this.Close();
                Hide();
                Form1 form = new Form1();
                form.Show();
               
               
            }
            else
            {
                MessageBox.Show("sai tên đăng nhập hoặc mật khẩu", "thông báo");
            }
        }

        private void hienmk_CheckedChanged(object sender, EventArgs e)
        {
            if (hienmk.Checked == true)
            {
                txtPassword.PasswordChar = '\0';
            }
            else txtPassword.PasswordChar = '*';

        }
    }
}
