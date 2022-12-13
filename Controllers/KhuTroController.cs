using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuTroController : ControllerBase
    {
        private readonly IKhuTroRepository _repo;

        public KhuTroController(IKhuTroRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(_repo.GetAllItems());
        }

        [HttpGet("{maKhuTro}")]
        public IActionResult GetItemByID(string maKhuTro)
        {
            KhuTroModel item = _repo.GetItemByID(maKhuTro);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpGet("ChuTro/{maChuTro}")]
        public IActionResult GetItemsByChuTro(string maChuTro)
        {
            return Ok(_repo.GetItemsByChuTro(maChuTro));
        }

        [HttpPost]
        public IActionResult PostNewItem(KhuTroModel newItem)
        {
            try
            {
                //Kiem tra ten khu da ton tai trong cac khu tro cua người dùng này hay chưa
                List<KhuTroModel> khuTroNguoiDung = _repo.GetItemsByChuTro(newItem.MaNguoiDung);
                foreach (var item in khuTroNguoiDung)
                {
                    if (item.TenKhu == newItem.TenKhu)
                        return BadRequest("Tên khu trọ đã tồn tại");
                }

                newItem.MaKhuTro = Guid.NewGuid().ToString();
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{maKhuTro}")]
        public IActionResult PutItem(string maKhuTro, KhuTroModel updateItem)
        {
            if (maKhuTro != updateItem.MaKhuTro)
                return NotFound();

            //Kiem tra ten khu da ton tai trong cac khu tro cua người dùng này hay chưa
            List<KhuTroModel> khuTroNguoiDung = _repo.GetItemsByChuTro(updateItem.MaNguoiDung);
            foreach (var item in khuTroNguoiDung)
            {
                if (item.TenKhu == updateItem.TenKhu && item.MaKhuTro != updateItem.MaKhuTro)
                    return BadRequest("Ten khu tro đa ton tai");
            }

            return _repo.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maKhuTro}")]
        public IActionResult DeleteItem(string maKhuTro)
        {
            try
            {
                if (_repo.GetItemByID(maKhuTro) == null)
                    return NotFound();
                return _repo.RemoveItem(maKhuTro) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
