namespace hosman_api.Models
{
    public class PhieuChiModel
    {
        public string MaPhieuChi { get; set; } = null!;
        public string ChiTietChi { get; set; } = null!;

        public DateTime NgayChi { get; set; }

        public decimal ChiPhi { get; set; }

        public decimal? TienKhachTra { get; set; }

        public string MaKhuTro { get; set; } = null!;

        public string? GhiChu { get; set; }
    }
}
