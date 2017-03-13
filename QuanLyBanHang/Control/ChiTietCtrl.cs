using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.Model;
using QuanLyBanHang.Object;

namespace QuanLyBanHang.Control
{
    public class ChiTietCtrl
    {
        private ChiTietMod sql = new ChiTietMod();

        public DataSet GetDataSet()
        {
            return sql.GetDataSet();
        }

        public DataSet GetDataSet(string maHD)
        {
            return sql.GetDataSet(maHD);
        }

        public DataTable GetDataSetHH(string maHH)
        {
            return sql.GetDataSetHH(maHH);
        }

        public bool Add(ChiTietObj vo)
        {
            return sql.Add(vo);
        }
        public bool Add(DataTable dt)
        {
            return sql.Add(dt);
        }
        public bool Update(ChiTietObj vo)
        {
            return sql.Update(vo);
        }
        public bool Delete(ChiTietObj vo)
        {
            return sql.Delete(vo);
        }

        public bool DelAllFrom3()
        {
            return sql.DelAllFrom3();
        }

        public bool CLeanUpDatabase()
        {
            return sql.CleanUpDatabase();
        }
    }
}
