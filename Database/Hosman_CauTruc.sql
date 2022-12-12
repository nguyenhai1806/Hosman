CREATE DATABASE Hosman123;
GO

USE Hosman123;
GO

--Tao bang
CREATE TABLE NguoiDung
(
    MaNguoiDung  CHAR(40)      PRIMARY KEY,
    TenNguoiDung NVARCHAR(150) NOT NULL,
    CCCD         CHAR(12)      NOT NULL UNIQUE,
    NgayCap      DATE,
    NoiCap       NVARCHAR(50),
    SoDienThoai  CHAR(10)      NOT NULL UNIQUE,
    NgaySinh     DATE,
    GioiTinh     BIT           NOT NULL,
    DiaChi       NVARCHAR(MAX),
    AnhCCCDTruoc NVARCHAR(MAX),
    AnhCCCDSau   NVARCHAR(MAX),
    TaiKhoan     NVARCHAR(MAX),
    MatKhau      NVARCHAR(MAX),
);

CREATE TABLE BinhLuan
(
    MaBinhLuan    CHAR(40)      PRIMARY KEY,
    Ngay          DATE          NOT NULL,
    NoiDung       NVARCHAR(300) NOT NULL,
    HinhAnh       VARCHAR(MAX),
    TrangThai     BIT           DEFAULT 1, -- 1: Hien, 0: An
    NguoiBinhLuan CHAR(40)      NOT NULL,
    ChuTro        CHAR(40)      NOT NULL,
    CONSTRAINT FK_BinhLuan_NguoiDung_NguoiBinhLuan FOREIGN KEY (NguoiBinhLuan) REFERENCES dbo.NguoiDung (MaNguoiDung),
    CONSTRAINT FK_BinhLuan_NguoiDung_ChuTro FOREIGN KEY (ChuTro) REFERENCES dbo.NguoiDung (MaNguoiDung),
);

CREATE TABLE QL_NhomNguoiDung
(
    MaNhom  CHAR(40)      PRIMARY KEY,
    TenNhom NVARCHAR(150) NOT NULL UNIQUE,
    GhiChu  NVARCHAR(150),
);

CREATE TABLE DM_ManHinh
(
    MaManHinh  CHAR(40)      PRIMARY KEY,
    TenManHinh NVARCHAR(150) NOT NULL UNIQUE,
);

CREATE TABLE QL_PhanQuyen
(
    MaNhomNguoiDung CHAR(40) NOT NULL,
    MaManHinh       CHAR(40) NOT NULL,
    CoQuyen         BIT      DEFAULT 0 NOT NULL, --1: Co quyen, 0: Khong co quyen

    CONSTRAINT PK_PhanQuyen PRIMARY KEY (MaNhomNguoiDung, MaManHinh),
    CONSTRAINT FK_PhanQuyen_NhomNguoiDung FOREIGN KEY (MaNhomNguoiDung) REFERENCES dbo.QL_NhomNguoiDung (MaNhom),
    CONSTRAINT FK_PhanQuyen_ManHinh FOREIGN KEY (MaManHinh) REFERENCES dbo.DM_ManHinh (MaManHinh),
);


CREATE TABLE QL_NguoiDungNhomNguoiDung
(
    MaNguoiDung     CHAR(40) NOT NULL,
    MaNhomNguoiDung CHAR(40) NOT NULL,
    GhiChu          NVARCHAR(50),
    CONSTRAINT PK_NguoiDungNhomNguoiDung PRIMARY KEY (MaNguoiDung, MaNhomNguoiDung),
    CONSTRAINT FK_NguoiDungNhomNguoiDung_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung (MaNguoiDung),
    CONSTRAINT FK_NguoiDungNhomNguoiDung_NhomNguoiDung FOREIGN KEY (MaNhomNguoiDung) REFERENCES dbo.QL_NhomNguoiDung
                                                       (MaNhom),
);

CREATE TABLE TienIch
(
    MaTienIch  CHAR(40)      PRIMARY KEY,
    TenTienIch NVARCHAR(150) NOT NULL UNIQUE,
    GhiChu     NVARCHAR(150),
);

