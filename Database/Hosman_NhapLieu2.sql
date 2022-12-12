--Hợp đồng thuê (Kiểm tra không trùng)
--Phụ lục
--Danh sách người trọ
--Yêu cầu sữa chữa
--Hoa đơn
--Hoá đơn_Phieu Chi
--HoaDonDien --> Update dong ho dien
--HoaDonNuoc -> Dong Ho nước
--Hoá đơn dịch vụ


INSERT INTO dbo.HopDongThue (MaHopDong, FileHopDong, TienCocDamBao, TinhTrangCoc, MaPhong, MaNguoiThue)
VALUES
    ('C7C779F3-ED14-4EDE-9489-DB1638BEFEB7', '', 2000000, 1, '32EFA4A6-76B6-428B-9FD0-18E7CB9995B2',
     '0EFC79B1-B8D7-4EF7-8722-46203B3802D3');
INSERT INTO dbo.HopDongThue (MaHopDong, FileHopDong, TienCocDamBao, TinhTrangCoc, MaPhong, MaNguoiThue)
VALUES
    ('2FC00D0B-A84A-4C19-A296-22B661DFD18C', '', 3500000, 0, '38C535A1-38EA-43BB-BBCA-5A621F714C22',
     '43D0D77E-4FF2-4558-9870-DB9EEC42714A');
INSERT INTO dbo.HopDongThue (MaHopDong, FileHopDong, TienCocDamBao, TinhTrangCoc, MaPhong, MaNguoiThue)
VALUES
    ('2FFD4B4A-EB08-4D00-8DA4-C17564F3DB87', '', 4500000, 1, '7F68D39E-7EF8-435F-BAD6-F20F2681519C',
     '43D0D77E-4FF2-4558-9870-DB9EEC42714A');
INSERT INTO dbo.HopDongThue (MaHopDong, FileHopDong, TienCocDamBao, TinhTrangCoc, MaPhong, MaNguoiThue)
VALUES
    ('6A502DDE-989C-4E6A-B91E-281CF1B87E38', '', 6900000, 0, 'A62F6D7C-A3B3-4AA5-8EEE-3D3BD98AE2E5',
     'F5A5DD74-D4C0-4F42-B821-FE3F5047032A');

SET DATEFORMAT DMY;
INSERT INTO dbo.PhuLuc (MaPhuLuc, NgayBatDau, NgayKetThuc, GiaThue, GhiChu, MaHopDong)
VALUES
    ('B0BCDAEF-BAD1-4415-BF27-C1B4F3E80214', '03/03/2022', '03/06/2022', 2000000, N'',
     'C7C779F3-ED14-4EDE-9489-DB1638BEFEB7');
INSERT INTO dbo.PhuLuc (MaPhuLuc, NgayBatDau, NgayKetThuc, GiaThue, GhiChu, MaHopDong)
VALUES
    ('B471BC1F-F89D-44DF-B326-DED435C778F7', '04/06/2022', '04/09/2022', 3000000, N'',
     'C7C779F3-ED14-4EDE-9489-DB1638BEFEB7');
INSERT INTO dbo.PhuLuc (MaPhuLuc, NgayBatDau, NgayKetThuc, GiaThue, GhiChu, MaHopDong)
VALUES
    ('79B93C91-D178-496D-862F-ADCB974784F4', '12/08/2022', '12/1/2023', 4000000, N'',
     '2FC00D0B-A84A-4C19-A296-22B661DFD18C');
INSERT INTO dbo.PhuLuc (MaPhuLuc, NgayBatDau, NgayKetThuc, GiaThue, GhiChu, MaHopDong)
VALUES
    ('1FE9C21A-45C7-4F33-9EE8-17DAD2883719', '05/04/2022', '05/10/2022', 8000000, N'',
     '6A502DDE-989C-4E6A-B91E-281CF1B87E38');
