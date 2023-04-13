using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DTO
{
    public class PhongBan
    {
        private string ma;
        private string ten;
        public PhongBan()
        { }
        public PhongBan(DataRow d)
        {
            Ma = d["MaPB"].ToString();
            Ten = d["TenPB"].ToString();
        }

        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
    }
}