CREATE TABLE KhuTro
(
    MaKhuTro    CHAR(40)       PRIMARY KEY,
    TenKhu      NVARCHAR(150)  NOT NULL,
    SoPhong     INT            DEFAULT 0 CHECK (SoPhong >= 0),
    DiaChi      NVARCHAR(MAX)  NOT NULL,
    GiaDien     DECIMAL(19, 4) NOT NULL,
    GiaNuoc     DECIMAL(19, 4) NOT NULL,
    NgayLapHD   INT            NOT NULL,
    HanDongTien INT            NOT NULL CHECK (HanDongTien >= 0),
    MaNguoiDung CHAR(40)       NOT NULL,
    CONSTRAINT FK_KhuTro_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung (MaNguoiDung)
);

CREATE TABLE KhuTro_TienIch
(
    MaTienIch CHAR(40) NOT NULL,
    MaKhuTro  CHAR(40) NOT NULL,
    CONSTRAINT PK_KhuTro_TienIch PRIMARY KEY (MaTienIch, MaKhuTro),
    CONSTRAINT FK_KhuTroTienIchKhuTro FOREIGN KEY (MaKhuTro) REFERENCES dbo.KhuTro (MaKhuTro),
    CONSTRAINT FK_KhuTroTienIch_TienIch FOREIGN KEY (MaTienIch) REFERENCES dbo.TienIch (MaTienIch)
);
-------------------------------------------------------
CREATE TABLE PhieuChi
(
    MaPhieuChi   CHAR(40)       PRIMARY KEY,
    ChiTietChi   NVARCHAR(150)  NOT NULL,
    NgayChi      DATE           NOT NULL,
    ChiPhi       DECIMAL(19, 4) NOT NULL,
    TienKhachTra DECIMAL(19, 4) DEFAULT 0,
    MaKhuTro     CHAR(40)       NOT NULL,
    GhiChu       NVARCHAR(150),
    CONSTRAINT FK_PhieuChi_KhuTro FOREIGN KEY (MaKhuTro) REFERENCES dbo.KhuTro (MaKhuTro)
);
CREATE TABLE Phong
(
    MaPhong   CHAR(40)       PRIMARY KEY,
    TenPhong  NVARCHAR(150)  NOT NULL,
    DienTich  FLOAT          NOT NULL,
    GiaThue   DECIMAL(19, 4) NOT NULL,
    UuTien    INT,                     --0: Nam, 1: Nu, 2: Ca hai
    GhiChu    NVARCHAR(150),
    TinhTrang BIT            NOT NULL, --1: Cho thue, 2: Khong
    MaKhuTro  CHAR(40)       NOT NULL,
    CONSTRAINT FK_Phong_KhuTro FOREIGN KEY (MaKhuTro) REFERENCES dbo.KhuTro (MaKhuTro)
);

CREATE TABLE LoaiPhong
(
    MaLoai  CHAR(40)      PRIMARY KEY,
    TenLoai NVARCHAR(150) NOT NULL UNIQUE,
    GhiChu  NVARCHAR(150),
);

CREATE TABLE LoaiPhong_Phong
(
    MaLoai  CHAR(40) NOT NULL,
    MaPhong CHAR(40) NOT NULL,
    CONSTRAINT PK_LoaiPhong_Phong PRIMARY KEY (MaLoai, MaPhong),
    CONSTRAINT FK_LoaiPhongPhong_LoaiPhong FOREIGN KEY (MaLoai) REFERENCES dbo.LoaiPhong (MaLoai),
    CONSTRAINT FK_LoaiPhongPhong_Phong FOREIGN KEY (MaPhong) REFERENCES dbo.Phong (MaPhong),
);

CREATE TABLE PhieuCocGiuPhong
(
    MaPhieuCoc     NVARCHAR(40)   PRIMARY KEY,
    NgayCoc        DATE           NOT NULL DEFAULT GETDATE(),
    NgayDuKienVaoO DATE           NOT NULL,
    SoTien         DECIMAL(19, 4) NOT NULL,
    GhiChu         NVARCHAR(200),
    DaHoanTien     BIT            DEFAULT 0 NOT NULL,
    MaPhong        CHAR(40)       NOT NULL,
    MaNguoiDung    CHAR(40)       NOT NULL,
    CONSTRAINT FK_PhieuCoc_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung (MaNguoiDung),
    CONSTRAINT FK_PhieuCoc_Phong FOREIGN KEY (MaPhong) REFERENCES dbo.Phong (MaPhong),
);

