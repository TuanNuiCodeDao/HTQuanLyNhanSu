using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DAO
{
    public class ChucVuDAO
    {
        private static ChucVuDAO instance;
        public static ChucVuDAO Instance
        {
            get { if (instance == null) instance = new ChucVuDAO(); return instance; }
            private set { instance = value; }
        }
        private ChucVuDAO() { }
        public List<ChucVu> loadDS()
        {
            List<ChucVu> l = new List<ChucVu>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM ChucVu");
            foreach (DataRow item in data.Rows)
            {
                ChucVu i = new ChucVu(item);
                l.Add(i);
            }
            return l;
        }
        public ChucVu getByMa(string ma)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM ChucVu WHERE MaCV=N'" + ma + "'");
            foreach (DataRow item in data.Rows)
            {
                ChucVu l = new ChucVu(item);
                return l;
            }
            return null;
        }
        public ChucVu getByTen(string ten)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM ChucVu WHERE TenCV=N'" + ten + "'");
            foreach (DataRow item in data.Rows)
            {
                ChucVu l = new ChucVu(item);
                return l;
            }
            return null;
        }
        public void them(string ma, string ten)
        {
            DataProvider.Instance.RunQuery("INSERT INTO ChucVu VALUES(N'" + ma + "',N'" + ten + "')");
        }
        public void sua(string ma, string ten)
        {
            DataProvider.Instance.RunQuery("UPDATE ChucVu SET TenCV=N'" + ten + "' WHERE MaCV=N'" + ma + "'");
        }
        public void xoa(string ma)
        {
            List<NhanVien> l = NhanVienDAO.Instance.loadDSByMaCV(ma);
            foreach (NhanVien i in l)
            {
                NhanVienDAO.Instance.xoa(i.MaNV);
            }
            DataProvider.Instance.RunQuery("DELETE FROM ChucVu WHERE MaCV = N'" + ma + "'");
        }
    }
}
