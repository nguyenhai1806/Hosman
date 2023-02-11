using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class TienIch
{
    public string MaTienIch { get; set; } = null!;

    public string TenTienIch { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual ICollection<KhuTro> MaKhuTros { get; } = new List<KhuTro>();
}
