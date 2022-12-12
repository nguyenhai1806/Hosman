using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class QlNhomNguoiDung
{
    public string MaNhom { get; set; } = null!;

    public string TenNhom { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual ICollection<QlNguoiDungNhomNguoiDung> QlNguoiDungNhomNguoiDungs { get; } = new List<QlNguoiDungNhomNguoiDung>();

    public virtual ICollection<QlPhanQuyen> QlPhanQuyens { get; } = new List<QlPhanQuyen>();
}
