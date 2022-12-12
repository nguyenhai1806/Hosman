using hosman_api.Interface;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhSachNguoiTroController : ControllerBase
    {
        private readonly IDanhSachNguoiTroRepository _repo;
        public DanhSachNguoiTroController(IDanhSachNguoiTroRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                return Ok(_repo.GetAllItems());
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
