using HTQuanLyNhanSu.DAO;
using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HTQuanLyNhanSu
{
    public partial class FThongTinDangNhap : Form
    {

        public FThongTinDangNhap()
        {
            InitializeComponent();
            loadThongTin();
        }
        private void loadThongTin()
        {
            DangNhap dn = DangNhapDAO.Instance.getDangNhap();
            tbTaiKhoan.Text = dn.TaiKhoan;
            tbMatKhau.Text = dn.MatKhau;
        }
        private void BtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool check(string s)
        {
            if (s.Length < 2)
                return false;
            for (int i = 0; i < s.Length; i++)
                if (s[i] == ' ')
                    return false;
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tbTaiKhoan.Text=tbTaiKhoan.Text.Trim();
            tbMatKhau.Text=tbMatKhau.Text.Trim();
            if(check(tbTaiKhoan.Text)==false)
            {
                MessageBox.Show("Tài khoản lỗi: Chứa ký tự trắng hoặc quá ngắn !", "Nhắc nhở");
                return;
            }
            if (check(tbMatKhau.Text) == false)
            {
                MessageBox.Show("Mật khẩu lỗi: Chứa ký tự trắng hoặc quá ngắn !", "Nhắc nhở");
                return;
            }
            DangNhapDAO.Instance.capNhat(tbTaiKhoan.Text, tbMatKhau.Text);
            MessageBox.Show("Cập nhật thành công !", "Thông báo");
            loadThongTin();
        }

        private void FThongTinDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
