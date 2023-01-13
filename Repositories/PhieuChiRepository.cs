using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class PhieuChiRepository : IPhieuChiRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public PhieuChiRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PhieuChiModel> GetAllItems()
        {
            List<PhieuChi> phieuChis = _context.PhieuChis.ToList();
            return _mapper.Map<List<PhieuChiModel>>(phieuChis);
        }

        public PhieuChiModel GetItemByID(string maPhieuChi)
        {
            var phieuChi = _context.PhieuChis.Find(maPhieuChi);
            return _mapper.Map<PhieuChiModel>(phieuChi);
        }

        public bool PostNewItem(PhieuChiModel newItem)
        {
            var phieuChi = _mapper.Map<PhieuChi>(newItem);
            _context.PhieuChis.Add(phieuChi);
            return _context.SaveChanges() > 0;
        }

        public bool PutItem(PhieuChiModel updateItem)
        {
            PhieuChi phieuChi = _context.PhieuChis.Find(updateItem.MaPhieuChi);
            phieuChi.ChiPhi = updateItem.ChiPhi;
            phieuChi.ChiTietChi = updateItem.ChiTietChi;
            phieuChi.GhiChu = updateItem.GhiChu;
            phieuChi.NgayChi = updateItem.NgayChi;
            phieuChi.TienKhachTra = updateItem.TienKhachTra;
            phieuChi.MaKhuTro= updateItem.MaKhuTro;
            //_context.PhieuChis.Update(phieuChi);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveItem(string maPhieuChi)
        {
            var phieuChi = _context.PhieuChis.Find(maPhieuChi);
            if (phieuChi != null)
            {
                _context.PhieuChis.Remove(phieuChi);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
