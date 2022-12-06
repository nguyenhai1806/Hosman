using hosman_api.DAL;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuTroController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(KhuTroDAL.Instance.GetAllItems());
        }

        [HttpGet("{maKhuTro}")]
        public IActionResult GetItemByID(string maKhuTro)
        {
            KhuTro item = KhuTroDAL.Instance.GetItemByID(maKhuTro);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpGet("ChuTro/{maChuTro}")]
        public IActionResult GetItemsByChuTro(string maChuTro)
        {
            return Ok(KhuTroDAL.Instance.GetItemsByChuTro(maChuTro));
        }

        [HttpPost]
        public IActionResult PostNewItem(KhuTroVM itemVM)
        {
            try
            {
                //Kiem tra ten khu da ton tai trong cac khu tro cua người dùng này hay chưa
                List<KhuTro> khuTroNguoiDung = KhuTroDAL.Instance.GetItemsByChuTro(itemVM.MaNguoiDung);
                foreach (var item in khuTroNguoiDung)
                {
                    if (item.TenKhu == itemVM.TenKhu)
                        return BadRequest("Tên khu trọ đã tồn tại");
                }

                KhuTro khuTro = new KhuTro();
                khuTro.MaKhuTro = Guid.NewGuid().ToString();
                khuTro.TenKhu = itemVM.TenKhu;
                khuTro.DiaChi = itemVM.DiaChi;
                khuTro.GiaDien = itemVM.GiaDien;
                khuTro.GiaNuoc = itemVM.GiaNuoc;
                khuTro.SoPhong = 0;
                khuTro.HanDongTien = itemVM.HanDongTien;
                khuTro.NgayLapHd = itemVM.NgayLapHd;
                khuTro.MaNguoiDung = itemVM.MaNguoiDung;

                return KhuTroDAL.Instance.PostNewItem(khuTro) ? Ok(khuTro) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{maKhuTro}")]
        public IActionResult PutItem(string maKhuTro, KhuTro updateItem)
        {
            if (maKhuTro != updateItem.MaKhuTro)
                return BadRequest();

            //Kiem tra ten khu da ton tai trong cac khu tro cua người dùng này hay chưa
            List<KhuTro> khuTroNguoiDung = KhuTroDAL.Instance.GetItemsByChuTro(updateItem.MaNguoiDung);
            foreach (var item in khuTroNguoiDung)
            {
                if (item.TenKhu == updateItem.TenKhu && item.MaKhuTro != updateItem.MaKhuTro)
                    return BadRequest("Ten khu tro đa ton tai");
            }

            return KhuTroDAL.Instance.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maKhuTro}")]
        public IActionResult DeleteItem(string maKhuTro)
        {
            try
            {
                if (KhuTroDAL.Instance.GetItemByID(maKhuTro) == null)
                    return NotFound();
                return KhuTroDAL.Instance.RemoveItem(maKhuTro) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}