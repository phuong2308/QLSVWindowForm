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
    public partial class frmQLQuyenNguoiDung : Form
    {
        public frmQLQuyenNguoiDung()
        {
            InitializeComponent();
        }

        RoleRepository roleRepository = new RoleRepository();
        UserRepository userRepository = new UserRepository();
        string currentRole = null;


        bool KiemTraDuLieu()
        {
            checkDuLieu.SetError(txtMaQuyen, "");
            checkDuLieu.SetError(txtQuyen, "");

            if (txtMaQuyen.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtMaQuyen, "RoleID cannot be empty");
                txtMaQuyen.Focus();
                return false;
            }
            if (txtQuyen.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtQuyen, "RoleName can not be empty");
                txtQuyen.Focus();
                return false;
            }
            return true;
        }

        void LayDuLieu()
        {
            dgvNguoiDung.DataSource = roleRepository.GetAllRole();
        }

        void XoaTrangThongTin()
        {
            txtMaQuyen.Text = "";
            txtQuyen.Text = "";
        }

        private void frmQLQuyenNguoiDung_Load(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void dgvNguoiDung_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNguoiDung.SelectedRows.Count <= 0)
            {
                return;
            }
            DataRowView dataRow = (DataRowView)dgvNguoiDung.SelectedRows[0].DataBoundItem;
            currentRole = (string)dataRow["RoleID"];
            txtMaQuyen.Text = currentRole;
            txtQuyen.Text = (string)dataRow["RoleName"];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (roleRepository.InsertDuLieu(txtMaQuyen.Text.Trim(), txtQuyen.Text.Trim()) > 0)
                {
                    MessageBox.Show("Insert Successful", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Insert Failed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LayDuLieu();
                XoaTrangThongTin();
                dgvNguoiDung.ClearSelection();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (currentRole != null)
                {
                    if (roleRepository.UpdateDuLieu(currentRole.Trim(), txtQuyen.Text.Trim()) > 0)
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
                dgvNguoiDung.ClearSelection();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (userRepository.KiemTraUserForDelete(currentRole) != null)
            {
                MessageBox.Show("This Role is currently in use", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (roleRepository.DeleteDuLieu(currentRole) > 0)
                {
                    MessageBox.Show("Delete Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Delete Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LayDuLieu();
                XoaTrangThongTin();
                dgvNguoiDung.ClearSelection();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
