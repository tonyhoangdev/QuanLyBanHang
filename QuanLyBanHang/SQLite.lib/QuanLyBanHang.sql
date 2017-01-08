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
    `MaNV`      VARCHAR(10) Not NULL,
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
INSERT INTO `tb_CTHD` (MaHD, MaHH, SoLuong, DonGia) VALUES ('HD002', 'HH001', 3300000, 3);
INSERT INTO `tb_CTHD` (MaHD, MaHH, SoLuong, DonGia) VALUES ('HD002', 'HH002', 6930000, 7);
INSERT INTO `tb_CTHD` (MaHD, MaHH, SoLuong, DonGia) VALUES ('HH003', 'HH001', 3300000, 5);
INSERT INTO `tb_CTHD` (MaHD, MaHH, SoLuong, DonGia) VALUES ('HH003', 'HH002', 6930000, 2);
INSERT INTO `tb_HangHoa` (MaHH, TenHang, DonGia, SoLuong) VALUES ('HH001', 'Máy in Canon 2900', 3000000, 17);
INSERT INTO `tb_HangHoa` (MaHH, TenHang, DonGia, SoLuong) VALUES ('HH002', 'Máy in HP m127dw', 6300000, 13);
INSERT INTO `tb_HoaDon` (MaHD, NgayLap, MaNV, MaKH) VALUES ('HD001', '2016-04-21 15:02', 'NV001', 'KH001');
INSERT INTO `tb_HoaDon` (MaHD, NgayLap, MaNV, MaKH) VALUES ('HD002', '2016-04-27 16:02', 'NV001', 'KH001');
INSERT INTO `tb_HoaDon` (MaHD, NgayLap, MaNV, MaKH) VALUES ('HH003', '2016-04-27 13:02', 'NV001', 'KH002');
INSERT INTO `tb_KhachHang` (MaKH, TenKH, GioiTinh, NamSinh, SDT, DiaChi, Diem, Email) VALUES ('KH001', 'Huỳnh Văn Phong', 'Nam', '1992-04-10', '0123456789', 'Hoài Hương', 0, 'phong@gmail.com');
INSERT INTO `tb_KhachHang` (MaKH, TenKH, GioiTinh, NamSinh, SDT, DiaChi, Diem, Email) VALUES ('KH002', 'Nguyễn Thị A', 'Nữ', '1991-12-12 ', '0123456789', 'Hồ Chí Minh', 0, 'a@gmail.com');
INSERT INTO `tb_NhanVien` (MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SDT, MatKhau) VALUES ('NV001', 'Huỳnh Văn Hoàng', 'Nam', '1991-03-12', 'Hoài Hương, Hoài Nhơn, Bình Định', '0964218938', '');
INSERT INTO `tb_NhanVien` (MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SDT, MatKhau) VALUES ('NV002', 'Nguyễn Thị Li A', 'Nữ', '1993-03-24', 'Ân Đức, Hoài Ân, Bình Định', '01677406649', '');

COMMIT;
