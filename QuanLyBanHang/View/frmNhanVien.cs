using QuanLyBanHang.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// https://www.youtube.com/watch?v=vQAktMh958I

namespace QuanLyBanHang.View
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        NhanVienCtrl nvCtr = new NhanVienCtrl();
        DataSet ds = new DataSet();
        int flagLuu = 0;

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            ds = nvCtr.GetDataSet();
            dgViewNV.DataSource = ds.Tables[0].DefaultView;
            binding();
            DisEnl(false);
        }

        void binding()
        {
            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", dgViewNV.DataSource, "MaNV");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dgViewNV.DataSource, "TenNV");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgViewNV.DataSource, "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgViewNV.DataSource, "SDT");
            dpNamSinh.DataBindings.Clear();
            dpNamSinh.DataBindings.Add("Text", dgViewNV.DataSource, "NamSinh");
            cbGioiTinh.DataBindings.Clear();
            cbGioiTinh.DataBindings.Add("Text", dgViewNV.DataSource, "GioiTinh");
        }

        private void DisEnl(bool e)
        {
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            txtMa.Enabled = e;
            txtTen.Enabled = e;
            txtDiaChi.Enabled = e;
            txtSDT.Enabled = e;
            cbGioiTinh.Enabled = e;
            dpNamSinh.Enabled = e;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            DisEnl(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            DisEnl(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flagLuu == 0)
            {
                // them
            }
            else
            {
                // sua
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DisEnl(false);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e) { }

        private void txtSDT_TextChanged(object sender, EventArgs e) { }
    }
}
