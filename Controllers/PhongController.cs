using hosman_api.DAL;
using hosman_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostNewItem(Phong itemVM)
        {
            try
            {
                //Kiem tra ten phong
                List<Phong> phongs = PhongDAL.Instance.GetAllItems();
                foreach(var item in phongs)
                {
                    if (item.TenPhong == itemVM.TenPhong)
                        return BadRequest();
                }
                Phong phong = new Phong();
                phong.MaPhong = itemVM.MaPhong;
                phong.TenPhong= itemVM.TenPhong;
                phong.DienTich= itemVM.DienTich;
                phong.GiaThue= itemVM.GiaThue;
                phong.UuTien = itemVM.UuTien;
                phong.GhiChu = itemVM.GhiChu;
                phong.TinhTrang= itemVM.TinhTrang;
                phong.MaKhuTro = itemVM.MaKhuTro;
                return PhongDAL.Instance.PostNewItem(phong) ? Ok(phong) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("{maPhong}")]
        public IActionResult PutItem(string maPhong, Phong updateItem)
        {
            try
            {
      
                if (maPhong != updateItem.MaPhong)
                {
                    return BadRequest();
                }
                else if (PhongDAL.Instance.ItemExistsByID(maPhong))
                {
                    return PhongDAL.Instance.PutItem(updateItem) ? Ok() : BadRequest();
                }
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet("{maPhong}")]
        public IActionResult ItemExistsByID(string maPhong)
        {
            try
            {
                bool item = PhongDAL.Instance.ItemExistsByID(maPhong);
                return item ? Ok(item) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{maPhong}")]
        public IActionResult DeleteItem(string maPhong)
        {
            try
            {
                if (PhongDAL.Instance.ItemExistsByID(maPhong))
                {
                    return PhongDAL.Instance.RemoveItem(maPhong) ? Ok() : BadRequest();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
