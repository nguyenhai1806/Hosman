namespace hosman_api.Models
{
    public class NguoiDungModel
    {
        public string MaNguoiDung { get; set; } = null!;

        public string TenNguoiDung { get; set; } = null!;

        public string Cccd { get; set; } = null!;

        public DateTime? NgayCap { get; set; }

        public string? NoiCap { get; set; }

        public string SoDienThoai { get; set; } = null!;

        public DateTime? NgaySinh { get; set; }

        public bool GioiTinh { get; set; }

        public string? DiaChi { get; set; }

        public string? AnhCccdtruoc { get; set; }

        public string? AnhCccdsau { get; set; }

        public string? Email { get; set; }

        public string? MatKhau { get; set; }
    }
}