INSERT INTO dbo.PhuLuc (MaPhuLuc, NgayBatDau, NgayKetThuc, GiaThue, GhiChu, MaHopDong)
VALUES
    ('FAF10DCB-D46F-45AC-BC89-ADF8F080038E', '05/08/2022', '05/08/2023', 9000000, N'',
     '6A502DDE-989C-4E6A-B91E-281CF1B87E38');
INSERT INTO dbo.PhuLuc (MaPhuLuc, NgayBatDau, NgayKetThuc, GiaThue, GhiChu, MaHopDong)
VALUES
    ('F5A5DD74-D4C0-4F42-B821-FE3F5047032A', '05/11/2022', '05/1/2023', 9000000, N'',
     '2FFD4B4A-EB08-4D00-8DA4-C17564F3DB87');

SET DATEFORMAT DMY;
INSERT INTO dbo.DanhSachNguoiTro (MaNguoiTro, TenNguoiTro, CCCD, NgayCap, NoiCap, SoDienThoai, NgaySinh, GioiTinh,
                                  DiaChi, AnhCCCDTruoc, AnhCCCDSau, MaHopDong, NgayDangKyTamTru, XacMinhThongTin)
VALUES
    (NEWID(), N'Lê Văn Nam', '596886541594', GETDATE(), N'Cục cảnh sát', '0754748485', '22/08/1999', 1, N'1', N'', N'',
     'C7C779F3-ED14-4EDE-9489-DB1638BEFEB7', NULL, 0);
INSERT INTO dbo.DanhSachNguoiTro (MaNguoiTro, TenNguoiTro, CCCD, NgayCap, NoiCap, SoDienThoai, NgaySinh, GioiTinh,
                                  DiaChi, AnhCCCDTruoc, AnhCCCDSau, MaHopDong, NgayDangKyTamTru, XacMinhThongTin)
VALUES
    (NEWID(), N'Nguyễn Thị Lệ Chi', '775349591875', GETDATE(), N'Cục cảnh sát', '0841485663', '15/08/2002', 0, N'',
     N'', N'', '2FFD4B4A-EB08-4D00-8DA4-C17564F3DB87', NULL, 1);
INSERT INTO dbo.DanhSachNguoiTro (MaNguoiTro, TenNguoiTro, CCCD, NgayCap, NoiCap, SoDienThoai, NgaySinh, GioiTinh,
                                  DiaChi, AnhCCCDTruoc, AnhCCCDSau, MaHopDong, NgayDangKyTamTru, XacMinhThongTin)
VALUES
    (NEWID(), N'Đoàn Thị Ánh', '226499239473', GETDATE(), N'Cục cảnh sát', '0952776465', GETDATE(), 0, N'', N'', N'',
     '2FC00D0B-A84A-4C19-A296-22B661DFD18C', GETDATE(), 0);
INSERT INTO dbo.DanhSachNguoiTro (MaNguoiTro, TenNguoiTro, CCCD, NgayCap, NoiCap, SoDienThoai, NgaySinh, GioiTinh,
                                  DiaChi, AnhCCCDTruoc, AnhCCCDSau, MaHopDong, NgayDangKyTamTru, XacMinhThongTin)
VALUES
    (NEWID(), N'Châu Ngọc Thạch Anh	', '213337238485', GETDATE(), N'Cục cảnh sát', '0182927463', '08/08/1989', 1, N'',
     N'', N'', '2FC00D0B-A84A-4C19-A296-22B661DFD18C', NULL, 0);
INSERT INTO dbo.DanhSachNguoiTro (MaNguoiTro, TenNguoiTro, CCCD, NgayCap, NoiCap, SoDienThoai, NgaySinh, GioiTinh,
                                  DiaChi, AnhCCCDTruoc, AnhCCCDSau, MaHopDong, NgayDangKyTamTru, XacMinhThongTin)
VALUES
    (NEWID(), N'Dương Mỹ An', '222794571778', GETDATE(), N'Cục cảnh sát', '0588893566', GETDATE(), 0, N'', N'', N'',
     '2FC00D0B-A84A-4C19-A296-22B661DFD18C', GETDATE(), 1);
