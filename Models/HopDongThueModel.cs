namespace hosman_api.Models
{
    public class HopDongThueModel
    {
        public string MaHopDong { get; set; } = null!;

        public string? FileHopDong { get; set; }

        public decimal TienCocDamBao { get; set; }

        public decimal TinhTrangCoc { get; set; }

        public string MaPhong { get; set; } = null!;

        public string MaNguoiThue { get; set; } = null!;
    }
}
