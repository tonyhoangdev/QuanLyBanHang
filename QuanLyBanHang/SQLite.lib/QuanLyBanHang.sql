BEGIN TRANSACTION;
CREATE TABLE `tb_KhachHang` (
    `MaKH`      VARCHAR(10) NOT NULL,
    `TenKH`     NVARCHAR(30),
    `GioiTinh`  NVARCHAR(5),
    `NamSinh`   DATE,
    `SDT`       VARCHAR(11),
    `DiaChi`    NVARCHAR(50),
    `Diem`      INTEGER,
    `Email`     VARCHAR(30),
    PRIMARY KEY(MaKH)
);
CREATE TABLE `tb_NhanVien` (
    `MaNV`      VARCHAR(10) NOT NULL,
    `TenNV`     NVARCHAR(30),
    `GioiTinh`  NVARCHAR(5),
    `NamSinh`   DATE,
    `DiaChi`    NVARCHAR(50),
    `SDT`       VARCHAR(11),
    `MatKhau`   VARCHAR(20),
    PRIMARY KEY(MaNV)
);
CREATE TABLE `tb_HangHoa` (
    `MaHH`      VARCHAR(10) NOT NULL,
    `TenHang`   TEXT,
    `DonGia`    INTEGER,
    `SoLuong`   INTEGER,
    PRIMARY KEY(MaHH)
);
CREATE TABLE `tb_HoaDon` (
    `MaHD`      VARCHAR(10) NOT NULL,
    `NgayLap`   DATETIME,
    `MaNV`      VARCHAR(10),
    `MaKH`      VARCHAR(10),
    PRIMARY KEY(MaHD),
    FOREIGN KEY (MaNV) references tb_NhanVien(MaNV),
    FOREIGN KEY (MaKH) references tb_KhachHang(MaKH)
);
CREATE TABLE `tb_CTHD` (
    `MaHD`      VARCHAR(10) NOT NULL,
    `MaHH`      VARCHAR(10) NOT NULL,
    `SoLuong`   INTEGER,
    `DonGia`    INTEGER,
    PRIMARY KEY(MaHD, MaHH),
    FOREIGN KEY (MaHH) references tb_HangHoa(MAHH),
    FOREIGN KEY (MaHD) references tb_HoaDon(MAHD)
);

INSERT INTO `tb_CTHD` (MaHD, MaHH, SoLuong, DonGia) VALUES ('HD001', 'HH001', 1, 3200000);
INSERT INTO `tb_CTHD` (MaHD, MaHH, SoLuong, DonGia) VALUES ('HD001', 'HH002', 2, 6000000);
INSERT INTO `tb_CTHD` (MaHD, MaHH, SoLuong, DonGia) VALUES ('HD002', 'HH001', 3, 3300000);
INSERT INTO `tb_CTHD` (MaHD, MaHH, SoLuong, DonGia) VALUES ('HD002', 'HH002', 7, 6930000);
INSERT INTO `tb_CTHD` (MaHD, MaHH, SoLuong, DonGia) VALUES ('HD003', 'HH001', 8, 3300000);
INSERT INTO `tb_CTHD` (MaHD, MaHH, SoLuong, DonGia) VALUES ('HD003', 'HH002', 9, 6930000);
INSERT INTO `tb_HangHoa` (MaHH, TenHang, DonGia, SoLuong) VALUES ('HH001', 'Máy in Canon 2900', 3000000, 17);
INSERT INTO `tb_HangHoa` (MaHH, TenHang, DonGia, SoLuong) VALUES ('HH002', 'Máy in HP m127dw', 6300000, 13);
INSERT INTO `tb_HangHoa` (MaHH, TenHang, DonGia, SoLuong) VALUES ('HH003','Nước lọc',10000,10);
INSERT INTO `tb_HangHoa` (MaHH, TenHang, DonGia, SoLuong) VALUES ('HH004','Kẹo',2000,100);
INSERT INTO `tb_HangHoa` (MaHH, TenHang, DonGia, SoLuong) VALUES ('HH006','Ống nước P21',40000,5);
INSERT INTO `tb_HoaDon` (MaHD, NgayLap, MaNV, MaKH) VALUES ('HD001', '2016-04-21', 'NV001', 'KH001');
INSERT INTO `tb_HoaDon` (MaHD, NgayLap, MaNV, MaKH) VALUES ('HD002', '2016-04-27', 'NV001', 'KH001');
INSERT INTO `tb_HoaDon` (MaHD, NgayLap, MaNV, MaKH) VALUES ('HH003', '2016-04-23', 'NV001', 'KH002');
INSERT INTO `tb_KhachHang` (MaKH, TenKH, GioiTinh, NamSinh, SDT, DiaChi, Diem, Email) VALUES ('KH001','Huỳnh Văn Phong','Nữ','1992-04-10','01234567221','Hoài Hương',10,'phong@gmail.com');
INSERT INTO `tb_KhachHang` (MaKH, TenKH, GioiTinh, NamSinh, SDT, DiaChi, Diem, Email) VALUES ('KH003','Hoàng Trọng Minh','Nam','1992-02-03','01675673576','Hải Phòng',50,'minh@gmail.com');
INSERT INTO `tb_KhachHang` (MaKH, TenKH, GioiTinh, NamSinh, SDT, DiaChi, Diem, Email) VALUES ('KH002','Trang','Nữ','1996-01-14','1234567890','Hai Phong',22001,'trang@gmail.com');
INSERT INTO `tb_NhanVien` (MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SDT, MatKhau) VALUES ('NV001','Hoàng Trọng Minh','Nam','1992-04-30','An Lư, Thủy Nguyên, Hải Phòng','01675673576','');
INSERT INTO `tb_NhanVien` (MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SDT, MatKhau) VALUES ('NV002','Nguyễn Thị Li A','Nữ','1993-03-24','Ân Đức, Hoài Ân, Bình Định','01677406649','');
INSERT INTO `tb_NhanVien` (MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SDT, MatKhau) VALUES ('NV003','Trần Văn Tâm','Nam','1992-09-06','An lư, Hải Phòng','01673120324','');
INSERT INTO `tb_NhanVien` (MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SDT, MatKhau) VALUES ('NV004','Hoàng Thị Thu Trang','Nữ','1996-11-06','Hải Phòng','0969606190','');
INSERT INTO `tb_NhanVien` (MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SDT, MatKhau) VALUES ('NV005','Máy Tính','Nam','2017-01-14','','','');

COMMIT;
