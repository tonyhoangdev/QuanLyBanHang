using System;

namespace QuanLyBanHang.Object
{
    public class KhachHangObj
    {
        #region Fields
        string _maKH;
        string _tenKH;
        string _gioiTinh;
        string _namSinh;
        string _sDT;
        string _diaChi;
        int _diem;
        string _email;
        #endregion

        #region Properties
        public string MaKH
        {
            get { return _maKH; }
            set { _maKH = value; }
        }

        public string TenKH
        {
            get { return _tenKH; }
            set { _tenKH = value; }
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

        public string SDT
        {
            get { return _sDT; }
            set { _sDT = value; }
        }

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }

        public int Diem
        {
            get { return _diem; }
            set { _diem = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        #endregion
    }
}

