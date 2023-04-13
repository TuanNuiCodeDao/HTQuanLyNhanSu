using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DAO
{
    public class ThuongPhatDAO
    {
        private static ThuongPhatDAO instance;
        public static ThuongPhatDAO Instance
        {
            get { if (instance == null) instance = new ThuongPhatDAO(); return instance; }
            private set { instance = value; }
        }
        private ThuongPhatDAO() { }
        public List<ThuongPhat> loadDS()
        {
            List<ThuongPhat> l = new List<ThuongPhat>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM ThuongPhat ORDER BY MaTP DESC");
            foreach (DataRow item in data.Rows)
            {
                ThuongPhat i = new ThuongPhat(item);
                l.Add(i);
            }
            return l;
        }
        public ThuongPhat getByMa(int ma)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM ThuongPhat WHERE MaTP=" + ma);
            foreach (DataRow item in data.Rows)
            {
                ThuongPhat l = new ThuongPhat(item);
                return l;
            }
            return null;
        }
        public void them(string maNV,string lyDo, int soTien,int phanLoai)
        {
            DataProvider.Instance.RunQuery("INSERT INTO ThuongPhat(MaNV,LyDo,SoTien,Loai) VALUES(N'" + maNV + "',N'" + lyDo + "',"+
                soTien+","+phanLoai+")");
        }
        public void sua(int maTP,string maNV, string lyDo, int soTien, int phanLoai)
        {
            DataProvider.Instance.RunQuery("UPDATE ThuongPhat SET MaNV=N'" + maNV + "',LyDo=N'" + lyDo + "',SoTien=" +
                soTien + ",Loai=" + phanLoai + " WHERE MaTP="+maTP);
        }
        public void xoa(int maTP)
        {
            DataProvider.Instance.RunQuery("DELETE FROM ThuongPhat WHERE MaTP="+maTP);
        }
    }
}
