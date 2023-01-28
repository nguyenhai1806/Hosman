using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhuLucController : ControllerBase
    {
        private readonly IPhuLucRepository _repoPhuLuc;

        public PhuLucController(IPhuLucRepository repoPhuLuc)
        {
            _repoPhuLuc = repoPhuLuc;
        }

        [HttpGet("{maPhuLuc}")]
        public IActionResult GetItemsByID(string maPhuLuc)
        {
            PhuLucModel phuLuc = _repoPhuLuc.GetPhuLucByID(maPhuLuc);
            return Ok(phuLuc);
        }

        [HttpGet("HopDong/{maHopDong}")]
        public IActionResult GetItemsByHopDong(string maHopDong)
        {
            List<PhuLucModel> list = _repoPhuLuc.GetPhuLucByHopDong(maHopDong);
            return Ok(list);
        }

        [HttpPost]
        public IActionResult PostNewItem(PhuLucModel phuLucModel)
        {
            List<PhuLucModel> listPhuLuc = _repoPhuLuc.GetPhuLucByHopDong(phuLucModel.MaHopDong);
            if (listPhuLuc.Exists(p => p.NgayKetThuc.Ticks >= phuLucModel.NgayBatDau.Ticks))
                return BadRequest("Phòng đã được thuê trong khoảng thời gian này");

            phuLucModel.MaPhuLuc = Guid.NewGuid().ToString().ToUpper();
            return _repoPhuLuc.PostPhuLuc(phuLucModel) ? Ok(phuLucModel) : BadRequest();
        }

        [HttpPut("{maPhuLuc}")]
        public IActionResult PutItem(string maPhuLuc, PhuLucModel phuLucModel)
        {
            if (maPhuLuc != phuLucModel.MaPhuLuc)
                return BadRequest();

            List<PhuLucModel> listPhuLuc = _repoPhuLuc.GetPhuLucByHopDong(phuLucModel.MaHopDong);
            if (listPhuLuc.Exists(p => p.NgayKetThuc.Ticks >= phuLucModel.NgayBatDau.Ticks && phuLucModel.MaPhuLuc != p.MaPhuLuc))
                return BadRequest("Phòng đã được thuê trong khoảng thời gian này");

            phuLucModel.MaPhuLuc = Guid.NewGuid().ToString();
            return _repoPhuLuc.PostPhuLuc(phuLucModel) ? Ok(phuLucModel) : BadRequest();
        }

        [HttpDelete("{maPhuLuc}")]
        public IActionResult DeleteItem(string maPhuLuc)
        {
            try
            {
                if (_repoPhuLuc.GetPhuLucByID(maPhuLuc) == null)
                    return NotFound();
                return _repoPhuLuc.DeletePhuLuc(maPhuLuc) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}