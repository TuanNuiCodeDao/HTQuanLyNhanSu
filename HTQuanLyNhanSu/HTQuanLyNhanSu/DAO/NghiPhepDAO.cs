using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DAO
{
    public class NghiPhepDAO
    {
        private static NghiPhepDAO instance;
        public static NghiPhepDAO Instance
        {
            get { if (instance == null) instance = new NghiPhepDAO(); return instance; }
            private set { instance = value; }
        }
        private NghiPhepDAO() { }
        public List<NghiPhep> loadDS()
        {
            List<NghiPhep> l = new List<NghiPhep>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM NghiPhep ORDER  BY MaNP DESC");
            foreach (DataRow item in data.Rows)
            {
                NghiPhep i = new NghiPhep(item);
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
        public NghiPhep getNowByMaNV(string maNV)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM NghiPhep WHERE MaNV=N'" + maNV + "'");
            NghiPhep l = null;
            foreach (DataRow item in data.Rows)
            {
                l = new NghiPhep(item);
            }
            return l;
        }
        public NghiPhep getByMa(int ma)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM NghiPhep WHERE MaNP=" + ma);
            foreach (DataRow item in data.Rows)
            {
                NghiPhep l = new NghiPhep(item);
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
        public void them(string maNV, DateTime ngayBD,DateTime ngayKT,string lyDo,int huongLuong)
        {
            DataProvider.Instance.RunQuery("INSERT INTO NghiPhep(MaNV,NgayBD,NgayKT,LyDo,HuongLuong) " +
                "VALUES(N'" + maNV + "','" + DataProvider.Instance.getDateSql(ngayBD) + "','"+ DataProvider.Instance.getDateSql(ngayKT) + "',N'"+lyDo+"',"+ huongLuong + ")");
        }
        public void sua(int maNP,DateTime ngayBD, DateTime ngayKT, string lyDo, int huongLuong)
        {
            DataProvider.Instance.RunQuery("UPDATE NghiPhep SET NgayBD='" + DataProvider.Instance.getDateSql(ngayBD) + "',NgayKT='" + DataProvider.Instance.getDateSql(ngayKT) + "',LyDo=N'" + lyDo + "',HuongLuong=" + huongLuong +" WHERE MaNP="+maNP);
        }
        public void xoa(int maNP)
        {
            DataProvider.Instance.RunQuery("DELETE FROM NghiPhep WHERE MaNP="+maNP);
        }
    }
}
