namespace hosman_api.Models
{
    public class PhieuCocGiuPhongModel
    {
        public string MaPhieuCoc { get; set; } = null!;
        public DateTime NgayCoc { get; set; }

        public DateTime NgayDuKienVaoO { get; set; }

        public decimal SoTien { get; set; }

        public string? GhiChu { get; set; }

        public bool DaHoanTien { get; set; }

        public string MaPhong { get; set; } = null!;

        public string MaNguoiDung { get; set; } = null!;
    }
}
