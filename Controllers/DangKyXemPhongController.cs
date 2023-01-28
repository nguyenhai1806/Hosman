using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DangKyXemPhongController : ControllerBase
    {
        private readonly IDangKyXemPhongRepository _repo;

        public DangKyXemPhongController(IDangKyXemPhongRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(_repo.GetAllItems());
        }

        [HttpGet("{maDangKy}")]
        public IActionResult GetItemByID(string maDangKy)
        {
            DangKyXemPhongModel item = _repo.GetItemByID(maDangKy);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(DangKyXemPhongModel newItem)
        {
            try
            {
                newItem.MaDangKy = Guid.NewGuid().ToString().ToUpper();
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{maDangKy}")]
        public IActionResult DeleteItem(string maDangKy)
        {
            try
            {
                if (_repo.GetItemByID(maDangKy) == null)
                    return NotFound();
                return _repo.RemoveItem(maDangKy) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{maDangKy}")]
        public IActionResult PutItem(string maDangKy, DangKyXemPhongModel updateItem)
        {
            if (maDangKy != updateItem.MaDangKy)
                return NotFound();
            return _repo.PutItem(updateItem) ? Ok() : BadRequest();
        }
    }
}
