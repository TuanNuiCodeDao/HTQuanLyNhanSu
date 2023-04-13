using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DAO
{
    public class PhongBanDAO
    {
        private static PhongBanDAO instance;
        public static PhongBanDAO Instance
        {
            get { if (instance == null) instance = new PhongBanDAO(); return instance; }
            private set { instance = value; }
        }
        private PhongBanDAO() { }
        public List<PhongBan> loadDS()
        {
            List<PhongBan> l = new List<PhongBan>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM PhongBan");
            foreach (DataRow item in data.Rows)
            {
                PhongBan i = new PhongBan(item);
                l.Add(i);
            }
            return l;
        }
        public PhongBan getByMa(string ma)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM PhongBan WHERE MaPB=N'" + ma + "'");
            foreach (DataRow item in data.Rows)
            {
                PhongBan l = new PhongBan(item);
                return l;
            }
            return null;
        }
        public PhongBan getByTen(string ten)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM PhongBan WHERE TenPB=N'" + ten + "'");
            foreach (DataRow item in data.Rows)
            {
                PhongBan l = new PhongBan(item);
                return l;
            }
            return null;
        }
        public void them(string ma,string ten)
        {
            DataProvider.Instance.RunQuery("INSERT INTO PhongBan VALUES(N'"+ma+"',N'" + ten + "')");
        }
        public void sua(string ma, string ten)
        {
            DataProvider.Instance.RunQuery("UPDATE PhongBan SET TenPB=N'" + ten + "' WHERE MaPB=N'" + ma+ "'");
        }
        public void xoa(string ma)
        {
            List<NhanVien> l = NhanVienDAO.Instance.loadDSByMaPB(ma);
            foreach (NhanVien i in l)
            {
                NhanVienDAO.Instance.xoa(i.MaNV);
            }
            DataProvider.Instance.RunQuery("DELETE FROM PhongBan WHERE MaPB = N'" + ma + "'");
        }
    }
}
