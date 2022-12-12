namespace hosman_api.Models
{
    public class BinhLuanModel
    {
        public string MaBinhLuan { get; set; } = null!;

        public DateTime Ngay { get; set; }

        public string NoiDung { get; set; } = null!;

        public string? HinhAnh { get; set; }

        public bool? TrangThai { get; set; }

        public string NguoiBinhLuan { get; set; } = null!;

        public string ChuTro { get; set; } = null!;
    }
}
