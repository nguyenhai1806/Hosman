using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuController : ControllerBase
    {
        private readonly IDichVuRepository _repo;

        public DichVuController(IDichVuRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(_repo.GetAllItems());
        }

        [HttpGet("{maDichVu}")]
        public IActionResult GetItemByID(string maDichVu)
        {
            DichVuModel item = _repo.GetItemByID(maDichVu);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(DichVuModel newItem)
        {
            try
            {
                List<DichVuModel> listDichVu = _repo.GetAllItems();
                foreach (var dv in listDichVu)
                {
                    if (dv.TenDichVu == newItem.TenDichVu)
                        return BadRequest("Dịch Vụ Đã Trùng Tên!");
                }
                newItem.MaDichVu = Guid.NewGuid().ToString().ToUpper();
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{maDichVu}")]
        public IActionResult PutItem(string maDichVu, DichVuModel updateItem)
        {
            if (maDichVu != updateItem.MaDichVu)
                return NotFound();
            List<DichVuModel> listDichVu = _repo.GetAllItems();
            foreach (var dv in listDichVu)
            {
                if (dv.TenDichVu == updateItem.TenDichVu && dv.MaDichVu != updateItem.MaDichVu)
                    return BadRequest("Dịch Vụ Đã Trùng Tên!");
            }
            return _repo.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maDichVu}")]
        public IActionResult DeleteItem(string maDichVu)
        {
            try
            {
                if (_repo.GetItemByID(maDichVu) == null)
                    return NotFound();
                return _repo.RemoveItem(maDichVu) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
