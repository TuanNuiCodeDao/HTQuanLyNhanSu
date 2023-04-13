using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DTO
{
    public class DangNhap
    {
        private string taiKhoan;
        private string matKhau;
        public DangNhap() { }
        public DangNhap(DataRow d)
        {
            TaiKhoan = d["TenDangNhap"].ToString();
            MatKhau = d["MatKhau"].ToString();
        }

        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
