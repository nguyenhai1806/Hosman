namespace hosman_api.Models;
public class QlNhomNguoiDungVM
{
    public string TenNhom { get; set; } = null!;

    public string? GhiChu { get; set; }
}
public partial class QlNhomNguoiDung : QlNhomNguoiDungVM
{
    public string MaNhom { get; set; } = null!;

    public virtual ICollection<QlNguoiDungNhomNguoiDung> QlNguoiDungNhomNguoiDungs { get; } = new List<QlNguoiDungNhomNguoiDung>();

    public virtual ICollection<QlPhanQuyen> QlPhanQuyens { get; } = new List<QlPhanQuyen>();
}
