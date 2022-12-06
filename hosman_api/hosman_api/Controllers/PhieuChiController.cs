using hosman_api.DAL;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuChiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(PhieuChiDAL.Instance.GetAllItems());
        }

        [HttpGet("{maPhieuChi}")]
        public IActionResult GetItemByID(string maPhieuChi)
        {
            PhieuChi item = PhieuChiDAL.Instance.GetItemByID(maPhieuChi);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(PhieuChiVM itemVM)
        {
            try
            {
                PhieuChi phieuChi = new PhieuChi();
                phieuChi.MaPhieuChi = Guid.NewGuid().ToString();
                phieuChi.ChiTietChi = itemVM.ChiTietChi;
                phieuChi.NgayChi = itemVM.NgayChi;
                phieuChi.ChiPhi = itemVM.ChiPhi;
                phieuChi.TienKhachTra = itemVM.TienKhachTra;
                phieuChi.MaKhuTro = itemVM.MaKhuTro;
                phieuChi.GhiChu = itemVM.GhiChu;

                return PhieuChiDAL.Instance.PostNewItem(phieuChi) ? Ok(phieuChi) : BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{maPhieuChi}")]
        public IActionResult PutItem(string maPhieuChi, PhieuChi updateItem)
        {
            if (maPhieuChi != updateItem.MaPhieuChi)
                return BadRequest();

            return PhieuChiDAL.Instance.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maPhieuChi}")]
        public IActionResult DeleteItem(string maPhieuChi)
        {
            try
            {
                if (PhieuChiDAL.Instance.GetItemByID(maPhieuChi) == null)
                    return NotFound();
                return PhieuChiDAL.Instance.RemoveItem(maPhieuChi) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}