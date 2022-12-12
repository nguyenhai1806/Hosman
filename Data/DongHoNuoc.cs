using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class DongHoNuoc
{
    public string MaBanGhi { get; set; } = null!;

    public DateTime NgayGhi { get; set; }

    public int ChiSoNuoc { get; set; }

    public string MaPhong { get; set; } = null!;

    public virtual ICollection<HoaDonNuoc> HoaDonNuocBanGhiSoCuoiNavigations { get; } = new List<HoaDonNuoc>();

    public virtual ICollection<HoaDonNuoc> HoaDonNuocBanGhiSoDauNavigations { get; } = new List<HoaDonNuoc>();

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
