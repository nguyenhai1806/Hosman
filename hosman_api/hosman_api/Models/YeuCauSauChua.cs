using System;
using System.Collections.Generic;

namespace hosman_api.Models;

public partial class YeuCauSauChua
{
    public string MaYeuCau { get; set; } = null!;

    public string ChiTiet { get; set; } = null!;

    public string HinhAnh { get; set; } = null!;

    public DateTime NgayYeuCau { get; set; }

    public int? TinhTrang { get; set; }

    public string MaHopDong { get; set; } = null!;

    public virtual HopDongThue MaHopDongNavigation { get; set; } = null!;
}
