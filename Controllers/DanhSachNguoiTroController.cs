using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhSachNguoiTroController : ControllerBase
    {
        private readonly IDanhSachNguoiTroRepository _repo;
        public DanhSachNguoiTroController(IDanhSachNguoiTroRepository repo)
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
        [HttpGet("{maNguoiTro}")]
        public IActionResult GetItemByID(string maNguoiTro)
        {
            DanhSachNguoiTroModel item = _repo.GetItemByID(maNguoiTro);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(DanhSachNguoiTroModel newItem)
        {
            try
            {

                newItem.MaNguoiTro = Guid.NewGuid().ToString();
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{maNguoiTro}")]
        public IActionResult PutItem(string maNguoiTro, DanhSachNguoiTroModel updateItem)
        {
            if (maNguoiTro != updateItem.MaNguoiTro)
                return NotFound();
            return _repo.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maNguoiTro}")]
        public IActionResult DeleteItem(string maNguoiTro)
        {
            try
            {
                if (_repo.GetItemByID(maNguoiTro) == null)
                    return NotFound();
                return _repo.RemoveItem(maNguoiTro) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
