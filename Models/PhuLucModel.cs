namespace hosman_api.Models
{
    public class PhuLucModel
    {
        public string MaPhuLuc { get; set; } = null!;

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public decimal GiaThue { get; set; }

        public string? GhiChu { get; set; }

        public string MaHopDong { get; set; } = null!;
    }
}
