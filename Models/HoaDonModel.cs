namespace hosman_api.Models
{
    public class HoaDonModel
    {
        public string MaHoaDon { get; set; } = null!;

        public DateTime? NgayThanhToan { get; set; }

        public DateTime TuNgay { get; set; }

        public DateTime ToiNgay { get; set; }

        public DateTime NgayLapHd { get; set; }

        public DateTime HanDongTien { get; set; }
    }
}
