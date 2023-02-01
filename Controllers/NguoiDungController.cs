using hosman_api.Helpers;
using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungRepository _repo;
        public NguoiDungController(INguoiDungRepository repo)
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
        [HttpPost("/checkLogin")]
        public IActionResult checkLogin(Login login)
        {
            NguoiDungModel nguoiDung = _repo.GetAllItems().Where(ng => ng.Email == login.Email && ng.MatKhau == HashPassword.Hash(login.MatKhau)).FirstOrDefault();
            return nguoiDung != null ? Ok(nguoiDung) : NotFound();
        }
        [HttpGet("{maNguoiDung}")]
        public IActionResult GetItemByID(string maNguoiDung)
        {
            NguoiDungModel item = _repo.GetItemByID(maNguoiDung);
            if (item != null) item.MatKhau = null;
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(NguoiDungModel newItem)
        {
            try
            {
                newItem.MaNguoiDung = Guid.NewGuid().ToString();
                newItem.MatKhau = HashPassword.Hash(newItem.MatKhau);
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{maNguoiDung}")]
        public IActionResult PutItem(string maNguoiDung, NguoiDungModel updateItem)
        {
            if (maNguoiDung != updateItem.MaNguoiDung)
                return NotFound();
            return _repo.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maNguoiDung}")]
        public IActionResult DeleteItem(string maNguoiDung)
        {
            try
            {
                if (_repo.GetItemByID(maNguoiDung) == null)
                    return NotFound();
                return _repo.RemoveItem(maNguoiDung) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
