using HTQuanLyNhanSu.DAO;
using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQuanLyNhanSu
{
    public partial class F_Them_CapNhat_NhanVien : Form
    {
        private NhanVien nv; 
        public F_Them_CapNhat_NhanVien(string maNV)
        {
            InitializeComponent();
            this.nv = NhanVienDAO.Instance.getByMa(maNV);
            load();
        }
        private void load()
        {
            tbUrl.Hide();
            loadCbPhongBan();
            loadCbChucVu();
            if (nv==null)
            {
                this.Text = "Thêm mới thông tin nhân viên";
            }
            else
            {
                this.Text = "Cập nhật thông tin nhân viên";
                loadThongTinNhanVien();
            }
        }
        private void loadThongTinNhanVien()
        {
            tbHoTen.Text = nv.HoTen;
            tbSDT.Text = nv.Sdt;
            dateNgaySinh.Value = nv.NgaySinh;
            checkDangVien.Checked = nv.DangVien == 1;
            radioNam.Checked = nv.GioiTinh == 0;
            radioNu.Checked = nv.GioiTinh == 1;
            tbDanToc.Text = nv.DanToc;
            tbTonGiao.Text = nv.TonGiao;
            tbSoCMND.Text = nv.SoCMND;
            PhongBan p = PhongBanDAO.Instance.getByMa(nv.MaPB);
            cbPhongBan.Text = p.Ten;
            ChucVu cv = ChucVuDAO.Instance.getByMa(nv.MaCV);
            cbPhongBan.Text = cv.Ten;
            tbSoBHYT.Text = nv.SoBHYT;
            tbSoBHXH.Text = nv.SoBHXH;
            tbHocVan.Text = nv.HocVan;
            tbNgoaiNgu.Text=nv.NgoaiNgu;
            tbQueQuan.Text = nv.QueQuan;
            tbDiaChi.Text = nv.DiaChi;
            tbUrl.Text = nv.Anh;
            try
            {
                tbUrl.Text = nv.Anh;
                ptAnh.Image = Image.FromFile(tbUrl.Text);
            }catch (Exception ex)
            {
                tbUrl.Text = "";
                ptAnh.Image = null;
            }
        }    
        private void loadCbChucVu()
        {
            cbChucVu.DataSource = ChucVuDAO.Instance.loadDS();
            cbChucVu.DisplayMember = "Ten";
            if (ChucVuDAO.Instance.loadDS().Count > 0)
                cbChucVu.Text = ChucVuDAO.Instance.loadDS()[0].Ten;
        }
        private void loadCbPhongBan()
        {
            cbPhongBan.DataSource = PhongBanDAO.Instance.loadDS();
            cbPhongBan.DisplayMember = "Ten";
            if (PhongBanDAO.Instance.loadDS().Count > 0)
                cbPhongBan.Text = PhongBanDAO.Instance.loadDS()[0].Ten;
        }    
        private void button1_Click(object sender, EventArgs e)
        {
            PhongBan phongBan = PhongBanDAO.Instance.getByTen(cbPhongBan.Text);
            if (phongBan==null)
            {
                MessageBox.Show("Hãy thêm phòng ban trước !", "Nhắc nhở");
                return;
            }
            ChucVu chucVu = ChucVuDAO.Instance.getByTen(cbChucVu.Text);
            if (chucVu == null)
            {
                MessageBox.Show("Hãy thêm chức vụ trước !", "Nhắc nhở");
                return;
            }
            string hoTen=tbHoTen.Text;
            if(string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Họ tên không được để trống !", "Nhắc nhở");
                return;
            }
            int gioiTinh = 0;
            if (radioNu.Checked)
                gioiTinh = 1;
            DateTime ngaySinh = dateNgaySinh.Value;
            string sdt = tbSDT.Text;
            string danToc=tbDanToc.Text;
            string tonGiao=tbTonGiao.Text;
            string soCMND = tbSoCMND.Text;
            if (string.IsNullOrEmpty(soCMND))
            {
                MessageBox.Show("Số CMND không được để trống !", "Nhắc nhở");
                return;
            }
            string soBHYT = tbSoBHYT.Text;
            string soBHXH=tbSoBHXH.Text;
            int dangVien = 0;
            if (checkDangVien.Checked)
                dangVien = 1;
            string hocVan=tbHocVan.Text;
            string ngoaiNgu = tbNgoaiNgu.Text;
            string queQuan = tbQueQuan.Text;
            string diaChi = tbDiaChi.Text;
            string anh = tbUrl.Text;
            if(nv==null)
            {
                NhanVien nv1 = NhanVienDAO.Instance.getByCMND(soCMND);
                if (nv1!=null)
                {
                    MessageBox.Show("Số CMND đã tồn tại !", "Nhắc nhở");
                    return;
                }
                NhanVienDAO.Instance.them(hoTen, gioiTinh, ngaySinh, sdt, danToc, tonGiao, soCMND, dangVien, phongBan.Ma, chucVu.Ma
                    , soBHYT, soBHXH, hocVan, ngoaiNgu, queQuan, diaChi, anh);
                MessageBox.Show("Thêm mới nhân viên thành công", "Thông báo");
            }
            else
            {
                NhanVien nv1 = NhanVienDAO.Instance.getByCMND(soCMND);
                if (nv1 != null&&nv1.MaNV!=nv.MaNV)
                {
                    MessageBox.Show("Số CMND đã tồn tại !", "Nhắc nhở");
                    return;
                }
                NhanVienDAO.Instance.sua(nv.MaNV,hoTen, gioiTinh, ngaySinh, sdt, danToc, tonGiao, soCMND, dangVien, phongBan.Ma, chucVu.Ma
                    , soBHYT, soBHXH, hocVan, ngoaiNgu, queQuan, diaChi, anh);
                nv = NhanVienDAO.Instance.getByMa(nv.MaNV);
                MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_Them_CapNhat_NhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void ptAnh_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Chọn ảnh";
            openFileDialog1.Filter = "Windows Bitmap|*.png|JPEG Image|*.jpg|All Files|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbUrl.Text = openFileDialog1.FileName;
                String filePath = tbUrl.Text;
                if (File.Exists(filePath))
                {
                    ptAnh.Image = Image.FromFile(filePath);
                }
                else
                {
                    tbUrl.Text = "";
                    ptAnh.Image = null;
                }    
            }
            else
            {
                tbUrl.Text = "";
                ptAnh.Image = null;
            }    
        }
    }
}
