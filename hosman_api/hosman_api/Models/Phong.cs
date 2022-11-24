using System;
using System.Collections.Generic;

namespace hosman_api.Models;

public partial class Phong
{
    public string MaPhong { get; set; } = null!;

    public string TenPhong { get; set; } = null!;

    public double DienTich { get; set; }

    public decimal GiaThue { get; set; }

    public int? UuTien { get; set; }

    public string? GhiChu { get; set; }

    public bool TinhTrang { get; set; }

    public string MaKhuTro { get; set; } = null!;

    public virtual ICollection<DangKyXemPhong> DangKyXemPhongs { get; } = new List<DangKyXemPhong>();

    public virtual ICollection<DichVuPhong> DichVuPhongs { get; } = new List<DichVuPhong>();

    public virtual ICollection<DongHoDien> DongHoDiens { get; } = new List<DongHoDien>();

    public virtual ICollection<DongHoNuoc> DongHoNuocs { get; } = new List<DongHoNuoc>();

    public virtual ICollection<HopDongThue> HopDongThues { get; } = new List<HopDongThue>();

    public virtual KhuTro MaKhuTroNavigation { get; set; } = null!;

    public virtual ICollection<PhieuCocGiuPhong> PhieuCocGiuPhongs { get; } = new List<PhieuCocGiuPhong>();

    public virtual ICollection<LoaiPhong> MaLoais { get; } = new List<LoaiPhong>();
}
