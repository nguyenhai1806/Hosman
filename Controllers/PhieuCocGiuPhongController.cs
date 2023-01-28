using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuCocGiuPhongController : ControllerBase
    {
        private readonly IPhieuCocGiuPhongRepository _repo;

        public PhieuCocGiuPhongController(IPhieuCocGiuPhongRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(_repo.GetAllItems());
        }

        [HttpGet("{maPhieuCoc}")]
        public IActionResult GetItemByID(string maPhieuCoc)
        {
            PhieuCocGiuPhongModel item = _repo.GetItemByID(maPhieuCoc);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(PhieuCocGiuPhongModel newItem)
        {
            try
            {

                newItem.MaPhieuCoc = Guid.NewGuid().ToString().ToUpper();
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{maPhieuCoc}")]
        public IActionResult PutItem(string maPhieuCoc, PhieuCocGiuPhongModel updateItem)
        {
            if (maPhieuCoc != updateItem.MaPhieuCoc)
                return NotFound();
            return _repo.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maPhieuCoc}")]
        public IActionResult DeleteItem(string maPhieuCoc)
        {
            try
            {
                if (_repo.GetItemByID(maPhieuCoc) == null)
                    return NotFound();
                return _repo.RemoveItem(maPhieuCoc) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
