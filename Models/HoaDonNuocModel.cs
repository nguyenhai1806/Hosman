namespace hosman_api.Models
{
    public class HoaDonNuocModel
    {
        public string MaHoaDon { get; set; } = null!;

        public string BanGhiSoDau { get; set; } = null!;

        public string BanGhiSoCuoi { get; set; } = null!;

        public decimal DonGia { get; set; }

        public decimal ThanhTien { get; set; }
    }
}
