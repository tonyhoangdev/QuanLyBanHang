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
        }

        void bindingHoaDon()
        {
            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("Text", dgvHoaDon.DataSource, "MaHD");
            txtNgayLap.DataBindings.Clear();
            txtNgayLap.DataBindings.Add("Text", dgvHoaDon.DataSource, "NgayLap");
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dgvHoaDon.DataSource, "TenNV");
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", dgvHoaDon.DataSource, "TenKH");
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
            //btnNhapHang.Enabled = !e;
            //btnThem.Enabled = !e;
            //btnXoa.Enabled = !e;
            //btnSua.Enabled = !e;
            //btnLuu.Enabled = e;
            //btnHuy.Enabled = e;
            //txtMa.Enabled = e;
            //txtTen.Enabled = e;
            //txtDonGia.Enabled = e;
            //cbSoLuong.Enabled = e;
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
            //txtMa.Text = "HH00";
            //txtTen.Text = "";
            //LoadControl();
            //txtDonGia.Text = "0";
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dsChiTiet = chiTietCtrl.GetDataSet(txtMaHD.Text.Trim());
                dgvChiTiet.DataSource = dsChiTiet.Tables[0].DefaultView;
                bindingChiTiet();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
