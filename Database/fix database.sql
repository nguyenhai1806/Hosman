USE HOSMAN123
GO

DELETE YEUCAUSAUCHUA
DROP TABLE YEUCAUSAUCHUA

CREATE TABLE YeuCauSuaChua
(
    MaYeuCau CHAR(40) PRIMARY KEY,
    ChiTiet NVARCHAR(150) NOT NULL,
    HinhAnh VARCHAR(MAX) NOT NULL,
    NgayYeuCau DATE NOT NULL,
    TinhTrang INT, --: 0 Da gui, 1: Da sua chua, 2: Tu choi
    MaHopDong CHAR(40) NOT NULL,
    CONSTRAINT FK_SuaChua_HopDong
        FOREIGN KEY (MaHopDong)
        REFERENCES dbo.HopDongThue (MaHopDong)
);

INSERT INTO dbo.YeuCauSuaChua
(
    MaYeuCau,
    ChiTiet,
    HinhAnh,
    TinhTrang,
    MaHopDong,
    NgayYeuCau
)
VALUES
(NEWID(), N'May lanh bị hỏng', '', 1, '2FC00D0B-A84A-4C19-A296-22B661DFD18C', '07/11/2022'),
(NEWID(), N'Máy nước nóng', '', 1, '2FC00D0B-A84A-4C19-A296-22B661DFD18C', '10/11/2022'),
(NEWID(), N'Bồn rửa tay bị rỉ nước', '', 2, '2FFD4B4A-EB08-4D00-8DA4-C17564F3DB87', '06/11/2022'),
(NEWID(), N'Bồn tắm bị hư', '', 1, '6A502DDE-989C-4E6A-B91E-281CF1B87E38', '09/05/2022'),
(NEWID(), N'Gác bị hư', '', 2, 'C7C779F3-ED14-4EDE-9489-DB1638BEFEB7', '05/06/2022'),
(NEWID(), N'Tường nứt', '', 2, 'C7C779F3-ED14-4EDE-9489-DB1638BEFEB7', '01/07/2022');

