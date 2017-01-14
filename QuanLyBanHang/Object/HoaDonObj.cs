using System;

namespace QuanLyBanHang.Object
{
    public class HoaDonObj
    {
        #region Fields
        string _maHD;
        string _ngayLap;
        string _maNV;
        string _maKH;
        #endregion

        #region Properties
        public string MaHD
        {
            get { return _maHD; }
            set { _maHD = value; }
        }

        public string NgayLap
        {
            get { return _ngayLap; }
            set { _ngayLap = value; }
        }

        public string MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }

        public string MaKH
        {
            get { return _maKH; }
            set { _maKH = value; }
        }
        #endregion
    }
}

