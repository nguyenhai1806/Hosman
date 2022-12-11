﻿using System;
using System.Collections.Generic;

namespace hosman_api.Models;
public class DichVuKhuTroVM
{
    public string MaDichVu { get; set; } = null!;

    public string MaKhuTro { get; set; } = null!;
    public decimal DonGia { get; set; }
}

public partial class DichVuKhuTro: DichVuKhuTroVM
{
   
    public virtual ICollection<DichVuPhong> DichVuPhongs { get; } = new List<DichVuPhong>();

    public virtual DichVu MaDichVuNavigation { get; set; } = null!;

    public virtual KhuTro MaKhuTroNavigation { get; set; } = null!;
}
