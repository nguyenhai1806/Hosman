using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class BinhLuan
{
    public string MaBinhLuan { get; set; } = null!;

    public DateTime Ngay { get; set; }

    public string NoiDung { get; set; } = null!;

    public string? HinhAnh { get; set; }

    public bool? TrangThai { get; set; }

    public string NguoiBinhLuan { get; set; } = null!;

    public string ChuTro { get; set; } = null!;

    public virtual NguoiDung ChuTroNavigation { get; set; } = null!;

    public virtual NguoiDung NguoiBinhLuanNavigation { get; set; } = null!;
}
