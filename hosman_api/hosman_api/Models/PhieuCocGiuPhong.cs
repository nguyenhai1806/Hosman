using System;
using System.Collections.Generic;

namespace hosman_api.Models;
public class PhieuCocGiuPhongVM
{
    public DateTime NgayCoc { get; set; }

    public DateTime NgayDuKienVaoO { get; set; }

    public decimal SoTien { get; set; }

    public string? GhiChu { get; set; }

    public bool DaHoanTien { get; set; }

    public string MaPhong { get; set; } = null!;

    public string MaNguoiDung { get; set; } = null!;
}
public partial class PhieuCocGiuPhong: PhieuCocGiuPhongVM
{
    public string MaPhieuCoc { get; set; } = null!;

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
