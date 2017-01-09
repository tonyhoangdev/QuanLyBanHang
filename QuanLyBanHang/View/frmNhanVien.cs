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
using QuanLyBanHang.Object;
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
        NhanVienObj nv = new NhanVienObj();
        int flagLuu = 0;

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            ds = nvCtr.GetDataSet();
            dgViewNV.DataSource = ds.Tables[0].DefaultView;
            binding();
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

        private void GanData(NhanVienObj obj)
        {
            obj.MaNV = txtMa.Text.Trim();
            obj.TenNV = txtTen.Text.Trim();
            obj.GioiTinh = cbGioiTinh.Text.Trim();
            obj.NamSinh = dpNamSinh.Value.ToString("yyyy-MM-dd");
            obj.DiaChi = txtDiaChi.Text.Trim();
            obj.SDT = txtSDT.Text.Trim();
            obj.MatKhau = "";
        }

        void LoadControl()
        {
            cbGioiTinh.Items.Clear();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
        }

        void ClearData()
        {
            txtMa.Text = "NV00";
            txtTen.Text = "";
            dpNamSinh.Text = DateTime.Now.Date.ToShortDateString();
            LoadControl();
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            DisEnl(true);
            ClearData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            DisEnl(true);
            txtMa.Enabled = false;
            LoadControl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            GanData(nv);
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa - " + nv.MaNV, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Xoa
                nvCtr.Delete(nv);
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            }
            frmNhanVien_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            GanData(nv);
            if (flagLuu == 0)
            {
                // them
                nvCtr.Add(nv);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // sua
                nvCtr.Update(nv);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            frmNhanVien_Load(sender, e);
            DisEnl(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmNhanVien_Load(sender, e);
            DisEnl(false);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e) { }

        private void txtSDT_TextChanged(object sender, EventArgs e) { }
    }
}
