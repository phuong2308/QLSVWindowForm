using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class FormChinh : Form
    {
        public FormChinh()
        {
            InitializeComponent();
        }

        private void btnQLMonHoc_Click(object sender, EventArgs e)
        {   
            panel3.Controls.Clear();
            frmQLMonHoc frmQLMonHoc = new frmQLMonHoc();
            frmQLMonHoc.TopLevel = false;
            panel3.Controls.Add(frmQLMonHoc);
            frmQLMonHoc.Dock = DockStyle.Fill;
            frmQLMonHoc.Show();
        }

        private void btnQLNguoiDung_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmQLQuyenNguoiDung frmQLQuyenNguoiDung = new frmQLQuyenNguoiDung();
            frmQLQuyenNguoiDung.TopLevel = false;
            panel3.Controls.Add(frmQLQuyenNguoiDung);
            frmQLQuyenNguoiDung.Dock = DockStyle.Fill;
            frmQLQuyenNguoiDung.Show();
        }

        private void btnQLPhanQuyen_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmQLQuyenNDvaPhanQuyen frmQLQuyenNDvaPhanQuyen = new frmQLQuyenNDvaPhanQuyen();
            frmQLQuyenNDvaPhanQuyen.TopLevel = false;
            panel3.Controls.Add(frmQLQuyenNDvaPhanQuyen);
            frmQLQuyenNDvaPhanQuyen.Dock = DockStyle.Fill;
            frmQLQuyenNDvaPhanQuyen.Show();
        }

        private void btnQLSinhVien_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmQLSinhVien frmQLSinhVien = new frmQLSinhVien();
            frmQLSinhVien.TopLevel = false;
            panel3.Controls.Add(frmQLSinhVien);
            frmQLSinhVien.Dock = DockStyle.Fill;
            frmQLSinhVien.Show();
        }

        private void btnQLLop_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmQLLop frmQLLop = new frmQLLop();
            frmQLLop.TopLevel = false;
            panel3.Controls.Add(frmQLLop);
            frmQLLop.Dock = DockStyle.Fill;
            frmQLLop.Show();
        }

        private void btnQLKhoa_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmQLKhoa frmQLKhoa = new frmQLKhoa();
            frmQLKhoa.TopLevel = false;
            panel3.Controls.Add(frmQLKhoa);
            frmQLKhoa.Dock = DockStyle.Fill;
            frmQLKhoa.Show();
        }

        private void btnQLDiem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmQLDiem frmQLDiem = new frmQLDiem();
            frmQLDiem.TopLevel = false;
            panel3.Controls.Add(frmQLDiem);
            frmQLDiem.Dock = DockStyle.Fill;
            frmQLDiem.Show();
        }

        private void btnQLGiangVien_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmQLGiangVien frmQLGiangVien = new frmQLGiangVien();
            frmQLGiangVien.TopLevel = false;
            panel3.Controls.Add(frmQLGiangVien);
            frmQLGiangVien.Dock = DockStyle.Fill;
            frmQLGiangVien.Show();
        }
    }
}
