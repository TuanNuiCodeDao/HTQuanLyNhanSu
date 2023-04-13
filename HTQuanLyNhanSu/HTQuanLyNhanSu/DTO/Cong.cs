using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DTO
{
    public class Cong
    {
        private int maCong;
        private string maNV;
        private int soNgayCong;
        private int soNgayNghiHuongLuong;
        private int thang;
        private int nam;
        public Cong()
        {

        }
        public Cong(DataRow d)
        {
            MaCong = (int)d["MaCong"];
            MaNV = (string)d["MaNV"];
            SoNgayCong = (int)d["SoNgayCong"];
            SoNgayNghiHuongLuong = (int)d["SoNgayNghiHuongLuong"];
            Thang = (int)d["Thang"];
            Nam = (int)d["Nam"];
        }

        public int MaCong { get => maCong; set => maCong = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public int SoNgayCong { get => soNgayCong; set => soNgayCong = value; }
        public int SoNgayNghiHuongLuong { get => soNgayNghiHuongLuong; set => soNgayNghiHuongLuong = value; }
        public int Thang { get => thang; set => thang = value; }
        public int Nam { get => nam; set => nam = value; }
    }
}
