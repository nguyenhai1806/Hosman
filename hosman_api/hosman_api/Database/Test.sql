SELECT *
FROM HopDongThue h
    LEFT JOIN PhuLuc p
        ON h.MaHopDong = p.MaHopDong

DECLARE @MaHopDong NVARCHAR(MAX) = 'a1ba026d-bb9a-4d9d-b924-985e6902894b    '
DELETE PhuLuc WHERE MaHopDong = @MaHopDong
DELETE HopDongThue WHERE MaHopDong = @MaHopDong


SELECT *
FROM Phong
SELECT *
FROM NguoiDung
SELECT *
FROM HopDongThue

--{
--  "fileHopDong": "string",
--  "tienCocDamBao": 10,
--  "tinhTrangCoc": 0,
--  "maPhong": "38C535A1-38EA-43BB-BBCA-5A621F714C22",
--  "ngayBatDau": "2022-12-11T09:54:07.815Z",
--  "ngayKetThuc": "2023-12-11T09:54:07.815Z",
--  "giaThue": 10,
--  "ghiChu": "string",
--  "maNguoiThue": "54309E44-4174-482B-B940-48E47C1633F2"
--}