CREATE TABLE DichVu
(
    MaDichVu  CHAR(40)      PRIMARY KEY,
    TenDichVu NVARCHAR(150) NOT NULL,
    DonViTinh NVARCHAR(100) NOT NULL,
);

CREATE TABLE DichVu_KhuTro
(
    MaDichVu CHAR(40),
    MaKhuTro CHAR(40),
    DonGia   DECIMAL(19, 4) NOT NULL,
    CONSTRAINT PK_DichVu_KhuTro PRIMARY KEY (MaDichVu, MaKhuTro),
    CONSTRAINT FK_DichVuKhuTro_KhuTro FOREIGN KEY (MaKhuTro) REFERENCES dbo.KhuTro (MaKhuTro),
    CONSTRAINT FK_DichVuKhuTro_DichVu FOREIGN KEY (MaDichVu) REFERENCES dbo.DichVu (MaDichVu),
);

CREATE TABLE DichVu_Phong
(
    SoLuong  INT      NOT NULL,
    MaDichVu CHAR(40) NOT NULL,
    MaKhuTro CHAR(40) NOT NULL,
    MaPhong  CHAR(40) NOT NULL,
    CONSTRAINT PK_DichVu_Phong PRIMARY KEY (MaDichVu, MaKhuTro, MaPhong),
    CONSTRAINT FK_DichVu_Phong FOREIGN KEY (MaDichVu, MaKhuTro) REFERENCES dbo.DichVu_KhuTro (MaDichVu, MaKhuTro),
    CONSTRAINT FK_DichVuPhong_Phong FOREIGN KEY (MaPhong) REFERENCES dbo.Phong (MaPhong)
);

CREATE TABLE HopDongThue
(
    MaHopDong     CHAR(40)       PRIMARY KEY,
    FileHopDong   VARCHAR(MAX),
    TienCocDamBao DECIMAL(19, 4) DEFAULT 0 NOT NULL,
    TinhTrangCoc  DECIMAL(19, 4) DEFAULT 0 NOT NULL,
    MaPhong       CHAR(40)       NOT NULL,
    MaNguoiThue   CHAR(40)       NOT NULL,
    CONSTRAINT FK_HopDong_Phong FOREIGN KEY (MaPhong) REFERENCES Phong (MaPhong),
    CONSTRAINT FK_HopDong_NguoiThue FOREIGN KEY (MaNguoiThue) REFERENCES dbo.NguoiDung (MaNguoiDung)
);

CREATE TABLE PhuLuc
(
    MaPhuLuc    CHAR(40)       PRIMARY KEY,
    NgayBatDau  DATE           NOT NULL,
    NgayKetThuc DATE           NOT NULL,
    GiaThue     DECIMAL(19, 4) NOT NULL,
    GhiChu      NVARCHAR(150),
    MaHopDong   CHAR(40)       NOT NULL,
    CONSTRAINT FK_PhuLuc_HopDong FOREIGN KEY (MaHopDong) REFERENCES dbo.HopDongThue (MaHopDong),
);

CREATE TABLE DanhSachNguoiTro
(
    MaNguoiTro       CHAR(40)      PRIMARY KEY,
    TenNguoiTro      NVARCHAR(150) NOT NULL,
    CCCD             CHAR(12)      NOT NULL,
    NgayCap          DATE,
    NoiCap           NVARCHAR(50),
    SoDienThoai      CHAR(10)      NOT NULL,
    NgaySinh         DATE,
    GioiTinh         BIT           NOT NULL,
    DiaChi           NVARCHAR(MAX),
    AnhCCCDTruoc     NVARCHAR(MAX),
    AnhCCCDSau       NVARCHAR(MAX),
    MaHopDong        CHAR(40)      NOT NULL,
    NgayDangKyTamTru DATE,
    XacMinhThongTin  BIT           DEFAULT 0,
    CONSTRAINT FK_DSNguoiTro_HopDong FOREIGN KEY (MaHopDong) REFERENCES dbo.HopDongThue (MaHopDong),
);

