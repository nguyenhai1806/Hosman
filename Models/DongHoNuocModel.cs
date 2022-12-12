namespace hosman_api.Models
{
    public class DongHoNuocModel
    {
        public string MaBanGhi { get; set; } = null!;

        public DateTime NgayGhi { get; set; }

        public int ChiSoNuoc { get; set; }

        public string MaPhong { get; set; } = null!;
    }
}
