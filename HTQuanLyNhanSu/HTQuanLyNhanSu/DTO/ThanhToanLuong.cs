using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DTO
{
    public class ThanhToanLuong
    {
        private int maTTL;
        private int maCong;
        private int tamUng;
        private int thuong;
        private int khauTruBHXH;
        private int thucLinh;
        private int trangThai;
        public ThanhToanLuong()
        { }
        public ThanhToanLuong(DataRow d)
        {
            MaTTL = (int)d["MaTTL"];
            MaCong = (int)d["MaCong"];
            TamUng = (int)d["TamUng"];
            Thuong = (int)d["Thuong"];
            KhauTruBHXH = (int)d["KhauTruBHXH"];
            ThucLinh = (int)d["ThucLinh"];
            TrangThai = (int)d["TrangThai"];
        }

        public int MaTTL { get => maTTL; set => maTTL = value; }
        public int MaCong { get => maCong; set => maCong = value; }
        public int TamUng { get => tamUng; set => tamUng = value; }
        public int Thuong { get => thuong; set => thuong = value; }
        public int KhauTruBHXH { get => khauTruBHXH; set => khauTruBHXH = value; }
        public int ThucLinh { get => thucLinh; set => thucLinh = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
    }
}
