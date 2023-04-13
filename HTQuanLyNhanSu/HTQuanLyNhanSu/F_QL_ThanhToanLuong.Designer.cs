namespace HTQuanLyNhanSu
{
    partial class F_QL_ThanhToanLuong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateThangNam = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTTLuong = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.tbHoTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSoNgayLamViec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSoNgayNghiHuongLuong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTongSoNgayCong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbThucLinh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudThuong = new System.Windows.Forms.NumericUpDown();
            this.nudTamUng = new System.Windows.Forms.NumericUpDown();
            this.nudBHXH = new System.Windows.Forms.NumericUpDown();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.tbTrangThai = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTLuong)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamUng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBHXH)).BeginInit();
            this.SuspendLayout();
            // 
            // dateThangNam
            // 
            this.dateThangNam.CustomFormat = "MM/yyyy";
            this.dateThangNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateThangNam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateThangNam.Location = new System.Drawing.Point(172, 15);
            this.dateThangNam.Name = "dateThangNam";
            this.dateThangNam.Size = new System.Drawing.Size(212, 28);
            this.dateThangNam.TabIndex = 112;
            this.dateThangNam.ValueChanged += new System.EventHandler(this.dateThangNam_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 22);
            this.label2.TabIndex = 111;
            this.label2.Text = "Chọn tháng";
            // 
            // dgvTTLuong
            // 
            this.dgvTTLuong.AllowUserToAddRows = false;
            this.dgvTTLuong.AllowUserToDeleteRows = false;
            this.dgvTTLuong.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTTLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTLuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column7,
            this.Column4,
            this.Column8});
            this.dgvTTLuong.Location = new System.Drawing.Point(3, 261);
            this.dgvTTLuong.Name = "dgvTTLuong";
            this.dgvTTLuong.RowHeadersWidth = 51;
            this.dgvTTLuong.RowTemplate.Height = 24;
            this.dgvTTLuong.Size = new System.Drawing.Size(1531, 465);
            this.dgvTTLuong.TabIndex = 110;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(485, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 22);
            this.label7.TabIndex = 125;
            this.label7.Text = "Thông tin nhân viên";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbMaNV);
            this.panel1.Controls.Add(this.tbHoTen);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(412, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1073, 64);
            this.panel1.TabIndex = 124;
            // 
            // cbMaNV
            // 
            this.cbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Location = new System.Drawing.Point(249, 17);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(265, 30);
            this.cbMaNV.TabIndex = 81;
            this.cbMaNV.SelectedIndexChanged += new System.EventHandler(this.cbMaNV_SelectedIndexChanged);
            // 
            // tbHoTen
            // 
            this.tbHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHoTen.Location = new System.Drawing.Point(787, 19);
            this.tbHoTen.Name = "tbHoTen";
            this.tbHoTen.ReadOnly = true;
            this.tbHoTen.Size = new System.Drawing.Size(265, 28);
            this.tbHoTen.TabIndex = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 22);
            this.label5.TabIndex = 77;
            this.label5.Text = "Mã nhân viên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(616, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 22);
            this.label6.TabIndex = 79;
            this.label6.Text = "Họ tên ";
            // 
            // tbSoNgayLamViec
            // 
            this.tbSoNgayLamViec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSoNgayLamViec.Location = new System.Drawing.Point(412, 102);
            this.tbSoNgayLamViec.Name = "tbSoNgayLamViec";
            this.tbSoNgayLamViec.ReadOnly = true;
            this.tbSoNgayLamViec.Size = new System.Drawing.Size(217, 28);
            this.tbSoNgayLamViec.TabIndex = 121;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 22);
            this.label1.TabIndex = 120;
            this.label1.Text = "Số ngày làm việc";
            // 
            // tbSoNgayNghiHuongLuong
            // 
            this.tbSoNgayNghiHuongLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSoNgayNghiHuongLuong.Location = new System.Drawing.Point(412, 154);
            this.tbSoNgayNghiHuongLuong.Name = "tbSoNgayNghiHuongLuong";
            this.tbSoNgayNghiHuongLuong.ReadOnly = true;
            this.tbSoNgayNghiHuongLuong.Size = new System.Drawing.Size(217, 28);
            this.tbSoNgayNghiHuongLuong.TabIndex = 130;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(154, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 22);
            this.label4.TabIndex = 129;
            this.label4.Text = "Số ngày nghỉ hưởng lương";
            // 
            // tbTongSoNgayCong
            // 
            this.tbTongSoNgayCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTongSoNgayCong.Location = new System.Drawing.Point(881, 105);
            this.tbTongSoNgayCong.Name = "tbTongSoNgayCong";
            this.tbTongSoNgayCong.ReadOnly = true;
            this.tbTongSoNgayCong.Size = new System.Drawing.Size(225, 28);
            this.tbTongSoNgayCong.TabIndex = 132;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(670, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 22);
            this.label3.TabIndex = 131;
            this.label3.Text = "Tổng số ngày lương";
            // 
            // tbThucLinh
            // 
            this.tbThucLinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbThucLinh.Location = new System.Drawing.Point(881, 212);
            this.tbThucLinh.Name = "tbThucLinh";
            this.tbThucLinh.ReadOnly = true;
            this.tbThucLinh.Size = new System.Drawing.Size(225, 28);
            this.tbThucLinh.TabIndex = 134;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(670, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 22);
            this.label8.TabIndex = 133;
            this.label8.Text = "Thực lĩnh";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1132, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 22);
            this.label9.TabIndex = 137;
            this.label9.Text = "Khấu trừ BHXH";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1132, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 22);
            this.label10.TabIndex = 135;
            this.label10.Text = "Tạm ứng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(670, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 22);
            this.label11.TabIndex = 139;
            this.label11.Text = "Thưởng";
            // 
            // nudThuong
            // 
            this.nudThuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudThuong.Location = new System.Drawing.Point(881, 156);
            this.nudThuong.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudThuong.Name = "nudThuong";
            this.nudThuong.Size = new System.Drawing.Size(225, 30);
            this.nudThuong.TabIndex = 140;
            this.nudThuong.ThousandsSeparator = true;
            this.nudThuong.ValueChanged += new System.EventHandler(this.nudThuong_ValueChanged);
            // 
            // nudTamUng
            // 
            this.nudTamUng.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTamUng.Location = new System.Drawing.Point(1282, 110);
            this.nudTamUng.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudTamUng.Name = "nudTamUng";
            this.nudTamUng.Size = new System.Drawing.Size(203, 30);
            this.nudTamUng.TabIndex = 141;
            this.nudTamUng.ThousandsSeparator = true;
            // 
            // nudBHXH
            // 
            this.nudBHXH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBHXH.Location = new System.Drawing.Point(1282, 156);
            this.nudBHXH.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudBHXH.Name = "nudBHXH";
            this.nudBHXH.Size = new System.Drawing.Size(203, 30);
            this.nudBHXH.TabIndex = 142;
            this.nudBHXH.ThousandsSeparator = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã thanh toán";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Mã nhân viên";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên nhân viên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tạm ứng";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Thưởng";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Khấu trừ BHXH";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Thực lĩnh";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Trạng thái";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 125;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightCyan;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(412, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 38);
            this.button2.TabIndex = 143;
            this.button2.Text = "Cập nhật";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbTrangThai
            // 
            this.tbTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTrangThai.Location = new System.Drawing.Point(1282, 208);
            this.tbTrangThai.Name = "tbTrangThai";
            this.tbTrangThai.ReadOnly = true;
            this.tbTrangThai.Size = new System.Drawing.Size(203, 28);
            this.tbTrangThai.TabIndex = 145;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1132, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 22);
            this.label12.TabIndex = 144;
            this.label12.Text = "Trạng thái";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCyan;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(158, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 38);
            this.button1.TabIndex = 146;
            this.button1.Text = "Thanh toán";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // F_QL_ThanhToanLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1537, 728);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbTrangThai);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.nudBHXH);
            this.Controls.Add(this.nudTamUng);
            this.Controls.Add(this.nudThuong);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbThucLinh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbTongSoNgayCong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSoNgayNghiHuongLuong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbSoNgayLamViec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateThangNam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTTLuong);
            this.Name = "F_QL_ThanhToanLuong";
            this.Text = "F_QL_ThanhToanLuong";
            this.Load += new System.EventHandler(this.F_QL_ThanhToanLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTLuong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamUng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBHXH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateThangNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTTLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbMaNV;
        private System.Windows.Forms.TextBox tbHoTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSoNgayLamViec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSoNgayNghiHuongLuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTongSoNgayCong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbThucLinh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudThuong;
        private System.Windows.Forms.NumericUpDown nudTamUng;
        private System.Windows.Forms.NumericUpDown nudBHXH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbTrangThai;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
    }
}