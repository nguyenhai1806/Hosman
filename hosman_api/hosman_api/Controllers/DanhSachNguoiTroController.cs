using hosman_api.DAL;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhSachNguoiTroController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostNewItem(DanhSachNguoiTroVM itemVM)
        {
            try
            {
                DanhSachNguoiTro newItem = new DanhSachNguoiTro
                {
                    MaNguoiTro = Guid.NewGuid().ToString(),
                    MaHopDong = itemVM.MaHopDong,
                    Cccd = itemVM.Cccd,
                    AnhCccdsau = itemVM.AnhCccdsau,
                    AnhCccdtruoc = itemVM.AnhCccdtruoc,
                    GioiTinh = itemVM.GioiTinh,
                    NgayCap = itemVM.NgayCap,
                    DiaChi = itemVM.DiaChi,
                    NgayDangKyTamTru = itemVM.NgayDangKyTamTru,
                    NgaySinh = itemVM.NgaySinh,
                    NoiCap = itemVM.NoiCap,
                    SoDienThoai = itemVM.SoDienThoai,
                    TenNguoiTro = itemVM.TenNguoiTro,
                    XacMinhThongTin = itemVM.XacMinhThongTin
                };
                return DanhSachNguoiTroDAL.Instance.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
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
                return Ok(DanhSachNguoiTroDAL.Instance.GetAllItems());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("{maNguoiTro}")]
        public IActionResult GetItemByID(string maNguoiTro)
        {
            try
            {
                DanhSachNguoiTro item = DanhSachNguoiTroDAL.Instance.GetItemByID(maNguoiTro);
                return item == null ? Ok(item) : NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{maNguoiTro}")]
        public IActionResult DeteleItem(string maNguoiTro)
        {
            try
            {
                if (DanhSachNguoiTroDAL.Instance.ItemExistsByID(maNguoiTro))
                {
                    return DanhSachNguoiTroDAL.Instance.RemoveItem(maNguoiTro) ? Ok() : BadRequest();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Lấy ds khách hàng từ tất cả khu trọ của chủ trọ
        /// </summary>
        /// <param name="maChuTro"></param>
        /// <returns></returns>
        [HttpGet("ChuTro/{maChuTro}")]
        public IActionResult GetItemsByChuTro(string maChuTro)
        {
            try
            {
                return Ok(DanhSachNguoiTroDAL.Instance.GetItemsByChuTro(maChuTro));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Lấy ds khách hàng từ tất cả khu trọ của chủ trọ
        /// </summary>
        /// <param name="maChuTro"></param>
        /// <returns></returns>
        [HttpGet("HopDong/{maHopDong}")]
        public IActionResult GetItemsByHopDong(string maHopDong)
        {
            try
            {
                List<DanhSachNguoiTro> ds = DanhSachNguoiTroDAL.Instance.GetItemsByHopDong(maHopDong);
                return ds.Count == 0 ? NotFound() : Ok(ds);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
