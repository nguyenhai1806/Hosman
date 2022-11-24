using System;
using System.Collections.Generic;

namespace hosman_api.Models;

public partial class KhuTro
{
    public string MaKhuTro { get; set; } = null!;

    public string TenKhu { get; set; } = null!;

    public int? SoPhong { get; set; }

    public string DiaChi { get; set; } = null!;

    public decimal GiaDien { get; set; }

    public decimal GiaNuoc { get; set; }

    public int NgayLapHd { get; set; }

    public int HanDongTien { get; set; }

    public string MaNguoiDung { get; set; } = null!;

    public virtual ICollection<DichVuKhuTro> DichVuKhuTros { get; } = new List<DichVuKhuTro>();

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;

    public virtual ICollection<PhieuChi> PhieuChis { get; } = new List<PhieuChi>();

    public virtual ICollection<Phong> Phongs { get; } = new List<Phong>();

    public virtual ICollection<TienIch> MaTienIches { get; } = new List<TienIch>();
}
