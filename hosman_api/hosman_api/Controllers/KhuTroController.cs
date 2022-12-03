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
            return Ok(KhuTroDAL.Instance.GetItemByID(maKhuTro));
        }

        [HttpGet("ChuTro/{maChuTro}")]
        public IActionResult GetItemsByChuTro(string maChuTro)
        {
            return Ok(KhuTroDAL.Instance.GetAllItems().FindAll(x => x.MaNguoiDung == maChuTro));
        }

        [HttpPost]
        public IActionResult PostNewItem(KhuTroVM itemVM)
        {
            try
            {
                //Kiem tra ten khu da ton tai trong cac khu tro cua người dùng này hay chưa
                if (KhuTroDAL.Instance.GetItemsByName(itemVM.MaNguoiDung, itemVM.TenKhu) != null)
                    return BadRequest("Ten khu tro da ton tai");
                KhuTro khuTro = new KhuTro
                {
                    MaKhuTro = Guid.NewGuid().ToString(),
                    TenKhu = itemVM.TenKhu,
                    DiaChi = itemVM.DiaChi,
                    GiaDien = itemVM.GiaDien,
                    GiaNuoc = itemVM.GiaNuoc,
                    SoPhong = 0,
                    HanDongTien = itemVM.HanDongTien,
                    NgayLapHd = itemVM.NgayLapHd,
                    MaNguoiDung = itemVM.MaNguoiDung,
                };
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

            KhuTro temp = KhuTroDAL.Instance.GetItemsByName(updateItem.MaNguoiDung, updateItem.TenKhu);
            if (temp != null && temp.MaKhuTro.Equals(maKhuTro))
                return BadRequest("Ten khu tro da ton tai");

            return KhuTroDAL.Instance.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteItem(string maKhuTro)
        {
            if (!KhuTroDAL.Instance.ItemExistsByID(maKhuTro))
                return BadRequest();
            return KhuTroDAL.Instance.RemoveItem(maKhuTro) ? Ok() : BadRequest();
        }
    }
}
