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
    public partial class frmQLSinhVien : Form
    {
        public frmQLSinhVien()
        {
            InitializeComponent();
        }

        StudentRepository studentRepository = new StudentRepository();
        DepartmentRepository departmentRepository = new DepartmentRepository();
        ClassRepository classRepository = new ClassRepository();
        int GioiTinh = 0;
        string currentStudent = null;

        bool KiemTraDuLieu()
        {
            checkDuLieu.SetError(txtMaSinhVien, "");
            checkDuLieu.SetError(txtHoTen, "");
            checkDuLieu.SetError(txtDiaChi, "");

            if (txtMaSinhVien.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtMaSinhVien, "StudentID can not be empty");
                txtMaSinhVien.Focus();
                return false;
            }
            if (txtHoTen.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtHoTen, "Student Name can not be empty");
                txtHoTen.Focus();
                return false;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtDiaChi, "Student Address can not be empty");
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }

        void LoadComboBoxDepartment()
        {
            cbKhoa.DataSource = departmentRepository.GetAllDepartment();
            cbKhoa.DisplayMember = "Department_Name";
            cbKhoa.ValueMember = "DepartmentID";
        }

        void LoadComboBoxClass()
        {
            cbLop.DataSource = classRepository.GetClassTheoDepartmentID(cbKhoa.SelectedValue.ToString());
            cbLop.DisplayMember = "Class_Name";
            cbLop.ValueMember = "ClassID";
        }

        void LoadRadioButton()
        {
            if (rdoNam.Checked)
            {
                GioiTinh = 1;
            }
            if (rdoNu.Checked)
            {
                GioiTinh = 2;
            }
        }

        void LayDuLieu()
        {
            dgvSinhVien.DataSource = studentRepository.GetAllStudent();
        }

        void XoaTrangThongTin()
        {
            txtMaSinhVien.Text = "";
            txtHoTen.Text = "";
            dtpNgayThangSinh.Text = "";
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            txtDiaChi.Text = "";
            cbKhoa.Text = "";
            cbLop.Text = "";
        }

        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count <= 0)
            {
                return;
            }
            DataRowView dataRow = (DataRowView)dgvSinhVien.SelectedRows[0].DataBoundItem;
            currentStudent = (string)dataRow["StudentID"];
            txtMaSinhVien.Text = currentStudent;
            txtHoTen.Text = (string)dataRow["Student_Name"];
            dtpNgayThangSinh.Value = (DateTime)dataRow["BirthDay"];
            txtDiaChi.Text = (string)dataRow["Address"];
            cbKhoa.Text = (string)dataRow["Department_Name"];
            cbLop.Text = (string)dataRow["Class_Name"];
            if ((string)dataRow["Sex_Name"] == "Nam")
            {
                rdoNam.Checked = true;
                GioiTinh = 1;
            }
            if ((string)dataRow["Sex_Name"] == "Nữ")
            {
                rdoNu.Checked = true;
                GioiTinh = 2;
            }
        }

        private void frmQLSinhVien_Load(object sender, EventArgs e)
        {
            LoadComboBoxDepartment();
            LayDuLieu();
        }

        private void cbKhoa_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadComboBoxClass();
        }
     
        private void btnThem_Click(object sender, EventArgs e)
        {
            LoadRadioButton();
            if (KiemTraDuLieu())
            {
                if (studentRepository.InsertDuLieu(txtMaSinhVien.Text.Trim(), txtHoTen.Text.Trim(), dtpNgayThangSinh.Value, GioiTinh, txtDiaChi.Text.Trim(), cbLop.SelectedValue.ToString(), cbKhoa.SelectedValue.ToString()) > 0)
                {
                    MessageBox.Show("Insert Succesful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Insert Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LayDuLieu();
                XoaTrangThongTin();
                dgvSinhVien.ClearSelection();
            }
        }

        

        private void btnSua_Click(object sender, EventArgs e)
        {
            LoadRadioButton();
            if (KiemTraDuLieu())
            {
                if (currentStudent != null)
                {
                    if (studentRepository.UpdateDuLieu(currentStudent, txtHoTen.Text.Trim(), dtpNgayThangSinh.Value, GioiTinh, txtDiaChi.Text.Trim(), cbLop.SelectedValue.ToString(), cbKhoa.SelectedValue.ToString()) > 0)
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
                dgvSinhVien.ClearSelection();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (studentRepository.DeleteDuLieu(currentStudent) > 0)
            {
                MessageBox.Show("Delete Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Delete Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LayDuLieu();
            XoaTrangThongTin();
            dgvSinhVien.ClearSelection();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
