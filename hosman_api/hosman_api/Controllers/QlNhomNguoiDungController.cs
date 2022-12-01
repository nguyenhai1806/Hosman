using hosman_api.DAL;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;
namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QlNhomNguoiDungController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostNewItem(QlNhomNguoiDungVM itemVM)
        {
            try
            {
                if (QlNhomNguoiDungDAL.Instance.ItemExistsByName(itemVM.TenNhom))
                    return BadRequest("Ten nhom da ton tai");
                QlNhomNguoiDung qlNhomNguoiDung = new QlNhomNguoiDung();
                qlNhomNguoiDung.MaNhom = Guid.NewGuid().ToString();
                qlNhomNguoiDung.TenNhom = itemVM.TenNhom;
                qlNhomNguoiDung.GhiChu = itemVM.GhiChu;

                return QlNhomNguoiDungDAL.Instance.PostNewItem(qlNhomNguoiDung) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult GetAllItem()
        {
            try
            {
                return Ok(QlNhomNguoiDungDAL.Instance.GetAllItems());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult PutItem(string maNhom, QlNhomNguoiDungVM itemVM)
        {
            try
            {
                QlNhomNguoiDung oldItem = QlNhomNguoiDungDAL.Instance.GetItemByID(maNhom);
                if (QlNhomNguoiDungDAL.Instance.ItemExistsByName(itemVM.TenNhom))
                    return BadRequest("Ten nhom da ton tai");
                if (oldItem != null)
                {
                    oldItem.TenNhom = itemVM.TenNhom;
                    oldItem.GhiChu = itemVM.GhiChu;
                    QlNhomNguoiDungDAL.Instance.UpdateItem(oldItem);
                    return Ok();
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public IActionResult ItemExistsByID(string maNhom)
        {
            if (QlNhomNguoiDungDAL.Instance.ItemExistsByID(maNhom))
                return BadRequest("Ten nhom da ton tai");
        }
    }
}
