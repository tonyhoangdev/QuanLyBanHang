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
    class NhanVienCtrl
    {
        private NhanVienMod sql = new NhanVienMod();

        public DataSet GetDataSet()
        {
            return sql.GetDataSet();
        }

        public bool Add(NhanVienObj vo)
        {
            return sql.Add(vo);
        }
        public bool Update(NhanVienObj vo)
        {
            return sql.Update(vo);
        }
        public bool Delete(NhanVienObj vo)
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
