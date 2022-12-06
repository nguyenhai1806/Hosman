namespace hosman_api.Models;

public class TienIchVM
{
    public string TenTienIch { get; set; } = null!;
    public string? GhiChu { get; set; }
}

public partial class TienIch : TienIchVM
{
    public string MaTienIch { get; set; } = null!;
    public virtual ICollection<KhuTro> MaKhuTros { get; } = new List<KhuTro>();
}
