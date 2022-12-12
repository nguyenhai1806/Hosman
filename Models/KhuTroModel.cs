namespace hosman_api.Models
{
    public class KhuTroModel
    {
        public string MaKhuTro { get; set; } = null!;


        public string TenKhu { get; set; } = null!;

        public string DiaChi { get; set; } = null!;

        public decimal GiaDien { get; set; }

        public decimal GiaNuoc { get; set; }

        public int NgayLapHd { get; set; }

        public int HanDongTien { get; set; }
        public int? SoPhong { get; set; }
        public string MaNguoiDung { get; set; } = null!;
    }
}
