using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class QlNguoiDungNhomNguoiDung
{
    public string MaNguoiDung { get; set; } = null!;

    public string MaNhomNguoiDung { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;

    public virtual QlNhomNguoiDung MaNhomNguoiDungNavigation { get; set; } = null!;
}
