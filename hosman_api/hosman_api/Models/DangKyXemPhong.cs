using System;
using System.Collections.Generic;

namespace hosman_api.Models;
public class DangKyXemPhongVM
{
    public DateTime NgayDangKy { get; set; }
    public DateTime NgayHenXem { get; set; }
    public string? GhiChu { get; set; }
    public int TinhTrang { get; set; }
    public string NguoiDung { get; set; } = null!;
    public string MaPhong { get; set; } = null!;
}
public partial class DangKyXemPhong: DangKyXemPhongVM
{
    public string MaDangKy { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;

    public virtual NguoiDung NguoiDungNavigation { get; set; } = null!;
}
