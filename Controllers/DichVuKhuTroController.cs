using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuKhuTroController : ControllerBase
    {
        private readonly IDichVuKhuTroRespository _repo;

        public DichVuKhuTroController(IDichVuKhuTroRespository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(_repo.GetAllItems());
        }
        [HttpGet("{maKhuTro}")]
        public IActionResult GetAllItemsByKhuTro(string maKhuTro)
        {
            return Ok(_repo.GetAllItemsByKhuTro(maKhuTro));
        }
        [HttpPost]
        public IActionResult PostNewItem(DichVuKhuTroModel newItem)
        {
            try
            {
                if (_repo.GetItemByID(newItem.MaDichVu, newItem.MaKhuTro) != null)
                {
                    return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
                }

                return BadRequest("Khu trọ đã có dịch vụ này");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{maDichVu}&{maKhuTro}")]
        public IActionResult GetItemByID(string maDichVu, string maKhuTro)
        {
            try
            {
                DichVuKhuTroModel m = _repo.GetItemByID(maDichVu, maKhuTro);
                return m == null ? NotFound() : Ok(m);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{maDichVu}&{maKhuTro}")]
        public IActionResult RemoveItem(string maDichVu, string maKhuTro)
        {
            try
            {
                if (_repo.GetItemByID(maDichVu, maKhuTro) == null)
                    return NotFound();
                else
                {
                    return _repo.RemoveItem(maDichVu, maKhuTro) ? Ok() : BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult PutItem(DichVuKhuTroModel updateItem)
        {
            try
            {
                if (_repo.GetItemByID(updateItem.MaDichVu, updateItem.MaKhuTro) == null)
                    return NotFound();
                else
                {
                    return _repo.PutItem(updateItem) ? Ok() : BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
