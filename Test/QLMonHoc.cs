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
    public partial class frmQLMonHoc : Form
    {
        public frmQLMonHoc()
        {
            InitializeComponent();
        }

        SubjectRepository subjectRepository = new SubjectRepository();
        string currentSubject = null;

        bool KiemTraDuLieu()
        {
            checkDuLieu.SetError(txtMaMonHoc, "");
            checkDuLieu.SetError(txtMonHoc, "");
            checkDuLieu.SetError(txtDVHocTrinh, "");
            checkDuLieu.SetError(txtTinChi, "");

            if (txtMaMonHoc.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtMaMonHoc, "SubjectID can not be empty");
                txtMaMonHoc.Focus();
                return false;
            }
            if (txtMonHoc.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtMonHoc, "Subject Name can not be empty");
                txtMonHoc.Focus();
                return false;
            }
            if (txtDVHocTrinh.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtDVHocTrinh, "TeachingUnit can not be empty");
                txtDVHocTrinh.Focus();
                return false;
            }
            if (txtTinChi.Text.Trim() == "")
            {
                checkDuLieu.SetError(txtTinChi, "Credits can not be empty");
                txtTinChi.Focus();
                return false;
            }
            return true;
        }

        void XoaTrangThongTin()
        {
            txtMaMonHoc.Text = "";
            txtMonHoc.Text = "";
            txtDVHocTrinh.Text = "";
            txtTinChi.Text = "";
        }

        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMonHoc.SelectedRows.Count <= 0)
            {
                return;
            }
            DataRowView dataRow = (DataRowView)dgvMonHoc.SelectedRows[0].DataBoundItem;
            currentSubject = (string)dataRow["SubjectID"];
            txtMaMonHoc.Text = currentSubject;
            txtMonHoc.Text = (string)dataRow["Subject_Name"];
            txtDVHocTrinh.Text = ((int)dataRow["TeachingUnit"]).ToString();
            txtTinChi.Text = ((int)dataRow["Credits"]).ToString();
        }

        void LayDuLieu()
        {
            dgvMonHoc.DataSource = subjectRepository.GetAllSubject();
        }

        private void frmQLMonHoc_Load(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (subjectRepository.InsertDuLieu(txtMaMonHoc.Text.Trim(), txtMonHoc.Text.Trim(), int.Parse(txtDVHocTrinh.Text.Trim()), int.Parse(txtTinChi.Text.Trim())) > 0)
                {
                    MessageBox.Show("Insert Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Insert Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LayDuLieu();
                XoaTrangThongTin();
                dgvMonHoc.ClearSelection();
            }
        }
   
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (currentSubject != null)
                {
                    if (subjectRepository.UpdateDuLieu(currentSubject, txtMonHoc.Text.Trim(), int.Parse(txtDVHocTrinh.Text.Trim()), int.Parse(txtTinChi.Text.Trim())) > 0)
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
                dgvMonHoc.ClearSelection();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (subjectRepository.DeleteDuLieu(currentSubject) > 0)
            {
                MessageBox.Show("Delete Successful", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Delete Failed", "Nontification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LayDuLieu();
            XoaTrangThongTin();
            dgvMonHoc.ClearSelection();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
