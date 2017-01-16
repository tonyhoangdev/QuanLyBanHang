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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        KhachHangCtrl khCtr = new KhachHangCtrl();
        DataSet ds = new DataSet();
        KhachHangObj kh = new KhachHangObj();
        int flagLuu = 0;

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ds = khCtr.GetDataSet();
            dgViewKH.DataSource = ds.Tables[0].DefaultView;
            binding();
            DisEnl(false);
        }

        void binding()
        {
            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", dgViewKH.DataSource, "MaKH");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dgViewKH.DataSource, "TenKH");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgViewKH.DataSource, "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgViewKH.DataSource, "SDT");
            dtpNamSinh.DataBindings.Clear();
            dtpNamSinh.DataBindings.Add("Text", dgViewKH.DataSource, "NamSinh");
            cbGioiTinh.DataBindings.Clear();
            cbGioiTinh.DataBindings.Add("Text", dgViewKH.DataSource, "GioiTinh");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgViewKH.DataSource, "Email");
            txtDiem.DataBindings.Clear();
            txtDiem.DataBindings.Add("Text", dgViewKH.DataSource, "Diem");
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
            dtpNamSinh.Enabled = e;
            txtDiem.Enabled = e;
            txtEmail.Enabled = e;
        }

        private void GanData(KhachHangObj obj)
        {
            obj.MaKH = txtMa.Text.Trim();
            obj.TenKH = txtTen.Text.Trim();
            obj.GioiTinh = cbGioiTinh.Text.Trim();
            obj.NamSinh = dtpNamSinh.Value.ToString("yyyy-MM-dd");
            obj.DiaChi = txtDiaChi.Text.Trim();
            obj.SDT = txtSDT.Text.Trim();
            obj.Email = txtEmail.Text.Trim();
            obj.Diem = int.Parse(txtDiem.Text.Trim());
        }

        void LoadControl()
        {
            cbGioiTinh.Items.Clear();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
        }

        void ClearData()
        {
            txtMa.Text = "KH00";
            txtTen.Text = "";
            dtpNamSinh.Text = DateTime.Now.Date.ToShortDateString();
            LoadControl();
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiem.Text = "";
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
            GanData(kh);
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa - " + kh.MaKH, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Xoa
                if (khCtr.Delete(kh))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmKhachHang_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            GanData(kh);
            if (flagLuu == 0)
            {
                // them
                if (khCtr.Add(kh))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
            }
            else
            {
                // sua
                if (khCtr.Update(kh))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmKhachHang_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn hủy!", "xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                frmKhachHang_Load(sender, e);
            }
        }


        private void txtSDT_TextChanged(object sender, EventArgs e) { }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
