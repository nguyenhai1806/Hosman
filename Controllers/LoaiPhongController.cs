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
                List<LoaiPhongModel> listLoaiPhong = _repo.GetAllItems();
                foreach (var dv in listLoaiPhong)
                {
                    if (dv.TenLoai == newItem.TenLoai)
                        return BadRequest("Tên Loại Phòng đã trùng!");
                }
                newItem.MaLoai = Guid.NewGuid().ToString().ToUpper();
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
            List<LoaiPhongModel> listLoaiPhong = _repo.GetAllItems();
            foreach (var dv in listLoaiPhong)
            {
                if (dv.TenLoai == updateItem.TenLoai & dv.MaLoai != updateItem.MaLoai)
                    return BadRequest("Tên Loại Phòng đã trùng!");
            }
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
