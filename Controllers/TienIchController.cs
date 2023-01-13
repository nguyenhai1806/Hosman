using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TienIchController : ControllerBase
    {
        private readonly ITienIchRepository _repoTienIch;
        private readonly IKhuTroRepository _repoKhuTro;

        public TienIchController(ITienIchRepository _repoTienIch, IKhuTroRepository _repoKhuTro)
        {
            this._repoTienIch = _repoTienIch;
            this._repoKhuTro = _repoKhuTro;
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                return Ok(_repoTienIch.GetAllItems());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{maTienIch}")]
        public IActionResult GetItemByID(string maTienIch)
        {
            TienIchModel item = _repoTienIch.GetItemByID(maTienIch);
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
                return _repoTienIch.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
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
            return _repoTienIch.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maTienIch}")]
        public IActionResult DeleteItem(string maTienIch)
        {
            try
            {
                if (_repoTienIch.GetItemByID(maTienIch) == null)
                    return NotFound();
                return _repoTienIch.RemoveItem(maTienIch) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("KhuTro/{maKhuTro}")]
        public IActionResult GetTienIchByKhuTro(string maKhuTro)
        {
            try
            {
                if (_repoKhuTro.GetItemByID(maKhuTro) == null)
                    return NotFound();
                else
                {
                    return Ok(_repoTienIch.GetTienIchByKhuTro(maKhuTro));
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("KhuTro")]
        public IActionResult PostTienIchKhuTro(KhuTroTienIch khutroTienIch)
        {
            try
            {
                if (_repoKhuTro.GetItemByID(khutroTienIch.MaKhuTro) == null)
                    return NotFound();
                if (_repoTienIch.GetItemByID(khutroTienIch.MaTienIch) == null)
                    return NotFound();
                else
                {
                    return _repoTienIch.PostTienIchKhuTro(khutroTienIch) ? Ok() : BadRequest();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("KhuTro")]
        public IActionResult DeleteTienIchKhuTro(KhuTroTienIch khutroTienIch)
        {
            try
            {
                if (_repoKhuTro.GetItemByID(khutroTienIch.MaKhuTro) == null)
                    return NotFound();
                if (_repoTienIch.GetItemByID(khutroTienIch.MaTienIch) == null)
                    return NotFound();
                else
                {
                    return _repoTienIch.DeleteTienIchKhuTro(khutroTienIch) ? Ok() : BadRequest();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
