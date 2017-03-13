using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;
using System.Data;
using QuanLyBanHang.Object;

namespace QuanLyBanHang.Model
{
    public class HoaDonMod
    {
        private SQLiteDatabaseAccess da = new SQLiteDatabaseAccess();

        public DataSet GetDataSet()
        {
            string str = "select hd.MaHD, hd.NgayLap, nv.TenNV, kh.TenKH from tb_HoaDon hd, tb_KhachHang kh, tb_NhanVien nv where kh.MaKH = hd.MaKH and nv.MaNV = hd.MaNV";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            return da.excuteQuery(cmd);
        }

        public bool Add(HoaDonObj vo)
        {
            string str = "insert into tb_HoaDon (MaHD, NgayLap, MaNV, MaKH) values (@MaHD, @NgayLap, @MaNV, @MaKH)";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            cmd.Parameters.Add("@MaHD", SqlDbType.Text).Value = vo.MaHD;
            cmd.Parameters.Add("@NgayLap", SqlDbType.Text).Value = vo.NgayLap;
            cmd.Parameters.Add("@MaNV", SqlDbType.Text).Value = vo.MaNV;
            cmd.Parameters.Add("@MaKH", SqlDbType.Text).Value = vo.MaKH;
            return da.executeNonQuery(cmd);
        }

        // Update du lieu
        public bool Update(HoaDonObj vo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_HoaDon ");
            sb.Append("set NgayLap = @NgayLap, MaNV = @MaNV, MaKH = @MaKH ");
            sb.Append("where MaHD = @MaHD");
            SQLiteCommand cmd = new SQLiteCommand(sb.ToString(), da.Conn);
            cmd.Parameters.Add("@MaHD", SqlDbType.Text).Value = vo.MaHD;
            cmd.Parameters.Add("@NgayLap", SqlDbType.Text).Value = vo.NgayLap;
            cmd.Parameters.Add("@MaNV", SqlDbType.Text).Value = vo.MaNV;
            cmd.Parameters.Add("@MaKH", SqlDbType.Text).Value = vo.MaKH;
            return da.executeNonQuery(cmd);
        }

        // Delete du lieu
        public bool Delete(HoaDonObj vo)
        {
            string str = "delete from tb_HoaDon where MaHD = @MaHD";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            cmd.Parameters.Add("@MaHD", SqlDbType.Text).Value = vo.MaHD;
            return da.executeNonQuery(cmd);
        }

        public bool DelAllFrom3()
        {
            string str = "delete from mains where id > 2";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            return da.executeNonQuery(cmd);
        }

        public bool CleanUpDatabase()
        {
            string str = "vacuum;";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            return da.executeNonQuery(cmd);
        }
    }
}
