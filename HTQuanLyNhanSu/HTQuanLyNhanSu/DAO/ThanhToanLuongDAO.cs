using DocumentFormat.OpenXml.Wordprocessing;
using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DAO
{
    public class ThanhToanLuongDAO
    {
        private static ThanhToanLuongDAO instance;
        public static ThanhToanLuongDAO Instance
        {
            get { if (instance == null) instance = new ThanhToanLuongDAO(); return instance; }
            private set { instance = value; }
        }
        private ThanhToanLuongDAO() { }
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
        public ThanhToanLuong getByMaCong(int maCong)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM ThanhToanLuong WHERE MaCong=" + maCong);
            foreach (DataRow item in data.Rows)
            {
                ThanhToanLuong i = new ThanhToanLuong(item);
                return i;
            }
            return null;
        }
        public ThanhToanLuong getByMa(int ma)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM ThanhToanLuong WHERE MaTTL=" + ma);
            foreach (DataRow item in data.Rows)
            {
                ThanhToanLuong i = new ThanhToanLuong(item);
                return i;
            }
            return null;
        }
        public void sua(int maTTL,int tamUng,int thuong,int BHXH)
        {
            ThanhToanLuong ttl = getByMa(maTTL);
            int thucLinh = ttl.ThucLinh - ttl.Thuong + ttl.KhauTruBHXH + ttl.TamUng - tamUng - BHXH + thuong;
            DataProvider.Instance.RunQuery("UPDATE ThanhToanLuong SET TamUng="+tamUng+",Thuong="+thuong+",KhauTruBHXH="+BHXH+
                ",ThucLinh="+thucLinh+" WHERE MaTTL="+maTTL);
        }
        public void thanhToan(int maTTL)
        {
            DataProvider.Instance.RunQuery("UPDATE ThanhToanLuong SET TrangThai=1 WHERE MaTTL=" + maTTL);
        }
    }
}
