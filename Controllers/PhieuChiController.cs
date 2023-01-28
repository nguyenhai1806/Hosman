using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuChiController : ControllerBase
    {
        private readonly IPhieuChiRepository _repo;
        public PhieuChiController(IPhieuChiRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                return Ok(_repo.GetAllItems());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{maPhieuChi}")]
        public IActionResult GetItemByID(string maPhieuChi)
        {
            PhieuChiModel item = _repo.GetItemByID(maPhieuChi);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(PhieuChiModel newItem)
        {
            try
            {

                newItem.MaPhieuChi = Guid.NewGuid().ToString().ToUpper();
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{maPhieuChi}")]
        public IActionResult PutItem(string maPhieuChi, PhieuChiModel updateItem)
        {
            if (maPhieuChi != updateItem.MaPhieuChi)
                return NotFound();
            return _repo.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maPhieuChi}")]
        public IActionResult DeleteItem(string maPhieuChi)
        {
            try
            {
                if (_repo.GetItemByID(maPhieuChi) == null)
                    return NotFound();
                return _repo.RemoveItem(maPhieuChi) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
