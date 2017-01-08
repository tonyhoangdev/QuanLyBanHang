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

        public void Add(NhanVienObj vo)
        {
            string str = "insert into tb_NhanVien (MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SDT, MatKhau) VALUES) values (@MaNV, @TenNV, @GioiTinh, @NamSinh, @DiaChi, @SDT, @MatKhau) VALUES)";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            cmd.Parameters.Add("@MaNV", SqlDbType.Text).Value = vo.MaNV;
            cmd.Parameters.Add("@TenNV", SqlDbType.Text).Value = vo.TenNV;
            cmd.Parameters.Add("@GioiTinh", SqlDbType.Text).Value = vo.GioiTinh;
            cmd.Parameters.Add("@NamSinh", SqlDbType.Text).Value = vo.NamSinh;
            cmd.Parameters.Add("@DiaChi", SqlDbType.Text).Value = vo.DiaChi;
            cmd.Parameters.Add("@SDT", SqlDbType.Text).Value = vo.SDT;
            cmd.Parameters.Add("@MatKhau", SqlDbType.Text).Value = vo.MatKhau;
            da.executeNonQuery(cmd);
        }

        public void DelAllFrom3()
        {
            string str = "delete from mains where id > 2";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            da.executeNonQuery(cmd);
        }

        public void CleanUpDatabase()
        {
            string str = "vacuum;";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            da.executeNonQuery(cmd);
        }
    }
}