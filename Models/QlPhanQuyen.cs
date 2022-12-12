using System;
using System.Collections.Generic;

namespace hosman_api.Models;

public partial class QlPhanQuyen
{
    public string MaNhomNguoiDung { get; set; } = null!;

    public string MaManHinh { get; set; } = null!;

    public bool CoQuyen { get; set; }

    public virtual DmManHinh MaManHinhNavigation { get; set; } = null!;

    public virtual QlNhomNguoiDung MaNhomNguoiDungNavigation { get; set; } = null!;
}
