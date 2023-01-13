using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class PhongRepository : IPhongRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public PhongRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PhongModel> GetAllItems()
        {
            List<Phong> phongs = _context.Phongs.ToList();
            return _mapper.Map<List<PhongModel>>(phongs);
        }

        public PhongModel GetItemByID(string maPhong)
        {
            var phong = _context.Phongs.Find(maPhong);
            return _mapper.Map<PhongModel>(phong);
        }

        public List<PhongModel> GetPhongByKhuTro(string maKhuTro)
        {
            return _mapper.Map<List<PhongModel>>(_context.Phongs.Where(x => x.MaKhuTro == maKhuTro));
        }

        public bool PostNewItem(PhongModel newItem)
        {
            var phong = _mapper.Map<Phong>(newItem);
            _context.Phongs.Add(phong);
            return _context.SaveChanges() > 0;
        }

        public bool PutItem(PhongModel updateItem)
        {
            Phong phong = _context.Phongs.Find(updateItem.MaPhong);
            phong.TenPhong = updateItem.TenPhong;
            phong.GhiChu = updateItem.GhiChu;
            phong.GiaThue = updateItem.GiaThue;
            phong.DienTich = updateItem.DienTich;
            phong.UuTien = updateItem.UuTien;
            phong.TinhTrang = updateItem.TinhTrang;
            phong.MaKhuTro = updateItem.MaKhuTro;
            //_context.Phongs.Update(phong);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveItem(string maPhong)
        {
            var phong = _context.Phongs.Find(maPhong);
            if (phong != null)
            {
                _context.Phongs.Remove(phong);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
