using hosman_api.DAL;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HopDongThueController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostNewItem(HopDong_PhuLuc hopDongPhuLuc)
        {
            HopDongThue hopDong = new HopDongThue();
            string maHopDong = Guid.NewGuid().ToString();
            hopDong.MaHopDong = maHopDong;
            hopDong.FileHopDong = hopDongPhuLuc.FileHopDong;
            hopDong.TienCocDamBao = hopDongPhuLuc.TienCocDamBao;
            hopDong.TinhTrangCoc = hopDongPhuLuc.TinhTrangCoc;
            hopDong.MaNguoiThue = hopDongPhuLuc.MaNguoiThue;
            hopDong.MaPhong = hopDongPhuLuc.MaPhong;

            PhuLuc phuLuc = new PhuLuc();
            phuLuc.MaPhuLuc = Guid.NewGuid().ToString();
            phuLuc.MaHopDong = maHopDong;
            phuLuc.GiaThue = hopDongPhuLuc.GiaThue;
            phuLuc.NgayBatDau = hopDongPhuLuc.NgayBatDau;
            phuLuc.NgayKetThuc = hopDongPhuLuc.NgayKetThuc;
            phuLuc.GhiChu = "Tạo mới hợp đồng";

            //return HopDongThueDAL.Instance.PostNewItem(hopDong, phuLuc) ? Ok(new { hopDong, phuLuc }) : BadRequest();

            bool result = HopDongThueDAL.Instance.PostNewItem(hopDong, phuLuc);
            hopDong.PhuLucs.Add(phuLuc);
            return result ? Ok(new { hopDong }) : BadRequest();

        }
    }
}
