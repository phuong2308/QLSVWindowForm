using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Repository;

namespace Test
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        UserRepository userRepository = new UserRepository();

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (userRepository.GetUserForLogin(txtTenDangNhap.Text,txtMatKhau.Text) != null)
            {
                MessageBox.Show("Login Successful","Nontification",MessageBoxButtons.OK,MessageBoxIcon.Information);
                FormChinh formChinh = new FormChinh();
                this.Hide();
                formChinh.ShowDialog();              
            }
            else
            {
                MessageBox.Show("Login Failed","Nontification",MessageBoxButtons.OK,MessageBoxIcon.Error);
                XoaTrangThongTin();
                txtTenDangNhap.Focus();
            }        
        }

        void XoaTrangThongTin()
        {
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
