using QuanLyBanHang.Control;
using QuanLyBanHang.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.View
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

        HoaDonCtrl hdCtrl = new HoaDonCtrl();
        HoaDonObj nv = new HoaDonObj();
        DataSet dsChiTiet = new DataSet();
        DataSet dsHoaDon = new DataSet();

        ChiTietCtrl chiTietCtrl = new ChiTietCtrl();
        ChiTietObj chiTietObj = new ChiTietObj();
        int flagLuu = 0;

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dsHoaDon = hdCtrl.GetDataSet();
            dgvHoaDon.DataSource = dsHoaDon.Tables[0].DefaultView;
            bindingHoaDon();
            DisEnl(false);
            txtNgayLap.Enabled = false;
        }

        void bindingHoaDon()
        {
            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("Text", dgvHoaDon.DataSource, "MaHD");
            txtNgayLap.DataBindings.Clear();
            txtNgayLap.DataBindings.Add("Text", dgvHoaDon.DataSource, "NgayLap");
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dgvHoaDon.DataSource, "TenNV");
            cbKH.DataBindings.Clear();
            cbKH.DataBindings.Add("Text", dgvHoaDon.DataSource, "TenKH");
        }

        void bindingChiTiet()
        {
            cbChiTietHang.DataBindings.Clear();
            cbChiTietHang.DataBindings.Add("Text", dgvChiTiet.DataSource, "TenHang");
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dgvChiTiet.DataSource, "DonGia");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", dgvChiTiet.DataSource, "SoLuong");
        }

        private void DisEnl(bool e)
        {
            txtMaHD.Enabled = e;
            txtMaNV.Enabled = e;
            cbKH.Enabled = e;
            btnTaoMoiHD.Enabled = !e;
            btnXoaHD.Enabled = !e;
            btnInHD.Enabled = !e;
            btnLuuHD.Enabled = e;
            btnHuy.Enabled = e;
            btnCham.Enabled = e;
        }

        private void GanData(HangHoaObj obj)
        {
            //obj.MaHH = txtMa.Text.Trim();
            //obj.TenHang = txtTen.Text.Trim();
            //obj.SoLuong = int.Parse(cbSoLuong.Text.Trim());
            //obj.DonGia = int.Parse(txtDonGia.Text.Trim());
        }

        void LoadControl()
        {
            //cbSoLuong.Items.Clear();
            //cbSoLuong.Items.Add("10");
            //cbSoLuong.Items.Add("20");
        }

        void ClearData()
        {
            txtMaHD.Text = "HD00";
            txtMaNV.Text = "";
            txtNgayLap.Text = DateTime.Now.Date.ToShortDateString();
            cbKH.Text = "";
        }

        private void LoadcbKhachHang()
        {
            KhachHangCtrl khCtrl = new KhachHangCtrl();
            cbKH.DataSource = khCtrl.GetDataSet().Tables[0].DefaultView;
            cbKH.DisplayMember = "TenKH";
            cbKH.ValueMember = "MaKH";
        }

        private void LoadcbChiTietHang()
        {
            HangHoaCtrl hhCtrl = new HangHoaCtrl();
            cbChiTietHang.DataSource = hhCtrl.GetDataSet().Tables[0].DefaultView;
            cbChiTietHang.DisplayMember = "TenHang";
            cbChiTietHang.ValueMember = "MaHH";
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dsChiTiet = chiTietCtrl.GetDataSet(txtMaHD.Text.Trim());
                dgvChiTiet.DataSource = dsChiTiet.Tables[0].DefaultView;
            }
            catch (Exception)
            {
                dgvChiTiet.DataSource = null;
            }
            bindingChiTiet();
        }


        private void dgvChiTiet_DataSourceChanged(object sender, EventArgs e)
        {
            bindingChiTiet();
        }

        private void btnTaoMoiHD_Click(object sender, EventArgs e)
        {
            DisEnl(true);
            LoadcbKhachHang();
            LoadcbChiTietHang();
            ClearData();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {

        }

        private void btnInHD_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }

        private void btnCham_Click(object sender, EventArgs e)
        {
            txtNgayLap.Enabled = true;
        }

    }
}
