using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class HoaDonDien
{
    public string MaHoaDon { get; set; } = null!;

    public string BanGhiSoDau { get; set; } = null!;

    public string BanGhiSoCuoi { get; set; } = null!;

    public decimal DonGia { get; set; }

    public decimal ThanhTien { get; set; }

    public virtual DongHoDien BanGhiSoCuoiNavigation { get; set; } = null!;

    public virtual DongHoDien BanGhiSoDauNavigation { get; set; } = null!;

    public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;
}
