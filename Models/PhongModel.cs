namespace hosman_api.Models
{
    public class PhongModel
    {
        public string MaPhong { get; set; } = null!;
        public string TenPhong { get; set; } = null!;

        public double DienTich { get; set; }

        public decimal GiaThue { get; set; }

        public int? UuTien { get; set; }

        public string? GhiChu { get; set; }

        public bool TinhTrang { get; set; }

        public string MaKhuTro { get; set; } = null!;
    }
}
