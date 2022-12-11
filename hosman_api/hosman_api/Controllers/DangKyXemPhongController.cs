using hosman_api.DAL;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DangKyXemPhongController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostNewItem(DangKyXemPhongVM itemVM)
        {
            try
            {
                DangKyXemPhong dangKyXemPhong = new DangKyXemPhong();
                dangKyXemPhong.MaDangKy = Guid.NewGuid().ToString();
                dangKyXemPhong.NgayDangKy = itemVM.NgayDangKy;
                dangKyXemPhong.NgayHenXem = itemVM.NgayHenXem;
                dangKyXemPhong.GhiChu = itemVM.GhiChu;
                dangKyXemPhong.TinhTrang = itemVM.TinhTrang;
                dangKyXemPhong.NguoiDung = itemVM.NguoiDung;
                dangKyXemPhong.MaPhong = itemVM.MaPhong;

                return DangKyXemPhongDAL.Instance.PostNewItem(dangKyXemPhong) ? Ok(dangKyXemPhong) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("{maDangKy}")]
        public IActionResult PutItem(string maDangKy, DangKyXemPhong updateItem)
        {
            try
            {
                if (maDangKy != updateItem.MaDangKy)
                {
                    return BadRequest();
                }
                else if (DangKyXemPhongDAL.Instance.ItemExistsByID(maDangKy))
                {
                    return DangKyXemPhongDAL.Instance.PutItem(updateItem) ? Ok() : BadRequest();
                }
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet("{maDangKy}")]
        public IActionResult ItemExistsByID(string maDangKy)
        {
            try
            {
                bool item = DangKyXemPhongDAL.Instance.ItemExistsByID(maDangKy);
                return item ? Ok(item) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{maDangKy}")]
        public IActionResult DeleteItem (string maDangKy)
        {
            try
            {
                if(DangKyXemPhongDAL.Instance.ItemExistsByID(maDangKy))
                {
                    return DangKyXemPhongDAL.Instance.RemoveItem(maDangKy) ? Ok() : BadRequest();
                }
                return NotFound();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet ("{maKhuTro}")]
        public IActionResult GetItemsByKhuTro(string maKhuTro)
        {
            try
            {
                return Ok(DangKyXemPhongDAL.Instance.GetItemsByKhuTro(maKhuTro));
            }
            catch(Exception e) 
            { 
                return BadRequest();
            }
        }
    }
}
