using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class DichVu
{
    public string MaDichVu { get; set; } = null!;

    public string TenDichVu { get; set; } = null!;

    public string DonViTinh { get; set; } = null!;

    public virtual ICollection<DichVuKhuTro> DichVuKhuTros { get; } = new List<DichVuKhuTro>();

    public virtual ICollection<HoaDonDichVu> HoaDonDichVus { get; } = new List<HoaDonDichVu>();
}
