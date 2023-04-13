using DocumentFormat.OpenXml.Bibliography;
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

namespace HTQuanLyNhanSu.DAO
{
    public partial class F_QL_ChamCong : Form
    {
        public F_QL_ChamCong()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            dateThangNam.ShowUpDown = true;
            loadDS();
        }
        private void loadDS()
        {
            DateTime d=dateThangNam.Value;
            List<Cong> l = CongDAO.Instance.loadDSByThangNam(d.Month, d.Year);
            dgvChamCong.Rows.Clear();
            foreach (Cong item in l )
            {
                NhanVien nv = NhanVienDAO.Instance.getByMa(item.MaNV);
                dgvChamCong.Rows.Add(item.MaCong, nv.MaNV, nv.HoTen, item.SoNgayCong, item.SoNgayNghiHuongLuong);
            }
        }

        private void dateThangNam_ValueChanged(object sender, EventArgs e)
        {
            loadDS();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime d = dateThangNam.Value;
            int thang = d.Month;
            int nam = d.Year;
            int soNgay = DateTime.DaysInMonth(nam, thang);
            foreach (DataGridViewRow r in dgvChamCong.Rows)
            {
                try
                {
                    int soN = int.Parse(r.Cells[3].Value.ToString());
                    if (soN < 0 || soN > soNgay)
                    {
                        MessageBox.Show("Giá trị số ngày công và số ngày nghỉ hưởng lương phải nằm trong đoạn [0;" + soNgay + "] !", "Nhắc nhở");
                        return;
                    }
                    soN = int.Parse(r.Cells[4].Value.ToString());
                    if (soN < 0 || soN > soNgay)
                    {
                        MessageBox.Show("Giá trị số ngày công và số ngày nghỉ hưởng lương phải nằm trong đoạn [0;" + soNgay + "] !", "Nhắc nhở");
                        return;
                    }
                    if (int.Parse(r.Cells[4].Value.ToString())+ int.Parse(r.Cells[3].Value.ToString())>soNgay)
                    {
                        MessageBox.Show("Giá trị số ngày công và số ngày nghỉ hưởng lương không hợp lệ !", "Nhắc nhở");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Số ngày công và số ngày nghỉ hưởng lương không hợp lệ !", "Nhắc nhở");
                    return;
                }
            }
            foreach (DataGridViewRow r in dgvChamCong.Rows)
            {
                int soNgayCong = int.Parse(r.Cells[3].Value.ToString());
                int soNgayNghiHuongLuong = int.Parse(r.Cells[4].Value.ToString());
                int maCong= int.Parse(r.Cells[0].Value.ToString());
                ThanhToanLuong ttl = ThanhToanLuongDAO.Instance.getByMaCong(maCong);
                if(ttl.TrangThai==0)
                    CongDAO.Instance.sua(maCong, soNgayCong, soNgayNghiHuongLuong);
            }
            MessageBox.Show("Cập nhật thành công !", "Thông báo");
        }

        private void dgvChamCong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dateThangNam_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void dateThangNam_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadDS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDS();
        }
    }
}
