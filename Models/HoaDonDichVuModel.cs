namespace hosman_api.Models
{
    public class HoaDonDichVuModel
    {
        public string MaHoaDon { get; set; } = null!;

        public string MaDichVu { get; set; } = null!;

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }

        public decimal ThanhTien { get; set; }
    }
}
