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
using QuanLyBanHang.Control;

namespace QuanLyBanHang.View
{
    public partial class frmHangHoa : Form
    {
        public frmHangHoa()
        {
            InitializeComponent();
        }

        HangHoaCtrl hhCtrl = new HangHoaCtrl();
        DataSet ds = new DataSet();
        HangHoaObj nv = new HangHoaObj();
        int flagLuu = 0;

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            ds = hhCtrl.GetDataSet();
            dgViewHH.DataSource = ds.Tables[0].DefaultView;
            binding();
            DisEnl(false);
        }

        void binding()
        {
            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", dgViewHH.DataSource, "MaHH");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dgViewHH.DataSource, "TenHang");
            cbSoLuong.DataBindings.Clear();
            cbSoLuong.DataBindings.Add("Text", dgViewHH.DataSource, "SoLuong");
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dgViewHH.DataSource, "DonGia");
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
            txtDonGia.Enabled = e;
            cbSoLuong.Enabled = e;
        }

        private void GanData(HangHoaObj obj)
        {
            obj.MaHH= txtMa.Text.Trim();
            obj.TenHang = txtTen.Text.Trim();
            obj.SoLuong = int.Parse(cbSoLuong.Text.Trim());
            obj.DonGia = int.Parse(txtDonGia.Text.Trim());
        }

        void LoadControl()
        {
            cbSoLuong.Items.Clear();
            cbSoLuong.Items.Add("10");
            cbSoLuong.Items.Add("20");

        }

        void ClearData()
        {
            txtMa.Text = "HH00";
            txtTen.Text = "";
            LoadControl();
            txtDonGia.Text = "0";
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
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa - " + nv.MaHH, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Xoa
                hhCtrl.Delete(nv);
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            }
            frmHangHoa_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            GanData(nv);
            if (flagLuu == 0)
            {
                // them
                hhCtrl.Add(nv);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // sua
                hhCtrl.Update(nv);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            frmHangHoa_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn hủy!", "xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                frmHangHoa_Load(sender, e);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
