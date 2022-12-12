using hosman_api.DAL;
using hosman_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YeuCauSuaChuaController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostNewItem(YeuCauSuaChuaVM itemVM)
        {
            try
            {
                YeuCauSauChua yeuCauSauChua = new YeuCauSauChua();
                yeuCauSauChua.MaYeuCau = Guid.NewGuid().ToString();
                yeuCauSauChua.ChiTiet = itemVM.ChiTiet;
                yeuCauSauChua.HinhAnh = itemVM.HinhAnh;
                yeuCauSauChua.NgayYeuCau = itemVM.NgayYeuCau;
                yeuCauSauChua.TinhTrang = itemVM.TinhTrang;
                yeuCauSauChua.MaHopDong = itemVM.MaHopDong;

                return YeuCauSuaChuaDAL.Instance.PostNewItem(yeuCauSauChua) ? Ok(yeuCauSauChua) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("{maYeuCau}")]
        public IActionResult PutItem(string maYeuCau, YeuCauSauChua updateItem)
        {
            try
            {
                if (maYeuCau != updateItem.MaYeuCau)
                {
                    return BadRequest();
                }
                else if (YeuCauSuaChuaDAL.Instance.ItemExistsByID(maYeuCau))
                {
                    return YeuCauSuaChuaDAL.Instance.PutItem(updateItem) ? Ok() : BadRequest();
                }
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet("{maYeuCau}")]
        public IActionResult ItemExistsByID(string maYeuCau)
        {
            try
            {
                bool item = YeuCauSuaChuaDAL.Instance.ItemExistsByID(maYeuCau);
                return item ? Ok(item) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{maYeuCau}")]
        public IActionResult DeleteItem(string maYeuCau)
        {
            try
            {
                if (YeuCauSuaChuaDAL.Instance.ItemExistsByID(maYeuCau))
                {
                    return YeuCauSuaChuaDAL.Instance.RemoveItem(maYeuCau) ? Ok() : BadRequest();
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
