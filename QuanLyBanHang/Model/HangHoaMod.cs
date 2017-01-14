using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;
using System.Data;
using QuanLyBanHang.Object;

namespace QuanLyBanHang.Model
{
    public class HangHoaMod
    {
        private SQLiteDatabaseAccess da = new SQLiteDatabaseAccess();

        public DataSet GetDataSet()
        {
            string str = "select * from tb_HangHoa";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            return da.excuteQuery(cmd);
        }

        public void Add(HangHoaObj vo)
        {
            string str = "insert into tb_HangHoa (MaHH, TenHang, SoLuong, DonGia) values (@MaHH, @TenHang, @SoLuong, @DonGia)";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            cmd.Parameters.Add("@MaHH", SqlDbType.Text).Value = vo.MaHH;
            cmd.Parameters.Add("@TenHang", SqlDbType.Text).Value = vo.TenHang;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = vo.SoLuong;
            cmd.Parameters.Add("@DonGia", SqlDbType.Int).Value = vo.DonGia;
            da.executeNonQuery(cmd);
        }

        // Update du lieu
        public void Update(HangHoaObj vo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_HangHoa ");
            sb.Append("set TenHang = @TenHang, SoLuong = @SoLuong, DonGia = @DonGia ");
            sb.Append("where MaHH = @MaHH");
            SQLiteCommand cmd = new SQLiteCommand(sb.ToString(), da.Conn);
            cmd.Parameters.Add("@MaHH", SqlDbType.Text).Value = vo.MaHH;
            cmd.Parameters.Add("@TenHang", SqlDbType.Text).Value = vo.TenHang;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Text).Value = vo.SoLuong;
            cmd.Parameters.Add("@DonGia", SqlDbType.Text).Value = vo.DonGia;
            da.executeNonQuery(cmd);
        }

        // Delete du lieu
        public void Delete(HangHoaObj vo)
        {
            string str = "delete from tb_HangHoa where MaHH = @MaHH";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            cmd.Parameters.Add("@MaHH", SqlDbType.Text).Value = vo.MaHH;
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
