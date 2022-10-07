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
    public partial class frmQLLop : Form
    {
        public frmQLLop()
        {
            InitializeComponent();
        }

        ClassRepository classRepository = new ClassRepository();
        DepartmentRepository departmentRepository = new DepartmentRepository();
        StudentRepository studentRepository = new StudentRepository();
        string currentClass = null;

        bool KiemTraDuLieu()
        {
            checkDuLieu.SetError(txtMaLop, "");
            checkDuLieu.SetError(txtTenLop, "");

            if (txtMaLop.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtMaLop, "ClassID can not be empty");
                txtMaLop.Focus();
                return false;
            }
            if (txtTenLop.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtTenLop, "Class Name can not be empty");
                txtTenLop.Focus();
                return false;
            }
            return true;
        }

        void LoadComboBox()
        {
            cbKhoa.DataSource = departmentRepository.GetAllDepartment();
            cbKhoa.DisplayMember = "Department_Name";
            cbKhoa.ValueMember = "DepartmentID";
        }

        void LayDuLieu()
        {
            dgvLop.DataSource = classRepository.GetAllClass();
        }

        void XoaTrangThongTin()
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            cbKhoa.Text = "";
        }

        private void dgvLop_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLop.SelectedRows.Count <= 0)
            {
                return;
            }
            DataRowView dataRow = (DataRowView)dgvLop.SelectedRows[0].DataBoundItem;
            currentClass = (string)dataRow["ClassID"];
            txtMaLop.Text = currentClass;
            txtTenLop.Text = (string)dataRow["Class_Name"];
            cbKhoa.Text = (string)dataRow["Department_Name"];
        }

        private void frmQLLop_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LayDuLieu();
            XoaTrangThongTin();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (classRepository.InsertDuLieu(txtMaLop.Text.Trim(), txtTenLop.Text.Trim(), cbKhoa.SelectedValue.ToString()) > 0)
                {
                    MessageBox.Show("Insert Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Insert Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LayDuLieu();
                XoaTrangThongTin();
                dgvLop.ClearSelection();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (currentClass != null)
                {
                    if (classRepository.UpdateDuLieu(txtMaLop.Text.Trim(), txtTenLop.Text.Trim(), cbKhoa.SelectedValue.ToString()) > 0)
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
                dgvLop.ClearSelection();
            }
        }
       
        private void btnXoa_Click(object sender, EventArgs e)
        {   
            if (studentRepository.GetStudentTheoClassID(currentClass) != null)
            {
                MessageBox.Show("This Class is currently in Student","Nontification",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (classRepository.DeleteDuLieu(currentClass) > 0)
                {
                    MessageBox.Show("Delete Succesful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Delete Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LayDuLieu();
                XoaTrangThongTin();
                dgvLop.ClearSelection();
            }           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
