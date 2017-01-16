using System;

namespace QuanLyBanHang.Object
{
    public class ChiTietObj
    {
        #region Fields
        string _maHD;
        string _maHH;
        int _soLuong;
        int _donGia;
        #endregion

        #region Properties
        public string MaHD
        {
            get { return _maHD; }
            set { _maHD = value; }
        }

        public string MaHH
        {
            get { return _maHH; }
            set { _maHH = value; }
        }

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }

        public int DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }
        #endregion
    }
}

