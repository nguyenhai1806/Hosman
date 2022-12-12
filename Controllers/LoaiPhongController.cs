using hosman_api.DAL;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiPhongController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(LoaiPhongDAL.Instance.GetAllItems());
        }

        [HttpGet("{maLoaiPhong}")]
        public IActionResult GetItemByID(string maLoaiPhong)
        {
            LoaiPhong item = LoaiPhongDAL.Instance.GetItemByID(maLoaiPhong);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(LoaiPhongVM itemVM)
        {
            try
            {
                //Kiem tra loai phong da ton tai trong chua
                List<LoaiPhong> loaiPhongs = LoaiPhongDAL.Instance.GetAllItems();
                foreach (var item in loaiPhongs)
                {
                    if (item.TenLoai == itemVM.TenLoai)
                        return BadRequest("Tên loại phòng đã tồn tại");
                }

                LoaiPhong loaiPhong = new LoaiPhong();
                loaiPhong.TenLoai = Guid.NewGuid().ToString();
                loaiPhong.GhiChu = itemVM.GhiChu;

                return LoaiPhongDAL.Instance.PostNewItem(loaiPhong) ? Ok(loaiPhong) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{maLoaiPhong}")]
        public IActionResult PutItem(string maLoaiPhong, LoaiPhong updateItem)
        {
            if (maLoaiPhong != updateItem.MaLoai)
                return BadRequest();

            List<LoaiPhong> loaiPhongs = LoaiPhongDAL.Instance.GetAllItems();
            foreach (var item in loaiPhongs)
            {
                if (item.TenLoai == updateItem.TenLoai && item.MaLoai != maLoaiPhong)
                    return BadRequest("Tên loại phòng đã tồn tại");
            }

            return LoaiPhongDAL.Instance.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maLoaiPhong}")]
        public IActionResult DeleteItem(string maLoaiPhong)
        {
            try
            {
                if (LoaiPhongDAL.Instance.GetItemByID(maLoaiPhong) == null)
                    return NotFound();
                return LoaiPhongDAL.Instance.RemoveItem(maLoaiPhong) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}