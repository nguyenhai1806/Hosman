using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Repositories
{
    public class DangKyXemPhongRepository : IDangKyXemPhongRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public DangKyXemPhongRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DangKyXemPhongModel> GetAllItems()
        {
            List<DangKyXemPhong> dangKyXemPhongs = _context.DangKyXemPhongs.ToList();
            return _mapper.Map<List<DangKyXemPhongModel>>(dangKyXemPhongs);
        }

        public DangKyXemPhongModel GetItemByID(string maDangKy)
        {
            var dangKyXemPhong = _context.DangKyXemPhongs.Find(maDangKy);
            return _mapper.Map<DangKyXemPhongModel>(dangKyXemPhong);
        }

        public List<DangKyXemPhongModel> GetItemsByKhuTro(string maKhuTro)
        {
            var list =
                    from KhuTro in _context.KhuTros.Where(n => n.MaKhuTro == maKhuTro).AsEnumerable()
                    join p in _context.Phongs on KhuTro.MaKhuTro equals p.MaKhuTro
                    join dangKyXemPhong in _context.DangKyXemPhongs on p.MaPhong equals dangKyXemPhong.MaPhong
                    select dangKyXemPhong;
            return _mapper.Map<List<DangKyXemPhongModel>>(list);
        }

        public bool ItemExistsByID(string maDangKy)
        {
            return _context.DangKyXemPhongs.Any(e => e.MaDangKy == maDangKy);
        }

        public bool PostNewItem(DangKyXemPhongModel newItem)
        {
            var dangKyXemPhong = _mapper.Map<DangKyXemPhong>(newItem);
            _context.DangKyXemPhongs.Add(dangKyXemPhong);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveItem(string maDangKy)
        {
            var dangKyXemPhong = _context.DangKyXemPhongs.Find(maDangKy);
            if (dangKyXemPhong != null)
            {
                _context.DangKyXemPhongs.Remove(dangKyXemPhong);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
