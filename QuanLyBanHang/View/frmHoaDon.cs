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
        HoaDonObj hd = new HoaDonObj();
        DataSet dsChiTiet = new DataSet();
        DataSet dsHoaDon = new DataSet();

        ChiTietCtrl chiTietCtrl = new ChiTietCtrl();
        ChiTietObj chiTietObj = new ChiTietObj();

        DataTable dtChiTiet = new DataTable();
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

            btnThemCT.Enabled = e;
            btnBotCT.Enabled = e;
        }

        private void GanData(HoaDonObj obj)
        {
            obj.MaHD = txtMaHD.Text.Trim();
            obj.MaNV = txtMaNV.Text.Trim();
            obj.NgayLap = Convert.ToDateTime(txtNgayLap.Text.Trim()).ToString("yy-MM-dd");
            obj.MaKH = cbKH.SelectedValue.ToString();
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
            cbKH.SelectedIndex = 0;
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
            cbKH.SelectedIndex = 0;

            dtChiTiet.Rows.Clear();
            dtChiTiet.Columns.Add("MaHD");
            dtChiTiet.Columns.Add("TenHang");
            dtChiTiet.Columns.Add("SoLuong");
            dtChiTiet.Columns.Add("DonGia");
            dtChiTiet.Columns.Add("ThanhTien");
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            GanData(hd);
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa - " + hd.MaHD, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Xoa
                if (hdCtrl.Delete(hd))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
            }
            frmHoaDon_Load(sender, e);
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa support");
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            GanData(hd);

            // them
            if (hdCtrl.Add(hd))
            {
                // Them chi tiet
                if (chiTietCtrl.Add(dtChiTiet))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm chi tiết chưa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            frmHoaDon_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn hủy!", "xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                frmHoaDon_Load(sender, e);
            }
        }

        private void btnCham_Click(object sender, EventArgs e)
        {
            txtNgayLap.Enabled = true;
        }

        private bool checkSame(DataTable dt, string maHH)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString() == maHH)
                {
                    return true;
                }
            }

            return false;
        }

        void UpdateSL(DataTable dt, string maHH, int soLuong)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString() == maHH)
                {
                    int soLuongMoi = int.Parse(dt.Rows[i][2].ToString()) + soLuong;
                    dt.Rows[i][2] = soLuongMoi;
                    double donGia = double.Parse(dt.Rows[i][3].ToString());
                    dt.Rows[i][4] = donGia * soLuongMoi;
                    break;
                }
            }
        }


        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaHD.Text))
            {
                string maHH = cbChiTietHang.SelectedValue.ToString();
                int soLuong;
                int.TryParse(txtSoLuong.Text, out soLuong);
                if (!checkSame(dtChiTiet, maHH))
                {
                    DataRow dr = dtChiTiet.NewRow();
                    dr[0] = txtMaHD.Text.Trim();
                    dr[1] = cbChiTietHang.SelectedValue.ToString();
                    dr[2] = txtSoLuong.Text;
                    dr[3] = txtDonGia.Text;
                    dr[4] = (double.Parse(txtDonGia.Text)) * soLuong;
                    dtChiTiet.Rows.Add(dr);
                    dgvChiTiet.DataSource = dtChiTiet;
                    txtSoLuong.Text = "1";
                }
                else
                {
                    UpdateSL(dtChiTiet, maHH, soLuong);
                }

            }
            else
            {
                MessageBox.Show("Không được để trống Mã HD", "Lỗi");
                txtMaHD.Focus();
            }
        }

        private void cbChiTietHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChiTietHang.SelectedIndex < 0) return;

            DataTable dt = new DataTable();
            dt = chiTietCtrl.GetDataSetHH(cbChiTietHang.SelectedValue.ToString());

            if (dt.Rows.Count > 0)
            {
                txtDonGia.Text = dt.Rows[0][2].ToString();

                lblThanhTien.Text = (double.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text)).ToString();
            }

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            int soLuong;
            int.TryParse(txtSoLuong.Text, out soLuong);
            lblThanhTien.Text = (double.Parse(txtDonGia.Text) * soLuong).ToString();
        }

        private void btnBotCT_Click(object sender, EventArgs e)
        {
            dtChiTiet.Rows.RemoveAt(cellClick);
            dgvChiTiet.DataSource = dtChiTiet;
        }

        int cellClick = -1;
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClick = e.RowIndex;
        }
    }
}
