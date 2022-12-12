namespace hosman_api.Models
{
    public class LoaiPhongModel
    {
        public string MaLoai { get; set; } = null!;
        public string TenLoai { get; set; } = null!;

        public string? GhiChu { get; set; }
    }
}
