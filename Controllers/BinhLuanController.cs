using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinhLuanController : ControllerBase
    {
        private readonly IBinhLuanRepository _repo;

        public BinhLuanController(IBinhLuanRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(_repo.GetAllItems());
        }

        [HttpGet("{maBinhLuan}")]
        public IActionResult GetItemByID(string maBinhLuan)
        {
            BinhLuanModel item = _repo.GetItemByID(maBinhLuan);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(BinhLuanModel newItem)
        {
            try
            {

                newItem.MaBinhLuan = Guid.NewGuid().ToString();
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{maBinhLuan}")]
        public IActionResult DeleteItem(string maBinhLuan)
        {
            try
            {
                if (_repo.GetItemByID(maBinhLuan) == null)
                    return NotFound();
                return _repo.RemoveItem(maBinhLuan) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
