using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuPhongController : ControllerBase
    {
        private readonly IDichVuPhongRespository _repo;

        public DichVuPhongController(IDichVuPhongRespository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(_repo.GetAllItems());
        }
        [HttpGet("{maPhong}")]
        public IActionResult GetAllItemsByPhong(string maPhong)
        {
            return Ok(_repo.GetAllItemsByPhong(maPhong));
        }
        [HttpPost]
        public IActionResult PostNewItem(DichVuPhongModel newItem)
        {
            try
            {
                if (_repo.GetItemById(newItem.MaDichVu, newItem.MaPhong, newItem.MaKhuTro) == null)
                {
                    return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
                }

                return BadRequest("Phòng trọ đã có dịch vụ này");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public IActionResult RemoveItem(string maDichVu, string maPhong, string maKhuTro)
        {
            try
            {
                return _repo.RemoveItem(maDichVu, maPhong, maKhuTro) ? Ok() : BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult PutItem(DichVuPhongModel updateItem)
        {
            try
            {
                return _repo.PutItem(updateItem) ? Ok() : BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
