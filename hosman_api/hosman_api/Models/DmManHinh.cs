using System;
using System.Collections.Generic;

namespace hosman_api.Models;

public partial class DmManHinh
{
    public string MaManHinh { get; set; } = null!;

    public string TenManHinh { get; set; } = null!;

    public virtual ICollection<QlPhanQuyen> QlPhanQuyens { get; } = new List<QlPhanQuyen>();
}
