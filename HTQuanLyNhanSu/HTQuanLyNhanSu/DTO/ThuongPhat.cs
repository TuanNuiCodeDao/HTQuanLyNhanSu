using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DTO
{
    public class ThuongPhat
    {
        private int maTP;
        private string maNV;
        private DateTime ngayQD;
        private string lyDo;
        private int soTien;
        private int phanLoai;
        public ThuongPhat() { }
        public ThuongPhat(DataRow d)
        {
            MaTP = (int)d["MaTP"];
            MaNV = d["MaNV"].ToString();
            NgayQD = (DateTime)d["NgayQD"];
            LyDo = d["LyDo"].ToString();
            SoTien = (int)d["SoTien"];
            PhanLoai = (int)d["Loai"];
        }

        public int MaTP { get => maTP; set => maTP = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public DateTime NgayQD { get => ngayQD; set => ngayQD = value; }
        public string LyDo { get => lyDo; set => lyDo = value; }
        public int SoTien { get => soTien; set => soTien = value; }
        public int PhanLoai { get => phanLoai; set => phanLoai = value; }
    }
}
