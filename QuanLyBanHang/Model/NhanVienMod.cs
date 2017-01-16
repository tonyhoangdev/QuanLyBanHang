using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;
using System.Data;
using QuanLyBanHang.Object;

namespace QuanLyBanHang.Model
{
    public class NhanVienMod
    {
        private SQLiteDatabaseAccess da = new SQLiteDatabaseAccess();

        public DataSet GetDataSet()
        {
            string str = "select * from tb_NhanVien";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            return da.excuteQuery(cmd);
        }

        public bool Add(NhanVienObj vo)
        {
            string str = "insert into tb_NhanVien (MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SDT, MatKhau) values (@MaNV, @TenNV, @GioiTinh, @NamSinh, @DiaChi, @SDT, @MatKhau)";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            cmd.Parameters.Add("@MaNV", SqlDbType.Text).Value = vo.MaNV;
            cmd.Parameters.Add("@TenNV", SqlDbType.Text).Value = vo.TenNV;
            cmd.Parameters.Add("@GioiTinh", SqlDbType.Text).Value = vo.GioiTinh;
            cmd.Parameters.Add("@NamSinh", SqlDbType.Text).Value = vo.NamSinh;
            cmd.Parameters.Add("@DiaChi", SqlDbType.Text).Value = vo.DiaChi;
            cmd.Parameters.Add("@SDT", SqlDbType.Text).Value = vo.SDT;
            cmd.Parameters.Add("@MatKhau", SqlDbType.Text).Value = vo.MatKhau;
            return da.executeNonQuery(cmd);
        }

        // Update du lieu
        public bool Update(NhanVienObj vo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_NhanVien ");
            sb.Append("set TenNV = @TenNV, GioiTinh = @GioiTinh, NamSinh = @NamSinh, DiaChi = @DiaChi, SDT = @SDT, MatKhau = @MatKhau ");
            sb.Append("where MaNV = @MaNV");
            SQLiteCommand cmd = new SQLiteCommand(sb.ToString(), da.Conn);
            cmd.Parameters.Add("@MaNV", SqlDbType.Text).Value = vo.MaNV;
            cmd.Parameters.Add("@TenNV", SqlDbType.Text).Value = vo.TenNV;
            cmd.Parameters.Add("@GioiTinh", SqlDbType.Text).Value = vo.GioiTinh;
            cmd.Parameters.Add("@NamSinh", SqlDbType.Text).Value = vo.NamSinh;
            cmd.Parameters.Add("@DiaChi", SqlDbType.Text).Value = vo.DiaChi;
            cmd.Parameters.Add("@SDT", SqlDbType.Text).Value = vo.SDT;
            cmd.Parameters.Add("@MatKhau", SqlDbType.Text).Value = vo.MatKhau;
            return da.executeNonQuery(cmd);
        }

        // Delete du lieu
        public bool Delete(NhanVienObj vo)
        {
            string str = "delete from tb_NhanVien where MaNV = @MaNV";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            cmd.Parameters.Add("@MaNV", SqlDbType.Text).Value = vo.MaNV;
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
