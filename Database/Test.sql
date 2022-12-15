SELECT *
FROM HopDongThue h
     LEFT JOIN PhuLuc p ON h.MaHopDong = p.MaHopDong
	 WHERE H.MaHopDong = '6A502DDE-989C-4E6A-B91E-281CF1B87E38' 
	

DELETE PhuLuc
WHERE MaHopDong IN
      (
          SELECT MaHopDong FROM dbo.PhuLuc WHERE GhiChu = N'Tạo mới hợp đồng'
      );
DELETE HopDongThue WHERE MaHopDong = N'6A502DDE-989C-4E6A-B91E-281CF1B87E38    ';

SELECT * FROM Phong;
SELECT * FROM NguoiDung;
SELECT * FROM HopDongThue;



{
 "fileHopDong": "string",
 "tienCocDamBao": 10,
 "tinhTrangCoc": 0,
 "maPhong": "38C535A1-38EA-43BB-BBCA-5A621F714C22",
 "ngayBatDau": "2022-12-11T09:54:07.815Z",
 "ngayKetThuc": "2023-12-11T09:54:07.815Z",
 "giaThue": 10,
 "ghiChu": "string",
 "maNguoiThue": "54309E44-4174-482B-B940-48E47C1633F2"
}