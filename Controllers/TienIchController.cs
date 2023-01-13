using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TienIchController : ControllerBase
    {
        private readonly ITienIchRepository _repo;
        public TienIchController(ITienIchRepository repo)
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
        [HttpGet("{maTienIch}")]
        public IActionResult GetItemByID(string maTienIch)
        {
            TienIchModel item = _repo.GetItemByID(maTienIch);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(TienIchModel newItem)
        {
            try
            {
                //TODO Kiểm tra có trùng tên hay không
                List<TienIchModel> listTienTich = _repo.GetAllItems();
                foreach (var p in listTienTich)
                {
                    if (p.TenTienIch == newItem.TenTienIch)
                        return BadRequest("Tên tiện ích đã trùng tên tiện ích trước!");
                }
                newItem.MaTienIch = Guid.NewGuid().ToString();
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{maTienIch}")]
        public IActionResult PutItem(string maTienIch, TienIchModel updateItem)
        {
            //TODO Kiểm tra có trùng tên hay không
            List<TienIchModel> listTienTich = _repo.GetAllItems();
            foreach (var p in listTienTich)
            {
                if (p.TenTienIch == updateItem.TenTienIch)
                    return BadRequest("Tên tiện ích đã trùng tên tiện ích trước!");
            }
            if (maTienIch != updateItem.MaTienIch)
                return NotFound();
            return _repo.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maTienIch}")]
        public IActionResult DeleteItem(string maTienIch)
        {
            try
            {
                if (_repo.GetItemByID(maTienIch) == null)
                    return NotFound();
                return _repo.RemoveItem(maTienIch) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
