namespace hosman_api.Models
{
    public class HopDong_PhuLuc
    {
        public string? FileHopDong { get; set; }

        public decimal TienCocDamBao { get; set; }

        public decimal TinhTrangCoc { get; set; }

        public string MaPhong { get; set; } = null!;

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public decimal GiaThue { get; set; }

        public string MaNguoiThue { get; set; } = null!;
    }
}
