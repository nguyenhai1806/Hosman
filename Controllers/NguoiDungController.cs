using hosman_api.Helpers;
using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

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
        [HttpPost("/login")]
        public IActionResult checkLogin(Login login)
        {
            NguoiDungModel nguoiDung = _repo.GetItemLogin(login.Email, HashString.HashPassword(login.MatKhau));
            
            if (nguoiDung!= null)
            {
                nguoiDung.MatKhau = "";
                string refeshToken = HashString.CreateRefeshToken();
                if(_repo.UpdateRefeshToken(nguoiDung.MaNguoiDung,refeshToken)){
                    nguoiDung.RefeshToken = refeshToken;
                }
                else
                    return BadRequest();
            }
            return nguoiDung != null ? Ok(nguoiDung) : NotFound();
        }
        [HttpPost("/refeshtoken")]  
        public IActionResult checkRefeshToken(string refeshToken)
        {
            NguoiDungModel nguoiDung = _repo.GetItemByRefeshToken(refeshToken);

            if (nguoiDung!= null)
            {
                nguoiDung.MatKhau = "";
                string newRefeshToken = HashString.CreateRefeshToken();
                if(_repo.UpdateRefeshToken(nguoiDung.MaNguoiDung,newRefeshToken)){
                    nguoiDung.RefeshToken = newRefeshToken;
                }
                else
                    return BadRequest();
            }
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
                newItem.MatKhau = HashString.HashPassword(newItem.MatKhau);
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
