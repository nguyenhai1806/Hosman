using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class LoaiPhong
{
    public string MaLoai { get; set; } = null!;

    public string TenLoai { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual ICollection<Phong> MaPhongs { get; } = new List<Phong>();
}
