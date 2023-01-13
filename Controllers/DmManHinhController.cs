using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DmManHinhController : ControllerBase
    {
        private readonly IDmManHinhRepository _repo;
        public DmManHinhController(IDmManHinhRepository repo)
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
        [HttpGet("{maManHinh}")]
        public IActionResult GetItemByID(string maManHinh)
        {
            DmManHinhModel item = _repo.GetItemByID(maManHinh);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(DmManHinhModel newItem)
        {
            try
            {
                List<DmManHinhModel> listDmManHinh = _repo.GetAllItems();
                foreach (var dv in listDmManHinh)
                {
                    if (dv.TenManHinh == newItem.TenManHinh)
                        return BadRequest("Tên đã trùng!");
                }
                newItem.MaManHinh = Guid.NewGuid().ToString();
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{maManHinh}")]
        public IActionResult PutItem(string maManHinh, DmManHinhModel updateItem)
        {
            if (maManHinh != updateItem.MaManHinh)
                return NotFound();
            return _repo.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maManHinh}")]
        public IActionResult DeleteItem(string maManHinh)
        {
            try
            {
                if (_repo.GetItemByID(maManHinh) == null)
                    return NotFound();
                return _repo.RemoveItem(maManHinh) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
