using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class HoaDonDichVu
{
    public string MaHoaDon { get; set; } = null!;

    public string MaDichVu { get; set; } = null!;

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public virtual DichVu MaDichVuNavigation { get; set; } = null!;

    public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;
}
