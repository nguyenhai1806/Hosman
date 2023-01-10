namespace hosman_api.Models
{
    public class HoaDonDienModel
    {
        public string MaHoaDon { get; set; } = null!;

        public string BanGhiSoDau { get; set; } = null!;

        public string BanGhiSoCuoi { get; set; } = null!;

        public decimal DonGia { get; set; }

        public decimal ThanhTien { get; set; }
    }
}
