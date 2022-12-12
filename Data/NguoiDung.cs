using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class NguoiDung
{
    public string MaNguoiDung { get; set; } = null!;

    public string TenNguoiDung { get; set; } = null!;

    public string Cccd { get; set; } = null!;

    public DateTime? NgayCap { get; set; }

    public string? NoiCap { get; set; }

    public string SoDienThoai { get; set; } = null!;

    public DateTime? NgaySinh { get; set; }

    public bool GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? AnhCccdtruoc { get; set; }

    public string? AnhCccdsau { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public virtual ICollection<BinhLuan> BinhLuanChuTroNavigations { get; } = new List<BinhLuan>();

    public virtual ICollection<BinhLuan> BinhLuanNguoiBinhLuanNavigations { get; } = new List<BinhLuan>();

    public virtual ICollection<DangKyXemPhong> DangKyXemPhongs { get; } = new List<DangKyXemPhong>();

    public virtual ICollection<HopDongThue> HopDongThues { get; } = new List<HopDongThue>();

    public virtual ICollection<KhuTro> KhuTros { get; } = new List<KhuTro>();

    public virtual ICollection<PhieuCocGiuPhong> PhieuCocGiuPhongs { get; } = new List<PhieuCocGiuPhong>();

    public virtual ICollection<QlNguoiDungNhomNguoiDung> QlNguoiDungNhomNguoiDungs { get; } = new List<QlNguoiDungNhomNguoiDung>();
}
