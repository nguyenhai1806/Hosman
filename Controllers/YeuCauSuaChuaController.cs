using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YeuCauSuaChuaController : ControllerBase
    {
        private readonly IYeuCauSuaChuaRepository _repo;
        public YeuCauSuaChuaController(IYeuCauSuaChuaRepository repo)
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
        [HttpGet("{maYeuCau}")]
        public IActionResult GetItemByID(string maYeuCau)
        {
            YeuCauSuaChuaModel item = _repo.GetItemByID(maYeuCau);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(YeuCauSuaChuaModel newItem)
        {
            try
            {
                newItem.MaYeuCau = Guid.NewGuid().ToString().ToUpper();
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{maYeuCau}")]
        public IActionResult PutItem(string maYeuCau, YeuCauSuaChuaModel updateItem)
        {
            if (maYeuCau != updateItem.MaYeuCau)
                return NotFound();
            return _repo.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maYeuCau}")]
        public IActionResult DeleteItem(string maYeuCau)
        {
            try
            {
                if (_repo.GetItemByID(maYeuCau) == null)
                    return NotFound();
                return _repo.RemoveItem(maYeuCau) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
