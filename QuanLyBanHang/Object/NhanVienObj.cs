using System;

namespace QuanLyBanHang.Object
{
    public class NhanVienObj
    {
        #region Fields
        string _maNV;
        string _tenNV;
        string _gioiTinh;
        string _namSinh;
        string _diaChi;
        string _sDT;
        string _matKhau;
        #endregion

        #region Properties
        public string MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }

        public string TenNV
        {
            get { return _tenNV; }
            set { _tenNV = value; }
        }

        public string GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }

        public string NamSinh
        {
            get { return _namSinh; }
            set { _namSinh = value; }
        }

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }

        public string SDT
        {
            get { return _sDT; }
            set { _sDT = value; }
        }

        public string MatKhau
        {
            get { return _matKhau; }
            set { _matKhau = value; }
        }
        #endregion

        public NhanVienObj() { }
        public NhanVienObj(string MaNV, string TenNV, string GioiTinh, string NamSinh, string DiaChi, string SDT, string MatKhau)
        {
            this.MaNV = MaNV;
            this.TenNV = TenNV;
            this.GioiTinh = GioiTinh;
            this.NamSinh = NamSinh;
            this.DiaChi = DiaChi;
            this.SDT = SDT;
            this.MatKhau = MatKhau;
        }
    }
}