CREATE TABLE YeuCauSuaChua
(
    MaYeuCau   CHAR(40)      PRIMARY KEY,
    ChiTiet    NVARCHAR(150) NOT NULL,
    HinhAnh    VARCHAR(MAX)  NOT NULL,
    NgayYeuCau DATE          NOT NULL,
    TinhTrang  INT, --: 0 Da gui, 1: Da sua chua, 2: Tu choi
    MaHopDong  CHAR(40)      NOT NULL,
    CONSTRAINT FK_SuaChua_HopDong FOREIGN KEY (MaHopDong) REFERENCES dbo.HopDongThue (MaHopDong)
);

CREATE TABLE HoaDon
(
    MaHoaDon      CHAR(40)       PRIMARY KEY,
    NgayThanhToan DATE,
    TuNgay        DATE           NOT NULL,
    ToiNgay       DATE           NOT NULL,
    NgayLapHD     DATE           NOT NULL,
    HanDongTien   DATE           NOT NULL,
    TongTien      DECIMAL(19, 4) NOT NULL,
    TienPhong     DECIMAL(19, 4) DEFAULT 0 NOT NULL,
    GhiChu        NVARCHAR(150),
    MaHopDong     CHAR(40)       FOREIGN KEY (MaHopDong) REFERENCES dbo.HopDongThue (MaHopDong) NOT NULL,
);


CREATE TABLE DongHoDien
(
    MaBanGhi  CHAR(40) PRIMARY KEY,
    NgayGhi   DATE     NOT NULL,
    ChiSoDien INT      NOT NULL,
    MaPhong   CHAR(40) NOT NULL,
    CONSTRAINT FK_DongHoDien_Phong FOREIGN KEY (MaPhong) REFERENCES dbo.Phong (MaPhong),
);


CREATE TABLE HoaDon_Dien
(
    MaHoaDon     CHAR(40)       PRIMARY KEY,
    BanGhiSoDau  CHAR(40)       NOT NULL,
    BanGhiSoCuoi CHAR(40)       NOT NULL,
    DonGia       DECIMAL(19, 4) NOT NULL,
    ThanhTien    DECIMAL(19, 4) NOT NULL,
    CONSTRAINT FK_HoaDonDien_SoDau FOREIGN KEY (BanGhiSoDau) REFERENCES dbo.DongHoDien (MaBanGhi),
    CONSTRAINT FK_HoaDonDien_SoCuoi FOREIGN KEY (BanGhiSoCuoi) REFERENCES dbo.DongHoDien (MaBanGhi),
    CONSTRAINT FK_MaHoaDon FOREIGN KEY (MaHoaDon) REFERENCES dbo.HoaDon (MaHoaDon),
);

CREATE TABLE DongHoNuoc
(
    MaBanGhi  CHAR(40) PRIMARY KEY,
    NgayGhi   DATE     NOT NULL,
    ChiSoNuoc INT      NOT NULL,
    MaPhong   CHAR(40) NOT NULL,
    CONSTRAINT FK_DongHoNuoc_Phong FOREIGN KEY (MaPhong) REFERENCES dbo.Phong (MaPhong),
);

CREATE TABLE HoaDon_Nuoc
(
    MaHoaDon     CHAR(40)       PRIMARY KEY,
    BanGhiSoDau  CHAR(40)       NOT NULL,
    BanGhiSoCuoi CHAR(40)       NOT NULL,
    DonGia       DECIMAL(19, 4) NOT NULL,
    ThanhTien    DECIMAL(19, 4) NOT NULL,
    CONSTRAINT FK_HoaDonNuoc_SoDau FOREIGN KEY (BanGhiSoDau) REFERENCES dbo.DongHoNuoc (MaBanGhi),
    CONSTRAINT FK_HoaDonNuoc_SoCuoi FOREIGN KEY (BanGhiSoCuoi) REFERENCES dbo.DongHoNuoc (MaBanGhi),
    CONSTRAINT FK_HoaDonNuoc_HoaDon FOREIGN KEY (MaHoaDon) REFERENCES dbo.HoaDon (MaHoaDon),
);

