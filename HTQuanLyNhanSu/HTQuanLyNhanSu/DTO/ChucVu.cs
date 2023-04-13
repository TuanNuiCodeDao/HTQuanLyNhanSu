using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyNhanSu.DTO
{
    public class ChucVu
    {
        private string ma;
        private string ten;
        public ChucVu()
        { }
        public ChucVu(DataRow d)
        {
            Ma = d["MaCV"].ToString();
            Ten = d["TenCV"].ToString();
        }

        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
    }
}
