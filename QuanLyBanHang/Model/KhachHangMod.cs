using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finisar.SQLite;
using System.Data;
using QuanLyBanHang.Object;

namespace QuanLyBanHang.Model
{
    class KhachHangMod
    {
        private SQLiteDatabaseAccess da = new SQLiteDatabaseAccess();

        public DataSet GetDataSet()
        {
            string str = "select * from tb_KhachHang";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            return da.excuteQuery(cmd);
        }

        public void Add(KhachHangObj vo)
        {
            string str = "insert into tb_KhachHang (MaKH, TenKH, GioiTinh, NamSinh, DiaChi, SDT, Email, Diem) values (@MaKH, @TenKH, @GioiTinh, @NamSinh, @DiaChi, @SDT, @Email, @Diem)";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            cmd.Parameters.Add("@MaKH", SqlDbType.Text).Value = vo.MaKH;
            cmd.Parameters.Add("@TenKH", SqlDbType.Text).Value = vo.TenKH;
            cmd.Parameters.Add("@GioiTinh", SqlDbType.Text).Value = vo.GioiTinh;
            cmd.Parameters.Add("@NamSinh", SqlDbType.Text).Value = vo.NamSinh;
            cmd.Parameters.Add("@DiaChi", SqlDbType.Text).Value = vo.DiaChi;
            cmd.Parameters.Add("@SDT", SqlDbType.Text).Value = vo.SDT;
            cmd.Parameters.Add("@Email", SqlDbType.Text).Value = vo.Email;
            cmd.Parameters.Add("@Diem", SqlDbType.Int).Value = vo.Diem;
            da.executeNonQuery(cmd);
        }

        // Update du lieu
        public void Update(KhachHangObj vo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_KhachHang ");
            sb.Append("set TenKH = @TenKH, GioiTinh = @GioiTinh, NamSinh = @NamSinh, DiaChi = @DiaChi, SDT = @SDT, Email = @Email, Diem = @Diem ");
            sb.Append("where MaKH = @MaKH");
            SQLiteCommand cmd = new SQLiteCommand(sb.ToString(), da.Conn);
            cmd.Parameters.Add("@MaKH", SqlDbType.Text).Value = vo.MaKH;
            cmd.Parameters.Add("@TenKH", SqlDbType.Text).Value = vo.TenKH;
            cmd.Parameters.Add("@GioiTinh", SqlDbType.Text).Value = vo.GioiTinh;
            cmd.Parameters.Add("@NamSinh", SqlDbType.Text).Value = vo.NamSinh;
            cmd.Parameters.Add("@DiaChi", SqlDbType.Text).Value = vo.DiaChi;
            cmd.Parameters.Add("@SDT", SqlDbType.Text).Value = vo.SDT;
            cmd.Parameters.Add("@Email", SqlDbType.Text).Value = vo.Email;
            cmd.Parameters.Add("@Diem", SqlDbType.Text).Value = vo.Diem;
            da.executeNonQuery(cmd);
        }

        // Delete du lieu
        public void Delete(KhachHangObj vo)
        {
            string str = "delete from tb_KhachHang where MaKH = @MaKH";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            cmd.Parameters.Add("@MaKH", SqlDbType.Text).Value = vo.MaKH;
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
