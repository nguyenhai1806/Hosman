using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class HoaDon
{
    public string MaHoaDon { get; set; } = null!;

    public DateTime? NgayThanhToan { get; set; }

    public DateTime TuNgay { get; set; }

    public DateTime ToiNgay { get; set; }

    public DateTime NgayLapHd { get; set; }

    public DateTime HanDongTien { get; set; }

    public decimal TongTien { get; set; }

    public decimal TienPhong { get; set; }

    public string? GhiChu { get; set; }

    public string MaHopDong { get; set; } = null!;

    public virtual ICollection<HoaDonDichVu> HoaDonDichVus { get; } = new List<HoaDonDichVu>();

    public virtual HoaDonDien? HoaDonDien { get; set; }

    public virtual HoaDonNuoc? HoaDonNuoc { get; set; }

    public virtual HopDongThue MaHopDongNavigation { get; set; } = null!;

    public virtual ICollection<PhieuChi> MaPhieuChis { get; } = new List<PhieuChi>();
}
