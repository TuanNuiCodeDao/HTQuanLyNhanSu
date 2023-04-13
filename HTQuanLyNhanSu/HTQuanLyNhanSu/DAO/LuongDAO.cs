using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DAO
{
    public class LuongDAO
    {
        private static LuongDAO instance;
        public static LuongDAO Instance
        {
            get { if (instance == null) instance = new LuongDAO(); return instance; }
            private set { instance = value; }
        }
        private LuongDAO() { }
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
        public List<Luong> loadDSByMaNV(string maNV)
        {
            List<Luong> l = new List<Luong>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM Luong WHERE MaNV=N'" + maNV + "'");
            foreach (DataRow item in data.Rows)
            {
                Luong i = new Luong(item);
                l.Add(i);
            }
            return l;
        }
        public Luong getNowByMaNV(string maNV)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM Luong WHERE MaNV=N'" + maNV + "'");
            Luong l = null;
            foreach (DataRow item in data.Rows)
            {
                l = new Luong(item);
            }
            return l;
        }
        public Luong getByMa(int ma)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM Luong WHERE MaLuong=" + ma );
            foreach (DataRow item in data.Rows)
            {
                Luong l = new Luong(item);
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
        public void them(string maNV, int mucLuong)
        {
            DataProvider.Instance.RunQuery("INSERT INTO Luong(MaNV,MucLuong) VALUES(N'" + maNV + "'," + mucLuong + ")");
        }
    }
}
