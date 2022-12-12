using System;
using System.Collections.Generic;

namespace hosman_api.Data;

public partial class HopDongThue
{
    public string MaHopDong { get; set; } = null!;

    public string? FileHopDong { get; set; }

    public decimal TienCocDamBao { get; set; }

    public decimal TinhTrangCoc { get; set; }

    public string MaPhong { get; set; } = null!;

    public string MaNguoiThue { get; set; } = null!;

    public virtual ICollection<DanhSachNguoiTro> DanhSachNguoiTros { get; } = new List<DanhSachNguoiTro>();

    public virtual ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();

    public virtual NguoiDung MaNguoiThueNavigation { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;

    public virtual ICollection<PhuLuc> PhuLucs { get; } = new List<PhuLuc>();

    public virtual ICollection<YeuCauSuaChua> YeuCauSuaChuas { get; } = new List<YeuCauSuaChua>();
}
