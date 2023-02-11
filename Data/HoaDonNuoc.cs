using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class HoaDonNuoc
{
    public string MaHoaDon { get; set; } = null!;

    public string BanGhiSoDau { get; set; } = null!;

    public string BanGhiSoCuoi { get; set; } = null!;

    public decimal DonGia { get; set; }

    public int SoLuong { get; set; }

    public virtual DongHoNuoc BanGhiSoCuoiNavigation { get; set; } = null!;

    public virtual DongHoNuoc BanGhiSoDauNavigation { get; set; } = null!;

    public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;
}
