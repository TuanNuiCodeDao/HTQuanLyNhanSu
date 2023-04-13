using HTQuanLyNhanSu.DAO;
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
    public partial class F_DangNhap : Form
    {
        public F_DangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DangNhapDAO.Instance.check(tbTenDN.Text, tbMatKhau.Text))
            {
                F_Chinh f = new F_Chinh();
                this.Hide();
                f.ShowDialog();
                tbMatKhau.Text = "";
                this.Show();
            }
            else MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác !", "Nhắc nhở");
        }

        private void F_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Xác nhận thoát chương trình ?", "Xác nhận", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
