CREATE DATABASE DataQLNS
GO
USE DataQLNS
GO
CREATE TABLE PhongBan
(
	MaPB VARCHAR(20),
	TenPB NVARCHAR(225)
	PRIMARY KEY(MaPB)
)
GO
CREATE TABLE ChucVu
(
	MaCV VARCHAR(20),
	TenCV NVARCHAR(225)
	PRIMARY KEY(MaCV)
)
GO
CREATE TABLE DangNhap
(
	TenDangNhap VARCHAR(20),
	MatKhau VARCHAR(20)
	PRIMARY KEY(TenDangNhap)
)
INSERT INTO DangNhap VALUES(N'admin',N'1234')
GO
CREATE TABLE NhanVien
(
	MaNV VARCHAR(20),
	HoTen NVARCHAR(100),
	GioiTinh INT,
	NgaySinh DATE,
	SDT VARCHAR(20),
	DanToc NVARCHAR(100),
	TonGiao NVARCHAR(100),
	CMND VARCHAR(20),
	DangVien INT,
	MaPB VARCHAR(20),
	MaCV VARCHAR(20),
	BHYT VARCHAR(20),
	BHXH VARCHAR(20),
	HocVan NVARCHAR(100),
	NgoaiNgu NVARCHAR(100),
	QueQuan NVARCHAR(300),
	DiaChi NVARCHAR(300),
	Anh NVARCHAR(max)
	PRIMARY KEY(MANV),
	FOREIGN KEY (MAPB) REFERENCES PHONGBAN,
	FOREIGN KEY (MACV) REFERENCES CHUCVU
)
GO
CREATE TABLE HopDong
(
	MaHD VARCHAR(20),
	MaNV VARCHAR(20),
	NgayBD DATE,
	NgayKT DATE,
	TrangThai INT DEFAULT 1
	PRIMARY KEY(MaHD),
	FOREIGN KEY (MaNV) REFERENCES NhanVien
)
GO
CREATE TABLE Luong
(
	MaLuong INT IDENTITY,
	MaNV VARCHAR(20),
	MucLuong INT,
	NgayApDung DATE DEFAULT GETDATE()
	PRIMARY KEY(MaLuong),
	FOREIGN KEY (MaNV) REFERENCES NhanVien
)
GO
CREATE TRIGGER tuThemLuong
ON NhanVien FOR INSERT
AS
BEGIN
     DECLARE @maNV VARCHAR(20) = (SELECT MaNV FROM Inserted)
	 INSERT INTO Luong(MaNV,MucLuong) VALUES (@maNV,0)

END
GO
CREATE TABLE Cong
(
	MaCong INT IDENTITY,
	MaNV VARCHAR(20),
	SoNgayCong INT,
	SoNgayNghiHuongLuong INT,
	Thang INT,
	Nam INT
	PRIMARY KEY(MaCong),
	FOREIGN KEY (MaNV) REFERENCES NhanVien
)
GO
CREATE TABLE ThanhToanLuong
(
	MaTTL INT IDENTITY,
	MaCong INT ,
	TamUng INT DEFAULT 0,
	Thuong INT DEFAULT 0,
	KhauTruBHXH INT DEFAULT 0,
	ThucLinh INT DEFAULT 0,
	TrangThai INT DEFAULT 0
	PRIMARY KEY(MaTTL),
	FOREIGN KEY (MaCong) REFERENCES Cong
)
GO
CREATE TABLE NghiPhep
(
	MaNP INT IDENTITY,
	MaNV VARCHAR(20),
	NgayBD DATE,
	NgayKT DATE,
	LyDo NVARCHAR(550),
	HuongLuong INT
	PRIMARY KEY(MaNP),
	FOREIGN KEY (MaNV) REFERENCES NhanVien
)
GO
CREATE TABLE ThuongPhat
(
	MaTP INT IDENTITY,
	MaNV VARCHAR(20),
	NgayQD DATE DEFAULT GETDATE(),
	LyDo NVARCHAR(550),
	SoTien INT,
	Loai INT
	PRIMARY KEY(MaTP),
	FOREIGN KEY (MaNV) REFERENCES NhanVien
)
GO
CREATE TRIGGER tuThemThanhToanLuong
ON Cong FOR INSERT
AS
BEGIN
     DECLARE @maCong INT = (SELECT MaCong FROM Inserted)
	 INSERT INTO ThanhToanLuong(MaCong) VALUES (@maCong)

END
GO
       