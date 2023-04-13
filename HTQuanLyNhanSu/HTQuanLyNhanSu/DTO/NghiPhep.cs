using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DTO
{
    public class NghiPhep
    {
        private int maNP;
        private string maNV;
        private DateTime ngayBD;
        private DateTime ngayKT;
        private string lyDo;
        private int huongLuong;
        public NghiPhep() { }
        public NghiPhep(DataRow d)
        {
            maNP = (int)d["MaNP"];
            maNV = (string)d["MaNV"];
            ngayBD = (DateTime)d["NgayBD"];
            ngayKT = (DateTime)d["NgayKT"];
            lyDo = (string)d["LyDo"];
            huongLuong = (int)d["HuongLuong"];
        }
        public int MaNP { get => maNP; set => maNP = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public DateTime NgayBD { get => ngayBD; set => ngayBD = value; }
        public DateTime NgayKT { get => ngayKT; set => ngayKT = value; }
        public string LyDo { get => lyDo; set => lyDo = value; }
        public int HuongLuong { get => huongLuong; set => huongLuong = value; }
    }
}
