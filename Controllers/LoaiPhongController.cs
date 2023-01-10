using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiPhongController : ControllerBase
    {
        private readonly ILoaiPhongRepository _repo;
        public LoaiPhongController(ILoaiPhongRepository repo)
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
        [HttpGet("{maLoaiPhong}")]
        public IActionResult GetItemByID(string maLoaiPhong)
        {
            LoaiPhongModel item = _repo.GetItemByID(maLoaiPhong);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(LoaiPhongModel newItem)
        {
            try
            {
                //TODO Kiểm tra tên có trùng không
                newItem.MaLoai = Guid.NewGuid().ToString();
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{maLoaiPhong}")]
        public IActionResult PutItem(string maLoaiPhong, LoaiPhongModel updateItem)
        {
            //TODO Kiểm tra tên có trùng không
            if (maLoaiPhong != updateItem.MaLoai)
                return NotFound();
            return _repo.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maLoaiPhong}")]
        public IActionResult DeleteItem(string maLoaiPhong)
        {
            try
            {
                if (_repo.GetItemByID(maLoaiPhong) == null)
                    return NotFound();
                return _repo.RemoveItem(maLoaiPhong) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
