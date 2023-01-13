using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class PhuLucRepository : IPhuLucRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public PhuLucRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<PhuLucModel> GetPhuLucByHopDong(string maHopDong)
        {
            return _mapper.Map<List<PhuLucModel>>(_context.PhuLucs.Where(x => x.MaHopDong == maHopDong));
        }
        public PhuLucModel GetPhuLucByID(string maPhuLuc)
        {
            PhuLuc? phuLuc = _context.PhuLucs.Find(maPhuLuc);
            return _mapper.Map<PhuLucModel>(phuLuc);
        }
        public bool PostPhuLuc(PhuLucModel newItem)
        {
            PhuLuc phuLuc = _mapper.Map<PhuLuc>(newItem);
            _context.PhuLucs.Add(phuLuc);
            return _context.SaveChanges() > 0;
        }

        public bool DeletePhuLuc(string maPhuLuc)
        {
            PhuLuc phuLuc = _context.PhuLucs.Find(maPhuLuc);
            _context.PhuLucs.Remove(phuLuc);
            return _context.SaveChanges() > 0;
        }

        public bool PutItem(PhuLucModel updateItem)
        {
            PhuLuc phuLuc = _context.PhuLucs.Find(updateItem.MaPhuLuc);
            phuLuc.NgayBatDau = updateItem.NgayBatDau;
            phuLuc.NgayKetThuc = updateItem.NgayKetThuc;
            phuLuc.GiaThue = updateItem.GiaThue;
            phuLuc.GhiChu = updateItem.GhiChu;
            phuLuc.MaHopDong= updateItem.MaHopDong;
            //_context.PhuLucs.Update(phuLuc);
            return _context.SaveChanges() > 0;
        }
    }
}
