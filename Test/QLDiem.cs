using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Component;
using Test.Repository;

namespace Test
{
    public partial class frmQLDiem : Form
    {
        public frmQLDiem()
        {
            InitializeComponent();
        }
        MarkRepository markRepository = new MarkRepository();
        DepartmentRepository departmentRepository = new DepartmentRepository();
        ClassRepository classRepository = new ClassRepository();
        SubjectRepository subjectRepository = new SubjectRepository();
        StudentRepository studentRepository = new StudentRepository();
        int Hocky = 0;
        float DiemTongKet = 0;
        int currentMark = 0;

        bool KiemTraDuLieu()
        {
            checkDuLieu.SetError(txtMaSinhVien, "");
            checkDuLieu.SetError(txtTenSinhVien, "");
            checkDuLieu.SetError(txtDiemGiuaKy, "");
            checkDuLieu.SetError(txtDiemCuoiKy, "");

            if (txtMaSinhVien.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtMaSinhVien, "StudentID can not be empty");
                txtMaSinhVien.Focus();
                return false;
            }
            if (txtTenSinhVien.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtTenSinhVien, "Student Name can not be empty");
                txtTenSinhVien.Focus();
                return false;
            }
            if (txtDiemGiuaKy.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtDiemGiuaKy, "MidtermScore can not be empty");
                txtDiemGiuaKy.Focus();
                return false;
            }
            if (txtDiemCuoiKy.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtDiemCuoiKy, "FinalScore can not be empty");
                txtDiemCuoiKy.Focus();
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

        void LoadComboBoxSubject()
        {
            cbMonHoc.DataSource = subjectRepository.GetAllSubject();
            cbMonHoc.DisplayMember = "Subject_Name";
            cbMonHoc.ValueMember = "SubjectID";
        }

        private void frmQLDiem_Load(object sender, EventArgs e)
        {
            LayDuLieu();
            LoadComboBoxDepartment();
            LoadComboBoxSubject();
            cbHocKy.Items.Add("1");
            cbHocKy.Items.Add("2");
        }

        int LoadComboBoxSemester()
        {
            string tem = cbHocKy.SelectedItem.ToString();
            if (tem == "1")
            {
                Hocky = 1;
            }
            if (tem == "2")
            {
                Hocky = 2;
            }
            return Hocky;
        }

        float TinhDiemTongKet()
        {
            DiemTongKet = (float.Parse(txtDiemGiuaKy.Text) + float.Parse(txtDiemCuoiKy.Text)) / 2;
            txtDiemTongKet.Text = DiemTongKet.ToString();
            return DiemTongKet;
        }

        private void cbKhoa_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadComboBoxClass();
        }

        void XoaTrangThongTin()
        {
            cbKhoa.Text = "";
            cbLop.Text = "";
            cbHocKy.Text = "";
            txtGhiChu.Text = "";
            cbLop.Text = "";
            txtMaSinhVien.Text = "";
            txtTenSinhVien.Text = "";
            txtDiemGiuaKy.Text = "";
            txtDiemCuoiKy.Text = "";
        }

        private void dgvDiemSV_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDiemSV.SelectedRows.Count <= 0)
            {
                return;
            }
            DataRowView data = (DataRowView)dgvDiemSV.SelectedRows[0].DataBoundItem;
            currentMark = (int)data["MarkID"];
            cbKhoa.Text = (string)data["Department_Name"];
            cbLop.Text = (string)data["Class_Name"];
            cbMonHoc.Text = (string)data["Subject_Name"];
            cbHocKy.Text = ((int)data["Semester"]).ToString();
            txtGhiChu.Text = (string)data["Note"];
            txtMaSinhVien.Text = (string)data["StudentID"];
            txtTenSinhVien.Text = (string)data["Student_Name"];
            txtDiemGiuaKy.Text = ((double)data["MidtermScore"]).ToString();
            txtDiemCuoiKy.Text = ((double)data["FinalScore"]).ToString();
            txtDiemTongKet.Text = ((double)data["FinalGrade"]).ToString();
            if ((double.Parse(txtDiemTongKet.Text)) < 5.0)
            {
                ckbDat.Checked = false;
            }
            else if ((double.Parse(txtDiemTongKet.Text)) >= 5.0)
            {
                ckbDat.Checked = true;
            }
        }

        void LayDuLieu()
        {
            dgvDiemSV.DataSource = markRepository.GetAllMark();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                LayDuLieu();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvDiemSV.DataSource = studentRepository.FindStudentTheoName(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoadComboBoxSemester();
            if (KiemTraDuLieu())
            {
                if (studentRepository.GetStudentTheoID(txtMaSinhVien.Text) == null)
                {
                    MessageBox.Show("Student does not exist yet", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (studentRepository.GetStudentNameTheoNameAndID(txtMaSinhVien.Text, txtTenSinhVien.Text) == null)
                    {
                        MessageBox.Show("Student Name does not match student ID", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (studentRepository.GetStudentTheoClassID(cbLop.SelectedValue.ToString()) == null)
                        {
                            MessageBox.Show("Students who do not belong to this Class", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (markRepository.InsertDuLieu(cbMonHoc.SelectedValue.ToString(), txtMaSinhVien.Text, Hocky, txtGhiChu.Text, float.Parse(txtDiemGiuaKy.Text), float.Parse(txtDiemCuoiKy.Text), TinhDiemTongKet()) > 0)
                            {
                                MessageBox.Show("Insert Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Insert Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                LayDuLieu();
                XoaTrangThongTin();
                dgvDiemSV.ClearSelection();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LoadComboBoxSemester();
            if (KiemTraDuLieu())
            {
                if (currentMark != 0)
                {
                    if (studentRepository.GetStudentTheoID(txtMaSinhVien.Text) == null)
                    {
                        MessageBox.Show("Student does not exist yet", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (studentRepository.GetStudentNameTheoNameAndID(txtMaSinhVien.Text, txtTenSinhVien.Text) == null)
                        {
                            MessageBox.Show("Student Name does not match student ID", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (studentRepository.GetStudentTheoClassID(cbLop.SelectedValue.ToString()) == null)
                            {
                                MessageBox.Show("Students who do not belong to this Class", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (markRepository.UpdateDuLieu(currentMark, cbMonHoc.SelectedValue.ToString(), txtMaSinhVien.Text, Hocky, txtGhiChu.Text, float.Parse(txtDiemGiuaKy.Text), float.Parse(txtDiemCuoiKy.Text), TinhDiemTongKet()) > 0)
                                {
                                    MessageBox.Show("Update Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Update Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    LayDuLieu();
                    XoaTrangThongTin();
                    dgvDiemSV.ClearSelection();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (markRepository.DeleteDuLieu(currentMark) > 0)
            {
                MessageBox.Show("Delete Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Delete Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LayDuLieu();
            XoaTrangThongTin();
            dgvDiemSV.ClearSelection();
        }
    }
}
