using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Repository;

namespace Test
{
    public partial class frmQLGiangVien : Form
    {
        public frmQLGiangVien()
        {
            InitializeComponent();
        }

        TeacherRepository teacherRepository = new TeacherRepository();
        DepartmentRepository departmentRepository = new DepartmentRepository();
        string currentTeacher = null;
        string duongDanAnh = null;
        string AnhSangByte = null;
        int GioiTinh = 0;

        bool KiemTraDuLieu()
        {
            checkDuLieu.SetError(txtMaGiangVien, "");
            checkDuLieu.SetError(txtTenGiangVien, "");
            checkDuLieu.SetError(txtEmail, "");
            checkDuLieu.SetError(txtDienThoai, "");
            checkDuLieu.SetError(txtDiaChi, "");

            if (txtMaGiangVien.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtMaGiangVien, "TeacherID can not be empty");
                txtMaGiangVien.Focus();
                return false;
            }
            if (txtTenGiangVien.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtTenGiangVien, "Teacher Name can not be empty");
                txtTenGiangVien.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtEmail, "Email can not be empty");
                txtEmail.Focus();
                return false;
            }
            if (txtDienThoai.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtDienThoai, "Phone can not be empty");
                txtDienThoai.Focus();
                return false;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtDiaChi, "Address can not be empty");
                txtDiaChi.Focus();
                return false;
            }
            return true;
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
        void LoadComboBox()
        {
            cbKhoa.DataSource = departmentRepository.GetAllDepartment();
            cbKhoa.DisplayMember = "Department_Name";
            cbKhoa.ValueMember = "DepartmentID";
        }
      
        void XoaTrangThongTin()
        {
            txtMaGiangVien.Text = "";
            txtTenGiangVien.Text = "";
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            txtEmail.Text = "";
            txtDienThoai.Text = "";
            cbKhoa.Text = "";
            txtGhiChu.Text = "";
            txtDiaChi.Text = "";
            txtQueQuan.Text = "";
            ptbAnh.Visible = false;
        }

        void LayDuLieu()
        {
            dgvQLGiangVien.DataSource = teacherRepository.GetAllTeacher();
        }

        private byte[] convertImgToByte()
        {
            FileStream fs;
            fs = new FileStream(duongDanAnh, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return data;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                LayDuLieu();
            }
        }

        private Image ByteToImg(string byteString)
        {
            byte[] data = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(data, 0, data.Length);
            ms.Write(data, 0, data.Length);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms, true);
            return img;
        }

        private void dgvQLGiangVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQLGiangVien.SelectedRows.Count <= 0)
            {
                return;
            }
            DataRowView dataRow = (DataRowView)dgvQLGiangVien.SelectedRows[0].DataBoundItem;
            currentTeacher = (string)dataRow["TeacherID"];
            txtMaGiangVien.Text = currentTeacher;
            txtTenGiangVien.Text = (string)dataRow["Teacher_Name"];
            txtEmail.Text = (string)dataRow["Email"];
            txtDienThoai.Text = (string)dataRow["Phone"];
            cbKhoa.Text = (string)dataRow["Department_Name"];
            txtGhiChu.Text = (string)dataRow["Note"];
            txtDiaChi.Text = (string)dataRow["Address"];
            txtQueQuan.Text = (string)dataRow["HomeTown"];
            AnhSangByte = (string)dataRow["Image"];
            ptbAnh.Image = ByteToImg(AnhSangByte);
            ptbAnh.Visible = true;
            if ((string)dataRow["Sex_Name"] == "Nam")
            {
                rdoNam.Checked = true;
                GioiTinh = 1;
            }
            else if ((string)dataRow["Sex_Name"] == "Nữ")
            {
                rdoNu.Checked = true;
                GioiTinh = 2;
            }
        }

        private void frmQLGiangVien_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LayDuLieu();
        }
     
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                duongDanAnh = openFileDialog.FileName;
                AnhSangByte = Convert.ToBase64String(convertImgToByte());
                ptbAnh.Image = ByteToImg(AnhSangByte);
                ptbAnh.Visible = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvQLGiangVien.DataSource = teacherRepository.GetTeacherTheoTeacherName(txtTimKiem.Text.Trim());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoadRadioButton();
            if (KiemTraDuLieu())
            {
                if (teacherRepository.InsertDuLieu(txtMaGiangVien.Text.Trim(), txtTenGiangVien.Text.Trim(), GioiTinh, cbKhoa.SelectedValue.ToString(), txtEmail.Text.Trim(), txtDienThoai.Text.Trim(), txtQueQuan.Text.Trim(), txtDiaChi.Text.Trim(), AnhSangByte, txtGhiChu.Text.Trim()) > 0)
                {
                    MessageBox.Show("Insert Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Insert Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LayDuLieu();
                XoaTrangThongTin();
                dgvQLGiangVien.ClearSelection();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LoadRadioButton();
            if (KiemTraDuLieu())
            {
                if (currentTeacher != null)
                {
                    if (teacherRepository.UpdateDuLieu(txtMaGiangVien.Text.Trim(), txtTenGiangVien.Text.Trim(), GioiTinh, cbKhoa.SelectedValue.ToString(), txtEmail.Text.Trim(), txtDienThoai.Text.Trim(), txtQueQuan.Text.Trim(), txtDiaChi.Text.Trim(), AnhSangByte, txtGhiChu.Text.Trim()) > 0)
                    {
                        MessageBox.Show("Update Succesful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Update Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                LayDuLieu();
                XoaTrangThongTin();
                dgvQLGiangVien.ClearSelection();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (teacherRepository.DeleteDuLieu(currentTeacher) > 0)
            {
                MessageBox.Show("Delete Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Delete Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LayDuLieu();
            XoaTrangThongTin();
            dgvQLGiangVien.ClearSelection();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
