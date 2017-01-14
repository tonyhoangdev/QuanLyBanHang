using System;

namespace QuanLyBanHang.Object
{
    public class HangHoaObj
    {
        #region Fields
        string _maHH;
        string _tenHang;
        int _donGia;
        int _soLuong;
        #endregion

        #region Properties
        public string MaHH
        {
            get { return _maHH; }
            set { _maHH = value; }
        }

        public string TenHang
        {
            get { return _tenHang; }
            set { _tenHang = value; }
        }

        public int DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        #endregion
    }
}