CREATE TABLE HoaDon_DichVu
(
    MaHoaDon  CHAR(40)       NOT NULL,
    MaDichVu  CHAR(40)       NOT NULL,
    SoLuong   INT            NOT NULL,
    DonGia    DECIMAL(19, 4) NOT NULL,
    ThanhTien DECIMAL(19, 4) NOT NULL,
    CONSTRAINT PK_HoaDon_DichVu PRIMARY KEY (MaHoaDon, MaDichVu),
    CONSTRAINT FK_MaHoaDonDichVu_HoaDon FOREIGN KEY (MaHoaDon) REFERENCES dbo.HoaDon (MaHoaDon),
    CONSTRAINT FK_HoaDonDichVu_DichVu FOREIGN KEY (MaDichVu) REFERENCES dbo.DichVu (MaDichVu),
);

CREATE TABLE HoaDon_PhieuChi
(
    MaHoaDon   CHAR(40) NOT NULL,
    MaPhieuChi CHAR(40) NOT NULL,
    CONSTRAINT PK_HoaDon_PhieuChi PRIMARY KEY (MaHoaDon, MaPhieuChi),
    CONSTRAINT FK_HoaDonPhieuChi_HoaDon FOREIGN KEY (MaHoaDon) REFERENCES dbo.HoaDon (MaHoaDon),
    CONSTRAINT FK_HoaDonPhieuChi_PhieuChi FOREIGN KEY (MaPhieuChi) REFERENCES dbo.PhieuChi (MaPhieuChi),
);

CREATE TABLE DangKyXemPhong
(
    MaDangKy   CHAR(40)     PRIMARY KEY,
    NgayDangKy DATE         NOT NULL,
    NgayHenXem DATE         NOT NULL,
    GhiChu     NVARCHAR(300),
    TinhTrang  INTEGER      NOT NULL, --0: Chua xem, 1: Da xem, 2: Huy
    NguoiDung  CHAR(40)     NOT NULL,
    MaPhong    CHAR(40)     NOT NULL,
    CONSTRAINT FK_DangKyXemPhong_NguoiDung FOREIGN KEY (NguoiDung) REFERENCES dbo.NguoiDung (MaNguoiDung),
    CONSTRAINT FK_DangKyXemPhong_Phong FOREIGN KEY (MaPhong) REFERENCES dbo.Phong (MaPhong)
);

GO

CREATE TRIGGER trgCapNhapPhongKhuTro
ON dbo.Phong
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    IF EXISTS (SELECT * FROM Deleted)
    BEGIN
        UPDATE dbo.KhuTro
        SET SoPhong = SoPhong - 1
        WHERE dbo.KhuTro.MaKhuTro IN
              (
                  SELECT Deleted.MaKhuTro FROM Deleted
              );
    END;


    IF EXISTS (SELECT * FROM Inserted)
    BEGIN
        UPDATE dbo.KhuTro
        SET SoPhong = SoPhong + 1
        WHERE dbo.KhuTro.MaKhuTro IN
              (
                  SELECT Inserted.MaKhuTro FROM Inserted
              );
    END;
END;
GO

CREATE TRIGGER trgTaoDongHoDienNuoc
ON dbo.Phong
FOR INSERT
AS
BEGIN
    DECLARE @MaPhong CHAR(40);
    SET @MaPhong = (
                       SELECT TOP 1 Inserted.MaPhong FROM Inserted
                   );
    PRINT @MaPhong;
    INSERT INTO dbo.DongHoDien (MaBanGhi, NgayGhi, ChiSoDien, MaPhong)
    VALUES
        (NEWID(), GETDATE(), 0, @MaPhong);
    INSERT INTO dbo.DongHoNuoc (MaBanGhi, NgayGhi, ChiSoNuoc, MaPhong)
    VALUES
        (NEWID(), GETDATE(), 0, @MaPhong);
END;

