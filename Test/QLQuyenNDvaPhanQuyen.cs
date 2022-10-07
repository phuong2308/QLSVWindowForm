using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Repository;

namespace Test
{
    public partial class frmQLQuyenNDvaPhanQuyen : Form
    {
        public frmQLQuyenNDvaPhanQuyen()
        {
            InitializeComponent();
        }

        UserRepository userRepository = new UserRepository();
        RoleRepository roleRepository = new RoleRepository();
        string currentUser = null;

        bool KiemTraDuLieu()
        {
            checkDuLieu.SetError(txtMaNguoiDung, "");
            checkDuLieu.SetError(txtTenNguoiDung, "");
            checkDuLieu.SetError(txtMatKhau, "");
            checkDuLieu.SetError(txtHoTen, "");
            checkDuLieu.SetError(txtDiaChi, "");
            checkDuLieu.SetError(txtDienThoai, "");

            if (txtMaNguoiDung.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtMaNguoiDung, "UserID can not be empty");
                txtMaNguoiDung.Focus();
                return false;
            }
            if (txtTenNguoiDung.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtTenNguoiDung, "User Name can not be empty");
                txtTenNguoiDung.Focus();
                return false;
            }
            if (txtMatKhau.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtMatKhau, "User Password can not be empty");
                txtMatKhau.Focus();
                return false;
            }          
            if (txtHoTen.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtHoTen, "User FullName can not be empty");
                txtHoTen.Focus();
                return false;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtDiaChi, "User Address can not be empty");
                txtDiaChi.Focus();
                return false;
            }
            if (txtDienThoai.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtDienThoai, "User Phone can not be empty");
                txtDienThoai.Focus();
                return false;
            }
            return true;
        }

        void LoadComboBox()
        {
            cbQuyen.DataSource = roleRepository.GetAllRole();
            cbQuyen.DisplayMember = "RoleName";
            cbQuyen.ValueMember = "RoleID";
        }

        void LayDuLieu()
        {
            dgvNDvaPQ.DataSource = userRepository.GetAllUser();
        }

        void XoaTrangThongTin()
        {
            txtMaNguoiDung.Text = "";
            txtTenNguoiDung.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            cbQuyen.Text = "";
        }

        private void dgvNDvaPQ_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNDvaPQ.SelectedRows.Count <= 0)
            {
                return;
            }
            DataRowView dataRow = (DataRowView)dgvNDvaPQ.SelectedRows[0].DataBoundItem;
            currentUser = (string)dataRow["UserID"];
            txtMaNguoiDung.Text = currentUser;
            txtTenNguoiDung.Text = (string)dataRow["User_Name"];
            txtMatKhau.Text = (string)dataRow["Password"];
            txtHoTen.Text = (string)dataRow["Fullname"];
            txtDiaChi.Text = (string)dataRow["Address"];
            txtDienThoai.Text = (string)dataRow["Phone"];
            cbQuyen.Text = (string)dataRow["RoleName"];
        }

        private void frmQLQuyenNDvaPhanQuyen_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LayDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (userRepository.InsertDuLieu(txtMaNguoiDung.Text.Trim(), txtTenNguoiDung.Text.Trim(), txtMatKhau.Text.Trim(), txtHoTen.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), cbQuyen.SelectedValue.ToString()) > 0)
                {
                    MessageBox.Show("Insert Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Insert Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LayDuLieu();
                XoaTrangThongTin();
                dgvNDvaPQ.ClearSelection();
            }
        }
       
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (currentUser != null)
                {
                    if (userRepository.UpdateDuLieu(currentUser.Trim(), txtTenNguoiDung.Text.Trim(), txtMatKhau.Text.Trim(), txtHoTen.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), cbQuyen.SelectedValue.ToString()) > 0)
                    {
                        MessageBox.Show("Update Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Update Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                LayDuLieu();
                XoaTrangThongTin();
                dgvNDvaPQ.ClearSelection();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (userRepository.DeleteDuLieu(currentUser) > 0)
            {
                MessageBox.Show("Delete Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Delete Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LayDuLieu();
            XoaTrangThongTin();
            dgvNDvaPQ.ClearSelection();
        }
                 
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
