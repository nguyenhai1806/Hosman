using hosman_api.Interface;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonRepository _repo;
        public HoaDonController(IHoaDonRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("maHoaDon")]
        public IActionResult GetItemByID(string maHoaDon)
        {
            return Ok(_repo.GetItemByID(maHoaDon));
        }
    }
}
