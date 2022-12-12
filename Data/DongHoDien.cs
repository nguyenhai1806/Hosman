using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class DongHoDien
{
    public string MaBanGhi { get; set; } = null!;

    public DateTime NgayGhi { get; set; }

    public int ChiSoDien { get; set; }

    public string MaPhong { get; set; } = null!;

    public virtual ICollection<HoaDonDien> HoaDonDienBanGhiSoCuoiNavigations { get; } = new List<HoaDonDien>();

    public virtual ICollection<HoaDonDien> HoaDonDienBanGhiSoDauNavigations { get; } = new List<HoaDonDien>();

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
