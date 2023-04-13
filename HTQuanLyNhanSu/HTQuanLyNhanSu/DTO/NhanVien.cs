using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DTO
{
    public class NhanVien
    {
        private string maNV;
        private string hoTen;
        private int gioiTinh;
        private DateTime ngaySinh;
        private string sdt;
        private string danToc;
        private string tonGiao;
        private string soCMND;
        private int dangVien;
        private string maPB;
        private string maCV;
        private string soBHYT;
        private string soBHXH;
        private string hocVan;
        private string ngoaiNgu;
        private string queQuan;
        private string diaChi;
        private string anh;
        public NhanVien()
        { }
        public NhanVien(DataRow d)
        {
            MaNV = d["MaNV"].ToString();
            HoTen = d["HoTen"].ToString();
            GioiTinh = (int)d["GioiTinh"];
            NgaySinh = (DateTime)d["NgaySinh"];
            Sdt = d["SDT"].ToString();
            DanToc = d["DanToc"].ToString();
            TonGiao = d["TonGiao"].ToString();
            SoCMND = d["CMND"].ToString();
            DangVien = (int)d["DangVien"];
            MaPB = d["MaPB"].ToString();
            MaCV = d["MaCV"].ToString();
            SoBHYT = d["BHYT"].ToString();
            SoBHXH = d["BHXH"].ToString();
            HocVan = d["HocVan"].ToString();
            NgoaiNgu = d["NgoaiNgu"].ToString();
            QueQuan = d["QueQuan"].ToString();
            DiaChi = d["DiaChi"].ToString();
            Anh = d["Anh"].ToString();
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DanToc { get => danToc; set => danToc = value; }
        public string TonGiao { get => tonGiao; set => tonGiao = value; }
        public string SoCMND { get => soCMND; set => soCMND = value; }
        public int DangVien { get => dangVien; set => dangVien = value; }
        public string MaPB { get => maPB; set => maPB = value; }
        public string MaCV { get => maCV; set => maCV = value; }
        public string SoBHYT { get => soBHYT; set => soBHYT = value; }
        public string SoBHXH { get => soBHXH; set => soBHXH = value; }
        public string HocVan { get => hocVan; set => hocVan = value; }
        public string NgoaiNgu { get => ngoaiNgu; set => ngoaiNgu = value; }
        public string QueQuan { get => queQuan; set => queQuan = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Anh { get => anh; set => anh = value; }
    }
}
