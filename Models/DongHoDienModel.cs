namespace hosman_api.Models
{
    public class DongHoDienModel
    {
        public string MaBanGhi { get; set; } = null!;

        public DateTime NgayGhi { get; set; }

        public int ChiSoDien { get; set; }

        public string MaPhong { get; set; } = null!;
    }
}
