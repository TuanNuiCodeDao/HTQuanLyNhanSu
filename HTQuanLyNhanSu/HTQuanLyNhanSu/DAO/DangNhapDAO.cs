using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DAO
{
    public class DangNhapDAO
    {
        private static DangNhapDAO instance;
        public static DangNhapDAO Instance
        {
            get { if (instance == null) instance = new DangNhapDAO(); return instance; }
            private set { instance = value; }
        }
        private DangNhapDAO() { }
        public bool check(string tenDN,string matKhau)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM DangNhap WHERE TenDangNhap=N'"+ tenDN + "' AND MatKhau=N'"+matKhau+"'");
            foreach (DataRow item in data.Rows)
            {
                return true;
            }
            return false;
        }
        public DangNhap getDangNhap()
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM DangNhap");
            foreach (DataRow item in data.Rows)
            {
                DangNhap i = new DangNhap(item);
                return i;
            }
            return null;
        }
        public void  capNhat(string tk,string mk)
        {
            DataProvider.Instance.RunQuery("UPDATE DangNhap SET TenDangNhap=N'" + tk + "',MatKhau=N'" + mk + "'");
        }
    }
}
