using hosman_api.DAL;
using hosman_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuCocGiuPhongController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostNewItem(PhieuCocGiuPhongVM itemVM)
        {
            try
            {
                PhieuCocGiuPhong phieuCocGiuPhong = new PhieuCocGiuPhong();
                phieuCocGiuPhong.MaPhieuCoc = Guid.NewGuid().ToString();
                phieuCocGiuPhong.NgayCoc = itemVM.NgayCoc;
                phieuCocGiuPhong.NgayDuKienVaoO = itemVM.NgayDuKienVaoO;
                phieuCocGiuPhong.SoTien = itemVM.SoTien;
                phieuCocGiuPhong.GhiChu = itemVM.GhiChu;
                phieuCocGiuPhong.DaHoanTien= itemVM.DaHoanTien;
                phieuCocGiuPhong.MaPhong = itemVM.MaPhong;
                phieuCocGiuPhong.MaNguoiDung = itemVM.MaNguoiDung;

                return PhieuCocGiuPhongDAL.Instance.PostNewItem(phieuCocGiuPhong) ? Ok(phieuCocGiuPhong) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("{maPhieuCoc}")]
        public IActionResult PutItem(string maPhieuCoc, PhieuCocGiuPhong updateItem)
        {
            try
            {
                if (maPhieuCoc != updateItem.MaPhieuCoc)
                {
                    return BadRequest();
                }
                else if (PhieuCocGiuPhongDAL.Instance.ItemExistsByID(maPhieuCoc))
                {
                    return PhieuCocGiuPhongDAL.Instance.PutItem(updateItem) ? Ok() : BadRequest();
                }
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet("{maPhieuCoc}")]
        public IActionResult ItemExistsByID(string maPhieuCoc)
        {
            try
            {
                bool item = PhieuCocGiuPhongDAL.Instance.ItemExistsByID(maPhieuCoc);
                return item ? Ok(item) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{maPhieuCoc}")]
        public IActionResult DeleteItem(string maPhieuCoc)
        {
            try
            {
                if (PhieuCocGiuPhongDAL.Instance.ItemExistsByID(maPhieuCoc))
                {
                    return PhieuCocGiuPhongDAL.Instance.RemoveItem(maPhieuCoc) ? Ok() : BadRequest();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
