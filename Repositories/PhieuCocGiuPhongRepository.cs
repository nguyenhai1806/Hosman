using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class PhieuCocGiuPhongRepository : IPhieuCocGiuPhongRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public PhieuCocGiuPhongRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PhieuCocGiuPhongModel> GetAllItems()
        {
            List<PhieuCocGiuPhong> phieuCocGiuPhongs = _context.PhieuCocGiuPhongs.ToList();
            return _mapper.Map<List<PhieuCocGiuPhongModel>>(phieuCocGiuPhongs);
        }

        public PhieuCocGiuPhongModel GetItemByID(string maPhieuCoc)
        {
            var phieuCocGiuPhong = _context.PhieuCocGiuPhongs.Find(maPhieuCoc);
            return _mapper.Map<PhieuCocGiuPhongModel>(phieuCocGiuPhong);
        }

        public bool ItemExistsByID(string maPhieuCoc)
        {
            return _context.PhieuCocGiuPhongs.Any(e => e.MaPhieuCoc == maPhieuCoc);
        }

        public bool PostNewItem(PhieuCocGiuPhongModel newItem)
        {
            var phieuCocGiuPhong = _mapper.Map<PhieuCocGiuPhong>(newItem);
            _context.PhieuCocGiuPhongs.Add(phieuCocGiuPhong);
            return _context.SaveChanges() > 0;
        }

        public bool PutItem(PhieuCocGiuPhongModel updateItem)
        {
            PhieuCocGiuPhong phieuCocGiuPhong = _context.PhieuCocGiuPhongs.Find(updateItem.MaPhieuCoc);
            phieuCocGiuPhong.NgayCoc = updateItem.NgayCoc;
            phieuCocGiuPhong.NgayDuKienVaoO = updateItem.NgayDuKienVaoO;
            phieuCocGiuPhong.SoTien = updateItem.SoTien;  
            phieuCocGiuPhong.GhiChu= updateItem.GhiChu;
            phieuCocGiuPhong.DaHoanTien = updateItem.DaHoanTien;
            phieuCocGiuPhong.MaNguoiDung = updateItem.MaNguoiDung;
            phieuCocGiuPhong.MaNguoiDung = updateItem.MaNguoiDung;
            //_context.PhieuCocGiuPhongs.Update(phieuCocGiuPhong);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveItem(string maPhieuCoc)
        {
            var phieuCocGiuPhong = _context.PhieuCocGiuPhongs.Find(maPhieuCoc);
            if (phieuCocGiuPhong != null)
            {
                _context.PhieuCocGiuPhongs.Remove(phieuCocGiuPhong);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
