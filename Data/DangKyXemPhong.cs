using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class DangKyXemPhong
{
    public string MaDangKy { get; set; } = null!;

    public DateTime NgayDangKy { get; set; }

    public DateTime NgayHenXem { get; set; }

    public string? GhiChu { get; set; }

    public int TinhTrang { get; set; }

    public string NguoiDung { get; set; } = null!;

    public string MaPhong { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;

    public virtual NguoiDung NguoiDungNavigation { get; set; } = null!;
}
