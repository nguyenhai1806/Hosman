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
        public IActionResult GetAllItems()
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

        [HttpGet("{maNhom}")]
        public IActionResult GetItemByID(string maNhom)
        {
            try
            {
                QlNhomNguoiDung qlNhomNguoiDung = QlNhomNguoiDungDAL.Instance.GetItemByID(maNhom);
                return qlNhomNguoiDung == null ? NotFound() : Ok(qlNhomNguoiDung);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{maNhom}")]
        public IActionResult DeteleItem(string maNhom)
        {
            try
            {
                QlNhomNguoiDung qlNhomNguoiDung = QlNhomNguoiDungDAL.Instance.GetItemByID(maNhom);
                if (qlNhomNguoiDung == null)
                    return QlNhomNguoiDungDAL.Instance.RemoveItem(maNhom) ? Ok() : BadRequest();
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}