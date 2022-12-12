namespace hosman_api.Models
{
    public class DangKyXemPhongModel
    {
        public string MaDangKy { get; set; } = null!;
        public DateTime NgayDangKy { get; set; }
        public DateTime NgayHenXem { get; set; }
        public string? GhiChu { get; set; }
        public int TinhTrang { get; set; }
        public string NguoiDung { get; set; } = null!;
        public string MaPhong { get; set; } = null!;
    }
}
