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
    public partial class frmQLKhoa : Form
    {
        public frmQLKhoa()
        {
            InitializeComponent();
        }

        DepartmentRepository departmentRepository = new DepartmentRepository();
        ClassRepository classRepository = new ClassRepository();
        string currentDepartment = null;

        bool KiemTraDuLieu()
        {
            checkDuLieu.SetError(txtMaKhoa, "");
            checkDuLieu.SetError(txtTenKhoa, "");

            if (txtMaKhoa.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtMaKhoa, "DepartmentID can not be empty");
                txtMaKhoa.Focus();
                return false;
            }
            if (txtTenKhoa.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtTenKhoa, "Department Name can not be empty");
                txtTenKhoa.Focus();
                return false;
            }
            return true;
        }

        void LayDuLieu()
        {
            dgvKhoa.DataSource = departmentRepository.GetAllDepartment();
        }

        void XoaTrangThongTin()
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
        }

        private void dgvKhoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoa.SelectedRows.Count <= 0)
            {
                return;
            }
            DataRowView dataRow = (DataRowView)dgvKhoa.SelectedRows[0].DataBoundItem;
            currentDepartment = (string)dataRow["DepartmentID"];
            txtMaKhoa.Text = currentDepartment;
            txtTenKhoa.Text = (string)dataRow["Department_Name"];
        }

        private void frmQLKhoa_Load(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (departmentRepository.InsertDuLieu(txtMaKhoa.Text.Trim(), txtTenKhoa.Text.Trim()) > 0)
                {
                    MessageBox.Show("Insert Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Insert Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LayDuLieu();
                XoaTrangThongTin();
                dgvKhoa.ClearSelection();
            }
        }            
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (currentDepartment != null)
                {
                    if (departmentRepository.UpdateDuLieu(currentDepartment.Trim(), txtTenKhoa.Text.Trim()) > 0)
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
                dgvKhoa.ClearSelection();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {   
            if (classRepository.KiemTraClassForDelete(currentDepartment) != null)
            {
                MessageBox.Show("This Department is currently in Class","Nontification",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (departmentRepository.DeleteDuLieu(currentDepartment) > 0)
                {
                    MessageBox.Show("Delete Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Delete Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LayDuLieu();
                XoaTrangThongTin();
                dgvKhoa.ClearSelection();
            }           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
