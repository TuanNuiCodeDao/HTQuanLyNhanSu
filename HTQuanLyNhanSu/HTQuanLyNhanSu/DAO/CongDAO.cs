using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DAO
{
    public class CongDAO
    {
        private static CongDAO instance;
        public static CongDAO Instance
        {
            get { if (instance == null) instance = new CongDAO(); return instance; }
            private set { instance = value; }
        }
        private CongDAO() { }
        public List<Cong> loadDSByThangNam(int thang,int nam)
        {
            List<Cong> l = new List<Cong>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM Cong WHERE Thang="+thang+" AND Nam="+nam);
            foreach (DataRow item in data.Rows)
            {
                Cong i = new Cong(item);
                l.Add(i);
            }
            return l;
        }
        public List<Cong> getByMaNV(string maNV)
        {
            List<Cong> l = new List<Cong>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM Cong WHERE MaNV=N'" + maNV + "'");
            foreach (DataRow item in data.Rows)
            {
                Cong i = new Cong(item);
                l.Add(i);
            }
            return l;
        }
        public Cong getByMaNV_Thang_Nam(string maNV, int thang, int nam)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM Cong WHERE Thang="+thang+" AND Nam="+nam+" AND MaNV=N'"+maNV+"'");
            foreach (DataRow item in data.Rows)
            {
                Cong i = new Cong(item);
                return i;
            }
            return null;
        }
        public Cong getByMa(int ma)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM Cong WHERE MaCong=" + ma);
            foreach (DataRow item in data.Rows)
            {
                Cong l = new Cong(item);
                return l;
            }
            return null;
        }
        public void update()
        {
            DateTime d = DateTime.Now;
            List<Cong> l = loadDSByThangNam(d.Month, d.Year);
            if (l.Count() == 0)
            {
                List<NhanVien> lNV = NhanVienDAO.Instance.loadDS();
                foreach (NhanVien nv in lNV)
                {
                    them(nv.MaNV, d.Month, d.Year, 0, 0);
                }    
            }
        }
        public void them(string maNV,int thang,int nam,int soNgayCong,int soNgayNghiHuongLuong)
        {
            DataProvider.Instance.RunQuery("INSERT INTO Cong(MaNV,Thang,Nam,SoNgayCong,SoNgayNghiHuongLuong)" +
                " VALUES(N'" + maNV + "'," + thang + ","+nam+","+soNgayCong+","+soNgayNghiHuongLuong+")");
        }
        public void sua(int maCong,int soNgayCong, int soNgayNghiHuongLuong)
        {
            Cong c = getByMa(maCong);
            Luong l = LuongDAO.Instance.getNowByMaNV(c.MaNV);
            ThanhToanLuong ttl = ThanhToanLuongDAO.Instance.getByMaCong(maCong);
            int thucLinh = l.MucLuong/30*(soNgayCong+soNgayNghiHuongLuong)+ttl.Thuong-ttl.TamUng-ttl.KhauTruBHXH;
            DataProvider.Instance.RunQuery("UPDATE ThanhToanLuong SET ThucLinh=" + thucLinh + " WHERE MaCong=" + maCong);
            DataProvider.Instance.RunQuery("UPDATE Cong SET SoNgayCong=" + soNgayCong + ",SoNgayNghiHuongLuong=" +
                soNgayNghiHuongLuong + " WHERE MaCong="+maCong);
        }
    }
}
