using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DAO
{
    public class HopDongDAO
    {
        private static HopDongDAO instance;
        public static HopDongDAO Instance
        {
            get { if (instance == null) instance = new HopDongDAO(); return instance; }
            private set { instance = value; }
        }
        private HopDongDAO() { }
        public List<HopDong> loadDS()
        {
            List<HopDong> l = new List<HopDong>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM HopDong");
            foreach (DataRow item in data.Rows)
            {
                HopDong i = new HopDong(item);
                l.Add(i);
            }
            return l;
        }
        public List<HopDong> loadDSByMaNV(string maNV)
        {
            List<HopDong> l = new List<HopDong>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM HopDong WHERE MaNV=N'"+maNV+"'");
            foreach (DataRow item in data.Rows)
            {
                HopDong i = new HopDong(item);
                l.Add(i);
            }
            return l;
        }
        public HopDong getConHieuLucByMaNV(string maNV)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM HopDong WHERE MaNV=N'" + maNV + "' AND TrangThai=1");
            foreach (DataRow item in data.Rows)
            {
                HopDong l = new HopDong(item);
                return l;
            }
            return null;
        }
        public HopDong getByMa(string ma)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM HopDong WHERE MaHD=N'" + ma + "'");
            foreach (DataRow item in data.Rows)
            {
                HopDong l = new HopDong(item);
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
        private string getMa()
        {
            List<HopDong> l = loadDS();
            if (l.Count == 0) return "HD0001";
            string ma = l[l.Count - 1].MaHD;
            string tam = "";
            for (int i = 2; i < ma.Length; i++)
                tam += ma[i];
            int so = int.Parse(tam);
            so++;
            string s = so + "";
            ma = "HD";
            for (int i = 0; i < 4 - s.Length; i++)
                ma += "0";
            ma += s;
            return ma;
        }
        public void update()
        {
            DataProvider.Instance.RunQuery("UPDATE HopDong SET TrangThai=2 WHERE NgayKT<GETDATE()");
        }
        public void them(string maNV,DateTime ngayBD,DateTime ngayKT)
        {
            DataProvider.Instance.RunQuery("INSERT INTO HopDong VALUES(N'" + getMa() + "',N'" + maNV + "','"+
                DataProvider.Instance.getDateSql(ngayBD)+"','"+ DataProvider.Instance.getDateSql(ngayKT) + "',1)");
        }
        public void sua(string maHD,DateTime ngayBD, DateTime ngayKT)
        {
            DataProvider.Instance.RunQuery("UPDATE HopDong SET NgayBD='" +
                DataProvider.Instance.getDateSql(ngayBD) + "',NgayKT='" + DataProvider.Instance.getDateSql(ngayKT) + "' WHERE MaHD=N'"+maHD+"'");
        }
        public void huy(string ma)
        {
            DataProvider.Instance.RunQuery("UPDATE HopDong SET TrangThai=0 WHERE MaHD = N'" + ma + "'");
        }
    }
}
