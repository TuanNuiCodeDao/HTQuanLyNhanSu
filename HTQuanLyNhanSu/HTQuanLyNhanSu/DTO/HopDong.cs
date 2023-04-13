using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DTO
{
    public  class HopDong
    {
        private string maHD;
        private string maNV;
        private DateTime ngayBD;
        private DateTime ngayKT;
        private int trangThai;
        public HopDong()
        {

        }   
        public HopDong(DataRow d)
        {
            MaHD = d["MaHD"].ToString();
            MaNV = d["MaNV"].ToString();
            NgayBD = (DateTime)d["NgayBD"];
            NgayKT = (DateTime)d["NgayKT"];
            TrangThai = (int)d["TrangThai"];
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public DateTime NgayBD { get => ngayBD; set => ngayBD = value; }
        public DateTime NgayKT { get => ngayKT; set => ngayKT = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
    }
}
