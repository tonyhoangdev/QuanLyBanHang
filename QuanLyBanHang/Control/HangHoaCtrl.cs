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
    public class HangHoaCtrl
    {
        private HangHoaMod sql = new HangHoaMod();

        public DataSet GetDataSet()
        {
            return sql.GetDataSet();
        }

        public void Add(HangHoaObj vo)
        {
            sql.Add(vo);
        }
        public void Update(HangHoaObj vo)
        {
            sql.Update(vo);
        }
        public void Delete(HangHoaObj vo)
        {
            sql.Delete(vo);
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
