using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class DanhSachNguoiTro
{
    public string MaNguoiTro { get; set; } = null!;

    public string TenNguoiTro { get; set; } = null!;

    public string Cccd { get; set; } = null!;

    public DateTime? NgayCap { get; set; }

    public string? NoiCap { get; set; }

    public string SoDienThoai { get; set; } = null!;

    public DateTime? NgaySinh { get; set; }

    public bool GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? AnhCccdtruoc { get; set; }

    public string? AnhCccdsau { get; set; }

    public string MaHopDong { get; set; } = null!;

    public DateTime? NgayDangKyTamTru { get; set; }

    public bool? XacMinhThongTin { get; set; }

    public virtual HopDongThue MaHopDongNavigation { get; set; } = null!;
}
