using hosman_api.DAL;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TienIchController : Controller
    {
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(TienIchDAL.Instance.GetAllItems());
        }

        [HttpGet("{maTienIch}")]
        public IActionResult GetItemByID(string maTienIch)
        {
            TienIch item = TienIchDAL.Instance.GetItemByID(maTienIch);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(TienIchVM itemVM)
        {
            try
            {
                //Kiem tra tien ich da ton tai trong chua
                List<TienIch> tienIchs = TienIchDAL.Instance.GetAllItems();
                foreach (var item in tienIchs)
                {
                    if (item.TenTienIch == itemVM.TenTienIch)
                        return BadRequest("Tên tiện ích đã tồn tại");
                }

                TienIch tienich = new TienIch();
                tienich.MaTienIch = Guid.NewGuid().ToString();
                tienich.TenTienIch = itemVM.TenTienIch;

                return TienIchDAL.Instance.PostNewItem(tienich) ? Ok(tienich) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{maTienIch}")]
        public IActionResult PutItem(string maTienIch, TienIch updateItem)
        {
            if (maTienIch != updateItem.MaTienIch)
                return BadRequest();

            List<TienIch> tienIchs = TienIchDAL.Instance.GetAllItems();
            foreach (var item in tienIchs)
            {
                if (item.TenTienIch == updateItem.TenTienIch && item.MaTienIch != maTienIch)
                    return BadRequest("Tên tiện ích đã tồn tại");
            }

            return TienIchDAL.Instance.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maTienIch}")]
        public IActionResult DeleteItem(string maTienIch)
        {
            try
            {
                if (TienIchDAL.Instance.GetItemByID(maTienIch) == null)
                    return NotFound();
                return TienIchDAL.Instance.RemoveItem(maTienIch) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}