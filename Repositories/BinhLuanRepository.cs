using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Repositories
{
    public class BinhLuanRepository : IBinhLuanRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public BinhLuanRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BinhLuanModel> GetAllItems()
        {
            List<BinhLuan> binhLuans = _context.BinhLuans.ToList();
            return _mapper.Map<List<BinhLuanModel>>(binhLuans);
        }

        public BinhLuanModel GetItemByID(string maBinhLuan)
        {
            var binhLuan = _context.BinhLuans.Find(maBinhLuan);
            return _mapper.Map<BinhLuanModel>(binhLuan);
        }

        public bool ItemExistsByID(string maBinhLuan)
        {
            return _context.Phongs.Any(e => e.MaPhong == maBinhLuan);
        }

        public bool PostNewItem(BinhLuanModel item)
        {
            var binhLuan = _mapper.Map<BinhLuan>(item);
            _context.BinhLuans.Add(binhLuan);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveItem(string maBinhLuan)
        {
            var binhLuan = _context.BinhLuans.Find(maBinhLuan);
            if (binhLuan != null)
            {
                _context.BinhLuans.Remove(binhLuan);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
