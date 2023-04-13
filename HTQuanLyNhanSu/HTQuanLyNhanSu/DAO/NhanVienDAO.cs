using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;
        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set { instance = value; }
        }
        private NhanVienDAO() { }
        public List<NhanVien> loadDS()
        {
            List<NhanVien> l = new List<NhanVien>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM NhanVien");
            foreach (DataRow item in data.Rows)
            {
                NhanVien i = new NhanVien(item);
                l.Add(i);
            }
            return l;
        }
        public List<NhanVien> loadDSByMaCV(string maCV)
        {
            List<NhanVien> l = new List<NhanVien>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM NhanVien WHERE MaCV=N'" + maCV + "'");
            foreach (DataRow item in data.Rows)
            {
                NhanVien i = new NhanVien(item);
                l.Add(i);
            }
            return l;
        }
        public List<NhanVien> loadDSByMaPB(string maPB)
        {
            List<NhanVien> l = new List<NhanVien>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM NhanVien WHERE MaPB=N'"+maPB+"'");
            foreach (DataRow item in data.Rows)
            {
                NhanVien i = new NhanVien(item);
                l.Add(i);
            }
            return l;
        }
        public NhanVien getByMa(string ma)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM NhanVien WHERE MaNV=N'" + ma + "'");
            foreach (DataRow item in data.Rows)
            {
                NhanVien i = new NhanVien(item);
                return i;
            }
            return null;
        }
        private string getMa()
        {
            List<NhanVien> l = loadDS();
            if (l.Count == 0) return "NV0001";
            string ma = l[l.Count - 1].MaNV;
            string tam = "";
            for (int i = 2; i < ma.Length; i++)
                tam += ma[i];
            int so = int.Parse(tam);
            so++;
            string s = so + "";
            ma = "NV";
            for (int i = 0; i < 4 - s.Length; i++)
                ma += "0";
            ma += s;
            return ma;
        }
        public NhanVien getByCMND(string cmnd)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM NhanVien WHERE CMND=N'" + cmnd + "'");
            foreach (DataRow item in data.Rows)
            {
                NhanVien i = new NhanVien(item);
                return i;
            }
            return null;
        }
        public void them(string hoTen,int gioiTinh, DateTime ngaySinh,string sdt, string danToc,string tonGiao,string soCMND, int dangVien,
            string maPB,string maCV,string soBHYT,string soBHXH,string hocVan,string ngoaiNgu,string queQuan,string diaChi,string anh)
        {
            DataProvider.Instance.RunQuery("INSERT INTO NhanVien VALUES(N'" + getMa() + "',N'" + hoTen + "',"+gioiTinh+",'"
                +DataProvider.Instance.getDateSql(ngaySinh)+"',N'"+sdt+"',N'"+danToc+"',N'"+tonGiao+"',N'"+soCMND+"',"+dangVien
                +",N'"+maPB+"',N'"+maCV+"',N'"+soBHYT+"',N'"+soBHXH+"',N'"+hocVan+"',N'"+ngoaiNgu
                +"',N'"+ queQuan + "',N'"+diaChi+"',N'"+anh+"')");
            DateTime d = DateTime.Now;
            List<NhanVien> l = loadDS();
            string ma = l[l.Count - 1].MaNV;
            CongDAO.Instance.them(ma, d.Month, d.Year, 0, 0);
        }
        public void sua(string maNV,string hoTen, int gioiTinh, DateTime ngaySinh, string sdt, string danToc, string tonGiao, string soCMND, int dangVien,
            string maPB, string maCV, string soBHYT, string soBHXH, string hocVan, string ngoaiNgu, string queQuan, string diaChi, string anh)
        {
            DataProvider.Instance.RunQuery("UPDATE NhanVien SET HoTen=N'" + hoTen + "',GioiTinh=" + gioiTinh + ",NgaySinh='"
                + DataProvider.Instance.getDateSql(ngaySinh) + "',SDT=N'" + sdt + "',DanToc=N'" + danToc + "',TonGiao=N'" + tonGiao 
                + "',CMND=N'" + soCMND + "',DangVien=" + dangVien
                + ",MaPB=N'" + maPB + "',MaCV=N'" + maCV + "',BHYT=N'" + soBHYT + "',BHXH=N'" + soBHXH + "',HocVan=N'" + hocVan + 
                "',NgoaiNgu=N'" + ngoaiNgu
                + "',QueQuan=N'" + queQuan + "',DiaChi=N'" + diaChi + "',Anh=N'" + anh + "' WHERE MaNV=N'"+maNV+"'");
        }
        public void xoa(string ma)
        {
            List<Cong> l = CongDAO.Instance.getByMaNV(ma);
            foreach(Cong cong in l)
            {
                DataProvider.Instance.RunQuery("DELETE FROM ThanhToanLuong WHERE MaCong = " + cong.MaCong );
            }
            DataProvider.Instance.RunQuery("DELETE FROM NghiPhep WHERE MaNV = N'" + ma + "'");
            DataProvider.Instance.RunQuery("DELETE FROM HopDong WHERE MaNV = N'" + ma + "'");
            DataProvider.Instance.RunQuery("DELETE FROM Luong WHERE MaNV = N'" + ma + "'");
            DataProvider.Instance.RunQuery("DELETE FROM Cong WHERE MaNV = N'" + ma + "'");
            DataProvider.Instance.RunQuery("DELETE FROM ThuongPhat WHERE MaNV = N'" + ma + "'");
            DataProvider.Instance.RunQuery("DELETE FROM NhanVien WHERE MaNV = N'" + ma + "'");
        }
    }
}