INSERT INTO dbo.DanhSachNguoiTro (MaNguoiTro, TenNguoiTro, CCCD, NgayCap, NoiCap, SoDienThoai, NgaySinh, GioiTinh,
                                  DiaChi, AnhCCCDTruoc, AnhCCCDSau, MaHopDong, NgayDangKyTamTru, XacMinhThongTin)
VALUES
    (NEWID(), N'Đỗ Thị Yến Anh	', '254283773741', GETDATE(), N'Cục cảnh sát', '0634821916', GETDATE(), 0, N'', N'',
     N'', '6A502DDE-989C-4E6A-B91E-281CF1B87E38', NULL, 1);
INSERT INTO dbo.DanhSachNguoiTro (MaNguoiTro, TenNguoiTro, CCCD, NgayCap, NoiCap, SoDienThoai, NgaySinh, GioiTinh,
                                  DiaChi, AnhCCCDTruoc, AnhCCCDSau, MaHopDong, NgayDangKyTamTru, XacMinhThongTin)
VALUES
    (NEWID(), N'Lê Kim Anh', '734785317231', GETDATE(), N'Cục cảnh sát', '0365925887', GETDATE(), 0, N'', N'', N'',
     '6A502DDE-989C-4E6A-B91E-281CF1B87E38', GETDATE(), 0);
INSERT INTO dbo.DanhSachNguoiTro (MaNguoiTro, TenNguoiTro, CCCD, NgayCap, NoiCap, SoDienThoai, NgaySinh, GioiTinh,
                                  DiaChi, AnhCCCDTruoc, AnhCCCDSau, MaHopDong, NgayDangKyTamTru, XacMinhThongTin)
VALUES
    (NEWID(), N'Lê Mai Hoàng Anh', '542242913922', GETDATE(), N'Cục cảnh sát', '0163968695', GETDATE(), 0, N'', N'',
     N'', '6A502DDE-989C-4E6A-B91E-281CF1B87E38', GETDATE(), 1);

INSERT INTO dbo.YeuCauSauChua (MaYeuCau, ChiTiet, HinhAnh, TinhTrang, MaHopDong, NgayYeuCau)
VALUES
    (NEWID(), N'May lanh bị hỏng', '', 1, '2FC00D0B-A84A-4C19-A296-22B661DFD18C', '07/11/2022'),
    (NEWID(), N'Máy nước nóng', '', 1, '2FC00D0B-A84A-4C19-A296-22B661DFD18C', '10/11/2022'),
    (NEWID(), N'Bồn rửa tay bị rỉ nước', '', 2, '2FFD4B4A-EB08-4D00-8DA4-C17564F3DB87', '06/11/2022'),
    (NEWID(), N'Bồn tắm bị hư', '', 1, '6A502DDE-989C-4E6A-B91E-281CF1B87E38', '09/05/2022'),
    (NEWID(), N'Gác bị hư', '', 2, 'C7C779F3-ED14-4EDE-9489-DB1638BEFEB7', '05/06/2022'),
    (NEWID(), N'Tường nứt', '', 2, 'C7C779F3-ED14-4EDE-9489-DB1638BEFEB7', '01/07/2022');


--Mã hợp đồng: C7C779F3-ED14-4EDE-9489-DB1638BEFEB7
SELECT HopDongThue.MaHopDong, FORMAT(NgayBatDau, 'dd/MM/yyyy') AS 'NgayBatDau',
       FORMAT(NgayKetThuc, 'dd/MM/yyyy') AS 'NgayKetThuc'
FROM dbo.HopDongThue
     JOIN dbo.PhuLuc ON PhuLuc.MaHopDong = HopDongThue.MaHopDong
     JOIN dbo.Phong ON Phong.MaPhong = HopDongThue.MaPhong
WHERE HopDongThue.MaHopDong = 'C7C779F3-ED14-4EDE-9489-DB1638BEFEB7';







