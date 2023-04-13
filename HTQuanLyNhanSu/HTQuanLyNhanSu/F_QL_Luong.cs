using HTQuanLyNhanSu.DAO;
using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQuanLyNhanSu
{
    public partial class F_QL_Luong : Form
    {
        private string maNV;
        public F_QL_Luong(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            load();
        }
        private void load()
        {
            NhanVien nv = NhanVienDAO.Instance.getByMa(maNV);
            tbMaNV.Text = nv.MaNV;
            tbHoTen.Text = nv.HoTen;
            loadDS();
        }
        private void loadDS()
        {
            List<Luong> l = LuongDAO.Instance.loadDSByMaNV(maNV);
            dgvLuong.Rows.Clear();
            foreach (Luong i in l)
            {
                dgvLuong.Rows.Add(i.MaLuong, i.NgayApDung.ToShortDateString(), 
                    DataProvider.Instance.getDinhDanhHangNghin(i.MucLuong)+" VNĐ");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LuongDAO.Instance.them(maNV, (int)nudMucLuong.Value);
            loadDS();
            MessageBox.Show("Điều chỉnh thành công", "Thông báo");
        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = dgvLuong.Rows[e.RowIndex];
                tbMaLuong.Text = r.Cells[0].Value.ToString();
                Luong l = LuongDAO.Instance.getByMa(int.Parse(tbMaLuong.Text));
                nudMucLuong.Value = l.MucLuong;
                tbNgayApDung.Text = l.NgayApDung.ToShortDateString();
            }catch(Exception ex)
            { }
        }
    }
}
