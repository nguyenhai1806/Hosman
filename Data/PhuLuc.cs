using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class PhuLuc
{
    public string MaPhuLuc { get; set; } = null!;

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public decimal GiaThue { get; set; }

    public string? GhiChu { get; set; }

    public string MaHopDong { get; set; } = null!;

    public virtual HopDongThue MaHopDongNavigation { get; set; } = null!;
}
