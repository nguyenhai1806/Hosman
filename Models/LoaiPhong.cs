namespace hosman_api.Models;

public class LoaiPhongVM
{
    public string TenLoai { get; set; } = null!;

    public string? GhiChu { get; set; }
}
public partial class LoaiPhong : LoaiPhongVM
{
    public string MaLoai { get; set; } = null!;

    public virtual ICollection<Phong> MaPhongs { get; } = new List<Phong>();
}
