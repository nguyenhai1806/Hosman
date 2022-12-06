namespace hosman_api.Models;

public class PhieuChiVM
{
    public string ChiTietChi { get; set; } = null!;

    public DateTime NgayChi { get; set; }

    public decimal ChiPhi { get; set; }

    public decimal? TienKhachTra { get; set; }

    public string MaKhuTro { get; set; } = null!;

    public string? GhiChu { get; set; }
}

public partial class PhieuChi : PhieuChiVM
{
    public string MaPhieuChi { get; set; } = null!;

    public virtual KhuTro MaKhuTroNavigation { get; set; } = null!;

    public virtual ICollection<HoaDon> MaHoaDons { get; } = new List<HoaDon>();
}
