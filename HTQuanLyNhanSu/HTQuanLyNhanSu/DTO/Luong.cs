using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DTO
{
    public class Luong
    {
        private int maLuong;
        private string maNV;
        private int mucLuong;
        private DateTime ngayApDung;
        public Luong()
        {
        }
        public Luong(DataRow d)
        {
            MaLuong = (int)d["MaLuong"];
            MaNV = d["MaNV"].ToString();
            MucLuong = (int)d["MucLuong"];
            NgayApDung = (DateTime)d["NgayApDung"];
        }
        public int MaLuong { get => maLuong; set => maLuong = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public int MucLuong { get => mucLuong; set => mucLuong = value; }
        public DateTime NgayApDung { get => ngayApDung; set => ngayApDung = value; }
    }
}
