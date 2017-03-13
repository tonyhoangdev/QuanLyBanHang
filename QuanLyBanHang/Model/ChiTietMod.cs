using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;
using System.Data;
using QuanLyBanHang.Object;

namespace QuanLyBanHang.Model
{
    public class ChiTietMod
    {
        private SQLiteDatabaseAccess da = new SQLiteDatabaseAccess();

        public DataSet GetDataSet()
        {
            string str = "select ct.MaHD, hh.TenHang, ct.DonGia, ct.SoLuong, from tb_CTHD ct, tb_HangHoa hh where ct.MaHH = hh.MaHH";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            return da.excuteQuery(cmd);
        }

        public DataSet GetDataSet(string maHD)
        {
            string str = "select ct.MaHD, hh.TenHang, ct.DonGia, ct.SoLuong from tb_CTHD ct, tb_HangHoa hh where ct.MaHH = hh.MaHH and ct.MaHD = @MaHD";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            cmd.Parameters.Add("@MaHD", SqlDbType.Text).Value = maHD;
            return da.excuteQuery(cmd);
        }


        public DataTable GetDataSetHH(string maHH)
        {
            string str = "select * from tb_HangHoa where MaHH = @MaHH";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            cmd.Parameters.Add("@MaHH", SqlDbType.Text).Value = maHH;
            return da.excuteQuery(cmd).Tables[0];
        }

        public bool Add(ChiTietObj vo)
        {
            string str = "insert into tb_CTHD (MaHD, MaHH, SoLuong, DonGia) values (@MaHD, @MaHH, @SoLuong, @DonGia)";
            SQLiteCommand cmd = new SQLiteCommand(str, da.Conn);
            cmd.Parameters.Add("@MaHD", SqlDbType.Text).Value = vo.MaHD;
            cmd.Parameters.Add("@MaHH", SqlDbType.Text).Value = vo.MaHH;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = vo.SoLuong;
            cmd.Parameters.Add("@DonGia", SqlDbType.Int).Value = vo.DonGia;
            return da.executeNonQuery(cmd);
        }
        public bool Add(DataTable dt)
        {
            bool flag = true;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChiTietObj vo = new ChiTietObj();
                    vo.MaHD = dt.Rows[i][0].ToString();
                    vo.MaHH = dt.Rows[i][1].ToString();
                    vo.SoLuong = int.Parse(dt.Rows[i][2].ToString());
                    vo.DonGia = int.Parse(dt.Rows[i][3].ToString());

                    flag = Add(vo);
                }
            }
            catch (Exception)
            {
            }

            return flag;
        }

        // Update du lieu
        public bool Update(ChiTietObj vo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_CTHD ");
            sb.Append("set MaHH = @MaHH, SoLuong = @SoLuong, DonGia = @DonGia ");
            sb.Append("where MaHD = @MaHD");
            SQLiteCommand cmd = new SQLiteCommand(sb.ToString(), da.Conn);
            cmd.Parameters.Add("@MaHD", SqlDbType.Text).Value = vo.MaHD;
            cmd.Parameters.Add("@MaHH", SqlDbType.Text).Value = vo.MaHH;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Text).Value = vo.SoLuong;
            cmd.Parameters.Add("@DonGia", SqlDbType.Text).Value = vo.DonGia;
            return da.executeNonQuery(cmd);
        }

        // Delete du lieu
        public bool Delete(ChiTietObj vo)
        {
            string str = "delete from tb_CTHD where MaHD = @MaHD";
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
