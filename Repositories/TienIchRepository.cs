using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class TienIchRepository : ITienIchRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public TienIchRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<TienIchModel> GetAllItems()
        {
            List<TienIch> tienIches = _context.TienIches.ToList();
            return _mapper.Map<List<TienIchModel>>(tienIches);
        }

        public TienIchModel GetItemByID(string maTienIch)
        {
            var tienIch = _context.TienIches.Find(maTienIch);
            return _mapper.Map<TienIchModel>(tienIch);
        }

        public bool ItemExistsByID(string maTienIch)
        {
            return _context.TienIches.Any(e => e.MaTienIch == maTienIch);
        }

        public bool PostNewItem(TienIchModel newItem)
        {
            var tienIch = _mapper.Map<TienIch>(newItem);
            _context.TienIches.Add(tienIch);
            return _context.SaveChanges() > 0;
        }

        public bool PutItem(TienIchModel updateItem)
        {
            TienIch tienIch = _context.TienIches.Find(updateItem.MaTienIch);
            tienIch.TenTienIch = updateItem.TenTienIch;
            tienIch.GhiChu = updateItem.GhiChu;
            //_context.TienIches.Update(tienIch);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveItem(string maTienIch)
        {
            var tienIch = _context.TienIches.Find(maTienIch);
            if (tienIch != null)
            {
                _context.TienIches.Remove(tienIch);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
