﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.Model;
using QuanLyBanHang.Object;

namespace QuanLyBanHang.Control
{
    public class KhachHangCtrl
    {
        private KhachHangMod sql = new KhachHangMod();

        public DataSet GetDataSet()
        {
            return sql.GetDataSet();
        }

        public bool Add(KhachHangObj vo)
        {
            return sql.Add(vo);
        }
        public bool Update(KhachHangObj vo)
        {
            return sql.Update(vo);
        }
        public bool Delete(KhachHangObj vo)
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
