using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HopDongThueController : ControllerBase
    {
        private readonly IHopDongRepository _repoHopDong;
        private readonly IPhuLucRepository _repoPhuLuc;

        public HopDongThueController(IHopDongRepository repoHopDong, IPhuLucRepository repoPhuLuc)
        {
            _repoHopDong = repoHopDong;
            _repoPhuLuc = repoPhuLuc;
        }

        //Hop dong
        [HttpGet("Phong/{maPhong}")]
        public IActionResult GetAllHopDongByPhong(string maPhong)
        {
            try
            {
                List<HopDongThueModel> list = _repoHopDong.GetHopDongByPhong(maPhong);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{maHopDong}")]
        public IActionResult GetHopDongByID(string maHopDong)
        {
            try
            {
                HopDongThueModel hopdong = _repoHopDong.GetHopDongByID(maHopDong);
                return hopdong == null ? NotFound() : Ok(hopdong);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult PostHopDong(HopDongPhuLuc hopDongPhuLuc)
        {
            List<HopDongThueModel> listHopDong = _repoHopDong.GetHopDongByPhong(hopDongPhuLuc.MaPhong);
            foreach (var h in listHopDong)
            {
                List<PhuLucModel> listPhuLuc = _repoPhuLuc.GetPhuLucByHopDong(h.MaHopDong);
                if (listPhuLuc.Exists(p => p.NgayKetThuc.Ticks >= hopDongPhuLuc.NgayBatDau.Ticks))
                    return BadRequest("Phòng đã được thuê trong khoảng thời gian này");
            }

            HopDongThueModel hopDong = new HopDongThueModel();
            string maHopDong = Guid.NewGuid().ToString().ToUpper();
            hopDong.MaHopDong = maHopDong;
            hopDong.FileHopDong = hopDongPhuLuc.FileHopDong;
            hopDong.TienCocDamBao = hopDongPhuLuc.TienCocDamBao;
            hopDong.TinhTrangCoc = hopDongPhuLuc.TinhTrangCoc;
            hopDong.MaNguoiThue = hopDongPhuLuc.MaNguoiThue;
            hopDong.MaPhong = hopDongPhuLuc.MaPhong;

            PhuLucModel phuLuc = new PhuLucModel();
            phuLuc.MaPhuLuc = Guid.NewGuid().ToString().ToUpper();
            phuLuc.MaHopDong = maHopDong;
            phuLuc.GiaThue = hopDongPhuLuc.GiaThue;
            phuLuc.NgayBatDau = hopDongPhuLuc.NgayBatDau;
            phuLuc.NgayKetThuc = hopDongPhuLuc.NgayKetThuc;
            phuLuc.GhiChu = "Tạo mới hợp đồng";

            return _repoHopDong.PostHopDong(hopDong, phuLuc) ? Ok(new { hopDong, phuLuc }) : BadRequest();
        }

        [HttpPut("{maHopDong}")]
        public IActionResult PutHopDong(string maHopDong, HopDongThueModel updateItem)
        {
            if (maHopDong != updateItem.MaHopDong)
                return BadRequest();
            try
            {
                return _repoHopDong.PutHopDong(updateItem) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}