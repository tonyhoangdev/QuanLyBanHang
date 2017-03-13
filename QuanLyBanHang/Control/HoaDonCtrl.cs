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
    public class HoaDonCtrl
    {
        private HoaDonMod sql = new HoaDonMod();

        public DataSet GetDataSet()
        {
            return sql.GetDataSet();
        }

        public bool Add(HoaDonObj vo)
        {
            return sql.Add(vo);
        }

        public bool Update(HoaDonObj vo)
        {
            return sql.Update(vo);
        }
        public bool Delete(HoaDonObj vo)
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
