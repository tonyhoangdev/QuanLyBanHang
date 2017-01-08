using QuanLyBanHang.Model;
using QuanLyBanHang.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Control
{
    class NhanVienCtrl
    {
        private NhanVienMod sql = new NhanVienMod();
        
        public DataSet GetDataSet()
        {
            return sql.GetDataSet();
        }

        public void Add(NhanVienObj vo)
        {
            sql.Add(vo);
        }

        public void DelAllFrom3()
        {
            sql.DelAllFrom3();
        }

        public void CLeanUpDatabase()
        {
            sql.CleanUpDatabase();
        }
    }
}
