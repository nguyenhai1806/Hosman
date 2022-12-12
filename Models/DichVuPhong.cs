using System;
using System.Collections.Generic;

namespace hosman_api.Models;
public class DichVuPhongVM
{
    public int SoLuong { get; set; }
    public string MaKhuTro { get; set; } = null!;

    public string MaPhong { get; set; } = null!;

}
public partial class DichVuPhong: DichVuPhongVM
{
   
    public string MaDichVu { get; set; } = null!;

    
    public virtual DichVuKhuTro Ma { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
