using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class YeuCauSuaChuaRepository : IYeuCauSuaChuaRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public YeuCauSuaChuaRepository()
        {
        }

        public YeuCauSuaChuaRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<YeuCauSuaChuaModel> GetAllItems()
        {
            List<YeuCauSuaChua> yeuCauSuaChuas = _context.YeuCauSuaChuas.ToList();
            return _mapper.Map<List<YeuCauSuaChuaModel>>(yeuCauSuaChuas);
        }

        public YeuCauSuaChuaModel GetItemByID(string maYeuCau)
        {
            var yeuCauSuaChua = _context.YeuCauSuaChuas.Find(maYeuCau);
            return _mapper.Map<YeuCauSuaChuaModel>(yeuCauSuaChua);
        }

        public bool ItemExistsByID(string maYeuCau)
        {
            return _context.YeuCauSuaChuas.Any(e => e.MaYeuCau == maYeuCau);
        }

        public bool PostNewItem(YeuCauSuaChuaModel newItem)
        {
            var yeuCauSuaChua = _mapper.Map<YeuCauSuaChua>(newItem);
            _context.YeuCauSuaChuas.Add(yeuCauSuaChua);
            return _context.SaveChanges() > 0;
        }

        public bool PutItem(YeuCauSuaChuaModel updateItem)
        {
            YeuCauSuaChua yeuCauSuaChua = _mapper.Map<YeuCauSuaChua>(updateItem);
            _context.YeuCauSuaChuas.Update(yeuCauSuaChua);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveItem(string maYeuCau)
        {
            var yeuCauSuaChua = _context.YeuCauSuaChuas.Find(maYeuCau);
            if (yeuCauSuaChua != null)
            {
                _context.YeuCauSuaChuas.Remove(yeuCauSuaChua);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
